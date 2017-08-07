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

namespace OnScreenKeyboard
{
    /// <summary>
    /// Логика взаимодействия для SeeMore.xaml
    /// </summary>
    public partial class SeeMore : UserControl
    {
        public SeeMore()
        {
            InitializeComponent();

        }

        bool pressed_num1 = false;
        bool pressed_num2 = false;
        bool pressed_num3 = false;
        bool pressed_num4 = false;

        private void num1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!pressed_num1)
            {
                num1.Source = new BitmapImage(new Uri("Images/num1pr.png", UriKind.Relative));
                num2.Source = new BitmapImage(new Uri("Images/num2.png", UriKind.Relative));
                num3.Source = new BitmapImage(new Uri("Images/num3.png", UriKind.Relative));
                num4.Source = new BitmapImage(new Uri("Images/num4.png", UriKind.Relative));
                pressed_num1 = true;
                pressed_num2 = false;
                pressed_num3 = false;
                pressed_num4 = false;
            }
            else
            {
                num1.Source = new BitmapImage(new Uri("Images/num1.png", UriKind.Relative));
                pressed_num1 = false;
            }
        }

        private void num2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!pressed_num2)
            {
                num2.Source = new BitmapImage(new Uri("Images/num2pr.png", UriKind.Relative));
                num1.Source = new BitmapImage(new Uri("Images/num1.png", UriKind.Relative));
                num3.Source = new BitmapImage(new Uri("Images/num3.png", UriKind.Relative));
                num4.Source = new BitmapImage(new Uri("Images/num4.png", UriKind.Relative));
                pressed_num2 = true;
                pressed_num1 = false;
                pressed_num3 = false;
                pressed_num4 = false;
            }
            else
            {
                num2.Source = new BitmapImage(new Uri("Images/num2.png", UriKind.Relative));
                pressed_num2 = false;
            }
        }

        private void num3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!pressed_num3)
            {
                num3.Source = new BitmapImage(new Uri("Images/num3pr.png", UriKind.Relative));
                num2.Source = new BitmapImage(new Uri("Images/num2.png", UriKind.Relative));
                num1.Source = new BitmapImage(new Uri("Images/num1.png", UriKind.Relative));
                num4.Source = new BitmapImage(new Uri("Images/num4.png", UriKind.Relative));
                pressed_num3 = true;
                pressed_num2 = false;
                pressed_num1 = false;
                pressed_num4 = false;
            }
            else
            {
                num3.Source = new BitmapImage(new Uri("Images/num3.png", UriKind.Relative));
                pressed_num3 = false;
            }
        }

        private void num4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!pressed_num4)
            {
                num4.Source = new BitmapImage(new Uri("Images/num4pr.png", UriKind.Relative));
                num2.Source = new BitmapImage(new Uri("Images/num2.png", UriKind.Relative));
                num3.Source = new BitmapImage(new Uri("Images/num3.png", UriKind.Relative));
                num1.Source = new BitmapImage(new Uri("Images/num1.png", UriKind.Relative));
                pressed_num4 = true;
                pressed_num2 = false;
                pressed_num3 = false;
                pressed_num1 = false;
            }
            else
            {
                num4.Source = new BitmapImage(new Uri("Images/num4.png", UriKind.Relative));
                pressed_num4 = false;
            }
        }
    }
}
