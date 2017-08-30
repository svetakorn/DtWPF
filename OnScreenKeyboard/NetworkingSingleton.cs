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
    public class PseudoAPI
    {
        public string q { get; set; }
        public string f { get; set; }
        public string c { get; set; }
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

        public Timer tmr2;
        //public void DisableTImer() { tmr.Enabled = false; }
        //public void EnableTImer() { tmr.Enabled = true; }
        //public void AppendToTimer(object a) { tmr.Elapsed += (ElapsedEventHandler)a; }
        Stack<string> msgquery = new Stack<string>();
        public TcpClient client = new TcpClient();
        private IPEndPoint serverEndPoint;

        public void Reconnect() { try { client.Connect(serverEndPoint); } catch { } }

        public void SendMessage(string msg)
        {
            msgquery.Push(msg);
        }

        public void send_itself(Object source, ElapsedEventArgs e)
        {
            try
            {
                string msg = msgquery.Pop();
                if (!msg.Equals(""))
                {
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(msg);
                    try
                    {
                        Debug.WriteLine("kek11 : " + msg.Substring(0, Math.Min(14, msg.Length)));
                        NetworkStream clientStream = client.GetStream();
                        clientStream.Flush();
                        clientStream.Write(buffer, 0, buffer.Length);
                        clientStream.Flush();
                        //Debug.WriteLine("kek22");
                    }
                    catch { Debug.WriteLine("CANT SEND DATA"); }
                }
            }
            catch { }
        }

        public void SendQuestion(string user_query = "NOOOPE", string formal_query = "", string confidence = "", string formatted_responce = "NOOOPE", string seeMoreQuestions1 = "", string seeMoreQuestions2 = "", int docs = 0, int pics = 0, int urls = 0, string videoNum1 = "0", string videoNum2 = "0")
        {
            PseudoAPI fullQuery = new PseudoAPI();
            fullQuery.q = user_query;
            fullQuery.f = formal_query;
            fullQuery.c = confidence;
            fullQuery.a = formatted_responce;
            fullQuery.s1 = seeMoreQuestions1;
            fullQuery.s2 = seeMoreQuestions2;
            fullQuery.dc = docs.ToString(); fullQuery.pc = pics.ToString(); fullQuery.uc = urls.ToString();
            fullQuery.vn1 = videoNum1;
            fullQuery.vn2 = videoNum2;

                SendMessage(JsonConvert.SerializeObject(fullQuery));
            
        }







        private static NetworkingSingleton instance;

        private NetworkingSingleton()
        {
            string line = "127.0.0.1";
            //try
            {
                using (StreamReader sr = new StreamReader("config.txt"))
                {
                    line = sr.ReadToEnd();
                }
            }
            //catch { }
            serverEndPoint = new IPEndPoint(IPAddress.Parse(line), 10000);
            try { client.Connect(serverEndPoint); } catch { }
            tmr2 = new Timer(100);
            tmr2.AutoReset = true;
            tmr2.Enabled = true;
            tmr2.Elapsed += send_itself;
        }

        public static NetworkingSingleton getInstance()
        {
            if (instance == null)
                instance = new NetworkingSingleton();
            return instance;
        }
    }

}