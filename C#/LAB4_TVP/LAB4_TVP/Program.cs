/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 09.04.2016
 * Время: 18:54
 * 
 * 
 */
using System;
using System.Windows.Forms;

namespace LAB4_TVP
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
