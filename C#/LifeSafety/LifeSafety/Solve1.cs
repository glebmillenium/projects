/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 27.03.2016
 * Время: 1:51
 * 
 * 
 */
using System;

namespace LifeSafety
{
	/// <summary>
	/// Description of Solve1.
	/// </summary>
	public class Solve1
	{
 		public Solve1() { }
        public double r1, r2, dRf, dRsk, dRf3, K, Db, Vb, tb, Ncm;

        override public string ToString()
        {
            return String.Format("Избыточное давление на заданном расстоянии: {0:F2} кПа\nСкоростной напор воздуха: {1:F2} кПа\nИзбыточное давление в зоне 3: {2:F2} кПа\nЧисло погибших людей: {3:F4} чел", dRf, dRsk, dRf3, Ncm);

        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="R"> Радиус до эпицентра взрыва, метры</param>
        /// <param name="M"> Масса тратила, кг</param>
        /// <param name="P"> Плотность населения, тыс.чел /км^2 </param>
        /// 
        static public void Raschet1(double R, double m, double P, Solve1 obj)
        {
            //Избыточное давление, кПа
            double dRf = 95 * Math.Pow(m, 1.0 / 3.0) / R + 390 * Math.Pow(m, 2.0 / 3.0) / Math.Pow(R, 2) + 1300 * m / Math.Pow(R, 3);
            obj.dRf = dRf;
            //Скоростной напор воздуха 
            double dRsk = (2.5 * dRf * dRf) / (dRf + 720); // кПа
            obj.dRsk = dRsk;
            //Скорость движения ударной волны м/с
            double Db = 340 * Math.Sqrt(1 + 0.0083 * dRf);
            obj.Db = Db;
            //Скорость движения за фротном ударной волны м/с
            double Vb = 8000 * dRf / Db;
            obj.Vb = Vb;
            //Время движения ВУВ, c
            double tb = 0.0013 * Math.Pow(m, 1.0 / 6.0) * Math.Sqrt(R);
            obj.tb = tb;
            //Потери среди населения
            double Ncm = P* 0.001* Math.Pow(m / 1000.0, 2.0 / 3.0);
            obj.Ncm = Ncm;
            //Радиус бризантного действия
            double r1 = 1.75 * Math.Pow(m, 1.0 / 3.0); //м
            obj.r1 = r1;
            //Радиус огненного шара
            double r2 = 1.7 * r1; //м
            obj.r2 = r2;
            //Избыточное давление в зоне 3:
            double K = 0.24 * R / r1;
            obj.K = K;
            double dRf3 = 0;
            if (K <= 2)
            {
                dRf3 = 700 / (3 * Math.Sqrt(1 + 29.8 * Math.Pow(K, 3)) - 1); //кПа
            }
            else
            {
                dRf3 = 22 / (K * Math.Sqrt(Math.Log(K) + 0.158)); //кПа
            }
            obj.dRf3 = dRf3;
        }
	}
}
