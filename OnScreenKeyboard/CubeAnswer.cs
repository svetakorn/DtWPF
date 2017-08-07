using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datatron.Classes
{
    class CubeAnswer
    {
        public class Dim
        {
            public string dim { get; set; }
            public string val { get; set; }
        }

        public class Formal
        {
            public List<Dim> dims { get; set; }
            public string cube { get; set; }
            public string measure { get; set; }
        }

        public class Dim2
        {
            public string full_value { get; set; }
            public string dimension { get; set; }
        }

        public class Verbal
        {
            public List<Dim2> dims { get; set; }
            public string domain { get; set; }
            public string measure { get; set; }
        }

        public class Feedback
        {
            public Formal formal { get; set; }
            public Verbal verbal { get; set; }
            public string user_request { get; set; }
        }
        
        public string message { get; set; }
        public Feedback feedback { get; set; }
        public string formatted_response { get; set; }
        public string type { get; set; }
        public long response { get; set; }
        
    }
}
