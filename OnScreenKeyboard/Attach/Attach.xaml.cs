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
    /// Логика взаимодействия для Attach.xaml
    /// </summary>
    public partial class Attach : UserControl
    {
        Random ran = new Random();

        private int docLabel = 0;
        private int picLabel = 0;
        private int urlLabel = 0;

        public void SetDocCount(int count)
        {
            docLabel = count;
            doc_label.Content = docLabel;
        }
        public void SetPicCount(int count)
        {
            picLabel = count;
            pic_label.Content = picLabel;
        }
        public void SetUrlCount(int count)
        {
            urlLabel = count;
            url_label.Content = urlLabel;
        }

        public int DocLabel
        {
            get { return docLabel; }
            set { docLabel = value; }
        }
        public int PicLabel
        {
            get { return picLabel; }
            set { picLabel = value; }
        }
        public int UrlLabel
        {
            get { return urlLabel; }
            set { urlLabel = value; }
        }


        public Attach()
        {
            InitializeComponent();
            UpdateCounts();
        }

        public void UpdateCounts ()
        {
            doc_label.Content = docLabel;
            pic_label.Content = picLabel;
            url_label.Content = urlLabel;
        }
        
   //     private void doc_rec_MouseDown(object sender, MouseButtonEventArgs e)
   //     {
   //         if (docLabel != 0)
   //         {
   //             NavigationService nav = NavigationService.GetNavigationService(this);
   //             nav.Navigate(new Uri("ListDocument.xaml", UriKind.RelativeOrAbsolute));
   //         }
   //     }
   //
   //     
   //     private void pic_rec_MouseDown(object sender, MouseButtonEventArgs e)
   //     {
   //         if (picLabel != 0)
   //         {
   //             NavigationService nav = NavigationService.GetNavigationService(this);
   //             nav.Navigate(new Uri("ListImage.xaml", UriKind.RelativeOrAbsolute));
   //
   //         }
   //     }
   //
   //     private void url_rec_MouseDown(object sender, MouseButtonEventArgs e)
   //     {
   //         if (urlLabel != 0)
   //         {
   //             NavigationService nav = NavigationService.GetNavigationService(this);
   //             nav.Navigate(new Uri("ListUrl.xaml", UriKind.RelativeOrAbsolute));
   //         }
   //     }
    }
}
