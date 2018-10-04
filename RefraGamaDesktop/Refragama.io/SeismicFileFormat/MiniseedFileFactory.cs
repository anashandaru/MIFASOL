using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefraGama.Core;

namespace Refragama.io.SeismicFileFormat
{
    class MiniseedFileFactory : SeismicFileFactory
    {
        public override ISeismicStream Read(string filename)
        {
            throw new NotImplementedException();
        }

        public override void Write(ISeismicStream stream, string filename)
        {
            MiniseedWriterWrapper.Write(stream, filename);
        }
    }
}
