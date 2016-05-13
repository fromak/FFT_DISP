using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace FFT_DISP
{
    class Search
    {
        public Search()
        {

        }
        /// <summary>
        /// Смещение для БПФ на 1024т.
        /// </summary>
        private readonly int OffsetFor1024 = 101;

        /// <summary>
        /// Смещение для БПФ на 512т.
        /// </summary>
        private readonly int OffsetFor512 = 73;
        /// <summary>
        /// Последняя интересующая нас гармоника на 1024т.
        /// </summary>
        private readonly int End1024 = 256;
        /// <summary>
        /// Последняя интересующая нас гармоника на 512т.
        /// </summary>
        private readonly int End512 = 128;
        /// <summary>
        /// Выполняет полный поиск по массиву с целью вывалить гармоники действительных частот
        /// </summary>
        /// <param name="AdcSamples">Семплы полученные на шаге 1</param>
        public void SearchHarmonicsFull(float[] AdcSamples)
        {
            #region Модифицированный Герцель
            Goerzel GoerzelModification = new Goerzel();
            ///Шаг2 Модифицированный Герцель ищет начало сигнала
            Goerzel_params GoerFullParam = new Goerzel_params()
            {
                freq = 1000,
                Length = AdcSamples.Length,
                NumOfPoints = 131072,
                SampleRate = 8000,
                StartFreq = 0,
                StopFreq = 0,
                Window = 512
            };
            float[] ModGoerzelResult = new float[AdcSamples.Length];
            //получили выборки
            ModGoerzelResult = GoerzelModification.GOERZEL_MOD(AdcSamples, GoerFullParam);
            /// 2.1 Пропускаем N отсчетов, равное размеру окна поиска
            bool NoSignalFlag = false;
            int SignalCount = 0;
            //На самом деле не сигнал, а опора в 1000Гц
            int NoSignalCount = 0;
            /// 2.2 Значение порога модуля = 2000
            int ModuleThreshold = 2000;
            //Точка конца сигнала
            int NoSignalStartPoint = 0;
            for (int i = GoerFullParam.Window; i < ModGoerzelResult.Length; i++)
            {
                if (NoSignalFlag)
                {
                    if (ModGoerzelResult[i] > ModuleThreshold)
                    {
                        NoSignalCount++;
                        /// 2.4 Модуль выше порога не менее 500 отсчетов
                        if (NoSignalCount > 511)
                        {
                            /// 2.4.1 Запомнить точку + 150 отсчетов, от которой у нас есть стабильный рост
                            NoSignalStartPoint = i - 255;
                            break;
                        }
                    }
                    else //сигнал еще не закончился
                        NoSignalCount = 0;
                }
                else
                {
                    //Если гоняем по зоне уже без сигнала, то пропускаем ее, нужно стабильное окончание сигнала
                    if (ModGoerzelResult[i] > ModuleThreshold)
                    {
                        SignalCount = 0;
                    }
                    else
                    {
                        SignalCount++;
                        /// 2.3 Модуль меньше порога не менее 3500 отсчетов
                        if (SignalCount > 4096)
                        {
                            NoSignalFlag = true;
                        }
                    }
                }
            }
            if (NoSignalStartPoint == 0)
            {
                int aaaaaaaaaaaaaaaaaa = 1;
            }
            FFTConfig FFTConfiguration = new FFTConfig()
            {
                NumOfPoints = 1024,
                SampleRate = 8000,
                StartPoint = NoSignalStartPoint
            };
            #endregion

            #region БПФ
            ///Шаг 3 БПФ анализ                                   
            FFT FFTModification = new FFT();
            Complex[] FFTSpectr = new Complex[FFTConfiguration.NumOfPoints];
            // В сигнале на 1024т. Нас интересуют гармоники 103-256
            float[] NoiseCanceler1024 = new float[End1024 - OffsetFor1024];
            // В сигнале на 512т. нас интересуют гармоники 75-128
            float[] NoiseCanceler512 = new float[End512 - OffsetFor512];
            for (int i = 0; i < NoiseCanceler1024.Length; i++)
                NoiseCanceler1024[i] = 0;
            for (int i = 0; i < NoiseCanceler512.Length; i++)
                NoiseCanceler512[i] = 0;

            CalculateNoise(NoiseCanceler1024, AdcSamples, FFTConfiguration.NumOfPoints, OffsetFor1024, NoSignalStartPoint, 2);
            CalculateNoise(NoiseCanceler512, AdcSamples, FFTConfiguration.NumOfPoints, OffsetFor512, NoSignalStartPoint, 4);
#region Refact

            //for (int avg = 0; avg < 2; avg++)
            //{
            //    for (int i = 0; i < FFTConfiguration.NumOfPoints; i++)
            //    {
            //        FFTSpectr[i] = AdcSamples[FFTConfiguration.StartPoint + (avg * FFTConfiguration.NumOfPoints) + i];
            //    }
            //    /// 3.1 БПФ на 1024т делаем 3 выборки, запоминаем и усредняем помеху по каждой гармонике для активного шумодава
            //    FFTSpectr = FFTModification.fftSharp(FFTSpectr);
            //    for (int j = 0; j < NoiseCanceler1024.Length; j++)
            //        NoiseCanceler1024[j] += (float)Math.Abs(FFTSpectr[j + OffsetFor1024].Real);
            //    FFTConfiguration.NumOfPoints = 512;
            //    FFTSpectr = new Complex[FFTConfiguration.NumOfPoints];
            //    for (int i = 0; i < FFTConfiguration.NumOfPoints; i++)
            //    {
            //        FFTSpectr[i] = AdcSamples[FFTConfiguration.StartPoint + (avg * FFTConfiguration.NumOfPoints) + i];
            //    }
            //    /// 3.2 Переключаемся на 512т., так же набираем данных для активного шумодава, не менее 4-х выборок
            //    FFTSpectr = FFTModification.fftSharp(FFTSpectr);
            //    for (int j = 0; j < NoiseCanceler512.Length; j++)
            //        NoiseCanceler512[j] += (float)Math.Abs(FFTSpectr[j + OffsetFor512].Real);
            //    FFTConfiguration.NumOfPoints = 1024;
            //    FFTSpectr = new Complex[FFTConfiguration.NumOfPoints];
            //}
            ////Среднее арифметическое для шума
            //for (int i = 0; i < NoiseCanceler1024.Length; i++)
            //    NoiseCanceler1024[i] /= 2;
            ////Среднее арифметическое для шума
            //for (int i = 0; i < NoiseCanceler512.Length; i++)
            //    NoiseCanceler512[i] /= 2;
            #endregion
            bool FirstHarmFind = false;
            bool SecondHarmFind = false;
            bool ThirdHarmFind = false;
            int ActualPosition = NoSignalStartPoint + 2048;///За это время точно нет сигнала
            int FirstHarmPosition = -1;
            /// 3.3 Формируем среднеарифмитическое в пределе поиска и на его осонве ищем полезный сигнал на каждом шаге
            /// 3.3.1 За среднее взять уровень шума без сигнала??????????????!!!!!
            float Avg1024 = 0;
            float Avg512 = 0;
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < FFTConfiguration.NumOfPoints; i++)
                {
                    FFTSpectr[i] = AdcSamples[NoSignalStartPoint + (j * FFTConfiguration.NumOfPoints) + i];
                }
                ///Получили спектр
                FFTSpectr = FFTModification.fftSharp(FFTSpectr);
                //Включили шумодав и посчитали среднее без шума для 1024т.
                for (int avg = 0; avg < NoiseCanceler1024.Length; avg++)
                    Avg1024 += (float)Math.Abs(FFTSpectr[avg + OffsetFor1024].Real) - NoiseCanceler1024[avg];

                ///Переключились на 512т.
                FFTConfiguration.NumOfPoints = 512;
                FFTSpectr = new Complex[FFTConfiguration.NumOfPoints];
                for (int i = 0; i < FFTConfiguration.NumOfPoints; i++)
                {
                    FFTSpectr[i] = AdcSamples[NoSignalStartPoint + (j * FFTConfiguration.NumOfPoints) + i];
                }

                ///Получили спектр
                FFTSpectr = FFTModification.fftSharp(FFTSpectr);
                //Включили шумодав и посчитали среднее без шума для 1024т.
                for (int avg = 0; avg < NoiseCanceler512.Length; avg++)
                    Avg512 += (float)Math.Abs(FFTSpectr[avg + OffsetFor512].Real) - NoiseCanceler512[avg];

                ///Переключились на 1024т.
                FFTConfiguration.NumOfPoints = 1024;
                FFTSpectr = new Complex[FFTConfiguration.NumOfPoints];
            }
            ///Среднее по уровню шума без помехи
            Avg1024 /= NoiseCanceler1024.Length * 2;
            ///Среднее по уровню шума без помехи
            Avg512 /= NoiseCanceler512.Length * 2;


            /// 3.4 Ждем гармонику в пределах 76-103, которая не менее, чем на 50% выше уровня шума и держится на одной позиции 3 выборки
            /// 3.4.1 Запоминаем точку как начальную точку действительного сигнала
            /// 3.5 БПФ на 1024т. с шумодавом определяем грубую гармонику в пределах 153-205, запоминаем эту частоту, что бы в дальнейшем не словить помеху, если она окажется сильнее действительного сигнала
            FFTConfiguration.NumOfPoints = 512;
            while (!FirstHarmFind)
            {
                FFTSpectr = new Complex[FFTConfiguration.NumOfPoints];
                for (int i = 0; i < FFTSpectr.Length; i++)
                {
                    FFTSpectr[i] = AdcSamples[ActualPosition + i];
                }
                FFTSpectr = FFTModification.fftSharp(FFTSpectr);
                for (int noise = 0; noise < NoiseCanceler512.Length; noise++)
                {
                    FFTSpectr[OffsetFor512 + noise] = Math.Abs(FFTSpectr[OffsetFor512 + noise].Real) - NoiseCanceler512[noise];

                }

            }
            /// 3.6 БПФ на 512т. с шумодавом ищем гармонику в пределах 102-128
            /// 3.7 БПФ на 1024т.: 204-256 --//--
            /// 3.7.1 ЗАпоминаем точку Т2
            while (!SecondHarmFind)
            {

            }
            /// 3.8 Пропускаем 2048т. от точки Т2
            /// 3.9 БПФ на 1024т.: 153-256 --//--
            while (!ThirdHarmFind)
            {

            }
            #endregion





            ///Шаг 4 Обычным Герцелем определяем Конкретные гармоники


        }
        /// <summary>
        /// Метод выполняет БПФ и получает усредненное значение для шумоподавления
        /// </summary>
        /// <param name="noiseCaneler">Массив шумоподавления</param>
        /// <param name="adcSamples">Массив семплов</param>
        /// <param name="FFTPoints">Длинна БПФ</param>
        /// <param name="NoiseOffset">Начальная гармоника шумоподавления</param>
        /// <param name="StartPoint">Начальная точка для выборки шумоподавления</param>
        /// <param name="AvgCount">Колличество выборок шумоподавления</param>
        public void CalculateNoise(float[] noiseCaneler, float[] adcSamples, int FFTPoints, int NoiseOffset, int StartPoint, int AvgCount)
        {
            //FFT
            FFT NoiseCalc = new FFT();
            //Spectr
            Complex[] FFTSpectr = new Complex[FFTPoints];
            //Calculate avg Harmonics
            for (int avg = 0; avg < AvgCount + 1; avg++)
            {
                //Заполняем массив точек для БПФ
                for (int i = 0; i < FFTPoints; i++)
                {
                    FFTSpectr[i] = adcSamples[StartPoint + (avg * FFTPoints) + i];
                }
                /// 3.1 БПФ, запоминаем 
                FFTSpectr = NoiseCalc.fftSharp(FFTSpectr);
                //Для каждой гармоники шумодава, берем гармонику из результата
                //Это не обязательно от начала и до конца спектра, может быть и небольшой кусок от NoiseOffset до конца массива
                for (int j = 0; j < noiseCaneler.Length; j++)
                    noiseCaneler[j] += (float)Math.Abs(FFTSpectr[j + NoiseOffset].Real);
            }
            //3.1 и усредняем помеху по каждой гармонике для активного шумодава
            for (int i = 0; i < noiseCaneler.Length; i++)
                noiseCaneler[i] /= AvgCount;
        }
    }
}
