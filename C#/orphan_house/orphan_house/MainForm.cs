/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 27.05.2016
 * Время: 21:58
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace orphan_house
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			textBox2.PasswordChar = '*';
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
			label4.Text = "";
			
			if(checkBox1.Checked){
				(new Menu("guest", 0)).Show();
				label4.Text = "Успешно!";
				Hide();
			}
			else{
				Tuple<string, int> getData = DB.authentificInSystem(textBox1.Text, textBox2.Text);
				if(getData.Item2 != -1){
					(new Menu(getData.Item1, getData.Item2)).Show();
					Hide();
				}else{
					label4.Text = "Неверные данные!";
				}
			}
		}
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			if(checkBox1.Checked){
				textBox1.Enabled = false;
				textBox2.Enabled = false;
			}else{
				textBox1.Enabled = true;
				textBox2.Enabled = true;
			}
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			// TODO: Implement MainFormLoad
		}
	}
}
