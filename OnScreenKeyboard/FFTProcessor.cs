using System;
using System.Collections.Generic;
using System.Text;

namespace FFT.External
{
    public class FFTProcessor
    {
        public static ComplexNumber[] FFT(ComplexNumber[] data)
        {
            int N = data.Length;
            ComplexNumber[] X = new ComplexNumber[N];
            ComplexNumber[] e, E, d, D;
            if (N == 1)
            {
                X[0] = data[0];
                return X;
            }

            int k = 0;
            e = new ComplexNumber[N / 2];
            d = new ComplexNumber[N / 2];
            for (k = 0; k < N / 2; k++)
            {
                e[k] = data[k * 2];
                d[k] = data[k * 2 + 1];
            }
            E = FFT(e);
            D = FFT(d);

            for (k = 0; k < N / 2; k++)
            {
                D[k] *= ComplexNumber.FromPolar(1, -2 * Math.PI * k / N);
            }

            for (k = 0; k < N / 2; k++)
            {
                X[k] = E[k] + D[k];
                X[k + N / 2] = E[k] - D[k];
            }
            return X;
        }
    }
}
