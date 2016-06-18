/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 14.03.2016
 * Время: 17:13
 * 
 * 
 */
using System;
using System.Windows.Forms;

namespace lab2_TVP
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
			Application.Run(new MainForm());
		}
		
	}
}
