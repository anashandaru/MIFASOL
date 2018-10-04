using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using RefraGama.Core;
using RefraGama.Core.SeismicFileHeader;

namespace Refragama.io.SeismicFileFormat
{
    public class MiniseedWriterWrapper
    {
        internal static void Write(ISeismicStream stream, string filepath)
        {
            var wdir = Path.GetDirectoryName(filepath);
            if (wdir == null) throw new Exception("The given filepath is invalid");

            var outputFile = Path.GetFileName(filepath);
            var processInfo = new ProcessStartInfo
            {
                FileName = "spmswrite.exe",
                RedirectStandardInput = true,
                WorkingDirectory = wdir,
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = $"\"{outputFile}\""
            };

            using (var p = Process.Start(processInfo))
            {
                if (p == null) throw new Exception("Fail to start spmswrite.exe");
                using (var bw = new BinaryWriter(p.StandardInput.BaseStream))
                {
                    bw.Write(stream.Count);
                    foreach (var trace in stream.Traces)
                    {
                        var miniSeedHeader = trace.Header as MiniseedHeader;

                        // refer to xls document for the spec

                        // some fallback when the header is created using the generic trace header
                        bw.Write(StringToByteArray(miniSeedHeader?.FullSourceName ?? trace.Header.SourceName, 50));
                        bw.Write(miniSeedHeader?.HpStartTime ?? MiniseedHeader.GetHpTime(trace.Header.StartTime));
                        var sampleType = miniSeedHeader?.OriginSampleType ?? 'f';
                        bw.Write(sampleType);
                        bw.Write(BitConverter.GetBytes((double)trace.Header.SamplingRate));
                        bw.Write(BitConverter.GetBytes(trace.Header.Npts));

                        // trace data buffer
                        byte[] buff;
                        switch (sampleType)
                        {
                            case 'i':
                                buff = new byte[trace.Data.Length * sizeof(int)];
                                var intSamples = Array.ConvertAll(trace.Data, Convert.ToInt32);
                                Buffer.BlockCopy(intSamples, 0, buff, 0, buff.Length);
                                break;
                            case 'd':
                                buff = new byte[trace.Data.Length * sizeof(double)];
                                var doubleSamples = Array.ConvertAll(trace.Data, Convert.ToDouble);
                                Buffer.BlockCopy(doubleSamples, 0, buff, 0, buff.Length);
                                break;
                            default:
                                buff = new byte[trace.Data.Length * sizeof(float)];
                                Buffer.BlockCopy(trace.Data, 0, buff, 0, buff.Length);
                                break;
                        }
                        bw.Write(buff);
                    }
                }
            }
        }

        private static byte[] StringToByteArray(string str, int length)
        {
            return Encoding.ASCII.GetBytes(str.PadRight(length, '\0'));
        }
    }
}