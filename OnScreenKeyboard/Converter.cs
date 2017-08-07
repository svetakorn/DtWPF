using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Fourier
{
    public class Converter
    {
        double _xCenter = 0;
        double _yCenter = 0;
        private double _maxScaledX = 0;
        private double _maxScaledY = 0;

        public double MaxScaledY
        {
            get
            {
                return _maxScaledY;
            }
            set
            {
                _maxScaledY = value;
            }
        }

        public Converter(double xCenter, double yCenter, double maxScaledX, double maxScaledY)
        {
            _xCenter = xCenter;
            _yCenter = yCenter;
            _maxScaledX = maxScaledX;
            _maxScaledY = maxScaledY;
        }

        public void FromReal(double x, double y, out int sx, out int sy)
        {
            sx = 0;
            sy = 0;
            sx = (int)(x * _maxScaledX + _xCenter);
            sy = (int)(-y * _maxScaledY + _yCenter);
        }


    }
}
