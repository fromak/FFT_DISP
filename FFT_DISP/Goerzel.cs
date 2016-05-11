using System;

namespace FFT_DISP
{
    class Goerzel
    {

        public Goerzel()
        {

        }
        public void Goerzel_normal(float[] AdcSamples)
        {

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
            float Ak1000 = (float)Math.Cos(((2 * Math.PI * param.freq) / param.SampleRate)  );
            float Bk1000 = (float)Math.Sin(((2 * Math.PI * param.freq) / param.SampleRate) );
            Bz1 = 0;
            Cz1 = 0;
            for (int i = 0; i < param.Length-param.Window; i++)
            {
                ///Расчет предыдущего
                delta = i < param.Window ? AdcSamples[i] : (AdcSamples[i] - AdcSamples[i-param.Window]);
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

    }
}
