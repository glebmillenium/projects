/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 06.11.2015
 * Время: 19:47
 * 
 * 
 */
using System;
using System.Windows.Forms;

namespace ControllerProcess
{
	/**
	 * class Program 
	 * Основной класс откуда происходит вызов графического интерфейса
	 * и формируется основной поток (при закрытии основного потока "Application"
	 * происходит выход из всего приложения).
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
			Application.Run(new MainForm());
		}
		
	}
}
