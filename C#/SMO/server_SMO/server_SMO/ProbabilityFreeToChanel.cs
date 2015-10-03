/*
 * Created by SharpDevelop.
 * User: Глеб
 * Date: 19.05.2015
 * Time: 18:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace server_SMO
{
	/// <summary>
	/// Description of Абстрактный класс.
	/// </summary>
	class ProbabilityFreeToChanel: Probability
	{
		
		public ProbabilityFreeToChanel(){}
		public ProbabilityFreeToChanel(double arg1,double arg2,double arg3){
			n=arg1;
			lyambda=arg2;
			t=arg3;
			ro=lyambda*t;
		}
		
		public override double countProbability()
		{
			double count=0;
			
			for(int i=0;i<=this.n;i++){
				count+=Math.Pow(this.ro,i)/factorial(i);
			}
			count=1/count;
			return count;
		}
		
	}
}
