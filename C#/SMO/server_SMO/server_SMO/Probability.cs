/*
 * Created by SharpDevelop.
 * User: Глеб
 * Date: 19.05.2015
 * Time: 16:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace server_SMO
{
	/// <summary>
	/// Description of Probability.
	/// </summary>
	abstract class Probability
	{
		protected double n;//поля класса, доступ из вне запрещен, кроме класса наследника!
		protected double lyambda;
		protected double t;
		
		protected double ro;//интенсивность нагрузки
		protected double mu;//интенсивность потока обслуживания
		
		public Probability(){
			n=0;
			lyambda=0;
			t=0;
			ro=0;
			mu=0;
		}
		
		public abstract double countProbability();//абстрактный метод для расчета необходимой вероятности
		
		public double factorial(int n)
		{
		    int i;
		    
		    for (i = n - 1; i > 0; i--)
		        n *= i;
		 
		    return (n == 0) ? 1 : n;
		}
		
	}
}
