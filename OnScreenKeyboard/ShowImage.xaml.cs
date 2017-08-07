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
    /// Логика взаимодействия для ShowImage.xaml
    /// </summary>
    public partial class ShowImage : Page
    {
        NetworkingSingleton networking = NetworkingSingleton.getInstance();

        private static int imgNum;
        private static string[] img;

        public static void SendNum(int i)
        {
            imgNum = i;
        }

        public static void SendImgs(JArray d)
        {
            img = d.ToObject<string[]>();
        }

        public ShowImage()
        {
            InitializeComponent();

            BitmapImage imgFile = new BitmapImage();
            imgFile.BeginInit();
            imgFile.UriSource = new Uri(@"C:\xampp\htdocs\docs\img\" + img[imgNum]);
            imgFile.EndInit();

            image.Source = imgFile;

            networking.tmr.Enabled = false;
            Task.Delay(150).ContinueWith(_ =>
            {
                networking.SendMessage("^I" + "/docs/img/" + img[imgNum]);
            });
            Task.Delay(300).ContinueWith(_ =>
            {
                networking.tmr.Enabled = true;
            });
        }

        private void backBut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
            networking.tmr.Enabled = false;
            Task.Delay(150).ContinueWith(_ =>
            {
                networking.SendMessage("^X");
            });
            Task.Delay(300).ContinueWith(_ =>
            {
                networking.tmr.Enabled = true;
            });
        }
    
    }
}
