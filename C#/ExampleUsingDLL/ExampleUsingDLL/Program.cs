﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 18.11.2015
 * Время: 0:29
 * 
 * 
 */
using System;
using System.Windows.Forms;

namespace ExampleUsingDLL
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
