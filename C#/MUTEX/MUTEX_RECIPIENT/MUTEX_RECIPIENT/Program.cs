/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 21.10.2015
 * Время: 22:48
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Windows.Forms;

namespace MUTEX_RECIPIENT
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if (args.Length == 0)
				Application.Run(new MainForm());
			else 
				Application.Run(new MainForm(args));
		}
		
	}
}
