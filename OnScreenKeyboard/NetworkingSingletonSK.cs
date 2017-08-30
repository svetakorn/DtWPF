using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Datatron.Networking
{
    class NetworkingSingletonSK
    {

        //public void DisableTImer() { tmr.Enabled = false; }
        //public void EnableTImer() { tmr.Enabled = true; }
        //public void AppendToTimer(object a) { tmr.Elapsed += (ElapsedEventHandler)a; }

        public TcpClient client = new TcpClient();
        private IPEndPoint serverEndPoint;

        public void Reconnect() { try { client.Connect(serverEndPoint); } catch { } }

        public void SendMessage(string msg)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(msg);
            try
            {
                NetworkStream clientStream = client.GetStream();
                clientStream.Flush();
                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
            }
            catch { Debug.WriteLine("CANT SEND DATA"); }
        }



        private static NetworkingSingletonSK instance;

        private NetworkingSingletonSK()
        {
            string line = "127.0.0.1";
            try
            {
                using (StreamReader sr = new StreamReader("config.txt"))
                {
                    line = sr.ReadToEnd();
                }
            }
            catch { }
            serverEndPoint = new IPEndPoint(IPAddress.Parse(line), 10007);
            try { client.Connect(serverEndPoint); } catch { }
        }

        public static NetworkingSingletonSK getInstance()
        {
            if (instance == null)
                instance = new NetworkingSingletonSK();
            return instance;
        }
    }

}