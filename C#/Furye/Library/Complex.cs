using System;

namespace Library
{
    public class Complex
    {
        public double r, //real part 
            i; //imaginary part
        
        //Constructors
        public Complex():this(0,0) {
        }
        public Complex(double r, double i) {
            this.r = r;
            this.i = i;
        }

        public override string ToString(){
            return (System.String.Format("{0:0.###} + {1:0.###}i", r, i));
        }

        // Overloading '+' operator:
        public static Complex operator +(Complex a, Complex b){
            return new Complex(a.r + b.r, a.i + b.i);
        }

        // Overloading '-' operator:
        public static Complex operator -(Complex a, Complex b){
            return new Complex(a.r - b.r, a.i - b.i);
        }

        // Overloading '*' operator:
        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.r*b.r - a.i*b.i, a.r*b.i + a.i*b.r);
        }

        // Overloading '/' operator:
        public static Complex operator /(Complex a, long b)
        {
            return new Complex(a.r/b, a.i/b);
        }
    }
}
