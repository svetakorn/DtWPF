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
using Datatron.Networking;

namespace OnScreenKeyboard
{
    /// <summary>
    /// Логика взаимодействия для ListUrl.xaml
    /// </summary>
    public partial class ListUrl : Page
    {
        NetworkingSingleton networking = NetworkingSingleton.getInstance();

        private static string[] urlNames;

        public ListUrl()
        {
            InitializeComponent();

            TextBlock[] myLabel = new TextBlock[urlNames.Length];
            for (int i = 0; i < urlNames.Length; i++)
            {
                myLabel[i] = new TextBlock();
                if (i != 0)
                {
                    myLabel[i - 1].Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                    double newMargin = (double)myLabel[i - 1].DesiredSize.Height + 16;
                    myLabel[i].Margin = new Thickness(8, newMargin, 0, 0);
                }
                else myLabel[i].Margin = new Thickness(8, 100, 0, 0);

                myLabel[i].Text = urlNames[i];
                myLabel[i].TextWrapping = TextWrapping.Wrap;
                myLabel[i].MaxWidth = 558;
                myLabel[i].Foreground = Brushes.White;
                grid1.Children.Add(myLabel[i]);
                myLabel[i].Tag = i;
                myLabel[i].MouseDown += new MouseButtonEventHandler(label_MouseDown);
            }
        }

        public static void SendUrlNames(JArray docs)
        {
            urlNames = docs.ToObject<string[]>();
        }

        private void label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("ShowUrl.xaml", UriKind.RelativeOrAbsolute));
            TextBlock control = (TextBlock)sender;

            //ShowUrlViewModel.SendNum((int)control.Tag);
            string queryURL = ShowUrlViewModel.url[(int)control.Tag];

            networking.tmr.Enabled = false;
            Task.Delay(150).ContinueWith(_ =>
            {
                networking.SendMessage("^U" + queryURL);
            });
            Task.Delay(300).ContinueWith(_ =>
            {
                networking.tmr.Enabled = true;
            });
            Task.Delay(9000).ContinueWith(_ =>
            {
                networking.SendMessage("^X");
            });
        }

        private void backBut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
