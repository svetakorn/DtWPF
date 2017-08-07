using System;
using System.Collections.Generic;
using System.Text;

namespace FFT.External
{
    public class ComplexNumber
    {
        public double R;
        public double I;

        public ComplexNumber(double real, double img)
        {
            R = real;
            I = img;
        }

        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.R * b.R - a.I * b.I, a.R * b.I + a.I * b.R);
        }
        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.R + b.R, a.I + b.I);
        }
        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.R - b.R, a.I - b.I);
        }

        public static ComplexNumber FromPolar(double length, double angle)
        {
            return new ComplexNumber(length * Math.Cos(angle), length * Math.Sin(angle));
        }
        public double Manigtude
        {
            get
            {
                return Math.Sqrt(Math.Pow(R, 2) + Math.Pow(I, 2));
            }
        }
    }
}
