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
                        if (NoSignalCount > 500)
                        {
                            /// 2.4.1 Запомнить точку + 150 отсчетов, от которой у нас есть стабильный рост
                            NoSignalStartPoint = i - 350;
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
                        if (SignalCount > 3500)
                        {
                            NoSignalFlag = true;
                        }
                    }
                }
            }
            if (NoSignalStartPoint ==0)
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
            float[] NoiseCaneler1024 = new float[256 - 102];
            // В сигнале на 512т. нас интересуют гармоники 75-128
            float[] NoiseCaneler512 = new float[128 - 74];
            for (int i = 0; i < NoiseCaneler1024.Length; i++)
                NoiseCaneler1024[i] = 0;
            for (int i = 0; i < NoiseCaneler512.Length; i++)
                NoiseCaneler512[i] = 0;
            for (int avg = 0; avg < 3; avg++)
            {
                for (int i = 0; i < FFTConfiguration.NumOfPoints; i++)
                {
                    FFTSpectr[i] = AdcSamples[FFTConfiguration.StartPoint + (avg * FFTConfiguration.NumOfPoints) + i];
                }
                /// 3.1 БПФ на 1024т делаем 3 выборки, запоминаем и усредняем помеху по каждой гармонике для активного шумодава
                FFTSpectr = FFTModification.fftSharp(FFTSpectr);
                for (int j = 0; j < NoiseCaneler1024.Length; j++)
                    NoiseCaneler1024[j] += (float)Math.Abs( FFTSpectr[j + 102].Real);
                FFTConfiguration.NumOfPoints = 512;
                FFTSpectr = new Complex[FFTConfiguration.NumOfPoints];
                for (int i = 0; i < FFTConfiguration.NumOfPoints; i++)
                {
                    FFTSpectr[i] = AdcSamples[FFTConfiguration.StartPoint + (avg * FFTConfiguration.NumOfPoints) + i];
                }
                /// 3.2 Переключаемся на 512т., так же набираем данных для активного шумодава, не менее 4-х выборок
                FFTSpectr = FFTModification.fftSharp(FFTSpectr);
                for (int j = 0; j < NoiseCaneler512.Length; j++)
                    NoiseCaneler512[j] += (float)Math.Abs(FFTSpectr[j + 74].Real);
                FFTConfiguration.NumOfPoints = 1024;
                FFTSpectr = new Complex[FFTConfiguration.NumOfPoints];
            }
            for (int i = 0; i < NoiseCaneler1024.Length; i++)
                NoiseCaneler1024[i] /= 3;
            for (int i = 0; i < NoiseCaneler512.Length; i++)
                NoiseCaneler512[i] /= 3;
            bool FirstHarmFind = false;
            bool SecondHarmFind = false;
            bool ThirdHarmFind = false;
            int ActualPosition = NoSignalStartPoint;
            int FirstHarmPosition = -1;
            /// 3.3 Формируем среднеарифмитическое в пределе поиска и на его осонве ищем полезный сигнал на каждом шаге
            /// 3.3.1 За среднее взять уровень шума без сигнала??????????????!!!!!
            /// 3.4 Ждем гармонику в пределах 76-103, которая не менее, чем на 50% выше уровня шума и держится на одной позиции 3 выборки
            /// 3.4.1 Запоминаем точку как начальную точку действительного сигнала
            /// 3.5 БПФ на 1024т. с шумодавом определяем грубую гармонику в пределах 153-205, запоминаем эту частоту, что бы в дальнейшем не словить помеху, если она окажется сильнее действительного сигнала
            while (!FirstHarmFind)
            {

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
    }
}
