/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 21.10.2015
 * Время: 22:48
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MUTEX_RECIPIENT
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		string[] args = null;
		public MainForm(string[] input)
		{
			InitializeComponent();
			Thread.Sleep(1000);
			this.args = input;
			Thread myThreadMD1 = new Thread(()=> getAwayFiles( args ));
 			myThreadMD1.Start();
		}
		
		public MainForm()
		{
			InitializeComponent();
			label1.Text = "Данное приложение будет корректно работать только, если будет запущено" +
				"из другого приложения, т.е. должно быть создано процессом из вне!";
		}
		void getAwayFiles(string[] args)
		{
			string[] files = null;
			Mutex m = null;
			m = Mutex.OpenExisting("TreatmentFiles");
			while(true) {
				
				if(m.WaitOne())
				{
					files = Directory.GetFiles(args[0]+"temp");
					if(files.Length == 0){
						label1.Text += "Перенос файлов завершен!";
						m.ReleaseMutex();
						break;
					}
					DirectoryInfo dirInfo = new DirectoryInfo(args[0]+"temp");
				  	foreach (FileInfo file in dirInfo.GetFiles("*"))
			  		{
				  		File.Copy(file.FullName, args[0]+file.Name, true);
				  		File.Delete(file.FullName);
				  		label1.Text += "Файл "+file.FullName+" перемещен!\n";
					}
				  	m.ReleaseMutex();
				  	Thread.Sleep(10000);
				}
			}
		}
				
	}
}
