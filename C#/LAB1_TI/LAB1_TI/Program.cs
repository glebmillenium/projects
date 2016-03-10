/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 11.03.2016
 * Время: 1:09
 * 
 * 
 */
using System;
using System.Windows.Forms;

namespace LAB1_TI
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
