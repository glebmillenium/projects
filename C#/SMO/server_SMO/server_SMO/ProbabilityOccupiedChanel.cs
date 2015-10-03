/*
 * Created by SharpDevelop.
 * User: Глеб
 * Date: 19.05.2015
 * Time: 20:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace server_SMO
{
	/// <summary>
	/// Description of ProbabilityOccupiedChanel.
	/// </summary>
	class ProbabilityOccupiedChanel: ProbabilityFreeToChanel
	{
		public int i;
		public ProbabilityOccupiedChanel(double arg1,double arg2,double arg3)
		{
			
			n=arg1;
			lyambda=arg2;
			t=arg3;
			ro=lyambda*t;
			i=0;
		}
		
		public override double countProbability(){
			
			if(this.i>=this.n) { return -1;}
			double r = base.countProbability();
			double P=r*Math.Pow(ro,i)/factorial(i);
			return P;
		}
		
			
	}
}
