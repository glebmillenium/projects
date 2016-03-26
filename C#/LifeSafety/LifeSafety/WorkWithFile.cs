/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 26.03.2016
 * Время: 17:49
 * 
 * 
 */
using System;

namespace LifeSafety
{
	/**
	 * Класс WorkWithFile - статический класс предназначеный 
	 * для работы с текстовыми файлами
	 * 
	 */
	public class WorkWithFile
	{
		string core = "";
		string data = "";
		string tables = "";
		string tasks = "";
		string way = "";
		public WorkWithFile(string core, string data, string tables, string tasks)
		{
			this.core = core;
			this.data = data;
			this.tables = tables;
			this.tasks = tasks;
		}
		public WorkWithFile(string way)
		{
			this.way = way;
		}
		public string[][] writtingToArray(char[] separate)
		{
			string[] lines = System.IO.File.ReadAllLines(way);
			string[][] alldata = new string[lines.Length][];
			int i = 0;
			foreach (var line in lines)
			{
				alldata[i] = line.Split(separate, StringSplitOptions.RemoveEmptyEntries);
				i++;
			}
			return alldata;
		}
	}
}
