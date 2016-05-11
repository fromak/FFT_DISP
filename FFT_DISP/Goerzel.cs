using System;

namespace FFT_DISP
{
    class Goerzel
    {

        public Goerzel()
        {

        }
        public float[] Goerzel_normal(float[] AdcSamples, Goerzel_params Params)
        {
            //Расчет шага спектра
            float SpectrStep = (float)Params.SampleRate / (float)Params.NumOfPoints;
            //Расчет начальной гармоники
            int StartHarmonic = (int)(Params.StartFreq / SpectrStep);
            //Расчет конечной гармоники
            int StopHarmonic = (int)(Params.StopFreq / SpectrStep);
            float[] Harmonics = new float[StopHarmonic - StartHarmonic];
            for (int i = 0; i < StopHarmonic - StartHarmonic; i++)
            {
                //Параметр альфа
                float alpha = (float)(2 * Math.Cos((float)(2 * Math.PI * (float)(StartHarmonic + i) / (float)Params.NumOfPoints)));
                //Поворотный коэфициент реальной части
                float wrs = (float)(Math.Cos((float)(2 * Math.PI * (float)(StartHarmonic + i) / (float)Params.NumOfPoints)));
                //Поворотный коэфициент мнимой части
                float wis = (float)(Math.Sin((float)(2 * Math.PI * (float)(StartHarmonic + i) / (float)Params.NumOfPoints)));
                float v0 = AdcSamples[0];
                float v1 = v0 + alpha * AdcSamples[1];
                float v2;
                //Расчитываем гармонику
                for (int j = 2; j < Params.NumOfPoints; j++)
                {
                    //v[i] = s[i] + a * v[i - 1] - v[i - 2];
                    v2 = AdcSamples[j] + alpha * v1 - v0;
                    v0 = v1;
                    v1 = v2;
                }
               //Считаем что получилось
                Harmonics[i] = (((v1 * wrs) - v0) + (v1 * wis));
            }
            //Возвращаем результат
            return Harmonics;
        }
        /// <summary>
        /// модифицированный герцель для одной частоты, выкидывает набор расчетов
        /// </summary>
        /// <param name="AdcSamples">Массив семпов</param>
        /// <param name="param">Параметры расчета, размер окна, частота поиска и.т.д.</param>
        /// <returns></returns>
        public float[] GOERZEL_MOD(float[] AdcSamples, Goerzel_params param)
        {
            float[] Module = new float[param.Length];
            float delta, A, B, C, Bz1, Cz1;
            //Поворотные коэфициенты
            float Ak1000 = (float)Math.Cos(((2 * Math.PI * param.freq) / param.SampleRate));
            float Bk1000 = (float)Math.Sin(((2 * Math.PI * param.freq) / param.SampleRate));
            Bz1 = 0;
            Cz1 = 0;
            for (int i = 0; i < param.Length - param.Window; i++)
            {
                ///Расчет предыдущего
                delta = i < param.Window ? AdcSamples[i] : (AdcSamples[i] - AdcSamples[i - param.Window]);
                //alpha cos((2*PI*f0)/Fs)
                //beta sin((2*PI*f0)/Fs)
                //Расчет
                ///Ключевые точки
                A = delta + Bz1;
                B = (A * Ak1000) - (Cz1 * Bk1000);
                C = (A * Bk1000) + (Cz1 * Ak1000);
                ///Результат
                Module[i] = (B * B) + (C * C); // (float)Math.Sqrt((B * B) + (C * C));
                //Сохранение предыдущего расчета, для сладеующего расчета.
                Bz1 = B;
                Cz1 = C;

            }
            return Module;
        }

    }
    /// <summary>
    /// Параметры поиска по Герцелю
    /// </summary>
    class Goerzel_params
    {
        /// <summary>
        /// Шаг окна для модифицированного алгоритма, он же N
        /// </summary>
        public int Window
        {
            get;
            set;
        }
        /// <summary>
        /// Частота семплирования
        /// </summary>
        public int SampleRate
        {
            get;
            set;
        }
        /// <summary>
        /// Частота поиска
        /// </summary>
        public int freq
        {
            get;
            set;
        }
        /// <summary>
        /// для теста как далеко бегать по массиву
        /// </summary>
        public int Length
        {
            get;
            set;
        }
        /// <summary>
        /// Для полного Алгоритма Герцеля НАЧАЛЬНАЯ частота
        /// </summary>
        public float StartFreq
        {
            get;
            set;
        }
        /// <summary>
        /// Для полного Алгоритма Герцеля КОНЕЧНАЯ частота
        /// </summary>
        public float StopFreq
        {
            get;
            set;
        }
        /// <summary>
        /// Количество точек Расчета для алгоритма Герцеля. Чем больше точек, тем больше разрядность алгоритма.
        /// </summary>
        public int NumOfPoints
        {
            get;
            set;
        }
    }
}
