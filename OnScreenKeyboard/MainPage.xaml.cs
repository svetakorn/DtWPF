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
        }


        #region UNITY_NETWORKING

        string[] recordedAnswers = {
            "2.1",
            "2.2",
            "2.3",
            "2.4",
            "4.1",
            "4.2",
            "4.3",
            "4.4",
            "4.5",
            "4.6",
            "4.7",
            "4.8",
            "4.9",
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
            "4.20",
            "4.21",
            "4.22",
            "4.23",
            "4.26",
            "4.27",
            "4.28",
            "4.29",
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
            "7.2",
            "7.3",
            "7.4",
            "7.5",
            "7.6",
            "7.7",
            "7.8",
            "7.9",
            "7.10",
            "7.11",
            "7.12",
            "8.1",
            "8.2",
            "8.3",
            "8.4",
            "8.5",
            "8.6",
            "8.7",
            "8.8",
            "8.9",
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
            "8.20",
            "8.21",
            "8.22",
            "9.1",
            "9.2",
            "9.3",
            "9.4",
            "9.5",
            "9.6",
            "10.1",
            "10.2",
            "10.3",
            "10.4",
            "10.5",
            "10.6",
            "11.1",
            "11.2",
            "11.3",
            "11.4",
            "11.5",
            "11.6",
            "11.7",
            "11.8",
            "11.9",
            "11.10",
            "11.11",
            "12.1",
            "12.2",
            "12.3",
            "12.4",
            "12.5",
            "12.6",
            "13.1",
            "13.2",
            "13.3",
            "13.4",
            "13.5",
            "13.6",
            "13.7",
            "13.8",
            "13.9",
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
            "13.20",
            "14.1",
            "14.2",
            "14.3",
            "14.4",
            "14.5",
            "16.1",
            "16.2",
            "16.3",
            "16.4",
            "16.5",
            "16.6",
            "16.7",
            "16.8",
            "17.1",
            "17.2",
            "17.3",
            "17.4",
            "17.5",
            "17.6",
            "17.7",
            "17.8",
            "17.9",
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
            "17.20",
            "17.21",
            "17.22",
            "17.23",
            "17.24",
            "17.25",
            "17.26",
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
            "18.1",
            "20.1",
            "20.2",
            "20.3",
            "20.4",
            "20.5",
            "21.1",
            "21.2",
            "21.3",
            "21.4",
            "21.5",
            "21.6",
            "21.7",
            "21.8",
            "21.9",
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
            "21.30",
            "21.31",
            "21.32",
            "21.33",
            "22.1",
            "22.3",
            "22.4",
            "22.5",
            "22.6",
            "22.7",
            "22.8",
            "22.9",
            "22.10",
            "22.11",
            "22.12",
            "22.13",
            "22.14",
            "22.15",
            "22.16",
            "22.17",
            "22.18",
            "23.1",
            "23.2",
            "23.3",
            "23.4",
            "23.5",
            "23.6",
            "23.7",
            "23.8",
            "23.9",
            "23.10",
            "23.11",
            "23.12",
            "23.13",
            "23.14",
            "23.15",
            "23.16",
            "23.17",
            "23.18",
            "23.19",
            "23.20",
            "23.21",
            "23.22",
            "23.23",
            "23.24",
            "23.25",
            "23.27",
            "23.28",
            "23.29",
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
            "23.100",
            "23.101",
            "24.1",
            "24.2",
            "24.3",
            "24.4",
            "24.5",
            "25.1",
            "25.2",
            "25.3",
            "25.4",
            "25.5",
            "25.6",
            "25.7",
            "25.8",
            "25.9",
            "25.10",
            "25.11",
            "25.12",
            "26.1",
            "26.2",
            "26.3",
            "26.4",
            "26.5",
            "26.6",
            "26.7",
            "26.8",
            "26.9",
            "26.10",
            "26.11",
            "27.1",
            "27.2",
            "27.3",
            "27.4",
            "28.1",
            "28.2",
            "28.3",
            "28.4",
            "28.5",
            "28.6",
            "30.1",
            "30.2",
            "30.3",
            "30.4",
            "30.5",
            "30.6",
            "30.7",
            "30.8",
            "30.9",
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
            "30.40"
        };

        NetworkingSingleton networking = NetworkingSingleton.getInstance();
        SendAudioData audioLoudness = new SendAudioData();


        private void Num2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            onScreenKeyboard.Text = seeMoreQ2;
            textBox.Text = seeMoreQ2;

            search_MouseDown(null, null);
        }

        private void Num1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            onScreenKeyboard.Text = seeMoreQ1;
            textBox.Text = seeMoreQ1;

            search_MouseDown(null, null);
        }

        private string RemoveEndingBrackets(string rawLine) { Debug.WriteLine("raw: " + rawLine); return rawLine.Substring(1, rawLine.Length - 2); }

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
                return System.Text.RegularExpressions.Regex.Unescape(sLine);
            }
            catch { textBox.Text = "NO INTERNET CONNECTION"; }

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
        string seeMoreQ1 = "", seeMoreQ2 = "";

        void proceedRequest(string requestString, bool needClean = true)
        {
            string APIRESPONCE = GetAPIanswer(requestString);

            Debug.WriteLine("RESPONCE: " + APIRESPONCE);
            dynamic responce;
            try
            {
                responce = JsonConvert.DeserializeObject(APIRESPONCE);


                try
                {
                    string user_query = "NOOOPE", formatted_responce = "NOOOPE", type = "none";
                    int docsCount = 0, picsCount = 0, urlsCount = 0;
                    int vn1 = 0, vn2 = 1;

                    try
                    {
                        type = responce["answer"]["type"].ToString();
                        if (type.Equals("minfin"))
                        {

                            string vns = ((string)(responce["answer"]["number"]));
                            vn1 = int.Parse(vns.Substring(0, vns.IndexOf('.')));
                            vn2 = int.Parse(vns.Substring(vns.IndexOf('.') + 1));

                            //seeMore.Visibility = Visibility.Visible; attach_control.Visibility = Visibility.Visible;
                            seeMore.Opacity = 1; attach_control.Opacity = 1;
                            user_query = responce["answer"]["question"];
                            formatted_responce = responce["answer"]["full_answer"];

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

                            if (!recordedAnswers.Contains(vns))
                            {
                                try
                                {
                                    speechKit.Program.text_to_speech((string)responce["answer"]["short_answer"]);
                                    SoundPlayer sp = new SoundPlayer();
                                    sp.SoundLocation = "speechGenerated.wav";
                                    sp.Load();
                                    Task.Delay(1500).ContinueWith(_ =>
                                    {
                                        sp.Play();
                                    });
                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine(ex);
                                    //MessageBox.Show("Голосовая запись ответа по кубу не создана");
                                }
                            }

                        }
                        if (type.Equals("cube"))
                        {
                            vn2 = 0;

                            //                        seeMore.Visibility = Visibility.Visible; attach_control.Visibility = Visibility.Hidden;
                            seeMore.Opacity = 1; attach_control.Opacity = 0.3;
                            user_query = responce["answer"]["feedback"]["user_request"];
                            try
                            {
                                speechKit.Program.text_to_speech((string)responce["answer"]["formatted_response"]);
                                SoundPlayer sp = new SoundPlayer();
                                sp.SoundLocation = "speechGenerated.wav";
                                sp.Load();
                                Task.Delay(1500).ContinueWith(_ =>
                                {
                                    sp.Play();
                                });
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex);
                                //MessageBox.Show("Голосовая запись ответа по кубу не создана");
                            }

                            formatted_responce = "Datatron понял ваш вопрос как: \n" + (string)responce["answer"]["feedback"]["verbal"]["domain"];
                            foreach (var item in responce["answer"]["feedback"]["verbal"]["dims"])
                            { formatted_responce += " | " + ((string)item["member_caption"]); }
                            formatted_responce += "\n\nОтвет: " + (string)responce["answer"]["formatted_response"];
                            formatted_responce += "\nАктуальность ответа: 03.08.2017";


                        }
                        if (formatted_responce == null)
                        {
                            formatted_responce = "Не найден ответ";
                        }

                    }
                    catch { formatted_responce = "Не найден ответ"; }

                    string[] seeMoreQuestions = new string[2];

                    try
                    {
                        
                        JArray[] seeMoreQuestionsArrays = new JArray[2];
                        int[] seeIndex = { 0, 0 };
                        try { seeMoreQuestionsArrays[0] = responce["more_cube_answers"]; } catch { }
                        try { seeMoreQuestionsArrays[1] = responce["more_minfin_answers"]; } catch { }
                        string order = responce["more_answers_order"];

                        for (int i = 0; i < seeMoreQuestions.Length; i++)
                        {
                            try
                            {
                                seeMoreQuestions[i] = (string)seeMoreQuestionsArrays[int.Parse(order.Substring(i, 1))][seeIndex[0]]["feedback"]["verbal"]["domain"];
                                foreach (var item in seeMoreQuestionsArrays[int.Parse(order.Substring(i, 1))][seeIndex[0]]["feedback"]["verbal"]["dims"])
                                { seeMoreQuestions[i] += " | " + ((string)item["member_caption"]); }
                                seeIndex[0]++;
                            }
                            catch { seeMoreQuestions[i] = (string)seeMoreQuestionsArrays[int.Parse(order.Substring(i, 1))][seeIndex[1]]["question"]; seeIndex[1]++; }
                        }
                        seeMoreQ1 = seeMoreQuestions[0];
                        seeMoreQ2 = seeMoreQuestions[1];

                        if (seeMoreQ1 == "") seeMore.num1.Opacity = 0.3;
                        if (seeMoreQ2 == "") seeMore.num2.Opacity = 0.3;
                    }
                    catch { }


                    if (networking.client.Connected)
                    {
                        networking.SendQuestion(user_query, formatted_responce, seeMoreQuestions[0], seeMoreQuestions[1], docsCount, picsCount, urlsCount, vn1.ToString(), vn2.ToString());
                        if (needClean)
                        {
                            onScreenKeyboard.Text = "";
                            textBox.Text = "";
                        }

                    }
                    else
                    {
                        try
                        {
                            networking.Reconnect();
                            networking.SendQuestion(user_query, formatted_responce, seeMoreQuestions[0], seeMoreQuestions[1], docsCount, picsCount, urlsCount);
                        }
                        catch
                        {
                            onScreenKeyboard.Text = "";
                            textBox.Text = "NO UNITY CONNECTED 1";
                        }
                    }
                }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }
            catch (Exception ex) { MessageBox.Show("JSON плагин упал. Это баг в плагине. Уже ищем другой."); }


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
            writer.Close();

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
                waveIn.Dispose();
                waveIn = null;
                writer.Close();
                writer = null;
            }
        }

        private void image_MouseDown(object sender, MouseButtonEventArgs e)
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
                waveIn.WaveFormat = new WaveFormat(8000, 2);
                //Инициализируем объект WaveFileWriter
                writer = new WaveFileWriter(outputFilename, waveIn.WaveFormat);
                //Начало записи
                waveIn.StartRecording();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }


            image.Visibility = Visibility.Hidden;
            image2.Visibility = Visibility.Visible;
        }

        private void image2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (waveIn != null)
            {
                StopRecording();
            }
            image2.Visibility = Visibility.Hidden;
            image.Visibility = Visibility.Visible;

            string voicetext = "";
            voicetext = speechKit.Program.speech_to_text(outputFilename);
            if (!voicetext.Equals("Извините, я не понимаю, попробуйте повторить запрос"))
            {
                textBox.Text = voicetext;
                proceedRequest(textBox.Text, false);
            }
            else
            {
                Debug.WriteLine("TTS START");
                speechKit.Program.text_to_speech("Извините, я не понимаю, попробуйте повторить запрос");
                Debug.WriteLine("TTS STOP");
                SoundPlayer sp = new SoundPlayer();
                sp.SoundLocation = "speechGenerated.wav";
                sp.Load();
                sp.Play();
                Debug.WriteLine("PLAY STOP");
            }
        }

        #endregion

        DoubleAnimation animation;
        ColorAnimation animation2;
        //double speed = 2;

        private void Page_Loaded()
        {
            // Центрируем строку в канвасе
            Canvas.SetBottom(_runningText, (canvas.ActualHeight - _runningText.ActualHeight) / 2);

            animation = new DoubleAnimation();
            animation2 = new ColorAnimation();
            animation.Duration = TimeSpan.FromSeconds(0.05);
            animation2.Duration = TimeSpan.FromSeconds(0.05);

            // При завершении анимации, запускаем функцию MyAnimation снова
            // (указано в обработчике)
            animation.Completed += myanim_Completed;

            MyAnimation(Canvas.GetTop(_runningText), Canvas.GetTop(_runningText));
        }

        bool isRollNeed = true;
        int qIndex = 0;

        private void MyAnimation(double from, double to)
        {
            // Если строка вышла за пределы канваса (отриц. Canvas.Left)
            // то возвращаем с другой стороны
            if (Canvas.GetTop(_runningText) >= 40)
            {
                qIndex = (qIndex + 1) % questions.Length;
                _runningText.Text = "\n" + questions[qIndex];
                animation.From = -40;
                animation.To = -40;
                _runningText.BeginAnimation(Canvas.TopProperty, animation);

                networking.tmr.Enabled = false;
                Task.Delay(150).ContinueWith(_ =>
                {
                    networking.SendMessage("I" + questions[qIndex]);
                });
                Task.Delay(300).ContinueWith(_ =>
                {
                    networking.tmr.Enabled = true;
                });
            }
            else
            {
                //  Debug.WriteLine(Canvas.GetTop(_runningText));
                //   if (Canvas.GetTop(_runningText) <= -1 && Canvas.GetTop(_runningText) >= -6)
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
                animation.From = from;
                animation.To = to;
                animation2.From = Color.FromArgb((byte)(int)(255 * (1 - Math.Min(Math.Abs(from / 24), 1))), 0xFF, 0xFF, 0xFF);
                animation2.To = Color.FromArgb((byte)(int)(255 * (1 - Math.Min(Math.Abs(to / 24), 1))), 0xFF, 0xFF, 0xFF);
                _runningText.BeginAnimation(Canvas.TopProperty, animation);
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

        private void myanim_Completed(object sender, EventArgs e)
        {
            //            MyAnimation(Canvas.GetTop(_runningText), Canvas.GetTop(_runningText) + 0.5 + (Canvas.GetTop(_runningText) / 16) * (Canvas.GetTop(_runningText) / 16));

            if (isRollNeed)
            {
                if (!isRollNeedActivated && Canvas.GetTop(_runningText) <= -1 && Canvas.GetTop(_runningText) >= -3)
                {
                    isRollNeed = false;
                    MyAnimation(Canvas.GetTop(_runningText), -1);
                }
                else
                {
                    MyAnimation(Canvas.GetTop(_runningText), Canvas.GetTop(_runningText) + 2 * (2 + Math.Cos(Math.PI * (-Canvas.GetTop(_runningText) - 64) / 64)));
                    if (isRollNeedActivated)
                    {
                        networking.tmr.Enabled = false;
                        Task.Delay(150).ContinueWith(_ =>
                        {
                            networking.SendMessage("IX");
                        });
                        Task.Delay(300).ContinueWith(_ =>
                        {
                            networking.tmr.Enabled = true;
                        });
                        isRollNeedActivated = false;
                    }
                }
                isRollNeedWaitsForActivation = false;
            }
            else
            {
                if (!isRollNeedWaitsForActivation)
                {
                    isRollNeedWaitsForActivation = true;
                    Task.Delay(5000).ContinueWith(_ =>
                    {
                        isRollNeedActivated = true;
                        isRollNeed = true;
                    });
                }
                MyAnimation(Canvas.GetTop(_runningText), 0);
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
            networking.tmr.Enabled = false;
            Task.Delay(150).ContinueWith(_ =>
            {
                networking.SendMessage("AD");
            });
            Task.Delay(300).ContinueWith(_ =>
            {
                networking.tmr.Enabled = true;
            });
        }

        private void PressAnswerScrollUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            networking.tmr.Enabled = false;
            Task.Delay(150).ContinueWith(_ =>
            {
                networking.SendMessage("AU");
            });
            Task.Delay(300).ContinueWith(_ =>
            {
                networking.tmr.Enabled = true;
            });
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
