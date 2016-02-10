using System;

using System.Threading.Tasks;

namespace Library
{
    public class Vector<T>
    {
        ulong length; //vector's length
        private T[] vector;

        public Vector(ulong N)
        {
            length = N;
            vector = new T[N];
        }
        public Vector(T[] v)
        {
            vector = v;
            length = (ulong)v.Length;
        }

        //Возвращает значение i-того разряда вектора
        public T this[ulong i]
        {
            get {
                if (i < length && i >= 0)
                {
                    return vector[i];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Размерность вектора не соответсвутет"
                        + "запрашиваемому значению: " + i);
                }
            }
            set {
                vector[i] = value;
            }
        }
        public ulong Length()
        {
            return length;
        }

        public override string ToString()
        {
            string[] vectorToString = new string[length];
            for (ulong j = 0; j < length; j++)
            {
                vectorToString[j] = vector[j].ToString() + ";";
            }
            return String.Join(" ", vectorToString);
        }

    }
}

