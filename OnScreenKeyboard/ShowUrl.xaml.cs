using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp;
using CefSharp.Wpf;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json.Linq;
using Datatron.Networking;

namespace OnScreenKeyboard
{
    /// <summary>
    /// Логика взаимодействия для ShowUrl.xaml
    /// </summary>
    public partial class ShowUrl : Page
    {
        NetworkingSingleton networking = NetworkingSingleton.getInstance();

        static string path;
        static string caption;

        public static void SendUrl(string url)
        {
            path = url;
        }

        public static void SendCaption(string capt)
        {
            caption = capt;
        }

        public ShowUrl()
        {
            InitializeComponent();
            browser.Address = path;
            url_name.Text = caption;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            networking.SendMessage("^X");
            NavigationService.GoBack();
        }
    }
}
