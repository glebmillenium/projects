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
	/// Description of Search.
	/// </summary>
	public partial class Search : Form
	{
		string[] str = new string[]{
			"Поиск ребенка по ФИО",
			"Поиск пользователя по логину",
			"Поиск зарегистрированного взрослого человека"
		};
		public Search()
		{
			InitializeComponent();
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			foreach (var arg1 in str)
			{
				comboBox1.Items.Add(arg1);
			}
			comboBox1.SelectedItem = str[0];
			listBox1.Items.Add(str[0]);
			listBox1.Items.Add(str[1]);
		}
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			if(comboBox1.SelectedItem.ToString() == str[0]){
				label1.Text = "ФИО(*)";
			}
			if(comboBox1.SelectedItem.ToString() == str[1]){
				label1.Text = "Логин";
			}
			if(comboBox1.SelectedItem.ToString() == str[2]){
				label1.Text = "ФИО(*)";
			}
		}
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			textBox1.Text = listBox1.SelectedItem.ToString();
		}
		void Button1Click(object sender, EventArgs e)
		{
			if(comboBox1.SelectedItem.ToString() == str[0]){
				DB.searchChildren(textBox1.Text);
			}
			if(comboBox1.SelectedItem.ToString() == str[1]){
				DB.searchLogin(textBox1.Text);
			}
			if(comboBox1.SelectedItem.ToString() == str[2]){
				DB.searchAdult(textBox1.Text);
			}
		}
			
	}
}
