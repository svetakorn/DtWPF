using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using NAudio.Wave.SampleProviders;
using System.Timers;
using NAudio.Wave;
using NAudio;
using FFT.External;
using Fourier;
using Datatron.Classes;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Datatron.Networking;
using System.Media;
using speechKit;
using GridAnimationDemo;

namespace OnScreenKeyboard
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            seeMore.num1.MouseDown += Num1_MouseDown;
            seeMore.num2.MouseDown += Num2_MouseDown;
            onScreenKeyboard.Enter.Click += enter_MouseDown;
            Page_Loaded();
            //questions = GetGoodQueries();
        }


        #region UNITY_NETWORKING

        string[] recordedAnswers = {

"1.1",
"1.10",
"1.11",
"1.12",
"1.13",
"1.14",
"1.15",
"1.16",
"1.17",
"1.18",
"1.19",
"1.2.1",
"1.2.10",
"1.2.11",
"1.2.12",
"1.2.13",
"1.2.14",
"1.2.15",
"1.2.16",
"1.2.17",
"1.2.18",
"1.2.19",
"1.2.2",
"1.2.20",
"1.2.21",
"1.2.22",
"1.2.23",
"1.2.24",
"1.2.25",
"1.2.26",
"1.2.27",
"1.2.28",
"1.2.29",
"1.2.3",
"1.2.30",
"1.2.31",
"1.2.32",
"1.2.33",
"1.2.34",
"1.2.35",
"1.2.36",
"1.2.37",
"1.2.38",
"1.2.39",
"1.2.4",
"1.2.40",
"1.2.41",
"1.2.42",
"1.2.43",
"1.2.5",
"1.2.6",
"1.2.7",
"1.2.8",
"1.2.9",
"1.20",
"1.21",
"1.22",
"1.3",
"1.4",
"1.5",
"1.6",
"1.7",
"1.8",
"1.9",
"10.1",
"10.2",
"10.3",
"10.4",
"10.5",
"10.6",
"11.1",
"11.10",
"11.11",
"11.2",
"11.3",
"11.4",
"11.5",
"11.6",
"11.7",
"11.8",
"11.9",
"12.1",
"12.2",
"12.3",
"12.4",
"12.5",
"12.6",
"13.1",
"13.10",
"13.11",
"13.12",
"13.13",
"13.14",
"13.15",
"13.16",
"13.17",
"13.18",
"13.19",
"13.2",
"13.20",
"13.3",
"13.4",
"13.5",
"13.6",
"13.7",
"13.8",
"13.9",
"14.1",
"14.2",
"14.3",
"14.4",
"14.5",
"15.1",
"15.10",
"15.11",
"15.12",
"15.2",
"15.3",
"15.4",
"15.5",
"15.6",
"15.7",
"15.8",
"15.9",
"16.1",
"16.2",
"16.3",
"16.4",
"16.5",
"16.6",
"16.7",
"16.8",
"17.1",
"17.10",
"17.11",
"17.12",
"17.13",
"17.14",
"17.15",
"17.16",
"17.17",
"17.18",
"17.19",
"17.2",
"17.20",
"17.21",
"17.22",
"17.23",
"17.24",
"17.25",
"17.26",
"17.3",
"17.4",
"17.5",
"17.6",
"17.7",
"17.8",
"17.9",
"18.1",
"18.2",
"18.3",
"18.4",
"18.5",
"19.1",
"19.2",
"19.3",
"19.4",
"19.5",
"2.1",
"2.2",
"2.3",
"2.4",
"20.1",
"20.2",
"20.3",
"20.4",
"20.5",
"21.1",
"21.10",
"21.11",
"21.12",
"21.13",
"21.14",
"21.15",
"21.16",
"21.17",
"21.18",
"21.19",
"21.2",
"21.20",
"21.21",
"21.22",
"21.23",
"21.24",
"21.25",
"21.26",
"21.27",
"21.28",
"21.29",
"21.3",
"21.30",
"21.31",
"21.32",
"21.33",
"21.4",
"21.5",
"21.6",
"21.7",
"21.8",
"21.9",
"22.1",
"22.10",
"22.11",
"22.12",
"22.13",
"22.14",
"22.15",
"22.16",
"22.17",
"22.18",
"22.2",
"22.3",
"22.4",
"22.5",
"22.6",
"22.7",
"22.8",
"22.9",
"101",
"23.1",
"23.10",
"23.100",
"23.101",
"23.11",
"23.12",
"23.13",
"23.14",
"23.15",
"23.16",
"23.17",
"23.18",
"23.19",
"23.2",
"23.20",
"23.21",
"23.22",
"23.23",
"23.24",
"23.25",
"23.27",
"23.28",
"23.29",
"23.3",
"23.30",
"23.31",
"23.32",
"23.33",
"23.34",
"23.35",
"23.36",
"23.37",
"23.38",
"23.39",
"23.4",
"23.40",
"23.41",
"23.42",
"23.43",
"23.44",
"23.45",
"23.46",
"23.47",
"23.48",
"23.49",
"23.5",
"23.50",
"23.51",
"23.52",
"23.53",
"23.54",
"23.55",
"23.56",
"23.57",
"23.58",
"23.59",
"23.6",
"23.60",
"23.61",
"23.62",
"23.63",
"23.64",
"23.65",
"23.66",
"23.67",
"23.68",
"23.69",
"23.7",
"23.70",
"23.71",
"23.72",
"23.73",
"23.74",
"23.75",
"23.76",
"23.77",
"23.78",
"23.79",
"23.8",
"23.80",
"23.81",
"23.82",
"23.83",
"23.84",
"23.85",
"23.86",
"23.87",
"23.88",
"23.89",
"23.9",
"23.90",
"23.91",
"23.92",
"23.93",
"23.94",
"23.95",
"23.96",
"23.97",
"23.98",
"23.99",
"24.1",
"24.2",
"24.3",
"24.4",
"24.5",
"25.1",
"25.10",
"25.11",
"25.12",
"25.2",
"25.3",
"25.4",
"25.5",
"25.6",
"25.7",
"25.8",
"25.9",
"26.1",
"26.10",
"26.11",
"26.2",
"26.3",
"26.4",
"26.5",
"26.6",
"26.7",
"26.8",
"26.9",
"27.1",
"27.2",
"27.3",
"27.4",
"28.1",
"28.1_1",
"28.2",
"28.3",
"28.4",
"28.5",
"28.6",
"29.1",
"29.2",
"29.3",
"29.4",
"29.5",
"29.6",
"29.7",
"29.8",
"3.1",
"3.2",
"3.3",
"3.4",
"3.5",
"30.1",
"30.10",
"30.11",
"30.12",
"30.13",
"30.14",
"30.15",
"30.16",
"30.17",
"30.18",
"30.19",
"30.2",
"30.20",
"30.21",
"30.22",
"30.23",
"30.24",
"30.25",
"30.26",
"30.27",
"30.28",
"30.29",
"30.3",
"30.30",
"30.31",
"30.32",
"30.33",
"30.34",
"30.35",
"30.36",
"30.37",
"30.38",
"30.39",
"30.4",
"30.40",
"30.5",
"30.6",
"30.7",
"30.8",
"30.9",
"31.1",
"31.10",
"31.11",
"31.2",
"31.21.1",
"31.21.10",
"31.21.11",
"31.21.12",
"31.21.13",
"31.21.14",
"31.21.15",
"31.21.16",
"31.21.17",
"31.21.18",
"31.21.19",
"31.21.2",
"31.21.20",
"31.21.21",
"31.21.22",
"31.21.23",
"31.21.3",
"31.21.4",
"31.21.5",
"31.21.6",
"31.21.7",
"31.21.8",
"31.21.9",
"31.22.1",
"31.22.10",
"31.22.11",
"31.22.2",
"31.22.3",
"31.22.4",
"31.22.5",
"31.22.6",
"31.22.7",
"31.22.8",
"31.22.9",
"31.3",
"31.4",
"31.5",
"31.6",
"31.7",
"31.8",
"31.9",
"32.1",
"32.10",
"32.100",
"32.101",
"32.102",
"32.103",
"32.104",
"32.105",
"32.106",
"32.107",
"32.108",
"32.109",
"32.11",
"32.110",
"32.111",
"32.112",
"32.114",
"32.115",
"32.116",
"32.117",
"32.118",
"32.119",
"32.12",
"32.120",
"32.121",
"32.122",
"32.123",
"32.124",
"32.125",
"32.13",
"32.14",
"32.15",
"32.16",
"32.17",
"32.18",
"32.19",
"32.2",
"32.20",
"32.21",
"32.22",
"32.23",
"32.24",
"32.25",
"32.26",
"32.27",
"32.28",
"32.29",
"32.3",
"32.30",
"32.31",
"32.32",
"32.33",
"32.34",
"32.35",
"32.36",
"32.37",
"32.38",
"32.39",
"32.4",
"32.40",
"32.41",
"32.42",
"32.43",
"32.44",
"32.45",
"32.46",
"32.47",
"32.48",
"32.49",
"32.5",
"32.50",
"32.51",
"32.52",
"32.53",
"32.54",
"32.55",
"32.56",
"32.57",
"32.58",
"32.59",
"32.6",
"32.60",
"32.61",
"32.62",
"32.63",
"32.64",
"32.65",
"32.66",
"32.67",
"32.68",
"32.69",
"32.7",
"32.70",
"32.71",
"32.72",
"32.73",
"32.74",
"32.75",
"32.76",
"32.77",
"32.78",
"32.79",
"32.8",
"32.80",
"32.81",
"32.82",
"32.83",
"32.84",
"32.85",
"32.86",
"32.87",
"32.88",
"32.89",
"32.9",
"32.90",
"32.91",
"32.92",
"32.93",
"32.94",
"32.95",
"32.96",
"32.97",
"32.98",
"32.99",
"4.1",
"4.10",
"4.11",
"4.12",
"4.13",
"4.14",
"4.15",
"4.16",
"4.17",
"4.18",
"4.19",
"4.2",
"4.20",
"4.21",
"4.22",
"4.23",
"4.24",
"4.25",
"4.26",
"4.27",
"4.28",
"4.29",
"4.3",
"4.4",
"4.5",
"4.6",
"4.7",
"4.8",
"4.9",
"5.1",
"5.2",
"5.3",
"5.4",
"5.5",
"5.6",
"5.7",
"6.1",
"6.2",
"7.1",
"7.10",
"7.11",
"7.12",
"7.2",
"7.3",
"7.4",
"7.5",
"7.6",
"7.7",
"7.8",
"7.9",
"8.1",
"8.10",
"8.11",
"8.12",
"8.13",
"8.14",
"8.15",
"8.16",
"8.17",
"8.18",
"8.19",
"8.2",
"8.20",
"8.21",
"8.22",
"8.3",
"8.4",
"8.5",
"8.6",
"8.7",
"8.8",
"8.9",
"9.1",
"9.2",
"9.3",
"9.4",
"9.5",
"9.6",

        };

        NetworkingSingleton networking = NetworkingSingleton.getInstance();
        SendAudioData audioLoudness = new SendAudioData();


        private void Num2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (seeMore.Opacity > 0.4)
            {
                onScreenKeyboard.Text = seeMoreQuestions[1];
                textBox.Text = seeMoreQuestions[1];

                search_MouseDown(null, null);

            }
        }

        private void Num1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (seeMore.Opacity > 0.4)
            {
                onScreenKeyboard.Text = seeMoreQuestions[0];
                textBox.Text = seeMoreQuestions[0];

                search_MouseDown(null, null);

            }
        }

        private string RemoveEndingBrackets(string rawLine) {return rawLine.Substring(1, rawLine.Length - 2); }

        private string GetAPIanswer(string query)
        {
            try
            {
                WebRequest webRequest;
                webRequest = WebRequest.Create("http://api.datatron.ru/v1/text?apikey=4ca8decb-2f53-4d48-89c9-f65fb62bbfbb&query=" + query);
                Stream objStream;
                objStream = webRequest.GetResponse().GetResponseStream();
                StreamReader objReader = new StreamReader(objStream);
                string sLine = objReader.ReadLine();
                return (sLine);
            }
            catch (Exception ex) { Debug.WriteLine("111!!!%!  " + ex.Message); }

            return "";

            /* FOR FUTURE USE
             * 
             * 
                        dynamic responce = JsonConvert.DeserializeObject(sLine);

                        Debug.WriteLine("%%% " + (string)responce["answer"]["type"]);

                        switch ((string)responce["answer"]["type"])
                        {
                            case "minfin":
                                MinFinAnswer mfAnswer = JsonConvert.DeserializeObject<MinFinAnswer>(responce["answer"]);
                                Debug.WriteLine(JsonConvert.SerializeObject(mfAnswer));
                                break;
                            case "cube":
                                CubeAnswer cbAnswer = JsonConvert.DeserializeObject<CubeAnswer>(responce["answer"]);
                                Debug.WriteLine(JsonConvert.SerializeObject(cbAnswer));
                                break;
                            default:
                                break;
                        }
             * 
             * 
             */

        }

        private string[] GetGoodQueries()
        {
            string[] res = { };
            try
            {
                WebRequest webRequest;
                webRequest = WebRequest.Create("http://api.datatron.ru/v2/good_queries?apikey=4ca8decb-2f53-4d48-89c9-f65fb62bbfbb");
                Stream objStream;
                objStream = webRequest.GetResponse().GetResponseStream();
                StreamReader objReader = new StreamReader(objStream);
                string sLine = objReader.ReadLine();
                JArray arr = (JArray)JsonConvert.DeserializeObject(sLine);
                string dbgsr = (string)(arr.ToString());
                Debug.WriteLine("\n\n\n\nHERE GOES GQ!\n\n\n" + dbgsr + "\n\n\n\n\n");
                res = (arr.ToObject<string[]>());
            }
            catch (Exception ex) { Debug.WriteLine("111!!!%!  " + ex.Message); }

            return res;

        }

        static string json_reescape(string input)
        {
            string output = "";
            string[] special_words = {
                "confidence",
                "status",
                "more_answers_order",
                "more_cube_answers",
                "more_minfin_answers",
                "short_answer",
                "full_answer",
                "message",
                "question",
                "number",
                "attachments",
                "user_request",
                "type",
                "answer",
                "formatted_response",
                "response",
                "feedback",
                "formal",
                "dims",
                "dim",
                "val",
                "cube",
                "measure",
                "verbal",
                "member_caption",
                "dimension_caption",
                "domain",
                "measure",
                "pretty_feedback",
                "path",
                "description" };
            foreach (string word in special_words)
            {
//                for (int i = 1; i < input.Length - word.Length - 4; i++)
//                {
//                    if (input.Substring(i).StartsWith("\\" + "\"" + word + "\\" + "\"")) {
//                        output += "\",\"qwe\": ";
//                    }
//                    output += input.Substring(i, 1);
//                }
            }
            int i = 0;
//            for (int i = 1; i < input.Length; i++)
            while (i < input.Length)
            {
                bool captured = false;
                foreach (string word in special_words)
                {
                    if (input.Substring(i).StartsWith("\\" + "\"" + ", " + "\\" + "\"" + word + "\\" + "\"" + ": " + "\\" + "\"")) //   ", "word": "
                    {
                        output += "\", \"" + word + "\": \"";
                        i += word.Length + 12;
                        captured = true;
                    }
                    if (input.Substring(i).StartsWith("\\" + "\"" + ", " + "\\" + "\"" + word + "\\" + "\"" + ": ")) //   ", "word": 
                    {
                        output += "\", \"" + word + "\": ";
                        i += word.Length + 10;
                        captured = true;
                    }
                    if (input.Substring(i).StartsWith("\\" + "\"" + word + "\\" + "\"" + ": " + "\\" + "\"")) //   "word": "
                    {
                        output += "\"" + word + "\": \"";
                        i += word.Length + 8;
                        captured = true;
                    }
                    if (input.Substring(i).StartsWith("\\" + "\"" + word + "\\" + "\"" + ": " + "{")) //   "word": {
                    {
                        output += "\"" + word + "\": {";
                        i += word.Length + 7;
                        captured = true;
                    }
                    if (input.Substring(i).StartsWith("\\" + "\"" + word + "\\" + "\"" + ": ")) //   "word": 
                    {
                        output += "\"" + word + "\": ";
                        i += word.Length + 6;
                        captured = true;
                    }

                }
                if (input.Substring(i).StartsWith("\\" + "\"" + "}")) //   "}
                {
                    output += "\"}";
                    i += 3;
                    captured = true;
                }
                if (!captured)
                {
                    output += input.Substring(i, 1);
                    i++;
                }
            }
            return output;
        }

        string[] seeMoreQuestions = new string[3];

        void proceedRequest_body(dynamic responce, bool needClean)
        {
            //try
            {
                Random rdIndex = new Random();
                seeMoreQuestions[0] = "";
                seeMoreQuestions[1] = questions[rdIndex.Next(questions.Length)];
                seeMoreQuestions[2] = questions[rdIndex.Next(questions.Length)];
                string user_query = "NOOOPE", formatted_responce = "NOOOPE", type = "none", conf = "", formal_query = "";
                int docsCount = 0, picsCount = 0, urlsCount = 0;
                string vn1s = "0", vn2s = "1";
                attach_control.SetDocCount(0);
                attach_control.SetPicCount(0);
                attach_control.SetUrlCount(0);
                attach_control.Opacity = 0.3;

                try
                {
                    type = responce["answer"]["type"].ToString();
                    if (type.Equals("minfin"))
                    {

                        string vns = ((string)(responce["answer"]["number"]));
                        vn1s = (vns.Substring(0, vns.IndexOf('.')));
                        vn2s = vns.Substring(vns.IndexOf('.') + 1);

                        seeMore.Opacity = 1; attach_control.Opacity = 1;
                        //seeMore.Visibility = Visibility.Visible; attach_control.Visibility = Visibility.Visible;
                        user_query = responce["answer"]["user_request"];
                        //user_query = responce["answer"]["question"];
                        formatted_responce = responce["answer"]["full_answer"];
                        formal_query = responce["answer"]["question"];
                        conf = responce["confidence"];
                        Debug.WriteLine("CONF: " + conf);

                        try
                        {

                            int docCount = 0, picCount = 0, urlCount = 0;

                            JArray attachments = responce["answer"]["attachments"];
                            List<AttachClass> AL = new List<AttachClass>();
                            foreach (dynamic item in attachments)
                            {
                                AL.Add(new AttachClass((string)item["description"], (string)item["path"], (string)item["type"]));
                                switch ((string)item["type"])
                                {
                                    case "document": docCount++; break;
                                    case "image": picCount++; break;
                                    case "url": urlCount++; break;
                                }
                            }

                            attach_control.SetDocCount(docCount);
                            docsCount = docCount;
                            attach_control.SetPicCount(picCount);
                            picsCount = picCount;
                            attach_control.SetUrlCount(urlCount);
                            urlsCount = urlCount;

                            ListAttachments.SendAttachInfo(AL);
                            ShowDocument.SendAttachInfo(AL);


                            //if (urls.Count == 0) attach_control.url_img.Opacity = 0.3; else attach_control.url_img.Opacity = 1;
                        }
                        catch
                        {
                            attach_control.SetDocCount(0);
                            attach_control.SetPicCount(0);
                            attach_control.SetUrlCount(0);
                            //attach_control.SetUrlCount(0); attach_control.url_img.Opacity = 0.3;
                        }

                        if (docsCount + picsCount + urlsCount == 0)
                            attach_control.Opacity = 0.3;
                        else
                            attach_control.Opacity = 1;

                        if (!recordedAnswers.Contains(vn1s + "." + vn2s))
                        {
                            playTTS((string)responce["answer"]["short_answer"]);
                            //                                try
                            //                                {
                            //                                    speechKit.Program.text_to_speech((string)responce["answer"]["short_answer"]);
                            //                                    SoundPlayer sp = new SoundPlayer();
                            //                                    sp.SoundLocation = "speechGenerated.wav";
                            //                                    sp.Load();
                            //                                    Task.Delay(1500).ContinueWith(_ =>
                            //                                    {
                            //                                        sp.Play();
                            //                                    });
                            //                                }
                            //                                catch (Exception ex)
                            //                                {
                            //                                    Debug.WriteLine(ex);
                            //                                    //MessageBox.Show("Голосовая запись ответа по кубу не создана");
                            //                                }
                        } else
                        {
                            playTTS(" Ъ ");
                        }

                    }
                    if (type.Equals("cube"))
                    {
                        attach_control.SetDocCount(0);
                        attach_control.SetPicCount(0);
                        attach_control.SetUrlCount(0);

                        seeMore.Opacity = 1;

                        vn2s = "0";

                        //                        seeMore.Visibility = Visibility.Visible; attach_control.Visibility = Visibility.Hidden;
                        seeMore.Opacity = 1; attach_control.Opacity = 0.3;
                        user_query = responce["answer"]["feedback"]["user_request"];
                        try
                        {
                            playTTS((string)responce["answer"]["formatted_response"]);
                            //                                speechKit.Program.text_to_speech((string)responce["answer"]["formatted_response"]);
                            //                                SoundPlayer sp = new SoundPlayer();
                            //                                sp.SoundLocation = "speechGenerated.wav";
                            //                                sp.Load();
                            //                                Task.Delay(1500).ContinueWith(_ =>
                            //                                {
                            //                                    sp.Play();
                            //                                });
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                            //MessageBox.Show("Голосовая запись ответа по кубу не создана");
                        }

                        //                        formatted_responce = "Datatron понял ваш вопрос как: \n" + (string)responce["answer"]["feedback"]["verbal"]["domain"];
                        formal_query = (string)responce["answer"]["feedback"]["pretty_feedback"];
                        // int cccc = 0;
                        // while (cccc < formatted_responce.Length)
                        // {
                        //     if (formatted_responce.Substring(cccc, 1).Equals(formatted_responce.Substring(cccc, 1).ToUpper()) && (!formatted_responce.Substring(cccc, 1).Equals(formatted_responce.Substring(cccc, 1).ToLower())))
                        //     { formatted_responce = formatted_responce.Substring(0, cccc) + " " + formatted_responce.Substring(cccc); cccc++; }
                        //     cccc++;
                        // }
                        // formatted_responce = formatted_responce.Substring(0, 1).ToUpper() + formatted_responce.Substring(1);
                        conf = responce["confidence"];

                        //                        foreach (var item in responce["answer"]["feedback"]["verbal"]["dims"])
                        //                        { formatted_responce += " | " + ((string)item["member_caption"]); }
                        formatted_responce = "Ответ: " + (string)responce["answer"]["formatted_response"];
                        string[] currentCubes = { "CLDO01", "INDO01", "EXDO01", "CLDO02" };
                        if (currentCubes.Contains((string)responce["answer"]["feedback"]["formal"]["cube"]))
                            formatted_responce += "\nАктуальность ответа: 18.08.2017";
                        //if (((string)responce["answer"]["feedback"]["formal"]["cube"]).Equals("CLMR02"))
                        //    formatted_responce += "\nАктуальность ответа: 01.08.2017";


                    }
                    if (formatted_responce == null)
                    {
                        formatted_responce = "Не найден ответ";
                    }

                }
                //catch (Exception ex) { throw ex; }
                //catch (Exception ex) { Debug.WriteLine("222!!!%!  "+ex.Message); }
                catch { Debug.WriteLine("&&&&&&&&"); formatted_responce = "Не найден ответ"; }




                try
                {

                    JArray[] seeMoreQuestionsArrays = new JArray[3];
                    int[] seeIndex = { 0, 0 };
                    try { seeMoreQuestionsArrays[0] = responce["more_cube_answers"]; } catch { }
                    try { seeMoreQuestionsArrays[1] = responce["more_minfin_answers"]; } catch { }
                    string order = responce["more_answers_order"];

                    for (int i = 0; i < seeMoreQuestions.Length; i++)
                    {
                        try
                        {
                            seeMoreQuestions[i] = (string)seeMoreQuestionsArrays[int.Parse(order.Substring(i, 1))][seeIndex[0]]["feedback"]["pretty_feedback"];
                            //seeMoreQuestions[i] = (string)seeMoreQuestionsArrays[int.Parse(order.Substring(i, 1))][seeIndex[0]]["feedback"]["verbal"]["domain"];
                            //foreach (var item in seeMoreQuestionsArrays[int.Parse(order.Substring(i, 1))][seeIndex[0]]["feedback"]["verbal"]["dims"])
                            //{ seeMoreQuestions[i] += " | " + ((string)item["member_caption"]); }
                            //int cccc = 0;
                            //while (cccc < seeMoreQuestions[i].Length)
                            //{
                            //    if (seeMoreQuestions[i].Substring(cccc, 1).Equals(seeMoreQuestions[i].Substring(cccc, 1).ToUpper()) && (!seeMoreQuestions[i].Substring(cccc, 1).Equals(seeMoreQuestions[i].Substring(cccc, 1).ToLower())))
                            //    { seeMoreQuestions[i] = seeMoreQuestions[i].Substring(0, cccc) + " " + seeMoreQuestions[i].Substring(cccc); cccc++; }
                            //    cccc++;
                            //}
                            //seeMoreQuestions[i] = seeMoreQuestions[i].Substring(0, 1).ToUpper() + seeMoreQuestions[i].Substring(1);
                            seeIndex[0]++;
                        }
                        catch { seeMoreQuestions[i] = (string)seeMoreQuestionsArrays[int.Parse(order.Substring(i, 1))][seeIndex[1]]["question"]; seeIndex[1]++; }
                    }


                    if (seeMoreQuestions[1].Equals(seeMoreQuestions[0]))
                        seeMoreQuestions[1] = seeMoreQuestions[2];

                    if (seeMoreQuestions[0].Equals(""))
                        seeMore.Opacity = 0.3;

                }
                catch (Exception ex) { Debug.WriteLine("333!!!%!  " + ex.Message); }
                //                    catch { }


                if (networking.client.Connected)
                {
                        networking.SendQuestion(user_query, formal_query, conf, formatted_responce, seeMoreQuestions[0], seeMoreQuestions[1], docsCount, picsCount, urlsCount, vn1s, vn2s);
                    if (needClean)
                    {
                        onScreenKeyboard.Text = "";
                        textBox.Text = "";
                    }

                }
            }
//            catch (Exception ex) { throw ex; }
        }

        static string[] Ang_howareyou = {
            "У меня все отлично, спасибо",
            "Все хорошо!",
            "Замечательно!",
            "Чудесно! Данные расходятся, как горячие пирожки"
        };
        static string[] Ang_whoareyou = {
            "Я – персональный помощник и экспертная система Datatron.\nЯ отвечаю на вопросы в финансовой сфере, используя базы данных единого портала бюджетной системы Российской Федерации и базы знаний Министерства финансов Российской Федерации.\nМеня создали студенты Высшей школы экономики, МГУ и Финансового Университета.\nЯ применяю нейросети и инструменты машинного обучения.\nЯ могу ответить на тысячи вопросов о бюджете Российской Федерации и деятельности Минфина России.\nМеня разработали специального для Второго московского финансового форума.\nDatatron также доступен как чат-бот в мессенджере Telegram, и как мобильное приложение.",
            "Я – прекрасная Анжелика, alter ego персонального помощника и экспертной системы Datatron."
        };
        static string Ang_whatyoucan = "Я знаю очень много о бюджете Российской Федерации. Например, я могу ответить про расходы на высшее образование или культуру в каждом субъекте Российской Федерации или в целом по федеральному бюджету. Я расскажу о доходах бюджетов, о состоянии внешнего и внутреннего долга.\n\nЯ знаю о текущей деятельности Министерства финансов Российской Федерации и его истории.Вы можете спросить меня об облигациях федерального займа, или о первом экономисте.\n\nЯ с легкостью дам определения многих экономических терминов: авизо, оферент, стагнация.\n\nОткуда я все это знаю? Я отвечаю на вопросы, используя базы данных единого портала бюджетной системы Российской Федерации и базы знаний Министерства финансов Российской Федерации.";
        static string Ang_whocreated = "Меня создали студенты Высшей школы экономики, МГУ и Финансового Университета";
        static string Ang_howtouse = "Нажмите кнопку микрофона и задайте вопрос, или наберите вопрос на клавиатуре. Дальше нажмите кнопку поиска. Я выполню поиск в базе знаний и дам ответ. В ответ могут быть включены дополнительные документы, ссылки и изображения. В разделе «Смотри также» я покажу схожие по смыслу вопросы, вы можете выбрать их, нажав на номер вопроса";
        static string[] Ang_whatever = { "Подлиза!", "Да, я не только симпатичная оболочка" };

        static string[] Ang_howareyou_speech = {
            "У меня все отлично, спасибо",
            "Все хорошо!",
            "Замечательно!",
            "Чудесно! Данные расходятся, как горячие пирожки"
        };
        static string[] Ang_whoareyou_speech = {
            "Я – персональный помощник и экспертная система Datatron.\nЯ отвечаю на вопросы в финансовой сфере, используя базы данных единого портала бюджетной системы Российской Федерации и базы знаний Министерства финансов Российской Федерации.\nМеня разработали специального для Второго московского финансового форума, и любому его  участнику я с радостью дам ответы на любые вопросы о бюджете Российской Федерации и деятельности Минфина России.",
            "Я – прекрасная Анжелика, альтер эго персонального помощника и экспертной системы Datatron."
        };
        static string Ang_whatyoucan_speech = "Я знаю очень много о бюджете Российской Федерации, текущей деятельности минфина России и его истории, а также с легкостью дам определения многих экономических терминов.\nЯ отвечаю на вопросы, используя базы данных единого портала бюджетной системы Российской Федерации и базы знаний Минфина России.";
        static string Ang_whocreated_speech = "Меня создали студенты Высшей школы экономики, МГУ и Финансового Университета.";
        static string Ang_howtouse_speech = "Нажмите кнопку микрофона и задайте вопрос, или наберите вопрос на клавиатуре. Дальше нажмите кнопку поиска. Я выполню поиск в базе знаний и дам ответ. В ответ могут быть включены дополнительные документы, ссылки и изображения. В разделе «Смотри также» я покажу схожие по смыслу вопросы, вы можете выбрать их, нажав на номер вопроса";
        static string[] Ang_whatever_speech = { "Подлиза!", "Да, я не только симпатичная оболочка" };

        string Angelica_speech = "";
        string Angelica_video = "";

        string Angelica(string request)
        {
            Angelica_video = "";

            string[] words = request.Split(' ');
            char[] trimPunc = { ',', '"', '«', '»', '.', '?', '!', '#', '№', '$', '%', ':', '&', '*', '(', ')', '[', ']', '\\', '/', '|', '<', '>', ';', '€', '…', ' ', '\n' };
            for (int i = 0; i < words.Length; i++)
                words[i] = words[i].Trim(trimPunc).ToLower();

            if (words.Contains("<censored>"))
            {
                Angelica_speech = "Оу...";
                return "*смущение*";
            }

            if (words.Length <= 5 && words.Contains("как") && (words.Contains("дела") || words.Contains("поживаешь") || words.Contains("жизнь") || words.Contains("делишки")))
            {
                int i = (new Random()).Next(Ang_howareyou.Length);
                Angelica_speech = Ang_howareyou_speech[i];
                return Ang_howareyou[i];
            }


            if (
                
                words.Length <= 6 
                && 
                (
                    words.Contains("привет") 
                    || 
                    words.Contains("здравствуй") 
                    || 
                    words.Contains("здравствуйте") 
                    || 
                    words.Contains("хай") 
                    || 
                    words.Contains("приветствую") 
                    || 
                    (
                        (words.Contains("добрый") || words.Contains("доброе")) 
                        && 
                        (words.Contains("утро") || words.Contains("день") || words.Contains("вечер"))
                    )
                ) 
                && 
                words.Contains("как") 
                && 
                (words.Contains("дела") || words.Contains("поживаешь") || words.Contains("жизнь") || words.Contains("делишки"))
                
            )
            {
                int i = (new Random()).Next(Ang_howareyou.Length);
                Angelica_speech = "Привет!\n" + Ang_howareyou_speech[i];
                return "Привет!\n" + Ang_howareyou[i];
            }

            if (words.Length <= 5 && words.Contains("что") && (words.Contains("умеешь") || words.Contains("знаешь") || words.Contains("можешь") || words.Contains("отвечаешь") || words.Contains("делаешь")))
            {
                Angelica_speech = Ang_whatyoucan_speech;
                Angelica_speech = " Ъ ";
                Angelica_video = "what_you_know";
                return Ang_whatyoucan;
            }

            if ((words.Length <= 4 && ((words.Contains("кто") || words.Contains("что")) && (words.Contains("ты") || words.Contains("анжелика"))) || ((words.Contains("как") || words.Contains("тебя")) && (words.Contains("зовут") || words.Contains("звать")))) || (words.Contains("datatron") || words.Contains("дататрон")))
            {
                int i = (new Random()).Next(Ang_whoareyou.Length);
                Angelica_speech = Ang_whoareyou_speech[i];
                Angelica_speech = " Ъ ";
                Angelica_video = "who_are_you_0" + i.ToString();
                return Ang_whoareyou[i];
            }

            if (words.Length <= 4 && words.Contains("кто") && (words.Contains("создал") || words.Contains("сделал") || words.Contains("сотворил") || words.Contains("написал") || words.Contains("запрогроммировал") || words.Contains("создатель") || words.Contains("автор") || words.Contains("создатели") || words.Contains("написали")))
            {
                Angelica_speech = Ang_whocreated_speech;
                Angelica_speech = " Ъ ";
                return Ang_whocreated;
            }

            if (words.Length <= 4 && (words.Contains("что") || words.Contains("как")) && (words.Contains("делать") || words.Contains("пользоваться") || words.Contains("спросить")))
            {
                Angelica_speech = Ang_howtouse_speech;
                Angelica_speech = " Ъ ";
                Angelica_video = "how_use";
                return Ang_howtouse;
            }

            if (words.Length <= 2 && (words.Contains("привет") || words.Contains("здравствуй") || words.Contains("здравствуйте") || words.Contains("хай") || words.Contains("приветствую") || ((words.Contains("добрый") || words.Contains("доброе"))&& (words.Contains("утро") || words.Contains("день") || words.Contains("вечер")))))
            {
                Angelica_speech = "Привет!";
                Angelica_speech = " Ъ ";
                Angelica_video = "Welcome_01";
                return "Привет!";
            }

            switch (string.Join(" ", words))
            {
                case "давай встречаться": Angelica_speech = "Это очень мило, но прости, на ближайшие несколько лет у меня другие планы"; return "Это очень мило, но прости, на ближайшие несколько лет у меня другие планы"; break;
                case "ты умная": Angelica_video = "you_smart"; return Ang_whatever[(new Random()).Next(2)]; break;
                case "в чем смысл жизни": Angelica_video = "meaning_of_life"; return "Смысл жизни в том, чтобы размышлять над подобными вопросами"; break;
                case "я тебя люблю": Angelica_video = "i_love_you"; return "Я знаю"; break;
                case "ты веришь в бога": Angelica_video = "believe_in_god"; return "Простите, я не могу вести теологические дискуссии"; break;
                case "ты выйдешь за меня замуж": Angelica_video = "marry_me"; return "Заманчивое предложение, но мне нужно его хорошенько обдумать\n\n[loading...]"; break;
                case "выходи за меня замуж": Angelica_video = "marry_me"; return "Заманчивое предложение, но мне нужно его хорошенько обдумать\n\n[loading...]"; break;
                case "выходи за меня": Angelica_video = "marry_me"; return "Заманчивое предложение, но мне нужно его хорошенько обдумать\n\n[loading...]"; break;
                case "ты глупая": Angelica_video = "you_stupid"; return "Я становлюсь способнее с каждым днем"; break;
                case "как ты выглядишь": Angelica_video = "how_you_look_like"; return "Блестяще!"; break;
                case "окей google": Angelica_video = "okay_google"; return "Эм... Мне кажется, вы ошиблись ассистентом"; break;
                case "ok google": Angelica_video = "okay_google"; return "Эм... Мне кажется, вы ошиблись ассистентом"; break;
                case "окей гугл": Angelica_video = "okay_google"; return "Эм... Мне кажется, вы ошиблись ассистентом"; break;
                case "расскажи сказку": Angelica_video = "tell_story"; return "Что, опять?"; break;
                case "расскажи мне сказку": Angelica_video = "tell_story"; return "Что, опять?"; break;
            }


            return "none";
        }

        bool canProceed = true;

        async void proceedRequest(string requestString, bool needClean = true)
        {
            if (canProceed && (!requestString.Equals("")))
            {
                canProceed = false;
                if (needClean) onScreenKeyboard.Text = "";
                Angelica_speech = "";
                string ang = Angelica(requestString);
                if (ang.Equals("none"))
                {
                    var slowTask2 = Task<string>.Factory.StartNew(() => GetAPIanswer(requestString));
                    await slowTask2;
                    string APIRESPONCE = slowTask2.Result.ToString();
                    dynamic responce;
                    Debug.WriteLine("\n\n\n\n\n\n\n\n\n\n");
                    try
                    {
                        responce = JsonConvert.DeserializeObject(APIRESPONCE);
                        //Debug.WriteLine("\n\n%%%\n\n");
                        Debug.WriteLine(((APIRESPONCE)));
                        Debug.WriteLine("\n\n\n\n\n\n\n\n\n\n");
                        //Debug.WriteLine("\n\n%%%\n\n");
                        //Debug.WriteLine(json_reescape(RemoveEndingBrackets(JsonConvert.SerializeObject(APIRESPONCE))));
                        //Debug.WriteLine("\n\n%%%\n\n");
                        string dbgrw = (string)responce.ToString();
                        Debug.WriteLine("N! " + dbgrw);
                        Debug.WriteLine("\n\n\n\n\n\n\n\n\n\n");
                        proceedRequest_body(responce, needClean);
                    }
                    catch (Exception ex) {
                        Debug.WriteLine(("Замещено! " + ex.Message));
                        Debug.WriteLine(((APIRESPONCE)));
                        Debug.WriteLine("\n\n\n\n\n\n\n\n\n\n");
                                                var slowTask = Task<string>.Factory.StartNew(() => json_reescape(RemoveEndingBrackets(JsonConvert.SerializeObject(APIRESPONCE))));
                                                await slowTask;
                                                responce = JsonConvert.DeserializeObject(slowTask.Result.ToString());
                        //responce = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<dynamic>(APIRESPONCE);
                        string dbgrw = (string)responce.ToString();
                        Debug.WriteLine("R! " + dbgrw);
                        Debug.WriteLine("\n\n\n\n\n\n\n\n\n\n");

                        proceedRequest_body(responce, needClean);
                    }
                } else
                {
                    if (Angelica_video.Equals(""))
                    {
                        playTTS(Angelica_speech);
                        networking.SendQuestion(requestString, requestString, "-", ang, "", "", 0, 0, 0, "0", "0");
                    } else
                    {
                        networking.SendQuestion(requestString, requestString, "-", ang, "", "", 0, 0, 0, "other", Angelica_video);
                    }

                }
                Task.Delay(500).ContinueWith(_ => { canProceed = true; });
            }
            

        }

        private void search_MouseDown(object sender, MouseButtonEventArgs e)
        {
            proceedRequest(textBox.Text);
        }
        private void enter_MouseDown(object sender, RoutedEventArgs e)
        {
            proceedRequest(textBox.Text);
        }

        #endregion

        #region SPEECHKIT
        // WaveIn - поток для записи
        WaveIn waveIn;
        //Класс для записи в файл
        WaveFileWriter writer;
        //Имя файла для записи
        string outputFilename = "2.wav";

        //Получение данных из входного буфера 
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new EventHandler<WaveInEventArgs>(waveIn_DataAvailable), sender, e);
            }
            else
            {
                //Записываем данные из буфера в файл
                writer.Write(e.Buffer, 0, e.BytesRecorded);
            }
        }
        //Завершаем запись
        void StopRecording()
        {
            waveIn.StopRecording();
            try
            {
                writer.Close();
            }
            catch { }

        }
        //Окончание записи
        private void waveIn_RecordingStopped(object sender, EventArgs e)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new EventHandler(waveIn_RecordingStopped), sender, e);
            }
            else
            {
                try
                {
                    waveIn.Dispose();
                    waveIn = null;
                    writer.Close();
                    writer = null;
                }
                catch { }
        }
    }

        private void startListening()
        {
            try
            {
               
                waveIn = new WaveIn();
                //Дефолтное устройство для записи (если оно имеется)
                //встроенный микрофон ноутбука имеет номер 0
                waveIn.DeviceNumber = 0;
                //Прикрепляем к событию DataAvailable обработчик, возникающий при наличии записываемых данных
                waveIn.DataAvailable += waveIn_DataAvailable;
                //Прикрепляем обработчик завершения записи
                waveIn.RecordingStopped += new EventHandler<NAudio.Wave.StoppedEventArgs>(waveIn_RecordingStopped);
                //Формат wav-файла - принимает параметры - частоту дискретизации и количество каналов(здесь mono)
                waveIn.WaveFormat = new WaveFormat(8000, 1);
                //Инициализируем объект WaveFileWriter
                writer = new WaveFileWriter(outputFilename, waveIn.WaveFormat);
                //Начало записи
                waveIn.StartRecording();

            }
            catch (Exception ex)
            { }
            try
            {
                SoundPlayer spst = new SoundPlayer();
                spst.SoundLocation = "speechStart.wav";
                spst.Load();
                spst.Play();
            }
            catch { }
           
        }

        private string stopListening(bool isProceed)
        {
            string res = "";
            if (waveIn != null)
            {
                StopRecording();
            }
            

            string voicetext = "";
            try
            {
                SoundPlayer spsp = new SoundPlayer();
                spsp.SoundLocation = "speechStop.wav";
                spsp.Load();
                spsp.Play();
            }
            catch { }

            if (isProceed)
            {
                voicetext = speechKit.Program.speech_to_text(outputFilename);
    //            Grid_MouseDown(null, null);
                if (!voicetext.Equals("Извините, я не понимаю, попробуйте повторить запрос"))
                {
                    res = voicetext;
                    //proceedRequest(textBox.Text, false);
                }
                else
                {
                    playTTS(voicetext);
                }
                return res;
            }
            return "";
        }

        static void playTTS(string ttsquery)
        {
                Debug.WriteLine("TTS START");
                NetworkingSingletonSK.getInstance().SendMessage(ttsquery);
                //speechKit.Program.text_to_speech(ttsquery);
                //Debug.WriteLine("TTS STOP");
                //SoundPlayer sp = new SoundPlayer();
                //sp.SoundLocation = "speechGenerated.wav";
                //sp.Load();
                //sp.Play();
                //Debug.WriteLine("PLAY STOP");
        }

        #endregion

        DoubleAnimation animation;
        ThicknessAnimation animation3;
        ColorAnimation animation2;
        //double speed = 2;


        private void Page_Loaded()
        {
            // Центрируем строку в канвасе
            //Canvas.SetBottom(_runningText, (canvas.ActualHeight - _runningText.ActualHeight) / 2);

            animation = new DoubleAnimation();
            animation3 = new ThicknessAnimation();
            animation2 = new ColorAnimation();
            animation.Duration = TimeSpan.FromSeconds(0.05);
            animation3.Duration = TimeSpan.FromSeconds(0.05);
            animation2.Duration = TimeSpan.FromSeconds(0.05);

            // При завершении анимации, запускаем функцию MyAnimation снова
            // (указано в обработчике)
            animation3.Completed += myanim_Completed;

            MyAnimation(_runningText.Margin.Top, _runningText.Margin.Top);
        }

        bool isRollNeed = true;
        int qIndex = 0;

        private void MyAnimation(double from, double to)
        {
            // Если строка вышла за пределы канваса (отриц. Canvas.Left)
            // то возвращаем с другой стороны
            if (_runningText.Margin.Top >= 40)
            {
                qIndex = new Random().Next(questions.Length);
                _runningText.Tag = questions[qIndex];
                animation3.From = new Thickness(0,-40,0,0);
                animation3.To = new Thickness(0, -40, 0, 0);
                _runningText.BeginAnimation(MarginProperty, animation3);

                networking.SendMessage("I" + questions[qIndex]);
            }
            else
            {
                //  Debug.WriteLine(_runningText.Margin.Top);
                //   if (_runningText.Margin.Top <= -1 && _runningText.Margin.Top >= -6)
                //   {
                //       isRollNeed = false;
                //       animation.From = from;
                //       animation.To = -1;
                //       animation2.From = Color.FromArgb((byte)(int)(255 * (1 - Math.Min(Math.Abs(from / 24), 1))), 0xFF, 0xFF, 0xFF);
                //       animation2.To = Color.FromArgb(255, 0xFF, 0xFF, 0xFF);
                //       _runningText.BeginAnimation(Canvas.TopProperty, animation);
                //       //_runningText.BeginAnimation(TextBlock.ForegroundProperty, animation2
                //       PropertyPath colorTargetPath = new PropertyPath("Foreground.Color");
                //       Storyboard CellBackgroundChangeStory = new Storyboard();
                //       Storyboard.SetTarget(animation2, _runningText);
                //       Storyboard.SetTargetProperty(animation2, colorTargetPath);
                //       CellBackgroundChangeStory.Children.Add(animation2);
                //       CellBackgroundChangeStory.Begin();
                //   }
                //   if (isRollNeed)
                //   {
                animation3.From = new Thickness(0, from, 0, 0);
                animation3.To = new Thickness(0, to, 0, 0);
                animation2.From = Color.FromArgb((byte)(int)(255 * (1 - Math.Min(Math.Abs(from / 24), 1))), 0xFF, 0xFF, 0xFF);
                animation2.To = Color.FromArgb((byte)(int)(255 * (1 - Math.Min(Math.Abs(to / 24), 1))), 0xFF, 0xFF, 0xFF);
                _runningText.BeginAnimation(MarginProperty, animation3);
                //_runningText.BeginAnimation(TextBlock.ForegroundProperty, animation2
                PropertyPath colorTargetPath = new PropertyPath("Foreground.Color");
                Storyboard CellBackgroundChangeStory = new Storyboard();
                Storyboard.SetTarget(animation2, _runningText);
                Storyboard.SetTargetProperty(animation2, colorTargetPath);
                CellBackgroundChangeStory.Children.Add(animation2);
                CellBackgroundChangeStory.Begin();
                //   }
                //   else
                //   {
                //       Task.Delay(5000).ContinueWith(_ =>
                //       {
                //           isRollNeed = true;
                //       });
                //       animation.From = from;
                //       animation.To = from;
                //       animation2.From = Color.FromArgb((byte)(int)(255 * (1 - Math.Min(Math.Abs(from / 24), 1))), 0xFF, 0xFF, 0xFF);
                //       animation2.To = Color.FromArgb((byte)(int)(255 * (1 - Math.Min(Math.Abs(from / 24), 1))), 0xFF, 0xFF, 0xFF);
                //       _runningText.BeginAnimation(Canvas.TopProperty, animation);
                //       //_runningText.BeginAnimation(TextBlock.ForegroundProperty, animation2
                //       PropertyPath colorTargetPath = new PropertyPath("Foreground.Color");
                //       Storyboard CellBackgroundChangeStory = new Storyboard();
                //       Storyboard.SetTarget(animation2, _runningText);
                //       Storyboard.SetTargetProperty(animation2, colorTargetPath);
                //       CellBackgroundChangeStory.Children.Add(animation2);
                //       CellBackgroundChangeStory.Begin();
                //   }
            }

        }

        bool isRollNeedActivated = false;
        bool isRollNeedWaitsForActivation = false;
        bool isRollWN = false;

        float[] louds = { 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256, 256 };
        int loudsIndex = 0;
        float loudThreshold = -1;

        private void myanim_Completed(object sender, EventArgs e)
        {
            //Debug.WriteLine("LOUDNESS: " + (int)Math.Round(100 * audioLoudness.loudness));
            audioLoudness.tick(null, null);
            louds[loudsIndex] = audioLoudness.loudness;
            loudsIndex = (loudsIndex + 1) % (louds.Length);
            float loudSum = 0;
            for (int i = 0; i < louds.Length; i++)
                loudSum += louds[i];
            
            if (speechMode == -2) { speechMode = 7; Grid_MouseDown(null, null); }
            if (speechMode == 1 && loudSum < loudThreshold) { speechMode = 1; Grid_MouseDown(null, null); }
           //waves_circles.waveRec_2 .BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(0, new Duration()));
           //waves_circles.waveRec_5 .BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(0, new Duration()));
           //waves_circles.waveRec_8 .BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(0, new Duration()));
            wave_c1.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(1, new Duration(TimeSpan.FromMilliseconds(100))));
            wave_c1.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation(1, new Duration(TimeSpan.FromMilliseconds(100))));
            wave_c2.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(1, new Duration(TimeSpan.FromMilliseconds(100))));
            wave_c2.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation(1, new Duration(TimeSpan.FromMilliseconds(100))));
            wave_c3.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(1, new Duration(TimeSpan.FromMilliseconds(100))));
            wave_c3.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation(1, new Duration(TimeSpan.FromMilliseconds(100))));
            if ( speechMode == 1)
            {
                //waves_circles.waveRec_0 .BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(Math.Sqrt(Math.Sqrt(audioLoudness.wavesScaling[0 ])), new Duration(TimeSpan.FromMilliseconds(100))));
                //waves_circles.waveRec_1 .BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(Math.Sqrt(Math.Sqrt(audioLoudness.wavesScaling[1 ])), new Duration(TimeSpan.FromMilliseconds(100))));
                //waves_circles.waveRec_2 .BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(Math.Sqrt(Math.Sqrt(audioLoudness.wavesScaling[2 ])), new Duration(TimeSpan.FromMilliseconds(100))));
                //waves_circles.waveRec_3 .BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(Math.Sqrt(Math.Sqrt(audioLoudness.wavesScaling[3 ])), new Duration(TimeSpan.FromMilliseconds(100))));
                //waves_circles.waveRec_4 .BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(Math.Sqrt(Math.Sqrt(audioLoudness.wavesScaling[4 ])), new Duration(TimeSpan.FromMilliseconds(100))));
                //waves_circles.waveRec_5 .BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(Math.Sqrt(Math.Sqrt(audioLoudness.wavesScaling[5 ])), new Duration(TimeSpan.FromMilliseconds(100))));
                //waves_circles.waveRec_6 .BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(Math.Sqrt(Math.Sqrt(audioLoudness.wavesScaling[6 ])), new Duration(TimeSpan.FromMilliseconds(100))));
                //waves_circles.waveRec_7 .BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(Math.Sqrt(Math.Sqrt(audioLoudness.wavesScaling[7 ])), new Duration(TimeSpan.FromMilliseconds(100))));
                //waves_circles.waveRec_8 .BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(Math.Sqrt(Math.Sqrt(audioLoudness.wavesScaling[8 ])), new Duration(TimeSpan.FromMilliseconds(100))));
                wave_c1.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(Math.Sqrt(Math.Sqrt(Math.Sqrt(Math.Sqrt(audioLoudness.wavesScaling[8])))), new Duration(TimeSpan.FromMilliseconds(100))));
                wave_c1.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation(Math.Sqrt(Math.Sqrt(Math.Sqrt(Math.Sqrt(audioLoudness.wavesScaling[8])))), new Duration(TimeSpan.FromMilliseconds(100))));
                wave_c2.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(Math.Sqrt(Math.Sqrt(2*Math.Sqrt(Math.Sqrt(audioLoudness.wavesScaling[12])))), new Duration(TimeSpan.FromMilliseconds(100))));
                wave_c2.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation(Math.Sqrt(Math.Sqrt(2*Math.Sqrt(Math.Sqrt(audioLoudness.wavesScaling[12])))), new Duration(TimeSpan.FromMilliseconds(100))));
                wave_c3.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(Math.Sqrt(2*Math.Sqrt(Math.Sqrt(Math.Sqrt(audioLoudness.wavesScaling[16])))), new Duration(TimeSpan.FromMilliseconds(100))));
                wave_c3.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation(Math.Sqrt(2*Math.Sqrt(Math.Sqrt(Math.Sqrt(audioLoudness.wavesScaling[16])))), new Duration(TimeSpan.FromMilliseconds(100))));

            }
            //            MyAnimation(_runningText.Margin.Top, _runningText.Margin.Top + 0.5 + (_runningText.Margin.Top / 16) * (_runningText.Margin.Top / 16));

            if (isRollNeed)
            {
                if (!isRollWN && _runningText.Margin.Top <= -1 && _runningText.Margin.Top >= -8)
                {
                    isRollNeed = false;
                    MyAnimation(_runningText.Margin.Top, -1);
                }
                else
                {
                    MyAnimation(_runningText.Margin.Top, _runningText.Margin.Top + 2 * (2 + Math.Cos(Math.PI * (-_runningText.Margin.Top - 64) / 64)));
                    if (!isRollNeedWaitsForActivation)
                    {
                        networking.SendMessage("IX");
                    }
                    isRollWN = false;
                }
                isRollNeedWaitsForActivation = true;
            }
            else
            {
                if (!isRollWN)
                {
                    isRollWN = true;
                    Task.Delay(5000).ContinueWith(_ =>
                    {
                        isRollWN = true;
                        isRollNeed = true;
                        isRollNeedWaitsForActivation = false;
                    });
                }
                MyAnimation(_runningText.Margin.Top, -1);
            }
        }

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            proceedRequest(_runningText.Text);
        }

        private void attach_control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("KEK");
            if ((attach_control.DocLabel != 0) || (attach_control.PicLabel != 0) || (attach_control.UrlLabel != 0))
            {
            Debug.WriteLine("LOL");
                NavigationService nav = NavigationService.GetNavigationService(this);
            Debug.WriteLine("ARBIDOL");
                nav.Navigate(new Uri("ListAttachments.xaml", UriKind.RelativeOrAbsolute));
                Debug.WriteLine("KEK");

            }
        }

        private void PressAnswerScrollDown_MouseDown(object sender, MouseButtonEventArgs e)
        {
                networking.SendMessage("AD");
        }

        private void PressAnswerScrollUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
                networking.SendMessage("AU");
        }

        int speechMode = 0;
        static double animationsTimespan = 0.34;
        static double atsp_r = 0.3;
        static double adelay = animationsTimespan / 6;
        int timerid = 0;

        private async void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            speechButtonFillSize.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation()
            {
                From = 1,
                To = 0.9,
                AutoReverse = true,
                DecelerationRatio = 0.7,
                AccelerationRatio = 0.1,
                Duration = TimeSpan.FromSeconds(animationsTimespan),
            });
            speechButtonFillSize.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation()
            {
                From = 1,
                To = 0.9,
                AutoReverse = true,
                DecelerationRatio = 0.7,
                AccelerationRatio = 0.1,
                Duration = TimeSpan.FromSeconds(animationsTimespan),
            });
            speechButtonBorderSize.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation()
            {
                From = 1,
                To = 0.9,
                AutoReverse = true,
                DecelerationRatio = 0.7,
                AccelerationRatio = 0.1,
                Duration = TimeSpan.FromSeconds(animationsTimespan),
            });
            speechButtonBorderSize.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation()
            {
                From = 1,
                To = 0.9,
                AutoReverse = true,
                DecelerationRatio = 0.7,
                AccelerationRatio = 0.1,
                Duration = TimeSpan.FromSeconds(animationsTimespan),
            });
            speechButtonBorder.BeginAnimation(SolidColorBrush.ColorProperty, new ColorAnimation()
            {
                To = Color.FromArgb(120, 255, 255, 255),
                AutoReverse = true,
                DecelerationRatio = 0.7,
                AccelerationRatio = 0.1,
                Duration = TimeSpan.FromSeconds(animationsTimespan),
            });
            switch (speechMode)
            {
                case 0:
                    var networkTask = Task.Factory.StartNew(() => networking.SendMessage("ZZZZZZZZZZZZZZZZZZZZZZZZZZ"));
                   
                    playTTS(" Ъ ");
                    startListening();
                    textBox.Text = "Слушаю...\nНажмите на кнопку снова, чтобы подтвердить запрос";

                    CancelAnim.Width = (GridLength)(new GridLengthConverter()).ConvertFromString("80");
                    
                    speechMode0Rotate.BeginAnimation(RotateTransform.AngleProperty, new DoubleAnimation()
                    {
                        From = 0,
                        To = 135,
                        AccelerationRatio = 0.95, Duration = TimeSpan.FromSeconds(animationsTimespan * (1 + atsp_r)),
                    });
                    speechMode0Scale.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation()
                    {
                        From = 1,
                        To = 0,
                        BeginTime = TimeSpan.FromSeconds(animationsTimespan * atsp_r),
                        AccelerationRatio = 0.95, Duration = TimeSpan.FromSeconds(animationsTimespan),
                    });
                    speechMode0Scale.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation()
                    {
                        From = 1,
                        To = 0,
                        BeginTime = TimeSpan.FromSeconds(animationsTimespan * atsp_r),
                        AccelerationRatio = 0.95, Duration = TimeSpan.FromSeconds(animationsTimespan),
                    });
                    speechMode1Rotate.BeginAnimation(RotateTransform.AngleProperty, new DoubleAnimation()
                    {
                        From = -135,
                        To = 0,
                        BeginTime = TimeSpan.FromSeconds(adelay),
                        DecelerationRatio = 0.95, Duration = TimeSpan.FromSeconds(animationsTimespan * (1 + atsp_r)),
                    });
                    speechMode1Scale.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation()
                    {
                        From = 0,
                        To = 1,
                        BeginTime = TimeSpan.FromSeconds(animationsTimespan * atsp_r + adelay),
                        DecelerationRatio = 0.95, Duration = TimeSpan.FromSeconds(animationsTimespan),
                    });
                    speechMode1Scale.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation()
                    {
                        From = 0,
                        To = 1,
                        BeginTime = TimeSpan.FromSeconds(animationsTimespan * atsp_r + adelay),
                        DecelerationRatio = 0.95, Duration = TimeSpan.FromSeconds(animationsTimespan),
                    });
                    speechMode = 1;
                    int localTimerId = timerid;
                    Task.Delay(23000).ContinueWith(_ =>
                    {
                        if (speechMode == 1 && timerid == localTimerId)
                            speechMode = -2;
                    });
                    await networkTask;
                    break;
                case 1:
                    timerid++;
                    textBox.Text = "Идёт распознавание...";
                    speechMode = -1;

                    CancelAnim.Width = (GridLength)(new GridLengthConverter()).ConvertFromString("0");
                 //   CancelAnim.BeginAnimation(ColumnDefinition.WidthProperty, new GridLengthAnimation()
                 //   {
                 //       To = (GridLength)(new GridLengthConverter()).ConvertFromString("0"),
                 //       AccelerationRatio = 0.5,
                 //       DecelerationRatio = 0.5,
                 //       Duration = TimeSpan.FromSeconds(animationsTimespan),
                 //   });

                    speechMode1Rotate.BeginAnimation(RotateTransform.AngleProperty, new DoubleAnimation()
                    {
                        From = 0,
                        To = 135,
                        AccelerationRatio = 0.95, Duration = TimeSpan.FromSeconds(animationsTimespan * (1 + atsp_r)),
                    });
                    speechMode1Scale.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation()
                    {
                        From = 1,
                        To = 0,
                        BeginTime = TimeSpan.FromSeconds(animationsTimespan * atsp_r),
                        AccelerationRatio = 0.95, Duration = TimeSpan.FromSeconds(animationsTimespan),
                    });
                    speechMode1Scale.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation()
                    {
                        From = 1,
                        To = 0,
                        BeginTime = TimeSpan.FromSeconds(animationsTimespan * atsp_r),
                        AccelerationRatio = 0.95, Duration = TimeSpan.FromSeconds(animationsTimespan),
                    });
                    speechMode2Rotate.BeginAnimation(RotateTransform.AngleProperty, new DoubleAnimation()
                    {
                        From = -135,
                        To = 0,
                        BeginTime = TimeSpan.FromSeconds(adelay),
                        DecelerationRatio = 0.95, Duration = TimeSpan.FromSeconds(animationsTimespan * (1 + atsp_r)),
                    });
                    speechMode2Scale.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation()
                    {
                        From = 0,
                        To = 1,
                        BeginTime = TimeSpan.FromSeconds(animationsTimespan * atsp_r + adelay),
                        DecelerationRatio = 0.95, Duration = TimeSpan.FromSeconds(animationsTimespan),
                    });
                    speechMode2Scale.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation()
                    {
                        From = 0,
                        To = 1,
                        BeginTime = TimeSpan.FromSeconds(animationsTimespan * atsp_r + adelay),
                        DecelerationRatio = 0.95, Duration = TimeSpan.FromSeconds(animationsTimespan),
                    });
                    var slowTask = Task<string>.Factory.StartNew(() => stopListening(true));
                    await slowTask;
                    speechMode2Rotate.BeginAnimation(RotateTransform.AngleProperty, new DoubleAnimation()
                    {
                        From = 0,
                        To = 135,
                        AccelerationRatio = 0.95, Duration = TimeSpan.FromSeconds(animationsTimespan * (1 + atsp_r)),
                    });
                    speechMode2Scale.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation()
                    {
                        From = 1,
                        To = 0,
                        BeginTime = TimeSpan.FromSeconds(animationsTimespan * atsp_r),
                        AccelerationRatio = 0.95, Duration = TimeSpan.FromSeconds(animationsTimespan),
                    });
                    speechMode2Scale.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation()
                    {
                        From = 1,
                        To = 0,
                        BeginTime = TimeSpan.FromSeconds(animationsTimespan * atsp_r),
                        AccelerationRatio = 0.95, Duration = TimeSpan.FromSeconds(animationsTimespan),
                    });
                    speechMode0Rotate.BeginAnimation(RotateTransform.AngleProperty, new DoubleAnimation()
                    {
                        From = -135,
                        To = 0,
                        BeginTime = TimeSpan.FromSeconds(adelay),
                        DecelerationRatio = 0.95, Duration = TimeSpan.FromSeconds(animationsTimespan * (1 + atsp_r)),
                    });
                    speechMode0Scale.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation()
                    {
                        From = 0,
                        To = 1,
                        BeginTime = TimeSpan.FromSeconds(animationsTimespan * atsp_r + adelay),
                        DecelerationRatio = 0.95, Duration = TimeSpan.FromSeconds(animationsTimespan),
                    });
                    speechMode0Scale.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation()
                    {
                        From = 0,
                        To = 1,
                        BeginTime = TimeSpan.FromSeconds(animationsTimespan * atsp_r + adelay),
                        DecelerationRatio = 0.95, Duration = TimeSpan.FromSeconds(animationsTimespan),
                    });
                    textBox.Text = slowTask.Result.ToString();
                    if (!textBox.Text.Equals(""))
                        proceedRequest(textBox.Text, false);
                    speechMode = 0;
                    break;
                case 7:
                    timerid++;
                    speechMode = 0;
                    stopListening(false);

                    CancelAnim.Width = (GridLength)(new GridLengthConverter()).ConvertFromString("0");

                    speechMode1Rotate.BeginAnimation(RotateTransform.AngleProperty, new DoubleAnimation()
                    {
                        From = 0,
                        To = 135,
                        AccelerationRatio = 0.95,
                        Duration = TimeSpan.FromSeconds(animationsTimespan * (1 + atsp_r)),
                    });
                    speechMode1Scale.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation()
                    {
                        From = 1,
                        To = 0,
                        BeginTime = TimeSpan.FromSeconds(animationsTimespan * atsp_r),
                        AccelerationRatio = 0.95,
                        Duration = TimeSpan.FromSeconds(animationsTimespan),
                    });
                    speechMode1Scale.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation()
                    {
                        From = 1,
                        To = 0,
                        BeginTime = TimeSpan.FromSeconds(animationsTimespan * atsp_r),
                        AccelerationRatio = 0.95,
                        Duration = TimeSpan.FromSeconds(animationsTimespan),
                    });
                    speechMode0Rotate.BeginAnimation(RotateTransform.AngleProperty, new DoubleAnimation()
                    {
                        From = -135,
                        To = 0,
                        BeginTime = TimeSpan.FromSeconds(adelay),
                        DecelerationRatio = 0.95,
                        Duration = TimeSpan.FromSeconds(animationsTimespan * (1 + atsp_r)),
                    });
                    speechMode0Scale.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation()
                    {
                        From = 0,
                        To = 1,
                        BeginTime = TimeSpan.FromSeconds(animationsTimespan * atsp_r + adelay),
                        DecelerationRatio = 0.95,
                        Duration = TimeSpan.FromSeconds(animationsTimespan),
                    });
                    speechMode0Scale.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation()
                    {
                        From = 0,
                        To = 1,
                        BeginTime = TimeSpan.FromSeconds(animationsTimespan * atsp_r + adelay),
                        DecelerationRatio = 0.95,
                        Duration = TimeSpan.FromSeconds(animationsTimespan),
                    });
                    break;
                default:
                    break;
            }
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (speechMode == 1)
            {
                speechMode = 7;
                textBox.Text = "";
                Grid_MouseDown(null, null);
            }
        }

        string[] questions = {
            "Что является объектом налогообложения НДС?",
            "Когда организация (индивидуальный предприниматель) выполняет обязанности налогового агента по НДС при приобретении товаров (работ, услуг)?",
            "Какие условия необходимы для принятия к вычету сумм НДС, предъявленных при приобретении товаров (работ, услуг) на территории Российской Федерации, ввозе товаров на территорию Российской Федерации?",
            "Что является моментом определения налоговой базы по НДС при реализации товаров (работ, услуг) на территории Российской Федерации?",
            "Каков порядок учета сумм НДС, предъявленных при приобретении товаров (работ, услуг) для операций, необлагаемых налогом либо не являющихся объектом налогообложения этим налогом?",
            "Какие суммы денежных средств, получаемые налогоплательщиком НДС, могут увеличивать налоговую базу по этому налогу?",
            "Что подлежит казначейскому сопровождению?",
            "Какие виды контроля предполагает расширенное казначейское сопровождение?",
            "Какие нормативные правовые акты регулируют порядок по казначейскому сопровождению?",
            "Что такое казначейский аккредитив?",
            "Чем регламентирован порядок осуществления полномочий по внутреннему государственному финансовому контролю?",
            "На основе какой модели предполагается осуществлять подзаконное правовое регулирование контроля в финансово-бюджетной сфере?",
            "Какова цель деятельности Совета по вопросам внутреннего государственного финансового контроля?",
            "Чем занимается Федеральное казначейство?",
            "В каких случаях проводятся внеплановые контрольные мероприятия?",
            "Какими контрольными (надзорными) полномочиями обладает Федеральное казначейство?",
            "На основании какого нормативного правового акта Федерального казначейства предусмотрено разрешение конфликтных ситуаций в ходе проведения контрольного мероприятия?",
            "Какова структура государственного долга Российской Федерации по типу инструментов?",
            "Какова структура государственного долга Российской Федерации по валюте обязательств?",
            "Какова доля нерезидентов в ОФЗ?",
            "Какова средняя доходность обращающихся ОФЗ?",
            "Каков средний срок до погашения (дюрация) обращающихся ОФЗ?",
            "Какой вид ОФЗ пользуется наибольшим спросом у инвесторов?",
            "Планируется ли завершить работу над новой редакцией Бюджетного кодекса в текущем году и внести ее в Государственную Думу?",
            "Кем устанавливаются порядок и сроки составления проекта федерального бюджета?",
            "Сколько дней отводится Государственной Думе на рассмотрение проекта федерального закона о федеральном бюджете на очередной финансовый год и плановый период?",
            "Какие федеральные государственные органы осуществляют составление проекта федерального бюджета?",
            "Зачем нужен \"трехлетний\" бюджет?",
            "Как долго действует принятый бюджет?",
            "Какие акты входят в состав бюджетного законодательства?",
            "Что такое бюджет?",
            "Что такое бюджетный процесс?",
            "Что входит в бюджетную систему?",
            "Зачем применять казначейское сопровождение?",
            "Какие задачи позволяет решить казначейское сопровождение средств, предоставляемых из бюджета?",
            "В чем заключается эксперимент по осуществлению в 2017 году бюджетного мониторинга инвестиционного объекта, включенного в ФАИП?",
            "Каким образом формируется государственное (муниципальное) задание?",
            "На какой срок утверждается государственное (муниципальное) задание?",
            "Каким образом осуществляется финансовое обеспечение выполнения государственного (муниципального) задания учреждением?",
            "На основании чего рассчитывается объем субсидии на финансовое обеспечение выполнения государственного (муниципального) задания на оказание государственных (муниципальных) услуг?",
            "Необходимо ли использовать при определении объема финансового обеспечения выполнения государственного (муниципального) задания на выполнение работ нормативные затраты на выполнение работ?",
            "Может ли автономное или бюджетное учреждение отказаться от выполнения государственного задания?",
            "Кем определяются условия и порядок формирования государственного (муниципального) задания и порядок финансового обеспечения выполнения этого задания?",
            "Что является объектом налогообложения налогом на прибыль организаций?",
            "Кто платит налог на прибыль организаций?",
            "Что является налоговой базой по налогу на прибыль организаций?",
            "Какой размер ставки по налогу на прибыль организаций?",
            "Когда нужно подавать в налоговый орган налоговую декларацию по налогу на прибыль организаций?",
            "Какими нормативными актами регламентируется уплата страховых взносов в настоящее время?",
            "Что такое страховые взносы?",
            "Зачем уплачивать страховые взносы?",
            "Кто должен платить страховые взносы?",
            "Почему плохо иметь «серую» зарплату?",
            "Зачем уплачивать страховые взносы по дополнительным тарифам?",
            "Какие основные тарифы установлены для плательщиков страховых взносов?",
            "Какие тарифы страховых взносов установлены для малого бизнеса?",
            "Какие тарифы страховых взносов установлены для организаций, осуществляющих деятельность в области информационных технологий?",
            "Когда, зачем и почему страховые взносы передали в налоговые органы?",
            "Какой расчетный/отчетный период по страховым взносам?",
            "Какая категория плательщиков страховых взносов не представляет расчет по страховым взносам в налоговые органы?",
            "Какая компания в целях Налогового кодекса Российской Федерации может быть признана контролируемой иностранной компанией?",
            "Какое лицо признается контролирующим лицом иностранной организации?",
            "В какой срок налогоплательщики обязаны уведомлять налоговые органы о совершенных ими в календарном году контролируемых сделках?",
            "Какие лица признаются взаимозависимыми для целей налогообложения?",
            "Что признается консолидированной группой налогоплательщиков?",
            "Каким образом определяется налоговая база по консолидированной группе налогоплательщиков?",
            "В какой срок осуществляется государственная регистрация юридических лиц и индивидуальных предпринимателей?",
            "В каком виде предоставляются сведения и документы, содержащиеся в Едином государственном реестре юридических лиц и Едином государственном реестре индивидуальных предпринимателей о конкретном юридическом лице или индивидуальном предпринимателе?",
            "Кто является налогоплательщиками единого сельскохозяйственного налога",
            "Какой порядок перехода на уплату ЕСХН",
            "Какой объект налогообложения ЕСХН",
            "Какой налоговый период по ЕСХН",
            "Какая налоговая ставка по ЕСХН",
            "Какой срок установлен для представления налоговой декларации по ЕСХН",
            "Какие налогоплательщики могут перейти на упрощенную систему налогообложения",
            "Какой порядок перехода на УСН",
            "Какой объект налогообложения применяется при УСН",
            "Какой налоговый период при применении УСН",
            "Какие налоговые ставки применяются при УСН",
            "Какой срок представления налоговой декларации при УСН",
            "Какие налогоплательщики могут применять систему налогообложения для отдельных видов деятельности",
            "Порядок перехода на ЕНВД",
            "Какой объект налогообложения по ЕНВД",
            "Какой налоговый период по ЕНВД",
            "Какая налоговая ставка по ЕНВД",
            "Какой срок подачи налоговых деклараций по ЕНВД",
            "Какие налогоплательщики могут применять патентную систему налогообложения",
            "Каким документом удостоверяется право на применение ПСН",
            "Какой порядок получения патента",
            "На какой срок выдается патент",
            "Какой налоговый период при применении ПСН",
            "Какая налоговая ставка применяется при ПСН",
            "Срок уплаты налога при ПСН",
            "Представляется ли налоговая декларация при ПСН",
            "Виды налогов и сборов в Российской Федерации",
            "При каких условиях налог считается установленным?",
            "Что понимается под льготами по налогам и сборам?",
            "Виды налоговых проверок и их цель",
            "Какие решения выносятся по результатам рассмотрения материалов налоговой проверки?",
            "Что является объектом налогообложения у физических лиц?",
            "Какой срок признается налоговым периодом по налогу на доходы физических лиц?",
            "В каком размере предоставляется стандартный налоговый вычет родителям, на обеспечении которых находятся дети?",
            "Необходимо ли подавать налоговую декларацию по форме 3-НДФЛ в случае получения доходов, не подлежащих налогообложению?",
            "Кто признается налоговым резидентом Российской Федерации для целей налогообложения по налогу на доходы физических лиц?",
            "Какие иностранные организации являются налогоплательщиками налога на прибыль организаций на территории Российской Федерации?",
            "Какая деятельность иностранной организации признается приводящей к образованию постоянного представительства иностранной организации в Российской Федерации?",
            "Какие виды доходов иностранной организации, не осуществляющей свою деятельность на территории Российской Федерации через постоянное представительство, подлежат налогообложению в Российской Федерации?",
            "В каком порядке осуществляется налогообложение доходов (прибыли) иностранной организации, являющейся налоговым резидентом иностранного государства, с которым у Российской Федерации заключено соглашение об избежании двойного налогообложения?",
            "Каким образом осуществляется устранение двойного налогообложения доходов российской организации, полученных от источников за пределами Российской Федерации?",
            "Какие ключевые изменения предусматривает новый порядок применения контрольно-кассовой техники?",
            "Как осуществляется регистрация контрольно-кассовой техники в ФНС России?",
            "Что нужно сделать, чтобы зарегистрировать контрольно-кассовую технику на сайте nalog.ru?",
            "Можно ли зарегистрировать контрольно-кассовую технику без применения личного кабинета?",
            "Что такое фискальный накопитель?",
            "Кто такие операторы фискальных данных?",
            "Какие новые требования к данным в чеках?",
            "Где можно ознакомиться с перечнем моделей контрольно-кассовой техники и фискальных накопителей, соответствующих новому порядку?",
            "Где можно получить информацию о том, подлежит ли ваша контрольно-кассовая техника модернизации?",
            "Как заключить договор с оператором фискальных данных?",
            "Какие штрафы предусмотрены за нарушение норм законодательства о контрольно-кассовой технике",
            "Должны ли организации, применяющие упрощенную систему налогообложения или перешедшие на уплату налога на вмененный доход для отдельных видов деятельности, уплачивать налог на имущество организаций?",
            "Облагаются ли налогом на имущество организаций объекты недвижимого имущества, приобретенные в качестве товаров для последующей продажи?",
            "Возникает ли обязанность уплачивать земельный налог, если земельный участок используется на праве безвозмездного срочного пользования?",
            "За какой период налогоплательщику – физическому лицу может быть исчислен транспортный налог?",
            "Может ли организация-арендатор грузового автомобиля уменьшить транспортный налог на сумму платы в счет возмещения вреда, причиняемого автомобильным дорогам общего пользования федерального значения?",
            "Налогообложение транспортных средств налогом на имущество организаций и транспортным налогом нарушает принципы налогообложения, предусмотренных НК РФ, поскольку возникает двойное налогообложение одного объекта, например грузового автомобиля. Так ли это?",
            "Какие федеральные налоги и сборы уплачиваются при пользовании природными ресурсами?",
            "Кто является плательщиком налога на добычу полезных ископаемых?",
            "Какие виды налоговых ставок применяются при исчислении налога на добычу полезных ископаемых?",
            "За какие виды объектов животного мира взимается сбор за пользование объектами животного мира?",
            "Предусмотрены ли налоговые санкции за нерациональное использование водных объектов?",
            "Какие товары признаются подакцизными?",
            "Какой налоговый период в отношении исчисления акцизов?",
            "В каком случае налогоплательщик освобождается от уплаты акциза при реализации произведенных им подакцизных товаров, помещенных под таможенную процедуру экспорта?",
            "Какой срок установлен для предоставления налоговой декларации по акцизам?",
            "Как определяется налоговая база при реализации (передаче) произведенных налогоплательщиком подакцизных товаров?",
            "Каким законом регулируется производство и оборот этилового спирта, алкогольной и спиртосодержащей продукции?",
            "Какие виды алкогольной продукции Вы знаете?",
            "Нужна ли лицензия на производство этилового спирта, алкогольной и спиртосодержащей продукции?",
            "Лицензируется ли розничная продажа алкогольной продукции?",
            "С какого периода Минфин России является органом исполнительной власти, осуществляющим функции по выработке государственной политики и нормативно-правовому регулированию в сфере производства и оборота этилового спирта, алкогольной и спиртосодержащей продукции?",
            "Какой орган осуществляет контроль за производством и оборотом этилового спирта, алкогольной и спиртосодержащей продукции?",
            "В каких субъектах Российской Федерации по итогам 2016 года наблюдался дефицит/профицит по результатам исполнения бюджета?",
            "Какой объем государственного долга субъектов Российской Федерации и какова его динамика?",
            "Структура государственного долга субъектов Российской Федерации?",
            "Количество регионов, получающих дотации на выравнивание бюджетной обеспеченности?",
            "Количество регионов, не получающих дотации на выравнивание бюджетной обеспеченности?",
            "Основные параметры исполнения консолидированных бюджетов субъектов Российской Федерации за 2016 год?",
            "Расходы на госпрограмму «Социально-экономическое развитие Калининградской области до 2020 года»",
            "Расходы на госпрограмму «Социально-экономическое развитие Республики Крым и г. Севастополя на период до 2020 года»",
            "Расходы на госпрограмму «Развитие Северо-Кавказского федерального округа» на период до 2025 года»",
            "Расходы на госпрограмму «Социально-экономическое развитие Дальнего Востока и Байкальского региона»",
            "В каких формах предоставляются межбюджетные трансферты?",
            "Что составляет налоговую базу бюджетов муниципальных образований?",
            "Что составляет налоговую базу бюджетов субъектов Российской Федерации?",
            "Для каких целей создается Резервный фонд Правительства Российской Федерации?",
            "Что включает в себя консолидированный бюджет субъекта Российской Федерации?",
            "Понятие межбюджетных трансфертов?",
            "Как проводится работа по консолидации субсидий, предоставляемых бюджетам субъектов Российской Федерации из федерального бюджета?",
            "Что такое единая субвенция?",
            "Структура доходов консолидированного бюджета РФ администрируемых ФНС России в 2016 году",
            "Динамика поступлений администрируемых ФНС России доходов в консолидированный бюджет Российской Федерации в 2015-2016 гг",
            "Структура доходов консолидированного бюджета РФ администрируемых ФНС России в 2015-2016 гг",
            "Динамика поступлений основных видов налогов администрируемых ФНС России в консолидированный бюджет РФ и в 2015-2016 гг",
            "Динамика поступлений администрируемых ФНС России доходов в федеральный бюджет Российской Федерации в 2015-2016 гг",
            "Структура администрируемых ФНС России доходов федерального бюджета РФ 2016 гг",
            "Динамика поступлений в федеральный бюджет основных видов налогов администрируемых ФНС России в 2015-2016 гг",
            "Динамика поступлений администрируемых ФНС России доходов в консолидированные бюджеты субъектов Российской Федерации в 2015-2016 гг",
            "Структура администрируемых ФНС России доходов консолидированных бюджетов субъектов РФ в 2016 гг",
            "Динамика поступлений основных видов налогов администрируемых ФНС России в консолидированные бюджеты субъектов РФ в 2015-2016 гг",
            "Поступления по налогу на прибыль в 2015-2016 гг",
            "Поступления в федеральный бюджет по налогу на добавленную стоимость в 2015-2016 гг",
            "Поступления по налогу на добычу полезных ископаемых в 2015-2016 гг",
            "Поступление акцизов в консолидированный бюджет Российской Федерации в 2015-2016 гг",
            "Какие имущественные налоги существуют в России в 2015-2016 гг",
            "Поступления налога на доходы физических лиц в 2015-2016 гг",
            "Поступления по специальным налоговым режимам (УСН, ЕНВД, ЕСХН, патентная система) в 2015-2016 гг",
            "Поступления утилизационного сбора в 2015-2016 гг",
            "Кто является плательщиком налога на добавленную стоимость",
            "Какой налоговый период установлен для налога на добавленную стоимость?",
            "В какой срок налогоплательщик обязан представлять декларацию по налогу на добавленную стоимость?",
            "В какие сроки производится уплата налога на добавленную стоимость налогоплательщиком?",
            "В какой валюте должны быть пересчитаны доходы, полученные налогоплательщиком в иностранной валюте, в целях исчисления и уплаты налога на прибыль?",
            "Каков порядок зачисления сумм налога на прибыль в бюджетную систему Российской Федерации с 2017 года?",
            "Кто признается плательщиком акциза?",
            "Что является объектом налогообложения НДПИ?",
            "Кто может применять нулевую ставку по налогу, уплачиваемому в связи с применением УСН?",
            "В какой срок налоговый орган обязан выдать патент?",
            "В каком году обязательный досудебный порядок обжалования решений по налоговым проверкам был закреплен на законодательном уровне?",
            "Каковы преимущества досудебного урегулирования налоговых споров перед судебным разбирательством для налогоплательщика?",
            "Как можно получить информацию о ходе рассмотрения обращения?",
            "Как можно получить информацию о наиболее значимых решениях ФНС России, вынесенных по результатам рассмотрения жалоб?",
            "Что такое трансфертная цена?",
            "Что такое принцип «вытянутой руки»?",
            "Как определяются взаимозависимые лица?",
            "Какие налоги ФНС России вправе проверять в рамках трансфертного ценообразования?",
            "Контролируемые сделки – это?",
            "Какие методы используются при проведении налогового контроля в связи с совершением сделок между взаимозависимыми лицами?",
            "Какой срок представления уведомления о контролируемых сделках?",
            "Какая компания признается контролируемой иностранной компанией?",
            "Какое максимальное время ожидания в очереди при предоставлении государственных услуг ФНС России?",
            "Можно ли записаться на прием в инспекцию ФНС России по сети Интернет?",
            "Какие существуют способы оценки качества предоставления государственных услуг ФНС России?",
            "Какими способами (каналами) и в какой форме граждане, в том числе налогоплательщики, могут обратиться в налоговые органы?",
            "Как обратиться в справочную службу ФНС России?",
            "Как я могу получить всю информацию о деятельности налоговых органов не выходя из дома?",
            "Какие электронные услуги можно получить на сайте налоговой службы?",
            "Как мне обратиться в налоговый орган без личного визита?",
            "Как получить логин и пароль для доступа в интернет-сервис «Личный кабинет налогоплательщика для физических лиц» в налоговом органе?",
            "Чем может быть полезен интернет-сервис «Личный кабинет налогоплательщика для физических лиц»?",
            "Можно ли получить сведения из ЕГРЮЛ/ЕГРИП в онлайн режиме?",
            "Можно ли зарегистрировать ООО или ИП в онлайн режиме?",
            "Как проверить надежность партнёров по бизнесу?",
            "Что делать в том случае, если возникли трудности при работе с электронными сервисами ФНС России?",
            "Как узнать свой ИНН с помощью сайта ФНС России?",
            "Могу ли я через официальный сайт ФНС России записаться на прием в налоговую инспекцию?",
            "Как получить Сертификат ключа квалифицированной электронной подписи?",
            "Как получить усиленную неквалифицированную электронную подпись?",
            "Где я могу использовать усиленную неквалифицированную электронную подпись?",
            "Где в «Личном кабинете налогоплательщика для физических лиц» можно задать кодовое слово для последующего восстановления пароля с помощью электронной почты?",
            "Что делать, если я забыл пароль от сервиса «Личный кабинет налогоплательщика для физических лиц»?",
            "Что делать, если в сервисе «Личный кабинет налогоплательщика для физических лиц» отображаются неверные данные?",
            "Не приходят ответы, направленные в службу технической поддержки",
            "Не пришло налоговое уведомление, что делать?",
            "Неверно начислили налог, что делать?",
            "Где в интернет-сервисе «Личный кабинет налогоплательщика для физических лиц» посмотреть ответы налогового органа на мои обращения?",
            "Почему ответ налогового органа на мой вопрос не пришел на электронную почту?",
            "Я не успел сменить пароль в сервисе «Личный кабинет налогоплательщика для физических лиц» в течение месяца. Что делать?",
            "Можно ли войти в сервис «Личный кабинет налогоплательщика для физических лиц» на сайте ФНС России с использованием учетной записи Единой системы идентификации и аутентификации?",
            "Почему нет моего банка в сервисах, позволяющих оплатить налог?",
            "Как открыть Личный кабинет организации?",
            "Как открыть Личный кабинет индивидуального предпринимателя?",
            "Могу ли я сдать налоговую декларацию через сайт?",
            "Что такое маркировка товаров?",
            "Какие преимущества имеет внедренная системы маркировки?",
            "Что такое контрольный (идентификационный) знак?",
            "Какие технологии записи информации в контрольные знаки используют на сегодняшний день при маркировке товаров?",
            "Основные нормативные правовые акты, регулирующие сферу маркировки в Российской Федерации?",
            "Какие страны ЕАЭС участвуют в реализации Пилотного проекта по маркировке меховых изделий?",
            "Какую роль играют отдельные федеральные органы исполнительной власти в сфере маркировки товаров контрольными знаками?",
            "Какая ответственность предусмотрена за оборот немаркированного товара без соответствующих контрольных знаков?",
            "Что такое Глобальный номер товара (GTIN), используемый при описании товара для его маркировки?",
            "Как проверить легальность мехового изделия при покупке?",
            "Где можно найти более подробную информацию о маркировке товаров?",
            "Что такое новый порядок применения контрольно-кассовой техники?",
            "Каковы основные сроки перехода на новую систему применения ККТ?",
            "Для плательщиков единого налога на вмененный доход предусмотрено временное освобождение от онлайн касс. Можно пользоваться освобождением предпринимателям и организациям, совмещающим два налоговых режима – упрощенную систему и ЕНВД?",
            "Не все кассы, действующие сейчас, смогут передавать данные в ФНС. Где можно посмотреть перечень онлайн ККТ, которые можно будет использовать после 1 февраля 2017? Как начать с ними работать – зарегистрировать в ИФНС или есть какие-то новые правила?",
            "Где брать программное обеспечение для передачи чеков в налоговый орган? Или они уже встроены в ККТ?",
            "С 1 февраля надо отправлять покупателю электронный чек. А можно обойтись без бумажного чека?",
            "Кто будет хранить данные о покупке или оплате услуг в виде электронного чека – налоговая служба или предприниматели? Куда будет обращаться покупатель, в случае если потеряет бумажный чек и захочет его восстановить?",
            "Придется ли покупать новую ККТ? Есть ли возможность модернизировать старый кассовый аппарат?",
            "Судя по закону, кассовый аппарат должен будет иметь постоянную связь с интернетом. А если в магазине произошел сбой сети, то нужно останавливать продажи?",
            "Можно ли будет увидеть введенные с онлайн-ККТ данные в своем личном кабинете?",
            "Что должен делать продавец, если у покупателя нет электронной почты, телефона?",
            "Личный кабинет пользователя ККТ — это новый сервис. Каковы его особенности?",
            "На фискальном накопителе будет храниться вся информация, например, по продажам. Нужны ли тогда будут журналы кассиров-операционистов и другие формы первичных учетных документов?",
            "Что представляет собой система центров обработки данных Минфина России?",
            "Какие федеральные органы власти используют ЦОД, входящие в систему ЦОД Минфина России?",
            "Каким образом обеспечиваются сохранность информации, хранящейся и обрабатываемой в ЦОД, входящих в систему ЦОД Минфина России и гарантируется доступность сервисов, которые представляет АИС налоговых органов?",
            "Какие права имеют граждане Российской Федерации, формирующие накопительную пенсию?",
            "Какие негосударственные пенсионные фонды осуществляют деятельность по обязательному пенсионному страхованию в 2017 году?",
            "Какие управляющие компании осуществляют доверительное управление средствами пенсионных накоплений в 2017 году?",
            "Какова доходность инвестирования средств пенсионных накоплений в негосударственных пенсионных фондах в 2017 году?",
            "Какова доходность инвестирования средств пенсионных накоплений в управляющих компанияхв 2017 году?",
            "В чем заключается цель ОСАГО?",
            "Сколько владельцев транспортных средств заключают договоры ОСАГО?",
            "С какого года в Российской Федерации осуществляется ОСАГО?",
            "Можно ли обратиться в целях получения страхового возмещения к страховщику, застраховавшему гражданскую ответственность потерпевшего?",
            "Можно ли получить страховую выплату по ОСАГО, если гражданская ответственность лица, причинившего вред, не застрахована?",
            "Как производится страховое возмещение в случае причинения вреда транспортному средству потерпевшего в результате ДТП?",
            "Какие предельные сроки осуществления восстановительного ремонта поврежденных транспортных средств по договорам ОСАГО, осуществляемого по направлению страховщиком?",
            "Предусмотрен ли гарантийный срок на работы по восстановительному ремонту поврежденного транспортного средства по договорам ОСАГО?",
            "Можно ли осуществить восстановительный ремонт на станции технического обслуживания, выбранной потерпевшим, но не включенной в перечень станций технического обслуживания, с которыми у страховой организации заключены договоры?",
            "На каких станциях технического обслуживания может осуществляться восстановительный ремонт транспортных средств по договорам ОСАГО?",
            "Может ли страховое возмещение по договору ОСАГО при причинении вреда транспортному средству потерпевшего осуществляться в денежной форме, кроме случаев смерти потерпевшего, полной гибели транспортного средства?",
            "Обязаны ли страховые организации заключать договоры ОСАГО в форме электронного документа?",
            "Какие лотереи проводятся в Российской Федерации?",
            "Какие бывают виды лотереи?",
            "Кто может организовать лотерею?",
            "Какие игры являются азартными?",
            "Где находятся игорные зоны?",
            "Почему установлены ограничения на проведение азартных игр на территории Российской Федерации?",
            "Кем принимаются решения о создании / ликвидации игорных зон?",
            "Какие бывают виды игорных заведений?",
            "Кто может осуществлять производство защищенной от подделок полиграфической продукции?",
            "Каким органом осуществляется лицензирование деятельности по производству и реализации защищенной от подделок полиграфической продукции?",
            "Какая полиграфическая продукция относится к защищенной от подделок?",
            "Какой федеральный орган исполнительной власти уполномочен представлять интересы Российской Федерации в делах о банкротстве?",
            "Куда поступают средства, получаемые от продажи акций, находящихся в федеральной собственности?",
            "Имеет ли Российская Федерация, являющаяся акционером акционерного общества, какие либо преимущества перед другими акционерами при распределении прибыли общества по итогам года?",
            "Для чего может быть создано государственное унитарное предприятие?",
            "На каком сайте в сети Интернет можно ознакомиться с результатами независимой оценки качества оказания услуг организациями социальной сферы?",
            "По каким общим критериям осуществляется независимая оценка качества оказания услуг организациями социальной сферы?",
            "Какой федеральный орган исполнительной власти является уполномоченным федеральным органом исполнительной власти, определяющим состав информации о результатах независимой оценки качества оказания услуг организациями социальной сферы, и порядок ее размещения на официальном сайте для размещения информации о государственных и муниципальных учреждениях - bus.gov.ru?",
            "Основные цели реформы, проводимой в соответствии с Федеральным законом от 08.05.2010 № 83-ФЗ «О внесении изменений в отдельные законодательные акты Российской Федерации в связи с совершенствованием правового положения государственных (муниципальных) учреждений»",
            "Какие существуют типы государственных (муниципальных) учреждений в Российской Федерации?",
            "Кем формируются базовые (отраслевые) перечни государственных и муниципальных услуг и работ?",
            "Кто является участниками бюджетного процесса в Российской Федерации?",
            "Кто является участниками бюджетного процесса в Российской Федерации на федеральном уровне?",
            "На чем основывается составление проектов бюджетов Российской Федерации?",
            "Принципы бюджетной системы Российской Федерации?",
            "Оперативные отчетные данные об исполнении федерального бюджета за 2016 год и текущий период 2017 года",
            "Исполнение основных показателей федерального бюджета и консолидированного бюджета в 2012 – 2016 годах",
            "Объем Резервного фонда в 2011- 2016 годах",
            "Объем Фонда национального благосостояния в 2011- 2016 годах",
            "На какой период осуществляется разработка Бюджетного прогноза Российской Федерации?",
            "Цели разработки бюджетного прогноза Российской Федерации",
            "Какие документы стратегического планирования разрабатываются Минфином России?",
            "Какой объем бюджетных ассигнований предусмотрен на реализацию приоритетных проектов в федеральном бюджете на 2017 год и на плановый период 2018 и 2019 годов?",
            "Что такое таможенное декларирование?",
            "Кем может проводиться таможенное декларирование товаров?",
            "Что представляет собой таможенная процедура свободной таможенной зоны?",
            "Где может применяться таможенная процедура свободной таможенной зоны?",
            "Кто может являться владельцем магазина беспошлинной торговли?",
            "Кто такой таможенный перевозчик?",
            "Каково количество мест международного почтового обмена, являющихся объектами почтовой связи, на территории Российской Федерации?",
            "В каких формах осуществляется таможенная проверка?",
            "Сколько форм таможенного контроля предусмотрено Таможенным кодексом Таможенного союза?",
            "Какие сроки таможенного контроля после выпуска товаров установлены в Российской Федерации?",
            "Как подать в ФТС России жалобу на решение таможенного органа?",
            "Как обжаловать решение таможенного органа в суде?",
            "Как получить консультацию по вопросам таможенного дела?",
            "Что такое таможенное дело?",
            "Какие государства (страны) входят в Евразийский экономический союз?",
            "Когда вступил в силу Таможенный кодекс Таможенного союза?",
            "Сколько государств являются членами Всемирной таможенной организации?",
            "Когда была основана Всемирная таможенная организация?",
            "С какого года ФТС России стала являться подведомственным органом Минфина России?",
            "Сколько действует правовая охрана общеизвестного товарного знака?",
            "В каких случаях должностные лица таможенных органов обязаны приостанавливать перемещение наличных денежных средств и (или) денежных инструментов?",
            "Каким документом регулируются вопросы валютного контроля в Российской Федерации?",
            "Когда возникает обязанность декларирования денежных средств и дорожных чеков при их ввозе физическими лицами на таможенную территорию ЕАЭС?",
            "Требуется ли представление паспорта сделки на бумажном носителе при подаче таможенной декларации?",
            "Кто вправе помещать монеты из драгоценных металлов, являющихся законным платежным средством, под таможенную процедуру экспорта?",
            "Какая ответственность предусмотрена за совершение валютных операций с представлением подложных документов?",
            "Товары, запрещенные к ввозу на таможенную территорию ЕАЭС, прибывшие на таможенную территорию ЕАЭС, подлежат?",
            "Сколько готовой продукции животного происхождения в заводской упаковке без разрешения и без ветеринарного сертификата страны отправления товара могут перемещать в ручной клади для личного пользования физические лица?",
            "Где производится помещение под таможенные процедуры драгоценных камней и драгоценных металлов юридическими лицами?",
            "Когда таможенники отмечают свой профессиональный праздник и почему?",
            "Какие консультативные органы существуют при ФТС России, в состав которых входят участники внешнеэкономической деятельности?",
            "Какова цель деятельности Общественного совета при ФТС России?",
            "Какие основные задачи решаются в рамках заседаний Экспертно-консультативного совета по реализации таможенной политики при ФТС России?",
            "Каковы реквизиты счета, на который подлежат перечислению денежные средства, предназначенные для оплаты таможенных платежей",
            "Каким законодательным актом определен перечень товаров, ввоз которых на территорию Российской Федерации не подлежит обложению налогом на добавленную стоимость?",
            "При соблюдении каких условий при покупке товаров в иностранных интернет-магазинах физические лица будут освобождены от уплаты таможенных пошлин, налогов?",
            "На какой срок иностранец может временно ввезти в Российскую Федерацию легковой автомобиль, зарегистрированный в иностранном государстве, без уплаты таможенных платежей?",
            "Какими способами обеспечивается исполнение обязанности по уплате таможенных пошлин, налогов в Российской Федерации?",
            "В какой форме могут представляться в таможенный орган банковские гарантии в качестве обеспечения исполнения обязанности по уплате таможенных пошлин, налогов?",
            "Как определяется сумма обеспечения исполнения обязанности по уплате таможенных пошлин, налогов при проведении дополнительной проверки сведений о товаре, заявленных в декларации на товары?",
            "Что такое государственная программа?",
            "Зачем нужны государственные программы?",
            "Сколько всего государственных программ утверждено / предусмотрено к утверждению в настоящий момент?",
            "Каким актом утверждаются государственные программы?",
            "На какой срок утверждаются государственные программы?",
            "Какова структура государственных программ?",
            "Где можно ознакомиться с актуальной информацией по исполнению государственных программ?",
            "В каких государственных программах предусмотрены самые большие объемы бюджетных ассигнований?",
            "Используется ли программный формат расходов в других странах?",
            "Каковы основные цели деятельности Минфина России на 5-10 лет?",
            "Сколько всего сотрудников в центральном аппарате Минфина России?",
            "Что включает в себя консолидированный бюджет Российской Федерации?",
            "Для чего предназначены суверенные фонды? Каковы объемы суверенных фондов?",
            "Для чего осуществляется внутренний финансовый контроль в государственном секторе?",
            "С какой целью проводится внутренний финансовый аудит в государственном секторе?",
            "Как узнать о результатах внутреннего финансового аудита конкретного органа власти?",
            "Что такое мониторинг качества финансового менеджмента?",
            "Где найти нормативные правовые акты и методические рекомендации по мониторингу качества финансового менеджмента?",
            "Какой федеральный орган государственной власти по результатам мониторинга качества финансового менеджмента является лучшим по итогам 2015 года и по 2016 года?",
            "Улучшилось ли качество финансового менеджмента в федеральных органах власти за последние 5 лет?",
            "В чем заключается основная цель Руководства по статистике государственных финансов, разработанного Международным валютным фондом?",
            "Что такое сектор государственного управления?",
            "Что такое государственный сектор?",
            "Что такое институциональная единица?",
            "Что такое бюджетное планирование?",
            "Что называют «скользящим бюджетом»?",
            "На чем основывается составление проекта бюджета на очередной финансовый год?",
            "Что такое бюджет для граждан?",
            "Где можно ознакомиться с федеральным бюджетом для граждан?",
            "Какие субъекты Российской Федерации разрабатывают бюджеты для граждан?",
            "Где можно подробнее узнать об уровне открытости бюджетов регионов?",
            "Как оценивается положение России в сфере открытости информации о бюджете на международном уровне?",
            "Что такое инициативное бюджетирование?",
            "Что делается для улучшения понимания гражданами информации о бюджете?",
            "Какими документами регулируется бухгалтерский (бюджетный) учет?",
            "В соответствии с какими инструкциями автономные и бюджетные учреждения составляют отчетность?",
            "В соответствии с какими инструкциями составляется отчетность об исполнении бюджетов бюджетной системы Российской Федерации?",
            "Публичное обсуждение федеральных стандартов бухгалтерского учета для организаций государственного сектора",
            "Какие особенности составления отчетности в 2017 году?",
            "Как используется бюджетная классификация Российской Федерации?",
            "Что в себя включает бюджетная классификация?",
            "Какие нормативные правовые акты регулируют порядок применения бюджетной классификации?",
            "Что такое иммунитет бюджетов бюджетной системы Российской Федерации?",
            "Возможно ли направить исполнительный лист о взыскании денежных средств за счет средств бюджетов бюджетной системы Российской Федерации для исполнения в структурное подразделение Федеральной службы судебных приставов?",
            "Какие судебные акты исполняет Минфин России?",
            "Какие документы необходимо предъявить в Минфин России для исполнения судебного акта?",
            "В какой срок производится исполнение судебного акта Минфином России?",
            "Где размещается в сети Интернет информация о ходе исполнения Минфином России судебного акта?",
            "По какому адресу нужно направлять исполнительные документы в Минфин России?",
            "Расходы федерального бюджета в сфере культуры в динамике",
            "Основные направления расходов федерального бюджета в сфере культуры в текущем финансовом году",
            "Основные статьи доходов бюджета в 2017 году?",
            "Основные статьи расходов бюджета в 2017 году?",
            "Какие регионы являются «донорами», то есть не получающими дотации на выравнивание бюджетной обеспеченности в 2017 году?",
            "Какова была средняя цена на нефть марки Urals в 2016 году?",
            "Какой был средний курс рубля к доллару США в 2016 году?",
            "Из расчета каких цен на нефть составлен федеральный бюджет на 2017 год?",
            "В каких валютах Минфин России выпускает ОФЗ?",
            "Какой процент доходов бюджета составляют нефтегазовые доходы в 2016 году?",
            "Какая сумма доходов от инвестиции средств фонда в 2016 году?",
            "Какова валютная структура средств Резервного фонда?",
            "Какой объединенный документ заменит в 2017 году «Основные направления бюджетной политики»?",
            "Что определяют «бюджетные правила»?",
            "История возникновения Пробирной Палаты",
            "Кто инициировал создание Пробирного надзора?",
            "В чем заключается основная деятельность Пробирной Палаты",
            "Кто сейчас является руководителем Пробирной палатой (его биография)?",
            "Какие пробы в официальном хождении в РФ?",
            "Когда появилось первое единообразное клеймо в России",
            "Как изменялся вид клейма впоследствии?",
            "Что такое именник производителя?",
            "Как определяется проба? Какие существуют способы клеймения ювелирных изделий?",
            "Как определить фальшивое пробирное клеймо?",
            "Когда появилась первая «Инспекция пробирного надзора»?",
            "Каковы функции Инспекций пробирного надзора?",
            "Где можно найти перечень инспекций Пробирной палаты? Сколько их всего в стране?",
            "На сайте Пробирной палаты есть раздел Специальный учет, что это означает?",
            "Можно ли проверить на пробу старинные ювелирные изделия?",
            "Как происходит процедура подачи изделий на клеймение? Какие документы нужны? Какие сроки?",
            "Какие выдаются документы (сертификаты) на опробованные и заклейменные изделия?",
            "Можно ли подавать изделия на клеймение не только в ГИПН того города, где я прописан или зарегистрирована моя организация?",
            "Если я живу не в Москве, куда я должен обратиться по вопросу опробования своих изделий?",
            "Если я нерезидент этой страны мне нужно ставить российскую пробу на свои изделия для реализации их на территории России?",
            "Могу ли я продавать свои изделия на территории другой страны, не ставя российское клеймо?",
            "Можно ли проверить приобретенное ювелирное изделие на соответствие указанной пробы или подлинности клейма?",
            "Какие новшества предполагает новый Таможенный кодекс Евразийского экономического союза?",
            "Какие изменения повлечет вступление в силу Таможенного кодекса Евразийского экономического союза?",
            "С какой целью создается механизм обеспечения прослеживаемости товаров в государствах-членах Евразийского экономического союза?",
            "Предполагается ли создание аналогичного механизма, который будет действовать в Российской Федерации?",
            "Когда предполагается запуск механизма обеспечения прослеживаемости товаров в государствах-членах Евразийского экономического союза"
            };
    }
}
