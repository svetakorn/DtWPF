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
    /// Логика взаимодействия для ListAttachments.xaml
    /// </summary>
    public partial class ListAttachments : Page
    {

        static AttachClass[] attachments;
        public ListAttachments()
        {
           InitializeComponent();
            for (int i = 0; i < attachments.Length; i++)
            {
                if (attachments[i].type.Equals("image"))
                {
                    AttachImageElement myLabel = new AttachImageElement();
                    myLabel.Margin = new Thickness(16);
                    myLabel.caption.Content = attachments[i].caption;
                    myLabel.SetValue(Grid.RowProperty, i);
                    grid1.Children.Add(myLabel);
                    myLabel.Tag = i;

                }
                else
                {
                    AttachElement myLabel = new AttachElement();
                    myLabel.Margin = new Thickness(16);
                    myLabel.caption.Content = attachments[i].caption;
                    myLabel.SetValue(Grid.RowProperty, i);
                    grid1.Children.Add(myLabel);
                    myLabel.Tag = i;
                    switch (attachments[i].type)
                    {
                        case "document":myLabel.icon.Source = BitmapFrame.Create(new Uri("pack://application:,,,/doc_only_icon.png"));break;
                        case "url":     myLabel.icon.Source = BitmapFrame.Create(new Uri("pack://application:,,,/url_only_icon.png"));break;
                    }
                }

                //myLabel[i].MouseDown += new MouseButtonEventHandler(label_MouseDown);
            }
        }


        public static void SendAttachInfo(List<AttachClass> attachs)
        {
            attachments = attachs.ToArray();
        }
    }
}
