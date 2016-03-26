/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 05.03.2016
 * Время: 1:28
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LifeSafety
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{

		string[] str = new string[]{
			"Прогноз взрыва конденсированного ВзВ",
			"Прогноз взрыва паро-, газовоздушных смесей в помещении",
			"Прогноз взрыва паро, газовоздушных смесей не в помещении",
			"Прогноз ядерного взрыва",
			"Прогноз химической обстановки"
		};
		string core = @"C:\Users\Глеб\Desktop\LifeSafety\Core\";
		string data = @"C:\Users\Глеб\Desktop\LifeSafety\Data\";
		string tables = @"C:\Users\Глеб\Desktop\LifeSafety\Tables\";
		string tasks = @"C:\Users\Глеб\Desktop\LifeSafety\Tasks\";
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			foreach (var arg1 in str)
			{
				comboBox1.Items.Add(arg1);
			}
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{

		}
		void Button2Click(object sender, EventArgs e)
		{

		}
		void Button3Click(object sender, EventArgs e)
		{

		}
		void Button4Click(object sender, EventArgs e)
		{

		}
		void Button5Click(object sender, EventArgs e)
		{

		}
		void Button7Click(object sender, EventArgs e)
		{
			Annex1 annex = new Annex1();
			annex.Show();
		}
		void Button8Click(object sender, EventArgs e)
		{
			Annex1 annex = new Annex1();
			annex.Show();
		}
		void Button9Click(object sender, EventArgs e)
		{
			Annex1 annex = new Annex1();
			annex.Show();
		}
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			panel1.Controls.Clear();
			if (comboBox1.SelectedItem.ToString() == str[0]){
				Form2 j = new Form2();
				j.TopLevel = false;
 				j.Visible = true;
      			j.FormBorderStyle = FormBorderStyle.None;
				j.Parent = panel1;
				j.Show();
			}
			if (comboBox1.SelectedItem.ToString() == str[1]){
				//createGraphicSolve2();
				Form1 j = new Form1();
				j.TopLevel = false;
 				j.Visible = true;
      			j.FormBorderStyle = FormBorderStyle.None;
				j.Parent = panel1;
				j.Show();
			}
			if (comboBox1.SelectedItem.ToString() == str[2]){
				
			}
			if (comboBox1.SelectedItem.ToString() == str[3]){
				
			}
			if (comboBox1.SelectedItem.ToString() == str[4]){
				
			}
		}
		void Button6Click(object sender, EventArgs e)
		{
			this.Close();
		}
		

	}
}
