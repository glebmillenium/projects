using System;
namespace LifeSafety
{
    public class Solve2
    {
        public Solve2() { }
        public double z, m, r1, r2, dPf2, K, dPf3, F, T, Q0, I, t, U, Ncm, R3;

        override public string ToString() {
            return String.Format("Избыточное давление в зоне 2: {0:F2} кПа\nИзбыточное давление в зоне 3: {1:F2} кПа\nТепловой импульс: {2:F2} кДж/(м^2)\nЧисло погибших людей: {3:F2} чел.", dPf2, dPf3, U, Ncm);

        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="R"> Радиус до эпицентра взрыва, метры</param>
        /// <param name="M"> Масса вещества, тонны</param>
        /// <param name="substance"> Тип вещества (из списка)</param>
        /// <param name="P"> Плотность населения, тыс.чел /км^2 </param>
        /// <param name="one"> Взрыв 1 цистерны или группы </param>
        /// 
        static public void Raschet2(double R, double M, double Q0, double P, bool one, Solve2 obj, double k1, double k2, double Vb, double Dm, bool secondPart)
        {
            //коэффициент условий хранения
            double z = 0.9;
            if (one) z = 0.5;
            obj.z = z;
            //масса в тротиловом эквиваленте
            double m = z * M; //т
            obj.m = m;
            //Радиус бризантного действия
            double r1 = 17.5 * Math.Pow(m, 1.0 / 3.0); //м
            obj.r1 = r1;
            //Радиус огненного шара
            double r2 = 1.7 * r1; //м
            obj.r2 = r2;
            //Избыточное давление в зоне огненного шара
            double dPf2 = 1300 * Math.Pow((r1 / r2), 3) + 50; //кПа
            obj.dPf2 = dPf2;
            //Избыточное давление в зоне действия воздушной ударной волны
            double K = 0.24 * R / r1;
            obj.K = K;
            double dPf3 = 0;
            if (K <= 2) {
            	dPf3 = 700 / (3*Math.Sqrt(1+ 29.8*Math.Pow(K, 3)) - 1); //кПа
            }
            else {
                dPf3 = 22 / (K * Math.Sqrt(Math.Log(K)+0.158)); //кПа
            }
            obj.dPf3 = dPf3;
            //Угловой коэффициент взаимного расположения объекта и источника взрыва
            double F = r2 * r2 * r1 / Math.Sqrt(Math.Pow(r2 * r2 + R * R, 3));
            obj.F = F;
            //Прозрачность атмосферы
            double T = 1 - 0.058 * Math.Log(R);
            obj.T = T;

            //Интенсивность теплового излучения
            double I = Q0 * F * T; //кДж*м^2/c
            obj.I = I;
            //Продолжительность существования огненного шара
            double t = 0.45 * Math.Pow(m, 1.0 / 3.0);
            obj.t = t;
            //Удельная теплота пожара
            double U = I * t; //кДж/(м^2)
            obj.U = U;
            //Число погибших людей
            double Ncm = 3 * P * Math.Pow(m, 1.0 / 3.0);
            obj.Ncm = Ncm;


            //Вторая часть
           
            if (secondPart) {
                //Радиус зоны токсичного задымления
                double R3 = (3.42 / k1) * Math.Pow((m / (Vb * k2 * Dm)), 2.0/3.0);
                obj.R3 = R3;
            }

        }
    }
}
