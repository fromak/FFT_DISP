using System;
using System.Numerics;

namespace FFT_DISP
{
    class FFT
    {
        /// <summary>
        /// Вычисление поворачивающего модуля e^(-i*2*PI*k/N)
        /// </summary>
        /// <param name="k"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        private static Complex w(int k, int N)
        {
            if (k % N == 0) return 1;
            double arg = -2 * Math.PI * k / N;
            return new Complex(Math.Cos(arg), Math.Sin(arg));
        }
        /// <summary>
        /// Возвращает спектр сигнала
        /// </summary>
        /// <param name="x">Массив значений сигнала. Количество значений должно быть степенью 2</param>
        /// <returns>Массив со значениями спектра сигнала</returns>
        public Complex[] fftSharp(Complex[] x)
        {
            Complex[] X;
            int N = x.Length;
            if (N == 2)
            {
                X = new Complex[2];
                X[0] = x[0] + x[1];
                X[1] = x[0] - x[1];
            }
            else
            {
                Complex[] x_even = new Complex[N / 2];
                Complex[] x_odd = new Complex[N / 2];
                for (int i = 0; i < N / 2; i++)
                {
                    x_even[i] = x[2 * i];
                    x_odd[i] = x[2 * i + 1];
                }
                Complex[] X_even = fftSharp(x_even);
                Complex[] X_odd = fftSharp(x_odd);
                X = new Complex[N];
                for (int i = 0; i < N / 2; i++)
                {
                    X[i] = X_even[i] + w(i, N) * X_odd[i];
                    X[i + N / 2] = X_even[i] - w(i, N) * X_odd[i];
                }
            }
            return X;
        }
        //_________________________________________________________________________________________
        //_________________________________________________________________________________________
        //
        // NAME:          FFT.
        // PURPOSE:       Быстрое преобразование Фурье: Комплексный сигнал в комплексный спектр и обратно.
        //                В случае действительного сигнала в мнимую часть (Idat) записываются нули.
        //                Количество отсчетов - кратно 2**К - т.е. 2, 4, 8, 16, ... (см. комментарии ниже).
        //                
        //              
        // PARAMETERS:  
        //
        //    float *Rdat    [in, out] - Real part of Input and Output Data (Signal or Spectrum)
        //    float *Idat    [in, out] - Imaginary part of Input and Output Data (Signal or Spectrum)
        //    int    N       [in]      - Input and Output Data length (Number of samples in arrays)
        //    int    LogN    [in]      - Logarithm2(N)
        // RETURN VALUE:  false on parameter error, true on success.
        //_________________________________________________________________________________________
        //
        // NOTE: In this algorithm N and LogN can be only:
        //       N    = 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384;
        //       LogN = 2, 3,  4,  5,  6,   7,   8,   9,   10,   11,   12,   13,    14;
        //_________________________________________________________________________________________
        //_________________________________________________________________________________________
        readonly float[] Rcoef =
        {
                -1.0000000000000000F,  0.0000000000000000F,  0.7071067811865475F,
                0.9238795325112867F,  0.9807852804032304F,  0.9951847266721969F,
                0.9987954562051724F,  0.9996988186962042F,  0.9999247018391445F,
                0.9999811752826011F,  0.9999952938095761F,  0.9999988234517018F,
                0.9999997058628822F,  0.9999999264657178F
        };
        readonly float[] Icoef =
        {
            0.0000000000000000F, -1.0000000000000000F, -0.7071067811865474F,
            -0.3826834323650897F, -0.1950903220161282F, -0.0980171403295606F,
            -0.0490676743274180F, -0.0245412285229122F, -0.0122715382857199F,
            -0.0061358846491544F, -0.0030679567629659F, -0.0015339801862847F,
            -0.0007669903187427F, -0.0003834951875714F
        };

        public bool FFT_Transform(float[] Rdat, int N)
        {

            int LogN = (int)Math.Log(N, 2);
            int i, j, n, k, io, ie, inn, nn;
            float ru, iu, rtp, rtq, rw, iw, sr;

            nn = N >> 1;
            ie = N;
            for (n = 1; n <= LogN; n++)
            {
                rw = Rcoef[LogN - n];
                iw = Icoef[LogN - n];

                inn = ie >> 1;
                ru = 1.0F;
                iu = 0.0F;
                for (j = 0; j < inn; j++)
                {
                    for (i = j; i < N; i += ie)
                    {
                        io = i + inn;
                        rtp = Rdat[i] + Rdat[io];
                        //itp = Idat[i] + Idat[io];
                        rtq = Rdat[i] - Rdat[io];
                        //itq = Idat[i] - Idat[io];
                        Rdat[io] = rtq * ru - 0;
                        //Idat[io] = itq * ru + rtq * iu;
                        Rdat[i] = rtp;
                        // Idat[i] = itp;
                    }

                    sr = ru;
                    ru = ru * rw - iu * iw;
                    iu = iu * rw + sr * iw;
                }

                ie >>= 1;
            }

            for (j = i = 1; i < N; i++)
            {
                if (i < j)
                {
                    io = i - 1;
                    inn = j - 1;
                    rtp = Rdat[inn];
                    // itp      = Idat[inn];
                    Rdat[inn] = Rdat[io];
                    // Idat[inn] = Idat[io];
                    Rdat[io] = rtp;
                    // Idat[io] = itp;
                }

                k = nn;

                while (k < j)
                {
                    j = j - k;
                    k >>= 1;
                }

                j = j + k;
            }

           
            return true;
        }

    }
}
