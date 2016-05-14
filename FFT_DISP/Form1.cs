using System;
using System.IO;
using System.Numerics;
using System.Windows.Forms;
/// <summary>
/// Disclaimer! My English not so very well 
/// </summary>
namespace FFT_DISP
{
    public partial class Form1 : Form
    {
        ViewerConfig Config;
        FFTConfig ConversionConfiguration;
        Goerzel_params GoerParam;
        public Form1()
        {
            InitializeComponent();
            Config = new ViewerConfig();
            ConversionConfiguration = new FFTConfig();
            GoerParam = new Goerzel_params();
            if (Config.ConfigHasConfiguration)
            {
                tbFile.Text = Config.FilesPath;
                rbBinary.Checked = true;
                cbBinLength.SelectedItem = cbBinLength.Items[1];
                ConversionConfiguration.FFTType = FFTConfig.FFTFileState.Binary;
                tbStartPoint.Text = "0";
                numFFT.Value = 1024;
                ConversionConfiguration.SampleRate = Convert.ToInt32(tbSampleRate.Text);
                ConversionConfiguration.ADCStep = CalcADCStep();
                if (CheckConversionParam(false))
                    HowManyPoints();
            }
        }
        /// <summary>
        /// Проверяем как у нас со стартовыми параметрами
        /// </summary>
        /// <param name="ConvCheck">Флаг, что проверка перед преобразованием</param>
        /// <returns>true - если все хорошо
        /// false - если все плохо(капитан очевидность)</returns>
        private bool CheckConversionParam(bool ConvCheck)
        {
            //Нужно проверить чатоту семплирования
            //Начальную точку, конечную точку
            //Колличество точек БПФ
            //Параметры файла, если у нас бинарный формат
            if (Convert.ToInt32(tbSampleRate.Text) <= 0)
                return false;
            if (ConvCheck)
            {
                if (Convert.ToInt32(tbStartPoint.Text) < 0
                    || Convert.ToInt32(tbStartPoint.Text) > ConversionConfiguration.TotalPoints
                    || ConversionConfiguration.StopPoint > ConversionConfiguration.TotalPoints)
                {
                    return false;
                }
                if (ConversionConfiguration.NumOfPoints <= 2)
                    return false;
            }
            if (ConversionConfiguration.FFTType == FFTConfig.FFTFileState.Binary || ConversionConfiguration.FFTType == FFTConfig.FFTFileState.Uint)
            {
                if (Convert.ToUInt16(cbBinLength.SelectedItem) < 8)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Open file if exist and calculate how many points we have
        /// </summary>
        private void HowManyPoints()
        {
            //If file exist start counting him
            if (File.Exists(Config.FilesPath))
            {
                //If Binary data, open binary reader
                if (ConversionConfiguration.FFTType == FFTConfig.FFTFileState.Binary)
                {
                    using (BinaryReader Reader = new BinaryReader(File.Open(Config.FilesPath, FileMode.Open)))
                    {
                        lbTotalPoints.Text = string.Format("Points: {0}", Reader.BaseStream.Length / (Convert.ToUInt16(cbBinLength.SelectedItem) / 8));
                        ConversionConfiguration.TotalPoints = Convert.ToInt32(Reader.BaseStream.Length / (Convert.ToUInt16(cbBinLength.SelectedItem) / 8));

                    }
                }
            }

        }

        /// <summary>
        /// Вызывает диалог открытия файла и если все хорошо, то прописывает его в конфиг
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Config.SetPath(Config.GetConfigPath(), dialog.FileName);
                tbFile.Text = dialog.FileName;
                ConversionConfiguration.ADCStep = CalcADCStep();
                if (CheckConversionParam(false))
                    HowManyPoints();
            }

        }

        private void tbStartPoint_TextChanged(object sender, EventArgs e)
        {
            PutStartPoint();
        }

        private void PutStartPoint()
        {
            if (Convert.ToInt32(tbStartPoint.Text == "" ? "-1" : tbStartPoint.Text) >= 0)
            {
                //Забили картиночке и заполнили конфиг
                lbEndPoint.Text = string.Format("EndPoint: {0}", numFFT.Value + Convert.ToInt32(tbStartPoint.Text));
                //todo Проверить точки
                ConversionConfiguration.StartPoint = Convert.ToInt32(tbStartPoint.Text);
                ConversionConfiguration.StopPoint = Convert.ToInt32(numFFT.Value) + Convert.ToInt32(tbStartPoint.Text);
            }
        }

