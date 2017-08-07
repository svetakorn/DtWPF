using System.Windows;
using TermControls.Commands;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System;

namespace OnScreenKeyboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame.NavigationService.Navigate(new Uri("WaitingMode.xaml", UriKind.Relative));
            microphone.Source = new BitmapImage(new Uri(@"C:\Users\mvideo\Desktop\Новая папка\WPF-Keyboard-Control-master\WPF-Keyboard-Control-master\OnScreenKeyboard\microphone.png"));
            docs.Source = new BitmapImage(new Uri(@"C:\Users\mvideo\Desktop\Новая папка\WPF-Keyboard-Control-master\WPF-Keyboard-Control-master\OnScreenKeyboard\file.png"));
            pics.Source = new BitmapImage(new Uri(@"C:\Users\mvideo\Desktop\Новая папка\WPF-Keyboard-Control-master\WPF-Keyboard-Control-master\OnScreenKeyboard\picture.png"));
            www.Source = new BitmapImage(new Uri(@"C:\Users\mvideo\Desktop\Новая папка\WPF-Keyboard-Control-master\WPF-Keyboard-Control-master\OnScreenKeyboard\www.png"));
            one.Source = new BitmapImage(new Uri(@"C:\Users\mvideo\Desktop\Новая папка\WPF-Keyboard-Control-master\WPF-Keyboard-Control-master\OnScreenKeyboard\1.png"));
            two.Source = new BitmapImage(new Uri(@"C:\Users\mvideo\Desktop\Новая папка\WPF-Keyboard-Control-master\WPF-Keyboard-Control-master\OnScreenKeyboard\2.png"));
            three.Source = new BitmapImage(new Uri(@"C:\Users\mvideo\Desktop\Новая папка\WPF-Keyboard-Control-master\WPF-Keyboard-Control-master\OnScreenKeyboard\3.png"));
            four.Source = new BitmapImage(new Uri(@"C:\Users\mvideo\Desktop\Новая папка\WPF-Keyboard-Control-master\WPF-Keyboard-Control-master\OnScreenKeyboard\4.png"));
        }

        public ICommand ButtonClickCommand
        {
            get { return new DelegateCommand(ButtonClick); }
        }


        private void ButtonClick(object param)
        {
            System.Windows.MessageBox.Show("EnterClick!");
        }

        private void docs_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window pdf = new Window();
            pdf.Show();
        }
    }
}
