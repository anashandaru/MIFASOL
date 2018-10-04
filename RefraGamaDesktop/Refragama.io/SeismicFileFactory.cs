using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefraGama.Core;

namespace Refragama.io
{
    public abstract class SeismicFileFactory
    {
        /// <summary>
        /// Read the specified filename
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public abstract ISeismicStream Read(string filename);

        /// <summary>
        /// Wrtie to the specified filename
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="filename"></param>
        public abstract void Write(ISeismicStream stream, string filename);
    }
}
