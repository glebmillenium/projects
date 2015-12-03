/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 28.11.2015
 * Время: 11:11
 * 
 * 
 */
using System;
using System.Windows.Forms;

namespace kript1
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
