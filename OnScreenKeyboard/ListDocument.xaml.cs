using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnScreenKeyboard
{
    /// <summary>
    /// Логика взаимодействия для ListDocument.xaml
    /// </summary>
    public partial class ListDocument : Page
    {
        private static string[] docNames;

        public ListDocument()
        {
            InitializeComponent();
            /*
            string[] arr = { "Постановление Правительства Российской Федерации от 31.09.2015 года № 914 «О бюджетном прогнозе Российской Федерации на долгосрочный период»",
                "Постановление Правительства Российской Федерации от 31 августа 2015 года № 914 «О бюджетном прогнозе Российской Федерации на долгосрочный период»; Постановление Правительства Российской Федерации от 15 апреля 2014 года № 320 «Государственная программа Российской Федерации «Управление государственными финансовыми рисками и регулирование финансовых рынков»; Постановление Правительства Российской Федерации от 18 мая 2016 г. № 445 «Об утверждении государственной программы Российской Федерации «Развитие федеративных отношений и создание условий для эффективного и ответственного управления региональными и муниципальными финансами»",
                "Распределение бюджетных ассигнований по приоритетным проектам и программам"};
                */
            TextBlock[] myLabel = new TextBlock[docNames.Length];
            for (int i = 0; i < docNames.Length; i++)
            {
                myLabel[i] = new TextBlock();
                if (i != 0)
                {
                    myLabel[i - 1].Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                    double newMargin = (double)myLabel[i - 1].DesiredSize.Height + 16;
                    myLabel[i].Margin = new Thickness(8, newMargin, 0, 0);
                }
                else myLabel[i].Margin = new Thickness(8, 100, 0, 0);

                myLabel[i].Text = docNames[i];
                myLabel[i].TextWrapping = TextWrapping.Wrap;
                myLabel[i].MaxWidth = 558;
                myLabel[i].Foreground = Brushes.White;
                grid1.Children.Add(myLabel[i]);
                myLabel[i].Tag = i;
                myLabel[i].MouseDown += new MouseButtonEventHandler(label_MouseDown);
            }
        }

        public static void SendDocNames(List<string> docs)
        {
            docNames = docs.ToArray();
        }

        private void label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("ShowDocument.xaml", UriKind.RelativeOrAbsolute));
            TextBlock control = (TextBlock)sender;
            ShowDocument.SendNum((int)control.Tag);
        }

        private void backBut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
