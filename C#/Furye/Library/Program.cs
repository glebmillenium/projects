using System;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex a1 = new Complex(2, 5);
            Complex a2 = new Complex(4, 3);
            Complex a3 = new Complex(1, 4);
            Complex a4 = new Complex(2, 6);
            Complex a5 = new Complex(2, 8);
            Complex a6 = new Complex(7, 3);
            Complex a7 = new Complex(4, 5);
            Complex a8 = new Complex(1, 3);
            Complex[] Vec = { a1, a2, a3, a4, a5, a6, a7, a8 };
            Vector<Complex> Data = new Vector<Complex>(Vec);

            ulong Len = Data.Length();
            int Dir = 1;
            Vector<Complex> NewData = Transformation.FFT_L(Data, Dir);
            Console.WriteLine(NewData.ToString());
            Console.WriteLine();

            Transformation.FFTReOrder(Data);
            Transformation.FFT_T(Data, 0, Len, Dir);

            Console.WriteLine(Data.ToString());
            Console.WriteLine();
            
            Dir = -1;
            NewData = Transformation.FFT_L(Data, Dir);

            Transformation.FFTReOrder(Data);
            Transformation.FFT_T(Data, 0, Len, Dir);

            if (Dir == -1) {
                for (ulong i = 0; i < Len; i++)
                {
                    Data[i].i /= Len;
                    Data[i].r /= Len;

                    NewData[i].i /= Len;
                    NewData[i].r /= Len;
                }
            }

            Console.WriteLine(NewData.ToString());
            Console.WriteLine();

            Console.WriteLine(Data.ToString());
            
            Console.ReadKey();
        }
    }
}
