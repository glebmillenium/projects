/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 12.03.2016
 * Время: 2:20
 * 
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LAB1_TI
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		FirstTask first = new FirstTask();
		SecondTask second = new SecondTask();
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
		void Button1Click(object sender, EventArgs e)
		{
			first.Show();
			Hide();
		}
		void Button2Click(object sender, EventArgs e)
		{
			second.Show();
			Hide();
		}
	}
}
