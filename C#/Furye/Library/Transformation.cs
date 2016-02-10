using System;

namespace Library
{
    public class Transformation
    {
        /// <summary>
        /// Глупый (прямой) алгоритм вычисления ДПФ. 
        /// Коэффициенты вычисляются прямо по формулам без какой-либо отпимизации.
        /// </summary>
        /// <param name="Data"> Входной массив длины Len = 2^k </param>
        /// <param name="Dir"> Переменная равная 1 или -1 для хранения данных о том, прямое или обратное ДПФ мы вычисляем </param>
        /// <returns></returns>
        static public Vector<Complex> FFT_L(Vector<Complex> Data, int Dir)
        {
            ulong Len = Data.Length();
            Vector<Complex> NewData = new Vector<Complex>(Len);

            //Инициализируем переменные для вычисления корней
            Complex PRoot, Root;

            ulong k;

            for (ulong i = 0; i < Len; i++)
            {

                PRoot = new Complex(1.0, 0.0);

                Root = new Complex(); //w_n = w
                Root.i = Math.Sin(2 * Math.PI / Len);
                Root.r = Math.Cos(2 * Math.PI / Len);

                Complex KRoot = new Complex();
                KRoot = Root;

                k = 1;
                //вычисляем w^k          
                while (k < i)
                {
                    KRoot *= Root;
                    k++;
                }

                //Инициализируем ai нового вектора
                Complex a = new Complex(0, 0);
                for (ulong j = 0; j < Len; j++)
                {
                    if (j == 0)
                    {
                        a += Data[j];
                    }
                    else
                    {
                        if (Dir == 1) a += Data[j] * PRoot;
                        else a += Data[j] * (new Complex(PRoot.r / (PRoot.r* PRoot.r + PRoot.i* PRoot.i), -PRoot.i / (PRoot.r * PRoot.r + PRoot.i * PRoot.i)));
                    }
                    if (i == 0) continue;
                    //вычисялем w^kj
                    PRoot *= KRoot;
                }
                NewData[i] = a;
            }
            return NewData;
        }

        #region Перестановка исходных данных в нужный порядок (2)
        /// <summary>
        /// Переворачивает входной массив длины 2^i в соответствии с некоторым правилом.
        /// Например, при порядке 01234567 получим 04261537
        /// </summary>
        /// <param name="Data">Массив комплексных чисел</param>
        static public void FFTReOrder(Vector<Complex> Data)
        {
            ulong N = Data.Length();
            Complex temp;
            if (N <= 2) return;
            ulong r = 0;
            for (ulong x = 1; x < N; x++)
            {
                r = rev_next(r, N);
                if (r > x) { temp = Data[x]; Data[x] = Data[r]; Data[r] = temp; }
            }
        } //Время операции О(2n)

        /// <summary>
        /// Вспомогательный метод для FFTReOrder
        /// </summary>
        /// <param name="r"> r = rev(x-1) </param>
        /// <param name="N"> Длина входного массива в FFTReOrder </param>
        /// <returns> Возвращает r = rev(x) </returns>
        static public ulong rev_next(ulong r, ulong N)
        {
            do
            {
                N = N >> 1;
                r = r ^ N;
            } while ((r & N) == 0);
            return r;
        }
        #endregion

        /// <summary>
        /// Бысрый рекурсивный алгоритм дискретного преобразования Фурье.
        /// На вход подаётся вектор длины N, который затем рекурсивно разбивается пополам.
        /// Вместо реального разбиения массива происходит передача параметров
        /// start и Len, отвечающих за границы обрабатываемой области начального вектора.  
        /// Перед запуском вектор должен быть обработан процедурой FFTReOrder()
        /// </summary>
        /// <param name="Data"> Входной массив длины Len = 2^k </param>
        /// <param name="start"> Индекс начала обрабатываемой области входного массива </param>
        /// <param name="Len"> Длина обрабатываеймой области входного массива </param>
        /// <param name="Dir"> Переменная равная 1 или -1 для хранения данных о том, прямое или обратное ДПФ мы вычисляем. </param>
        static public void FFT_T(Vector<Complex> Data, ulong start, ulong Len, int Dir)
        {
            ulong k;

            //Инициализируем переменные для вычисления корней
            ulong TLen, TNdx;
            int TDir;
            Complex PRoot, Root;

            Len /= 2;

            //Инициализируем w и w_n
            TNdx = 0; TLen = (Len); TDir = (Dir);
            PRoot = new Complex(1.0, 0.0);
            Root = new Complex();
            Root.r = Math.Sin(Math.PI / ((Len) * 2.0));
            Root.r = -2.0 * Root.r * Root.r;
            Root.i = Math.Sin(Math.PI / (Len)) * (Dir);

            if (Len > 1)
            {

                FFT_T(Data, start, Len, Dir); // пока длина вектора больше единицы
                FFT_T(Data, start + Len, Len, Dir); // рекурсивно делим на две части
            }

            ulong end = start + Len;
            for (k = start; k < end; k++)
            {
                Complex b, c;
                b = Data[k]; // преобразование
                c = Data[k + Len] * PRoot; // бабочки “на месте”
                Data[k] = b + c;
                Data[k + Len] = b - c;


                // переход к следующему корню, учитывая Dir
                if (((++TNdx) & 15) == 0)
                {
                    double Angle = (Math.PI * (TNdx)) / TLen;
                    PRoot.r = Math.Sin(Angle * 0.5);
                    PRoot.r = 1.0 - 2.0 * PRoot.r * PRoot.r;
                    PRoot.i = Math.Sin(Angle) * (TDir);
                }
                else
                {
                    Complex Temp;
                    Temp = PRoot;
                    PRoot = PRoot * Root;
                    PRoot = PRoot + Temp;
                }
            }
        }
    }
}
