/*
 * Created by SharpDevelop.
 * User: Глеб
 * Date: 19.05.2015
 * Time: 22:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace server_SMO
{
	/// <summary>
	/// Класс предназначен для извлечения полученной строки данных из клиента, 
	/// в полноценные данные для дальнейшего их использования
	/// </summary>
	class DataFromClient
	{
		public double n;//поля класса, доступ из вне запрещен, кроме класса наследника!
		public double lyambda;
		public double t;	
		public double ro;//интенсивность нагрузки
		public double mu;//интенсивность потока обслуживания
		
		public DataFromClient(string data)//конструктор класса
		{

		String[] words = data.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
		n=Convert.ToDouble(words[0]);
		lyambda=Convert.ToDouble(words[1]);
		t=Convert.ToDouble(words[2]);
		
		ro=lyambda*t;
		mu=1/t;
		}

	}
}
