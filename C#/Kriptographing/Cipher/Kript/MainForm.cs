/*
 * Created by SharpDevelop.
 * User: student
 * Date: 27.11.2015
 * Time: 14:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kript
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
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
		void NumericUpDown1ValueChanged(object sender, EventArgs e)
		{
			textBox2.MaxLength = (int)numericUpDown1.Value;
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
				string t = textBox1.Text.Replace("\r\n","¶");
				for(int i=0;i<t.Length;i++)
				{
					//Thread.Sleep(100);
					Invoke(new Action( () => 
					                  textBox3.Text += scrambler(alphabet, key[i % textBox2.Text.Length], t[i], true)));
					Invoke(new Action( () => progressBar1.Value = progressBar1.Maximum*(i+1) / t.Length ));
					if (i % 3 == 0) Invoke(new Action( () => label6.Text = "Идет обработка данных ." ));
					if (i % 3 == 1) Invoke(new Action( () => label6.Text = "Идет обработка данных . ." ));
					if (i % 3 == 2) Invoke(new Action( () => label6.Text = "Идет обработка данных . . ." ));
				}
				Invoke(new Action( () => label6.Text = "Исходный текст успешно зашифрован!" ));
			}
			else Invoke(new Action( () => label6.Text = "Шифрование текста уже началось!" ));
			mutexObj.Dispose();
		}
		
		string readAlphabet(string way)
		{
			return File.ReadAllText(way).Replace("\n", " ");
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
		void Button2Click(object sender, EventArgs e)
		{
		    File.WriteAllText(textBox4.Text + "\\key.txt", textBox2.Text);
		    File.WriteAllText(textBox4.Text + "\\information.txt", textBox3.Text);
		    label6.Text = "Запись прошла успешно!";
		}
		void Button3Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) 
		    {
		        textBox4.Text = folderBrowserDialog1.SelectedPath;
		    }
		}
		
	}
}
