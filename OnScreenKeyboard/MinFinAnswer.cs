using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Datatron.Classes
{
    class MinFinAnswer
    {
        public string type { get; set; }
        public string message { get; set; }
        public string number { get; set; }
        public string question { get; set; }
        public string short_answer { get; set; }
        public string full_answer { get; set; }

        public List<string> picture { get; set; }
        public List<string> picture_caption { get; set; }

        public List<string> document { get; set; }
        public List<string> document_caption { get; set; }

        public List<string> link { get; set; }
        public List<string> link_name { get; set; }
        
    }
}
