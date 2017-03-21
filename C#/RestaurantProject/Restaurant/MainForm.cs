/*
 * Created by SharpDevelop.
 * User: Глеб
 * Date: 06.06.2015
 * Time: 21:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Restaurant
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		public MainForm()
		{
			InitializeComponent();
			comboBox1.SelectedItem = "Гость";
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
		}

		void Button3Click(object sender, EventArgs e)
		{
			this.SetVisibleCore(false);
			if(comboBox1.SelectedItem.ToString() == "Гость"){
				(new Form1(0)).ShowDialog();
			}
			if(comboBox1.SelectedItem.ToString() == "Шеф-повар"){
				(new Form1(1)).ShowDialog();
			}
			if(comboBox1.SelectedItem.ToString() == "Управляющий"){
				(new Form1(2)).ShowDialog();
			}
			this.SetVisibleCore(true);
		}
	}
}
