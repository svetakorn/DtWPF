/*
 * Created by SharpDevelop.
 * User: User
 * Date: Вт 27.06.17
 * Time: 13:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using NAudio.Wave;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace speechKit
{
	public class Program
	{
		public static string YANDEX_API_KEY = "e05f5a12-8e05-4161-ad05-cf435a4e7d5b";
        public static string YANDEX_ASR_HOST = "asr.yandex.net";
		public static string YANDEX_ASR_PATH = "/asr_xml";
		public static double CHUNK_SIZE = Math.Pow(1024,2);
		public static string TTS_URL = "https://tts.voicetech.yandex.net/generate";
		public static int httpPort = 80;
		public static int httpsPort = 443;
		

        public static void Main(string[] args)
		{
		}

        /*
		public static byte[] convert_to_mp3(string filePath)
		{
			var output = new MemoryStream();
			var input_filePath = "output_mp3.mp3";
			using(var reader = new MediaFoundationReader(filePath)) {
				MediaFoundationEncoder.EncodeToMp3(reader, input_filePath, 192000);
			}
			
			using(Stream input = File.OpenRead(input_filePath)) {
				input.CopyTo(output);
			}
			output.Position = 0;
			return output.ToArray();
		}
		
		public static byte[] convert_to_pcm16b16000r(string filePath, byte[] in_bytes = null)
		{
			var output = new MemoryStream();
			var output_filePath = "output_pcm.wav";
			var desiredOutputFormat = new WaveFormat(16000,16,2);
			using(var reader = new WaveFileReader(filePath))
			using(var converter = new WaveFormatConversionStream(desiredOutputFormat, reader)) 
			{
    			WaveFileWriter.CreateWaveFile(output_filePath, converter);
			}
			
			using(Stream input = File.OpenRead(output_filePath)) {
				input.CopyTo(output);
			}
			output.Position = 0;
			return output.ToArray();
		}*/
		

		//public static void read_chunks(int chunk_size)
		//{
            //int bufferSize = 4096;
            //char[] songBytes = new char[bufferSize];
            //FileStream inFile = File.Open(FILE_PATH, FileMode.Open, FileAccess.Read);

            //long length = inFile.Length;

            //// Write the file name.
            //writer.WriteElementString("fileName", ns, Path.GetFileNameWithoutExtension(FILE_PATH));

            //// Write the size.
            //writer.WriteElementString("size", ns, length.ToString());

            //// Write the song bytes.
            //writer.WriteStartElement("song", ns);

            //StreamReader sr = new StreamReader(inFile, true);
            //int readLen = sr.Read(songBytes, 0, bufferSize);

            //while (readLen > 0)
            //{
            //    writer.WriteStartElement("chunk", ns);
            //    writer.WriteChars(songBytes, 0, readLen);
            //    writer.WriteEndElement();

            //    writer.Flush();
            //    readLen = sr.Read(songBytes, 0, bufferSize);
            //}

            //writer.WriteEndElement();
            //inFile.Close();
		//}
		
		public static void text_to_speech(string text, string filename = null, string lang="ru-RU", bool convert=true, bool as_audio=false, string file_like=null )
		{
			string url = string.Format("{0}?text={1}&format={2}&lang={3}&speaker={4}&key={5}&emotion={6}&speed={7}",
			                    TTS_URL, text, "wav", lang, "oksana", YANDEX_API_KEY, "good", "1.0");

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            
            request.Method = "GET";
			
			var req = (HttpWebRequest)WebRequest.Create(url);
			var resp = (HttpWebResponse)req.GetResponse();
            Stream dataStream = resp.GetResponseStream();
            var reader = new BinaryReader(dataStream);
            
            try
            {
                if (resp.StatusCode == (HttpStatusCode)200)
                {
                	var bArray = new byte[1000000];
                	var ms = new MemoryStream();
                	dataStream.CopyTo(ms);
                	bArray = ms.ToArray();
                	
                	using (FileStream fs = new FileStream("speechGenerated.wav", FileMode.Create, FileAccess.Write))
            		using (BinaryWriter bw = new BinaryWriter(fs))
            		{
                		foreach(var item in bArray)
                			bw.Write(item);
                	}
                    dataStream.Close();
                    reader.Close();
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
		}
		
		/* TASK USAGE
		
		public void send_request(byte[] bytes, string topic, string lang)
		{
			var request_id = new Guid();
			request_id = Guid.NewGuid();
			
			var strReqId = request_id.ToString();
            var s = strReqId.Split('-');
            var req_id = "";
            foreach(var item in s)
	            req_id += item;
            
			var set = new Settings();
			
			//Обмен рукопожатиями
			var client = new TcpClient();
			
			client.Connect(YANDEX_ASR_HOST, httpsPort);
			
			var handshake = "GET /asr_partial HTTP/1.1\r\n" +
				"Host: asr.yandex.net:80\r\n" +
				"User-Agent: KeepAliveClient\r\n" +
				"Upgrade: dictation\r\n\r\n";
			
			var tcpStream = client.GetStream();
			
			var hBytes = Encoding.ASCII.GetBytes(handshake);
			tcpStream.Write(hBytes, 0, hBytes.Length);
			
			var rBytes = new byte[client.ReceiveBufferSize];
			var bytesRead = tcpStream.Read(rBytes, 0, client.ReceiveBufferSize);
			var returnData = Encoding.UTF8.GetString(rBytes, 0, bytesRead);
			
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://" + YANDEX_ASR_HOST + YANDEX_ASR_PATH + string.Format("?uuid={0}&key={1}&topic={2}&lang={3}",
                                       req_id,
                                       set.YANDEX_API_KEY,
                                       topic,
                                       lang));
			
			request.Method = "POST";
			
            request.SendChunked = true;
            request.ContentType = "audio/x-wav";
            request.ContentLength = bytes.Length;
            request.Headers.Add("key", "e05f5a12-8e05-4161-ad05-cf435a4e7d5b");
            
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(bytes, 0, bytes.Length);
            dataStream.Close();
            
			Task resp_task = new Task(() => this.read_response(request, rBytes, client, bytesRead, tcpStream, returnData));
			resp_task.Start();
			resp_task.Wait();
		}
		
		public void read_response(HttpWebRequest request, byte[] rBytes, TcpClient client, int bytesRead, NetworkStream tcpStream, string returnData)
		{
			HttpWebResponse wResp;

            Stream stream;
            var text = "";
            
            try
            {
                wResp = (HttpWebResponse)request.GetResponse();
                
                using (stream = wResp.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    text = reader.ReadToEnd();
                    Console.WriteLine(text);
                    stream.Close();
                    wResp.Close();
                }
            }
            catch (WebException we)
            {
                using (stream = we.Response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    text = reader.ReadToEnd();
                    Console.WriteLine(text);
                    stream.Close();
                }
            }
            
            rBytes = new byte[client.ReceiveBufferSize];
            client.Client.Receive(rBytes, client.ReceiveBufferSize, SocketFlags.None);
            returnData = Encoding.UTF8.GetString(rBytes, 0, bytesRead);
                Console.Write(returnData);

            tcpStream.Close();
            client.Close();
		}
		*/
		
		public static string speech_to_text(string filepath)
		{
            /* TASK USAGE
			var topic= "queries";
			var lang="ru-RU";
			HttpWebRequest request = null;
			byte[] rBytes = null;
			TcpClient client = null;
			int bytesRead = 0;
			NetworkStream tcpStream = null;
			string returnData = "";
			
			Task send_task = new Task(() => this.send_request(bytes, topic, lang));
			send_task.Start();
			send_task.Wait();
			*/
            byte[] bytes = File.ReadAllBytes(filepath);

            var topic = "queries";
			var lang = "ru-RU";
			
			var request_id = new Guid();
			request_id = Guid.NewGuid();
			
			var strReqId = request_id.ToString();
            var s = strReqId.Split('-');
            var req_id = "";
            foreach(var item in s)
	            req_id += item;
            			
			//Обмен рукопожатиями
			var client = new TcpClient();
			
			client.Connect(YANDEX_ASR_HOST, httpsPort);
			
			var handshake = "GET /asr_partial HTTP/1.1\r\n" +
				"Host: asr.yandex.net:80\r\n" +
				"User-Agent: KeepAliveClient\r\n" +
				"Upgrade: dictation\r\n\r\n";
			
			var tcpStream = client.GetStream();
			
			var hBytes = Encoding.ASCII.GetBytes(handshake);
			tcpStream.Write(hBytes, 0, hBytes.Length);
			
			var rBytes = new byte[client.ReceiveBufferSize];
			var bytesRead = tcpStream.Read(rBytes, 0, client.ReceiveBufferSize);
			var returnData = Encoding.UTF8.GetString(rBytes, 0, bytesRead);
			
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://" + YANDEX_ASR_HOST + YANDEX_ASR_PATH + string.Format("?uuid={0}&key={1}&topic={2}&lang={3}",
                                       req_id,
                                       YANDEX_API_KEY,
                                       topic,
                                       lang));
			
			request.Method = "POST";
			
            request.SendChunked = true;
            request.ContentType = "audio/x-wav";
            request.ContentLength = bytes.Length;
            request.Headers.Add("key", "e05f5a12-8e05-4161-ad05-cf435a4e7d5b");
            
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(bytes, 0, bytes.Length);
            dataStream.Close();
            
           Stopwatch timer = new Stopwatch();
           timer.Start();
           
           HttpWebResponse wResp;

           Stream stream;
           var text = "";
           
           try
           {
               wResp = (HttpWebResponse)request.GetResponse();

               timer.Stop();
               TimeSpan timeTaken = timer.Elapsed;

               using (stream = wResp.GetResponseStream())
               using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
               {
                   text = reader.ReadToEnd();
                   Console.WriteLine(text);
                   stream.Close();
                   wResp.Close();
               }
               Console.WriteLine(timeTaken.ToString());
           }
           catch (WebException we)
           {
               using (stream = we.Response.GetResponseStream())
               using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
               {
                   text = reader.ReadToEnd();
                   Console.WriteLine(text);
                   stream.Close();
               }
           }
           
           rBytes = new byte[client.ReceiveBufferSize];
           client.Client.Receive(rBytes, client.ReceiveBufferSize, SocketFlags.None);
           returnData = Encoding.UTF8.GetString(rBytes, 0, bytesRead);

           tcpStream.Close();
           client.Close();
            Debug.WriteLine("!@#%^&" + returnData + "&^%$");

            string req = "";
            var doc = new XmlDocument();
            {
                doc.LoadXml(text);
                try
                {
                    foreach (XmlNode node in doc.SelectNodes("recognitionResults"))
                    {
                        req = node.FirstChild.InnerText; //полученный текст
                    }
                }
                catch (Exception)
                {

                    req = "Извините, я не понимаю, попробуйте повторить запрос";
                }
               
            }

            return req;

		}
		
		public static void SpeechException (Exception exc)
		{
			
		}
	
	}
	
	 
}