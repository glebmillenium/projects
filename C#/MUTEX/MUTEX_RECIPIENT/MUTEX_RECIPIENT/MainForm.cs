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
			string text = "";
			while(true) {
				string[] files = null;
				Mutex m = null;
				m = Mutex.OpenExisting("TreatmentFiles");
				if(m.WaitOne())
				{
					files = Directory.GetFiles(args[0]+"temp");
					if(files == null){
						label1.Text = "123";
						break;
					}
					DirectoryInfo dirInfo = new DirectoryInfo(args[0]+"temp");
				  	foreach (FileInfo file in dirInfo.GetFiles("*"))
			  		{
				  		File.Copy(file.FullName, args[0]+file.Name, true);
				  		File.Delete(file.FullName);
				  		text += "Файл "+file.FullName+" перемещен!\n";
				  		label1.Text = text;
					}
				  	m.ReleaseMutex();
				}
			}
		}
				
	}
}
