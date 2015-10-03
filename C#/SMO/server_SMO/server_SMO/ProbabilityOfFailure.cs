/*
 * Created by SharpDevelop.
 * User: Глеб
 * Date: 19.05.2015
 * Time: 22:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace server_SMO
{
	/// <summary>
	/// Description of ProbabilityOfFailure.
	/// </summary>
	class ProbabilityOfFailure:ProbabilityFreeToChanel
	{
		//n, lymbd, t ,ro
		public ProbabilityOfFailure(double arg1, double arg2, double arg3)
		{
			n=arg1;
			lyambda=arg2;
			t=arg3;
			ro=lyambda*t;
		}
		
		public override double countProbability(){
			double r = base.countProbability();//r0
			return Math.Pow(ro,n)*r/factorial(Convert.ToInt32(n));
		}
		public double toIncreaseCapacity_x2(){
			double p_free_all=(new ProbabilityFreeToChanel(this.n,this.lyambda,this.t)).countProbability();
			double src_fail=countProbability();
			while( src_fail<countProbability()*2 ){
				this.n++;
			}
			return this.n;
		}
	}
}
