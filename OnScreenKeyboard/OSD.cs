using System;
using System.Collections.Generic;
using System.Text;

namespace Fourier
{
    class OSD
    {
        public delegate void DrawFunc(params object[]pars);
        DrawFunc drawSomething;

        //public OSD()
        //{
        //    drawSomething = delegate(object t) { };
        //}

        public Dictionary<string, string> Info
        {
            get;
            set;
        }
        bool locked = false;
        public void AddSet(string label, string value)
        {
            if (!locked)
            {
                locked = true;
                if (Info == null)
                {
                    Info = new Dictionary<string, string>();
                }
                if (!Info.ContainsKey(label))
                    Info.Add(label, value);
                else
                    Info[label] = value;
                locked = false;
            }
        }

        public void Draw(params object[]pars)
        {
            if (drawSomething == null)
            {
                throw new Exception("Drawing not implemented");
            }
            else
            {
                if (!locked)
                {
                    locked = true;
                    drawSomething(pars);
                    locked  = false;                    
                }               
            }
        }

        public void ImplementDrawAction(DrawFunc func)
        {
            drawSomething = func;
        }
        
    }
}
