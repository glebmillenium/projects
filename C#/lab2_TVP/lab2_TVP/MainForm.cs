/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 14.03.2016
 * Время: 17:13
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace lab2_TVP
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		Thread Bar1 = null;
		Thread Bar2 = null;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			comboBox1.Items.AddRange(new object[] {
			                         "Высокий",
			                         "Выше нормального",
			                         "Нормальный",
			                         "Ниже нормального",
			                         "Низкий"
			                         });
			comboBox1.SelectedItem = "Нормальный";
			comboBox2.Items.AddRange(new object[] {
                         "Высокий",
                         "Выше нормального",
                         "Нормальный",
                         "Ниже нормального",
                         "Низкий"
                         });
			comboBox2.SelectedItem = "Нормальный";
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

			//comboBox1.SelectedItem.ToString();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
		
		void startBar1()
		{

			for(double i=0.0; i<=30; i+=0.00001)
			{
				/* Так как полоса прогресс бара, меняется путем задания
				 * значения из побочного потока в основной (прогресс бар создан в основном)
				 * требуется, чтобы побочный поток засыпал и 
				 * основной успел изменить значение
				 */
				Invoke(new Action(() => progressBar1.Value = Convert.ToInt32(i)));
			}
			Thread.Sleep(5000);	
		}
		
		void startBar2()
		{

			for(double i=0.0; i<=30; i+=0.00001)
			{
				/* Так как полоса прогресс бара, меняется путем задания
				 * значения из побочного потока в основной (прогресс бар создан в основном)
				 * требуется, чтобы побочный поток засыпал и 
				 * основной успел изменить значение
				 */
				Invoke(new Action(() => progressBar2.Value = Convert.ToInt32(i)));
			}
			Thread.Sleep(5000);
		
		}

		void Button1Click(object sender, EventArgs e)
		{
			if(checkBox1.Checked)
			{
				Bar1 = new Thread(startBar1);
				//Bar1.Priority = ThreadPriority.Highest;
				Bar1.Priority = checkPriority(comboBox1.SelectedItem.ToString());
				Bar1.Start();
				Bar1.Priority = checkPriority(comboBox1.SelectedItem.ToString());
			}
			if(checkBox2.Checked)
			{
				Bar2 = new Thread(startBar2);
				//Bar2.Priority = ThreadPriority.Lowest;
				Bar2.Priority = checkPriority(comboBox2.SelectedItem.ToString());
				Bar2.Start();
				Bar2.Priority = checkPriority(comboBox2.SelectedItem.ToString());
			}
		}
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			if(Bar1 != null)
			{
				if(Bar1.IsAlive && !checkBox1.Checked)
				{
					Bar1.Suspend();
					Bar1.Priority = checkPriority(comboBox1.SelectedItem.ToString());
				}
				else
				{
					Bar1.Resume();
				}
			}
		}
		void CheckBox2CheckedChanged(object sender, EventArgs e)
		{
			if(Bar2 != null)
			{
				if(Bar2.IsAlive && !checkBox2.Checked)
				{
					Bar2.Suspend();
					Bar2.Priority = checkPriority(comboBox2.SelectedItem.ToString());
				}
				else
				{
					Bar2.Resume();
				}
			}
		}
		
		ThreadPriority checkPriority(string str)
		{
			if(str == "Высокий") return ThreadPriority.Highest;
			if(str ==  "Выше нормального") return ThreadPriority.AboveNormal;
			if(str == "Нормальный") return ThreadPriority.Normal;
			if(str == "Ниже нормального") return ThreadPriority.BelowNormal;
			if(str == "Низкий") return ThreadPriority.Lowest;
			else return ThreadPriority.Normal;
		}
	}
}
