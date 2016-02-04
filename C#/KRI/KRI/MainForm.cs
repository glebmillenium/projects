/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 02.11.2015
 * Время: 21:26
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KRI
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
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void ОкClick(object sender, EventArgs e)
		{
			double count = Int32.Parse(textBox1.Text) * 2550 / 4 + Int32.Parse(textBox2.Text) * 0.0095;
			label.Text = count.ToString("0.000000");
		}
		void TextBox1TextChanged(object sender, EventArgs e)
		{
	
		}
	}
}
