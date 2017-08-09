using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboard
{
    public class AttachClass
    {
        public string caption;
        public string path;
        public string type;
        
        public AttachClass (string caption_in, string path_in, string type_in)
        {
            this.caption = caption_in;
            this.path = path_in;
            this.type = type_in;
        }
    }
}
