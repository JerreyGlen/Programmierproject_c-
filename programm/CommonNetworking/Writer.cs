using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
namespace CommonNetworking
{
    public class ConnectionNotWorkingException : Exception
    {
        public ConnectionNotWorkingException(string msg) : base(msg)
        {

        }
    }

    /// <summary>
    /// this class is used to write on a stream
    /// </summary>
    public class Writer
    {
        //the stream to write on 
        private NetworkStream nw_stream;

        //initializes the writer with a networkstream to write on
        public Writer(NetworkStream ns)
        {
            nw_stream = ns;
        }

        /// <summary>
        /// writes a byte array to the stream
        /// </summary>
        /// <param name="b">the byte array to stream</param>
        public void write(byte[] b)
        {
            try
            {
                nw_stream.Write(b, 0, b.Length);
            }
            catch
            {
                throw new ConnectionNotWorkingException("unable to write on network stream");
            }
        }
    }
}