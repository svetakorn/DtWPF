using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Datatron.Networking
{
    public class PseudoAPI
    {
        public string q { get; set; }
        public string a { get; set; }
        public string s1 { get; set; }
        public string s2 { get; set; }
        public string dc { get; set; }
        public string pc { get; set; }
        public string uc { get; set; }
        public string vn1 { get; set; }
        public string vn2 { get; set; }

    }

    class NetworkingSingleton
    {

        public Timer tmr;
        //public void DisableTImer() { tmr.Enabled = false; }
        //public void EnableTImer() { tmr.Enabled = true; }
        //public void AppendToTimer(object a) { tmr.Elapsed += (ElapsedEventHandler)a; }

        public TcpClient client = new TcpClient();
        private IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10000);

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

        public void SendQuestion(string user_query = "NOOOPE", string formatted_responce = "NOOOPE", string seeMoreQuestions1 = "", string seeMoreQuestions2 = "", int docs = 0, int pics = 0, int urls = 0, string videoNum1 = "2", string videoNum2 = "1")
        {
            tmr.Enabled = false;

            PseudoAPI fullQuery = new PseudoAPI();
            fullQuery.q = user_query;
            fullQuery.a = formatted_responce;
            fullQuery.s1 = seeMoreQuestions1;
            fullQuery.s2 = seeMoreQuestions2;
            fullQuery.dc = docs.ToString(); fullQuery.pc = pics.ToString(); fullQuery.uc = urls.ToString();
            fullQuery.vn1 = videoNum1;
            fullQuery.vn2 = videoNum2;

            Task.Delay(150).ContinueWith(_ =>
            {
                SendMessage(JsonConvert.SerializeObject(fullQuery));
            });
            Task.Delay(300).ContinueWith(_ =>
            {
                tmr.Enabled = true;
            });
        }







        private static NetworkingSingleton instance;

        private NetworkingSingleton()
        {
            try { client.Connect(serverEndPoint); } catch { }
            tmr = new Timer(100);
            tmr.AutoReset = true;
            tmr.Enabled = true;
        }

        public static NetworkingSingleton getInstance()
        {
            if (instance == null)
                instance = new NetworkingSingleton();
            return instance;
        }
    }

}