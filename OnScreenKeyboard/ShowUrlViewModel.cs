using CefSharp.Wpf;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboard
{

    public class ShowUrlViewModel
    {
        public string Title { get; set; }
        public string Address { get; set; }

        private static int urlNum;
        public static string[] url;

        public static void SendNum(int i)
        {
            urlNum = i;
        }

        public static void SendUrls(List<string> d)
        {
            url = d.ToArray();
        }


        public IWpfWebBrowser WebBrowser { get; set; }

        public ShowUrlViewModel()
        {
            Address = url[urlNum];
        }
    }
}
