using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Sockets;

namespace CommonNetworking
{
    public class readingcomponent
    {
        //the networkstream this readingcomponent reads from
        

        /// <summary>
        /// reads a specified amount of bytes from the networkstream nw_stream
        /// </summary>
        /// <param name="count">the amount to read</param>
        /// <returns>the read bytes</returns>
        public byte[] read(NetworkStream nw_stream, int count)
        {
            MemoryStream memstream = new MemoryStream();
            int read;
            byte[] buf = new byte[count];
            while (count > 0)
            {
                read = nw_stream.Read(buf, 0, count);
                memstream.Write(buf, 0, read);
                count -= read;
            }

            return memstream.ToArray();
        }
    }

    /// <summary>
    /// this class is used to read on a stream
    /// </summary>
    public class Reader
    {
        /*
         * by making an additional class for reading component we can lock the reading component,
         * while we still can access the asyncreadingflag and the networkstream from other threads
         */
        public bool asyncreadflag = true;
        public readingcomponent ReadingComponent = new readingcomponent();

        public NetworkStream nw_stream { get; private set; }

        public byte[] read(int count)
        {
            return ReadingComponent.read(nw_stream, count);
        }

        public Reader(NetworkStream ns)
        {
            nw_stream = ns;
        }
    }
}

