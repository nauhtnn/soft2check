using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Client99
{
    public delegate bool DgSrvrBufHndl(byte[] msg, out byte[] outMsg);

    public class Server3
    {
        TcpListener mTcpListr = null;
        //bool bRW;//todo all clnt
        bool bRW1;//will cause trouble in multithreading, so it's thread-depending
        bool bListning;//raise flag to stop
        int mPort;
        DgSrvrBufHndl dgHndl;

        public Server3(DgSrvrBufHndl dg)
        {
            string filePath = "ServerPort3.txt";
            mPort = 33333;
            if (System.IO.File.Exists(filePath))
                mPort = Convert.ToInt32(System.IO.File.ReadAllText(filePath));
            bRW1 = bListning = false;
            dgHndl = dg;
        }

        public int SrvrPort { set { mPort = value; } }

        public void Start()
        {
            if (mTcpListr != null)
                return;
            bListning = true;
            mTcpListr = new TcpListener(IPAddress.Any, mPort);
            try {
                mTcpListr.Start();
            }
            catch (SocketException ) {
                Stop();
            }

            while (bListning)
            {
                System.Threading.Thread.Sleep(8);//do not overhead CPU
                bool p = false;
                try { p = mTcpListr.Pending(); }
                catch (InvalidOperationException ) {
                    Stop();
                    break;
                }
                if (p)
                {
                    bRW1 = true;
                    TcpClient cli = null;
                    NetworkStream stream = null;
                    try { cli = mTcpListr.AcceptTcpClient(); }
                    catch (SocketException )
                    {
                        Stop();
                        break;
                    }

                    try { stream = cli.GetStream(); }
                    catch (InvalidOperationException )
                    {
                        bRW1 = false;
                    }

                    byte[] buf = new byte[1024 * 1024];

                    int nByte;
                    while (bRW1)
                    {
                        //Incoming message may be larger than the buffer size.
                        //Do not rely on stream.DataAvailable, because the response
                        //  may be split into multiple TCP packets, and a packet
                        //  has not yet been delivered at the moment checking DataAvailable
                        try
                        {
                            nByte = stream.Read(buf, 0, buf.Length);
                        }
                        catch (System.IO.IOException )
                        {
                            break;
                        }
                        if (nByte < 4)
                            break;

                        int nLength = BitConverter.ToInt32(buf, 0);
                        nByte -= 4;

                        if (nLength < 1)
                            break;

                        byte[] recvMsg = new byte[nLength];

                        int offs = 0;
                        if (0 < nByte)
                        {
                            if (nLength < nByte)
                                nByte = nLength;
                            Buffer.BlockCopy(buf, 4, recvMsg, offs, nByte);
                            nLength -= nByte;
                            offs += nByte;
                        }

                        while (bRW1 && 0 < nLength)
                        {
                            try
                            {
                                nByte = stream.Read(buf, 0, buf.Length);
                            }
                            catch (System.IO.IOException )
                            {
                                bRW1 = false;
                            }
                            if (bRW1)
                            {
                                if (nLength < nByte)
                                    nByte = nLength;
                                Buffer.BlockCopy(buf, 0, recvMsg, 0, nByte);
                                nLength -= nByte;
                                offs += nByte;
                            }
                        }

                        if (bRW1 && recvMsg != null && 3 < recvMsg.Length)
                        {
                            byte[] msg;
                            bRW1 = dgHndl(recvMsg, out msg);//slaver not reply here
                        }
                        else
                            bRW1 = false;
                    }
                    cli.Close();
                }
            }
            bListning = false;
            try { mTcpListr.Stop(); }
            catch (SocketException ) {}
            mTcpListr = null;
        }

        public void Stop()
        {
            bRW1 = bListning = false;
        }
    }
}
