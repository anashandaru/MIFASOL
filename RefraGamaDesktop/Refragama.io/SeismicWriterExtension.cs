using System;
using Refragama.io.SeismicFileFormat;
using RefraGama.Core;

namespace Refragama.io
{
    public static class SeismicWriterExtension
    {
        public static void Write(this ISeismicStream stream, string filename, string type)
        {
            SeismicFileFactory seismicFile;
            switch (type)
            {
                case "msd":
                case "mseed":
                    seismicFile = new MiniseedFileFactory();
                    break;
                case ".gse":
                    throw new NotSupportedException("The file you are trying to write is not supported");
                    break;
                case "sac":
                    throw new NotSupportedException("The file you are trying to write is not supported yet");
                    break;
                default:
                    throw new NotSupportedException("The file you are trying to write is not supported");
            }

            seismicFile.Write(stream, filename);
        }
    }
}