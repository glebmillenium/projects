/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 30.05.2016
 * Время: 18:53
 * 
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace orphan_house
{
	/// <summary>
	/// Description of Added.
	/// </summary>
	public partial class Added : Form
	{
		public Added()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			if(checkBox1.Checked){
				dateTimePicker1.Enabled = true;
			}
			else{
				dateTimePicker1.Enabled = false;
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			int getIdHistory = DB.addHistoryId(textBox2.Text);
		}
	}
}
