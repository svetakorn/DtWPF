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
        
        private void num1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            num1.Source = new BitmapImage(new Uri("Images/num1pr.png", UriKind.Relative));
        }

        private void num2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            num2.Source = new BitmapImage(new Uri("Images/num2pr.png", UriKind.Relative));
        }

        private void num1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            num1.Source = new BitmapImage(new Uri("Images/num1.png", UriKind.Relative));
        }

        private void num2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            num2.Source = new BitmapImage(new Uri("Images/num2.png", UriKind.Relative));
        }
    }
}
