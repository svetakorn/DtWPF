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
using System.Timers;
using Datatron.Networking;
using System.Diagnostics;
using MoonPdfLib;
using System.IO;
using MoonPdfLib.MuPdf;

namespace OnScreenKeyboard
{
    /// <summary>
    /// Логика взаимодействия для ShowDocument.xaml
    /// </summary>
    public partial class ShowDocument : Page
    {
        NetworkingSingleton networking = NetworkingSingleton.getInstance();
        private static int docNum;
        private static string[] docs;
        private int pastPage;
        static AttachClass[] attachments;

        public static void SendNum(int i)
        {
            docNum = i;
        }

        public static void SendAttachInfo(List<AttachClass> attachs)
        {
            attachments = attachs.ToArray();
        }

        public static void SendDocs(List<string> d)
        {
            docs = d.ToArray();
        }

        public ShowDocument()
        {
            InitializeComponent();



            //MessageBox.Show(docs[docNum]);
            /*
            pdfViewer1.LoadDocument(@"C:\Users\mvideo\Desktop\docs\doc\" + docs[docNum]);
            pdfViewer1.ShowPageSeparator = false;
            pdfViewer1.ScrollToPage(-2);
            pdfViewer1.ShowCurrentPageHighlight = false;

            pdfViewer1.CurrentPageChanged += PdfViewer1_CurrentPageChanged;
            */

            //byte[] bytes = File.ReadAllBytes(@"C:\Users\mvideo\Desktop\docs\doc\" + docs[docNum]);
            //var source = new MemorySource(bytes);

            pdfViewer.VerticalContentAlignment = VerticalAlignment.Center;
            pdfViewer.HorizontalContentAlignment = HorizontalAlignment.Center;

            doc_name.Content = attachments[docNum].caption;

            pdfViewer.OpenFile("C:/xampp/htdocs/docs/doc/" + attachments[docNum].path);
            //MessageBox.Show(pdfViewer.TotalPages.ToString());
          
            pdfViewer.PageRowDisplay = PageRowDisplayType.ContinuousPageRows;

            

            networking.tmr.Enabled = false;
            Task.Delay(150).ContinueWith(_ =>
            {
                networking.SendMessage("^D"+"/docs/doc/" + attachments[docNum].path);
            });
            Task.Delay(300).ContinueWith(_ =>
            {
                networking.SendMessage("^t1");
            });
            Task.Delay(450).ContinueWith(_ =>
            {
                networking.tmr.Enabled = true;
            });

        }

        private void prevBut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void nextBut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            networking.SendMessage("^X");
            NavigationService.GoBack();
        }

        private void pdfViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (pdfViewer.IsLoaded)
            {
                if (pdfViewer.GetCurrentPageNumber() != pastPage)
                {
                    pastPage = pdfViewer.GetCurrentPageNumber();
                    networking.SendMessage("^t" + pastPage.ToString());
                }
            }
            
        }
    }
}
