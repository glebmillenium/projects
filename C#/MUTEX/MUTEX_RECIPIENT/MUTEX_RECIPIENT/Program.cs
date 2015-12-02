/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 21.10.2015
 * Время: 22:48
 * 
 */
using System;
using System.Windows.Forms;

namespace MUTEX_RECIPIENT
{
	/**
	 * class Program 
	 * Основной класс откуда происходит вызов графического интерфейса.
	 * 
	 */
	internal sealed class Program
	{
		/**
		 * Main - Метод класса Program (начальная точка вызова программы)
		 * 
		 * @param  args параметры передаваемые приложению при вызове через консоль
		 * 
		 * @return void
		 * 
		 */
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			if (args.Length == 0) 					 // Если параметры при вызове 
													 // программы отсуствовали, то 
				Application.Run(new MainForm());	 // вызываем обычный конструктор
			else 
				Application.Run(new MainForm(args)); // Если параметры были переданы, то 
													 // вызываем графический фрейм, который 
													 // производит передачу данных
			// endif
		}
		
	}
}
