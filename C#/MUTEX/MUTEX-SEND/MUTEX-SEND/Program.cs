/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 21.10.2015
 * Время: 9:30
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Windows.Forms;

namespace MUTEX_SEND
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
			Application.Run(new MainForm());
		}
		
	}
}
