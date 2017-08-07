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
    /// Логика взаимодействия для ListImage.xaml
    /// </summary>
    public partial class ListImage : Page
    {
        private static string[] imgNames;
        private static string[] img;

        public ListImage()
        {
            InitializeComponent();

            TextBlock[] myLabel = new TextBlock[imgNames.Length];
            Image[] myImage = new Image[imgNames.Length];
            for (int i = 0; i < imgNames.Length; i++)
            {
                myLabel[i] = new TextBlock();
                myImage[i] = new Image();
                if (i != 0)
                {
                    myLabel[i - 1].Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                    double newMargin = (double)myLabel[i - 1].DesiredSize.Height + 96;
                    myLabel[i].Margin = new Thickness(8, newMargin, 0, 0);
                    myImage[i].Margin = new Thickness(60, newMargin + (double)myLabel[i].DesiredSize.Height, 0, 0);
                    myImage[i].HorizontalAlignment = HorizontalAlignment.Left;
                    myImage[i].Source = new BitmapImage(new Uri(@"C:\xampp\htdocs\docs\img\" + img[i]));
                }
                else
                {
                    myLabel[i].Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                    myLabel[i].Margin = new Thickness(8, 100, 0, 0);
                    myImage[i].Margin = new Thickness(60, 100 + (double)myLabel[i].DesiredSize.Height + 10, 0, 0);
                    myImage[i].HorizontalAlignment = HorizontalAlignment.Left;
                    myImage[i].VerticalAlignment = VerticalAlignment.Top;
                    myImage[i].Source = new BitmapImage(new Uri(@"C:\xampp\htdocs\docs\img\" + img[i]));
                }
                if (imgNames[i].Length > 48)
                    myLabel[i].Text = imgNames[i].Substring(0, 48) + "..."; 
                else
                    myLabel[i].Text = imgNames[i];
                myLabel[i].TextWrapping = TextWrapping.Wrap;
                myLabel[i].MaxWidth = 558;
                myLabel[i].Foreground = Brushes.White;
                myImage[i].Height = 200;

                grid1.Children.Add(myLabel[i]);
                grid1.Children.Add(myImage[i]);
                myLabel[i].Tag = i;
                myImage[i].Tag = i;
                myLabel[i].MouseDown += new MouseButtonEventHandler(label_MouseDown);
                myImage[i].MouseDown += new MouseButtonEventHandler(img_MouseDown);
            }
        }

        public static void SendImgs(JArray im)
        {
            img = im.ToObject<string[]>();
        }

        public static void SendImgNames(JArray img)
        {
            imgNames = img.ToObject<string[]>();
        }

        private void label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("ShowImage.xaml", UriKind.RelativeOrAbsolute));
            TextBlock control = (TextBlock)sender;
            ShowImage.SendNum((int)control.Tag);
        }

        private void img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("ShowImage.xaml", UriKind.RelativeOrAbsolute));
            Image control = (Image)sender;
            ShowImage.SendNum((int)control.Tag);
        }

        private void backBut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
