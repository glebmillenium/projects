/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 21.10.2015
 * Время: 9:30
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MUTEX_SEND
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private static Mutex MyMutex = new Mutex(false, "TreatmentFiles");
		private static Process MyProcess;
		private static Mutex ControllStartProcess = new Mutex(false, "ControllStartProcess");
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			MyProcess = Process.Start("C:\\Users\\Глеб\\Documents\\SharpDevelop Projects\\MUTEX_RECIPIENT\\MUTEX_RECIPIENT\\bin\\Debug\\MUTEX_RECIPIENT.exe", textBox3.Text);
			Directory.CreateDirectory(textBox3.Text);
			Directory.CreateDirectory(textBox3.Text + "temp");
			label4.Text = "Идет передача файлов...";
			Thread myThreadMD = new Thread(()=> getAwayFiles());
 			myThreadMD.Start();
		}
		
		void getAwayFiles()
		{
			Mutex m = null;
			DirectoryInfo dirInfo = new DirectoryInfo(textBox1.Text);
			int listener = 0;
			m = Mutex.OpenExisting("TreatmentFiles");
		  	foreach (FileInfo file in dirInfo.GetFiles("*."+textBox2.Text))
		  	{
		  		if (listener != 0)
		  		{
		  			Thread.Sleep(10000);
		  		}
		  		else
		  		{
		  			listener = 1;
		  		}
		  		
		  		if(m.WaitOne())
		  		{
			    	File.Copy(file.FullName, textBox3.Text + "temp" + "\\" + file.Name, true);
			    	m.ReleaseMutex();
		  		}
			}
		  	label4.Invoke(new Action(updateLabel));
		  	
		  	MyProcess.Close();
		}
		void updateLabel()
        {
            label4.Text = "Передача завершена!";
        }
	}
}
