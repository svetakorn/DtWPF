using Datatron.Networking;
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
        NetworkingSingleton networking = NetworkingSingleton.getInstance();
        static AttachClass[] attachments;
        public ListAttachments()
        {
           InitializeComponent();
            dynamic[] elements = new dynamic[8];
            List<int> used_slots = new List<int>();
            int current_slot = 0;

            for (int i = 0; i < attachments.Length; i++)
            {
                if (attachments[i].type.Equals("image"))
                {
                    while (used_slots.Contains(current_slot))
                    {
                        current_slot++;
                    }
                    elements[i] = new AttachImageElement();
                    elements[i].Margin = new Thickness(16);
                    elements[i].caption.Text = attachments[i].caption;
                    grid1.Children.Add(elements[i]);
                    elements[i].SetValue(Grid.RowProperty, current_slot/2);
                    elements[i].SetValue(Grid.ColumnProperty, current_slot%2);
                    elements[i].SetValue(Grid.RowSpanProperty, 2);
                    elements[i].image.SetValue(Image.SourceProperty, BitmapFrame.Create(new Uri(@"C:\xampp\htdocs\docs\img\"+attachments[i].path)));
                    used_slots.Add(current_slot);
                    used_slots.Add(current_slot+2);
                    elements[i].Tag = i;

                    if ((i == attachments.Length - 1)&&(current_slot % 2 == 1))
                        foreach (dynamic element in elements)
                            element.SetValue(Grid.ColumnProperty, 1 - element.GetValue(Grid.ColumnProperty));

                    elements[i].MouseDown += new MouseButtonEventHandler(imageElement_MouseDown);
                }
                else
                {
                    while (used_slots.Contains(current_slot))
                    {
                        current_slot++;
                    }
                    elements[i] = new AttachElement();
                    elements[i].Margin = new Thickness(16);
                    elements[i].caption.Text = attachments[i].caption;
                    used_slots.Add(current_slot);
                    elements[i].SetValue(Grid.RowProperty, i);
                    elements[i].SetValue(Grid.RowProperty, current_slot / 2);
                    elements[i].SetValue(Grid.ColumnProperty, current_slot % 2);
                    grid1.Children.Add(elements[i]);
                    elements[i].Tag = i;
                    switch (attachments[i].type)
                    {
                        case "document":
                            {
                                elements[i].icon.Source = BitmapFrame.Create(new Uri("pack://application:,,,/doc_only_icon.png"));
                                elements[i].MouseDown += new MouseButtonEventHandler(docElement_MouseDown);
                                break;
                            }
                        case "url":
                            {
                                elements[i].icon.Source = BitmapFrame.Create(new Uri("pack://application:,,,/url_only_icon.png"));
                                elements[i].MouseDown += new MouseButtonEventHandler(urlElement_MouseDown);
                                break;
                            }
                    }
                }

                //elements[i][i].MouseDown += new MouseButtonEventHandler(label_MouseDown);
            }
        }


        public static void SendAttachInfo(List<AttachClass> attachs)
        {
            attachments = attachs.ToArray();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void imageElement_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("ShowImage.xaml", UriKind.RelativeOrAbsolute));
            AttachImageElement control = (AttachImageElement)sender;
            ShowDocument.SendNum((int)control.Tag);

            ShowImage.SendImage(attachments[(int)control.Tag].path);
            ShowImage.SendCaption(attachments[(int)control.Tag].caption);
        }

        private void docElement_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("ShowDocument.xaml", UriKind.RelativeOrAbsolute));
            AttachElement control = (AttachElement)sender;
            ShowDocument.SendNum((int)control.Tag);
        }

        private void urlElement_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("ShowUrl.xaml", UriKind.RelativeOrAbsolute));
            AttachElement control = (AttachElement)sender;


            ShowUrl.SendUrl(attachments[(int)control.Tag].path);
            ShowUrl.SendCaption(attachments[(int)control.Tag].caption);

            networking.tmr.Enabled = false;
            string qwerty = "^U" + attachments[(int)control.Tag].path;
            Task.Delay(150).ContinueWith(_ =>
            {
                networking.SendMessage(qwerty);
            });
            Task.Delay(300).ContinueWith(_ =>
            {
                networking.tmr.Enabled = true;
            });
            
        }
    }
}
