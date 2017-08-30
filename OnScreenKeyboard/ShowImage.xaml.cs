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

        static string path;
        static string caption;

        public static void SendImage(string url)
        {
            path = url;
        }

        public static void SendCaption(string capt)
        {
            caption = capt;
        }

        public ShowImage()
        {
            InitializeComponent();

            pic_name.Text = caption;

            BitmapImage imgFile = new BitmapImage();
            imgFile.BeginInit();
            imgFile.UriSource = new Uri(@"C:\xampp\htdocs\docs\img\" + path);
            imgFile.EndInit();

            image.Source = imgFile;

            networking.SendMessage("^N" + caption);
                networking.SendMessage("^I" + "/docs/img/" + path);
            
            pic_name.Text = caption;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            networking.SendMessage("^X");
            NavigationService.GoBack();
        }
    
    }
}
