/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 27.05.2016
 * Время: 21:58
 * 
 * 
 */
using System;
using System.Windows.Forms;

namespace orphan_house
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
