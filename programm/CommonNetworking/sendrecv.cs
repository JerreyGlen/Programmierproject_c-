using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace CommonNetworking
{
    public class sendrecv
    {
        /// <summary>
        /// blocks the thread it's running in until a startpattern is received
        /// </summary>
        /// <param name="r">the reeader used to check for startpattern</param>
        /// <returns>
        /// true=stopped because a start pattern was found
        /// false=stopped for other reasons
        /// </returns>
        public static bool waitforstartpattern(Reader r)
        {
            lock (r.ReadingComponent)
            {
                byte[] buf;
                try
                {
                    while (r.asyncreadflag) // stop waiting if asynchronousrreading is not allowed anymore
                    {
                        if (r.nw_stream.DataAvailable)
                        {
                            buf = new byte[1];
                            for (int i = 0; i < headers.magicstartpattern.Length; i++)
                            {

                                buf = r.read(1);

                                if (!buf[0].Equals(headers.magicstartpattern[i])) break;
                                if (i == headers.magicstartpattern.Length - 1) return true;
                            }
                        }

                        Thread.Sleep(50); //wait 50ms to relieve cpu
                    }


                    return false;
                }
                catch
                {
                    return false;
                }
            }

        }

        /// <summary>
        /// reads a specified amount of bytes from networkstream using byte array
        /// </summary>
        /// <param name="r">the Reader used to read the bytes</param>
        /// <param name="count">the amount of bytes to read</param>
        /// <returns>the read bytes</returns>
        public static byte[] readfromstream(Reader r, int count)
        {
            byte[] ret;
            lock (r.ReadingComponent)
            {
                ret = r.read(count);
            }

            return ret;
        }

        /// <summary>
        /// sends the startpattern
        /// </summary>
        /// <param name="w">the writer used to write the start pattern</param>
        public static void sendStartPattern(Writer w)
        {
            lock (w)
            {
                w.write(headers.magicstartpattern);
            }
        }

        /// <summary>
        /// write an bytearray on stream
        /// </summary>
        /// <param name="w"></param>
        /// <param name="b"></param>
        public static void writeOnStream(Writer w, byte[] b)
        {
            lock (w)
            {
                w.write(b);
            }
        }

        /// <summary>
        /// sends a string
        /// </summary>
        /// <param name="w">the writer used to write the packet on the networkstrem</param>
        /// <param name="msg">the string to send</param>
        public static void sendString(Writer w, string msg)
        {
            lock (w)
            {
                w.write(headers.magicstartpattern); //startpatternsenden
                byte[] buf = BitConverter.GetBytes(msg.Length);
                w.write(buf); //msglength senden
                buf = Encoding.UTF8.GetBytes(msg);
                w.write(buf); //msg senden
            }

        }

        /// <summary>
        /// blocks the thread this method is called from until a string was received
        /// </summary>
        /// <param name="r">the reader used to check for a string</param>
        /// <returns>the received string</returns>
        public static string waitforstring(Reader r)
        {
            byte[] msg;
            lock (r.ReadingComponent)
            {
                byte[] buf = new byte[4];
                Int32 msglength;
                if (!waitforstartpattern(r)) return null;
                buf = r.read(4);
                msglength = BitConverter.ToInt32(buf, 0);
                msg = readfromstream(r, msglength);
            }

            return Encoding.UTF8.GetString(msg);
        }


        /// <summary>
        /// sends a sessioninfo packet with the information that the session ended
        /// </summary>
        /// <param name="nw_Stream"></param>
        public static void sendend(Writer w)
        {
            lock (w)
            {
                w.write(headers.magicstartpattern);
                w.write(new byte[] { headers.packettypebytes[headers.packettype.SessionInfo] });
                w.write(new byte[] { headers.infotypebytes[headers.infotype.EndSession] });

            }
        }

        /// <summary>
        /// sends a sessioninfopacket with the information that a client quit the session
        /// </summary>
        /// <param name="nw_Stream"></param>
        public static void sendquit(Writer w)
        {
            lock (w)
            {
                w.write(headers.magicstartpattern);
                w.write(new byte[] { headers.packettypebytes[headers.packettype.SessionInfo] });
                w.write(new byte[] { headers.infotypebytes[headers.infotype.QuitSession] });

            }
        }

        /// <summary>
        /// checks if a tcp connection is still alive by trying to send a byte through it
        /// </summary>
        /// <param name="w"></param>
        /// <returns>
        /// true=connection is alive
        /// false=connection is broken
        /// </returns>
        public static bool ConnectionAlive(Writer w)
        {
            lock (w)
            {
                try
                {
                    w.write(new byte[] { 1 });
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}