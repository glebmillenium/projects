/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 28.11.2015
 * Время: 11:11
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace kript1
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button3Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) 
		    {
		        textBox4.Text = folderBrowserDialog1.SelectedPath;
		    }
		}
		void Button2Click(object sender, EventArgs e)
		{
			textBox2.Text = readAlphabet(textBox4.Text+"\\key.txt");
			textBox1.Text = readAlphabet(textBox4.Text+"\\information.txt");
			button1.Enabled = true;
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			Thread go = new Thread( ()=>createCode() );
			go.Start();
		}
		
		void createCode()
		{
			bool existed;
			Mutex mutexObj = new Mutex(true, "MutexControllProcess", out existed);
			if(existed)
			{
				Invoke(new Action( () =>textBox3.Text = ""));
				string alphabet=readAlphabet(@"C:\Users\Глеб\Desktop\kript\alphabet.txt");
				string key=textBox2.Text;
				for(int i=0;i<textBox1.Text.Length;i++)
				{
					//Thread.Sleep(100);
					Invoke(new Action( () => 
					                  textBox3.Text += scrambler(alphabet, key[i % textBox2.Text.Length], textBox1.Text[i], false)));
					Invoke(new Action( () => progressBar1.Value = progressBar1.Maximum*(i+1)/textBox1.Text.Length ));
					if (i % 3 == 0) Invoke(new Action( () => label6.Text = "Идет обработка данных ." ));
					if (i % 3 == 1) Invoke(new Action( () => label6.Text = "Идет обработка данных . ." ));
					if (i % 3 == 2) Invoke(new Action( () => label6.Text = "Идет обработка данных . . ." ));
				}
				Invoke(new Action( () => label6.Text = "Исходный текст успешно расшифрован!" ));
			}
			else 
				Invoke(new Action( () => label6.Text = "Расшифровка текста уже началось!" ));
			
			mutexObj.Dispose();
		}
				/*сделаем сдвиг алфавита, +*/
		string scrambler(string alphabet, char code, char source, bool crypt)
		{
			int index;
			if (crypt) 
				index = (alphabet.IndexOf(code)+alphabet.IndexOf(source)) % alphabet.Length;
			else 
				index = (alphabet.IndexOf(source)-alphabet.IndexOf(code) + alphabet.Length) % alphabet.Length;
			return (source == '¶' ? source : alphabet[index]).ToString();
		}
		
		string readAlphabet(string way)
		{
			return System.IO.File.ReadAllText(way).Replace("\n", " ");
		}
	}
}
