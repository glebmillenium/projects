/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 11.03.2016
 * Время: 1:09
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LAB1_TI
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		List<TextBox> textfields = new List<TextBox>();
		int y = 0;
		int i = -1;
		int high = 20;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			createTextField();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
			createTextField();
		}
		
		private void createTextField()
		{
			var valueBlock = new TextBox();
			valueBlock.Size = new Size(80, 20);
			valueBlock.Location= new Point(0, this.y);
			this.panel1.Controls.Add(valueBlock);
			textfields.Add(valueBlock);
			this.i++;
			this.y += this.high;
		}
		
		private void removeTextField()
		{
			textfields.RemoveAt(this.i);
			this.panel1.Controls.RemoveAt(this.i);
			this.i--;
			this.y -= this.high;
		}
		void Button2Click(object sender, EventArgs e)
		{
			if (this.i > 0) 
				removeTextField();
		}
		void Button3Click(object sender, EventArgs e)
		{
			var arrayValues = textfields.ToArray();
			Double summ = 0;
			for(int i = 0; i < arrayValues.Length; i++)
			{
				var value = Double.Parse(arrayValues[i].Text);
				summ -= value*Math.Log(value);
			}
			textBox1.Text = summ.ToString();
		}
	}
}
