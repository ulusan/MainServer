using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace MainServer
{
    class Program
    {
        static void Main(string[] args)
        {

            TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 600);
            tcpListener.Start();

            while (true)
            {
                Socket socket = tcpListener.AcceptSocket();
                if (socket.Connected)
                {
                    Console.WriteLine("Sunucuya Bir Client Bağlandı");
                    NetworkStream networkStream = new NetworkStream(socket);
                    StreamWriter streamWriter = new StreamWriter(networkStream);
                    StreamReader streamReader = new StreamReader("C:\\Deneme\\DATA.txt.txt");
                    streamWriter.AutoFlush = true;
                    string line = "";
                    //do while amacı =Dosya tamamen boşsa içerisine girip doldurabilmek
                    do
                    {
                        line = streamReader.ReadLine();
                        if (line != null)
                        {
                            streamWriter.WriteLine(line);
                            streamWriter.Flush();
                        }
                    }
                    while (line != null);
                    streamReader.Close();
                    networkStream.Close();
                    streamWriter.Close();
                    Console.Read();

                }
            }

        }
    }
}