        private void rbBinary_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender) == rbBinary)
            {
                lbLength.Visible = true;
                cbBinLength.Visible = true;
                ConversionConfiguration.FFTType = FFTConfig.FFTFileState.Binary;

                //доделать остальное
            }
            else if (((RadioButton)sender) == rbFloat)
            {
                lbLength.Visible = false;
                cbBinLength.Visible = false;
            }
            else if (((RadioButton)sender) == rbInt)
            {
                lbLength.Visible = true;
                cbBinLength.Visible = true;
            }
        }
        //Заполняем количество точек БПФ
        private void numFFT_ValueChanged(object sender, EventArgs e)
        {
            ConversionConfiguration.NumOfPoints = Convert.ToInt32(numFFT.Value);
            PutStartPoint();
        }
        //Заполняем частоту семплирования
        private void tbSampleRate_TextChanged(object sender, EventArgs e)
        {
            if (tbSampleRate.Text != "")
                ConversionConfiguration.SampleRate = Convert.ToInt32(tbSampleRate.Text);
        }

        private void btFFT_Click(object sender, EventArgs e)
        {
            StartConversion();
        }
        /// <summary>
        /// Проверяет параметры преобразования и запускает адской счтетчик
        /// </summary>
        private void FFTCheckAndComplete()
        {
            if (CheckConversionParam(true))
            {
                //Очищаем графики
                crtFFT.Series[0].Points.Clear();
                crtADC.Series[0].Points.Clear();
                //Запулили массив в 2 раза больше, чем точек, пока что, т.к. все на коленочке
                byte[] points = new byte[ConversionConfiguration.NumOfPoints * 2];
                ///Считали точки в массив
                ReadSamplesToArray(points);
                float[] Rdat = new float[ConversionConfiguration.NumOfPoints];
                //Адско копирнули массив из байт в значения АЦП
                this.CopyToADCSteps(points, Rdat);
                //for (int i = 1; i < points.Length;)
                //{
                //    Rdat[(i - 1) / 2] = ((UInt16)((points[i - 1] << 8) + (points[i])) * ConversionConfiguration.ADCStep);
                //    i += 2;
                //}
                if (cbHamming.Checked)
                    HammingWindow(Rdat);
                if (cbBlackman.Checked)
                    BlackmanWindow(Rdat);


                foreach (float data in Rdat)
                {
                    crtADC.Series[0].Points.AddY(Math.Abs(data));
                }
                FFT Conv = new FFT();
                //Конвертуем
                Complex[] Spectr = new Complex[Rdat.Length];

                if (rbFFTSharp.Checked)
                {
                    for (int i = 0; i < Rdat.Length; i++)
                    {
                        Spectr[i] = Rdat[i];
                    }
                    Spectr = Conv.fftSharp(Spectr);
                }
                else
                    Conv.FFT_Transform(Rdat, ConversionConfiguration.NumOfPoints);
                //Conv.DPF(Rdat);
                //Вот вообще зачем она нужна эта непутевая постоянная состовляющая нам
                Rdat[0] = 0;
                if (cbAverage.Checked)
                {
                    //Отфильтровываем среднее значение
                    ///Усредняем с шагом avrWin, там посмотрим как пойдет
                    int avrWin = ConversionConfiguration.NumOfPoints / 100;
                    if (cbAverage.Checked)
                    {
                        float average = 0;
                        for (int i = 0; i < Rdat.Length; i++)
                        {
                            if (rbFFTSharp.Checked)
                                for (int j = 0; j < avrWin; j++)
                                    average += i + j >= Spectr.Length ? 0 : (float)(Spectr[i + j].Real * (Spectr[i + j].Real));
                            else
                                for (int j = 0; j < avrWin; j++)
                                    average += i + j >= Rdat.Length ? 0 : (Rdat[i + j] * (Rdat[i + j]));
                            average /= avrWin;
                            average = (float)Math.Sqrt(average);
                            if (rbFFTSharp.Checked)
                                Spectr[i] = average;
                            else
                                Rdat[i] = average;
                        }
                    }
                }
                if(rbFFTSharp.Checked && cbDecrNoise.Checked)
                {
                    for (int i = 0; i < Rdat.Length; i++)
                    {
                        Spectr[i] = Math.Abs(Spectr[i].Real) - Noise[i];
                    }
                }
                else if (cbDecrNoise.Checked)
                {
                    for (int i = 0; i < Rdat.Length; i++)
                    {
                        Rdat[i] = Math.Abs(Rdat[i]) - Noise[i];
                    }
                }
                if (rbFFTSharp.Checked)
                {
                    for (int i = 1; i < Rdat.Length / 2; i++)
                    {
                        if (cbDecrNoise.Checked)
                            crtFFT.Series[0].Points.AddY(Spectr[i].Real);
                        else
                            crtFFT.Series[0].Points.AddY(Math.Abs(Spectr[i].Real));
                    }
                }
                else
                {
                    for (int i = 1; i < Rdat.Length / 2; i++)
                    {
                        if (cbDecrNoise.Checked)
                            crtFFT.Series[0].Points.AddY(Rdat[i]);
                        else
                        crtFFT.Series[0].Points.AddY(Math.Abs(Rdat[i]));
                    }
                }

            }
        }
        /// <summary>
        /// Считываем побайтово значения АЦП
        /// </summary>
        /// <param name="points">Куда считываем</param>
        private void ReadSamplesToArray(byte[] points)
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(Config.FilesPath)))
            {
                ///Здесь полная жесть, но пока пойдет
                //reader.BaseStream.Position = ConversionConfiguration.StartPoint; 
                //points = reader.ReadBytes(ConversionConfiguration.NumOfPoints * 2);
                reader.BaseStream.Position = ConversionConfiguration.StartPoint * 2;
                reader.BaseStream.Read(points, 0, points.Length);
            }
        }

        /// <summary>
        /// Простой  цифровой фильтр
        /// </summary>
        /// <param name="rdat"></param>
        private void ApplyFilter(float[] rdat)
        {
            float alpha = (float)Math.Exp(-6.908 / ConversionConfiguration.NumOfPoints);
            float beta = 1 - alpha;
            for (int i = 1; i < rdat.Length - 1; i++)
            {
                rdat[i] = alpha * rdat[i - 1] + beta * rdat[i];
            }
        }

        private void BlackmanWindow(float[] rdat)
        {
            for (int i = 0; i < rdat.Length; i++)
            {
                rdat[i] = (float)(0.42
                    - 0.50 * Math.Cos(((Math.PI * 2 * rdat[i]) / (ConversionConfiguration.NumOfPoints - 1)))
                    + 0.08 * Math.Cos(((Math.PI * 4 * rdat[i]) / (ConversionConfiguration.NumOfPoints - 1))));
            }
        }

        /// <summary>
        /// Окно Хемминга
        /// </summary>
        /// <param name="rdat">Массив данных</param>
        private void HammingWindow(float[] rdat)
        {
            for (int i = 0; i < rdat.Length; i++)
            {
                rdat[i] = (float)(0.54 - 0.46 * Math.Cos(((Math.PI * 2 * rdat[i]) / (ConversionConfiguration.NumOfPoints - 1))));
            }
        }



        #region Считаем шаг ацп и благополучно забываем о нем
        private float CalcADCStep()
        {
            return (Convert.ToSingle(tbADCVolt.Text) / (1 << (int)numAdcAcc.Value));
        }

        private void numAdcAcc_ValueChanged(object sender, EventArgs e)
        {
            if (numAdcAcc.Value > 0)
                ConversionConfiguration.ADCStep = CalcADCStep();
        }

        private void tbADCVolt_TextChanged(object sender, EventArgs e)
        {
            if (tbADCVolt.Text != "" && Convert.ToSingle(tbADCVolt.Text) > 0)
                ConversionConfiguration.ADCStep = CalcADCStep();
        }
        #endregion

        private void btStepForward_Click(object sender, EventArgs e)
        {
            tbStartPoint.Text = (Convert.ToInt32(tbStartPoint.Text) + Convert.ToInt32(numFFT.Value)).ToString();
            StartConversion();
        }

        private void cbHamming_CheckedChanged(object sender, EventArgs e)
        {
            StartConversion();
        }
        /// <summary>
        /// Запускает либо Фурье, либо Герцеля
        /// </summary>
        private void StartConversion()
        {
            if (rbFFTSharp.Checked)
                FFTCheckAndComplete();
            else if (rbGoerzelMod.Checked)
                GoerzelModCheckAndComplete();
            else if (rbGoerzel.Checked)
                GoerzelCheckAndComplete();
            else
                FFTCheckAndComplete();
        }
        /// <summary>
        /// Запуск нормального преобразования Герцеля для точной выборки
        /// </summary>
        private void GoerzelCheckAndComplete()
        {
            //Очищаем графики
            crtADC.Series[0].Points.Clear();
            crtFFT.Series[0].Points.Clear();
            //Параметры преобразования
            GoerParam.SampleRate = ConversionConfiguration.SampleRate;
            //Константа, меньше разрешающая способность не должна быть
            GoerParam.NumOfPoints = ConversionConfiguration.NumOfPoints;
            GoerParam.StartFreq = Convert.ToSingle(tbStartGoer.Text);
            GoerParam.StopFreq = Convert.ToSingle(tbStopGoer.Text);
            //Считали массив байт
            byte[] samples = new byte[GoerParam.NumOfPoints * 2];
            ReadSamplesToArray(samples);
            float[] AdcSampl = new float[GoerParam.NumOfPoints];
            CopyToADCSteps(samples, AdcSampl);
            //Нарисовали значения АЦП
            foreach (float sampl in AdcSampl)
            {
                crtADC.Series[0].Points.AddY(sampl);
            }
            //Сконвертировали
            Goerzel Conv = new Goerzel();
            
            float[] Harm = Conv.Goerzel_normal(AdcSampl, GoerParam);
            //Нарисовали
            foreach (float Har in Harm)
            {
                crtFFT.Series[0].Points.AddY(Math.Abs(Har));
            }
        }

        private void btStepBack_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(tbStartPoint.Text) - Convert.ToInt32(numFFT.Value)) >= 0)
            {
                tbStartPoint.Text = (Convert.ToInt32(tbStartPoint.Text) - Convert.ToInt32(numFFT.Value)).ToString();
                StartConversion();
            }
        }

        private void cbBlackman_CheckedChanged(object sender, EventArgs e)
        {
            StartConversion();
        }

        private void cbAverage_CheckedChanged(object sender, EventArgs e)
        {
            StartConversion();
        }

        private void crtFFT_CursorPositionChanged(object sender, System.Windows.Forms.DataVisualization.Charting.CursorEventArgs e)
        {
            string Format = "Freq: {0}\r\nPoint: {1}";
            if (rbGoerzel.Checked)
                lbFreq.Text = string.Format(Format, ConversionConfiguration.GetFreqByHarm((int)crtFFT.ChartAreas[0].CursorX.Position + (int)(GoerParam.StartFreq / ((float)GoerParam.SampleRate/GoerParam.NumOfPoints))).ToString(), crtFFT.ChartAreas[0].CursorX.Position);
            else
                lbFreq.Text = string.Format(Format, ConversionConfiguration.GetFreqByHarm((int)crtFFT.ChartAreas[0].CursorX.Position).ToString(), crtFFT.ChartAreas[0].CursorX.Position);
        }

        private void cbFFTSharp_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbFilter_CheckedChanged(object sender, EventArgs e)
        {
            ///Бахнем Герцеля 
           // StartConversion();

        }

        private void GoerzelModCheckAndComplete()
        {
            if (CheckConversionParam(true))
            {
                //параметры герцеля, от них пляшем танец маленьких утят

                GoerParam.freq = 1000;
                    GoerParam.Length = 100000;
                    GoerParam.SampleRate = ConversionConfiguration.SampleRate;
                    GoerParam.Window = 512;
                

                Goerzel Conversation = new Goerzel();

                byte[] points = new byte[GoerParam.Length * 2];
                ReadSamplesToArray(points);
                float[] Rdat = new float[GoerParam.Length];
                //Очищаем графики
                crtFFT.Series[0].Points.Clear();
                crtADC.Series[0].Points.Clear();
                //Адско копирнули массив из байт в значения АЦП
                CopyToADCSteps(points, Rdat);
                //Если че, то наводим порядок на кухне и шлифуем сигнал
                if (cbHamming.Checked)
                    HammingWindow(Rdat);
                if (cbBlackman.Checked)
                    BlackmanWindow(Rdat);
                foreach (float data in Rdat)
                {
                    crtADC.Series[0].Points.AddY(data);
                }
                //Запустили преобразование и позырили

                Rdat = Conversation.GOERZEL_MOD(Rdat, GoerParam);
                //Окно Хамминга вносит погрешность в результат в момент установления
                if (cbHamming.Checked)
                    for (int i = 0; i < 513; i++)
                    {
                        Rdat[i] = 0;
                    }
                ///Простое усреднение среднеарифметическое               
                ///Усредняем с шагом avrWin, там посмотрим как пойдет
                if (cbAverage.Checked)
                {
                    int avrWin = 512;

                    float average = 0;
                    for (int i = 0; i < Rdat.Length; i++)
                    {
                        for (int j = 0; j < avrWin; j++)
                        {
                            average += i + j >= Rdat.Length ? 0 : (Rdat[i + j] * Rdat[i + j]);
                        }
                        average /= avrWin;
                        average = (float)Math.Sqrt(average);
                        Rdat[i] = average;
                    }
                }
                foreach (float data in Rdat)
                {
                    crtFFT.Series[0].Points.AddY(data);
                }
            }
        }
        /// <summary>
        /// Конвертирует семплы АЦП в значения напряжения
        /// </summary>
        /// <param name="points">массив БАЙТ АЦП</param>
        /// <param name="Rdat">Массив значений напряжения</param>
        private void CopyToADCSteps(byte[] points, float[] Rdat)
        {
            for (int i = 1; i < points.Length;)
            {
                Rdat[(i - 1) / 2] = ((UInt16)((points[i - 1] << 8) + (points[i])) * ConversionConfiguration.ADCStep);
                i += 2;
            }
        }

        private void btMicroStep_Click(object sender, EventArgs e)
        {
            tbStartPoint.Text = (Convert.ToInt32(tbStartPoint.Text) + 1).ToString();
            StartConversion();
        }

        private void btMicroBack_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(tbStartPoint.Text) - 1) >= 0)
            {
                tbStartPoint.Text = (Convert.ToInt32(tbStartPoint.Text) - 1).ToString();
                StartConversion();
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (tbSearchLen.Text != "")
            {
                ///Вот тут мы типа считали данные в память и погнали по ним галопом по Европам
                byte[] Samples = new byte[Convert.ToInt32(tbSearchLen.Text) * 2];
                ReadSamplesToArray(Samples);
                float[] AdcSamples = new float[Convert.ToInt32(tbSearchLen.Text)];
                CopyToADCSteps(Samples, AdcSamples);
                //Начинаем искать
                Search FindIt = new Search();
                FindIt.SearchHarmonicsFull(AdcSamples);
            }
        }
        private float[] Noise;
        private void btRemNoise_Click(object sender, EventArgs e)
        {
            if (tbNoiseDepth.Text != "" )
            {
                if (Convert.ToInt32(tbNoiseDepth.Text) > 0)
                {
                    Noise = new float[(int)numFFT.Value];
                    byte[] Samples = new byte[Convert.ToInt32(tbSearchLen.Text) * 2];
                    ReadSamplesToArray(Samples);
                    float[] AdcSamples = new float[Convert.ToInt32(tbSearchLen.Text)];
                    CopyToADCSteps(Samples, AdcSamples);
                    Search Ser = new Search();
                    Ser.CalculateNoise(Noise, AdcSamples, Convert.ToInt32(numFFT.Value), 0, Convert.ToUInt16(tbNoiseDepth.Text));
                }
            }
        }

        private void cbDecrNoise_CheckedChanged(object sender, EventArgs e)
        {
            StartConversion();
        }
    }
}
