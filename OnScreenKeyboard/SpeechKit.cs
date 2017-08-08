using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NAudio.Wave;
using System.Net;
using System.Net.Sockets;
using System.Xml;

namespace Datatron.Classes
{
    class SpeechKit { 

            public static string YANDEX_API_KEY = "e05f5a12-8e05-4161-ad05-cf435a4e7d5b";
            public static string YANDEX_ASR_HOST = "asr.yandex.net";
            public static string YANDEX_ASR_PATH = "/asr_xml";
            public static double CHUNK_SIZE = Math.Pow(1024, 2);
            public static string TTS_URL = "https://tts.voicetech.yandex.net/generate";
            public static string FILE_PATH = "c41vqhpdek.wav";
            public static int httpPort = 80;
            public static int httpsPort = 443;

            /*
            public static byte[] convert_to_ogg(string filePath)
            {
                var output = new MemoryStream();
                var ffMpeg = new FFMpegConverter();
                ffMpeg.ConvertMedia(filePath, output, Format.ogg);
                output.Seek(0, SeekOrigin.Begin);

                return output.ToArray();
            }*/
            /*
            public static byte[] convert_to_mp3(string filePath)
            {
                var output = new MemoryStream();
                var input_filePath = "output_mp3.mp3";
                using (var reader = new MediaFoundationReader(filePath))
                {
                    MediaFoundationEncoder.EncodeToMp3(reader, input_filePath, 192000);
                }

                using (Stream input = File.OpenRead(input_filePath))
                {
                    input.CopyTo(output);
                }
                output.Position = 0;
                return output.ToArray();
            }*/

            public static byte[] convert_to_pcm16b16000r(string filePath, byte[] in_bytes = null)
            {
                var output = new MemoryStream();
                var output_filePath = "output_pcm.wav";
                var desiredOutputFormat = new WaveFormat(16000, 16, 2);
                using (var reader = new WaveFileReader(filePath))
                using (var converter = new WaveFormatConversionStream(desiredOutputFormat, reader))
                {
                    WaveFileWriter.CreateWaveFile(output_filePath, converter);
                }

                using (Stream input = File.OpenRead(output_filePath))
                {
                    input.CopyTo(output);
                }
                output.Position = 0;
                return output.ToArray();
            }

            public static IEnumerable<byte[]> read_chunks(int chunk_size)
            {
                while (true)
                {
                    var chunk = new byte[chunk_size];
                    List<byte> bytes = new List<byte>(chunk);
                    bytes.RemoveRange(0, chunk_size);

                    yield return chunk;

                    if (bytes.Count == 0)
                        break;
                }
            }

            public static void text_to_speech(string text, string filename = null, string lang = "ru-RU", bool convert = true, bool as_audio = false, string file_like = null)
            {

                string url = string.Format("{0}?text={1}&format={2}&lang={3}&speaker={4}&key={5}&emotion={6}&speed={7}",
                                    TTS_URL, text, "wav", lang, "oksana", YANDEX_API_KEY, "neutral", "1.0");

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
                        var bArray = new byte[500000];
                        var ms = new MemoryStream();
                        dataStream.CopyTo(ms);
                        bArray = ms.ToArray();

                        using (FileStream fs = new FileStream(@".\speechGenerated.wav", FileMode.Create, FileAccess.Write))
                        using (BinaryWriter bw = new BinaryWriter(fs))
                        {
                            foreach (var item in bArray)
                                bw.Write(item);
                        }
                        dataStream.Close();
                        reader.Close();
                        Console.WriteLine("Файл записан");
                    }
                    else
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            public static void speech_to_text(int port, string filename, byte[] bytes = null, Guid request_id = new Guid(), string topic = "queries", string lang = "ru-RU")
            {
                request_id = Guid.NewGuid();
                var strReqId = request_id.ToString();
                var s = strReqId.Split('-');
                var req_id = "";
                foreach (var item in s)
                {
                    req_id += item;
                }

                bytes = convert_to_pcm16b16000r("2.wav", in_bytes: bytes);

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
                var returnData = Encoding.ASCII.GetString(rBytes, 0, bytesRead);
                Console.Write(returnData);
                IEnumerable<byte[]> chunks = read_chunks((int)CHUNK_SIZE);

                byte[] fileBytes = File.ReadAllBytes(FILE_PATH);

                var wClient = new WebClient();
                wClient.OpenWrite("https://" + YANDEX_ASR_HOST + YANDEX_ASR_PATH);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://" + YANDEX_ASR_HOST + YANDEX_ASR_PATH + string.Format("?uuid={0}&key={1}&topic={2}&lang={3}",
                                           req_id,
                                           YANDEX_API_KEY,
                                           topic,
                                           lang));

                request.Method = "POST";

                request.ContentType = "audio/x-wav";
                request.ContentLength = fileBytes.Length;
                request.Headers.Add("key", "e05f5a12-8e05-4161-ad05-cf435a4e7d5b");


                Stream dataStream = request.GetRequestStream();
                dataStream.Write(fileBytes, 0, fileBytes.Length);
                dataStream.Close();

                HttpWebResponse wResp;

                Stream errorSream;
                var text = "";

                //System.Threading.Thread.Sleep(5000);

                try
                {
                    wResp = (HttpWebResponse)request.GetResponse();
                    using (errorSream = wResp.GetResponseStream())
                    using (StreamReader reader = new StreamReader(errorSream, Encoding.UTF8))
                    {
                        text = reader.ReadToEnd();
                        Console.WriteLine(text);
                    }
                }
                catch (WebException we)
                {
                    using (errorSream = we.Response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(errorSream, Encoding.UTF8))
                    {
                        text = reader.ReadToEnd();
                        Console.WriteLine(text);
                    }
                }

                rBytes = new byte[client.ReceiveBufferSize];
                client.Client.Receive(rBytes, client.ReceiveBufferSize, SocketFlags.None);
                returnData = Encoding.UTF8.GetString(rBytes, 0, bytesRead);
                Console.Write(returnData);

                client.Close();

            }





    }
}

