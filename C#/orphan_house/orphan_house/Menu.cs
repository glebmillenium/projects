/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 30.05.2016
 * Время: 17:49
 * 
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace orphan_house
{
	/// <summary>
	/// Description of Menu.
	/// </summary>
	public partial class Menu : Form
	{
		string[] str = new string[]{
			"Добавить сироту",
			"Поиск",
			"Усыновление",
			"Статистика",
			"Добавить/изменить данные о ребенке",
			"Добавить/изменить пользователя"
		};
		public Menu(string name, int status)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			label1.Text = "Добро пожаловать, " + name;
			foreach (var arg1 in str)
			{
				comboBox1.Items.Add(arg1);
			}
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			label3.Text = DateTime.Today.ToString("D");

			button1.Image = Image.FromFile(@"C:\Users\Глеб\Desktop\orphan_house\Application\img\exit.bmp");
            button2.Image = Image.FromFile(@"C:\Users\Глеб\Desktop\orphan_house\Application\img\settings.bmp");
            
            var label = new Label(){
            	Location = new Point(20, 20),
            	Size = new Size(480, 300)
            };
            label.Text = "Данная программа предназначена для работников детского приюта, родителей и гостей,\n" +
							"интересующихся некоторыми данными о детях, которые находятся в приюте";
          
            panel1.Controls.Add(label);
		}
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			string st = comboBox1.SelectedItem.ToString();
			panel1.Controls.Clear();
			
			
			if(st == str[0]){
				Added t = new Added();
				t.TopLevel = false;
 				t.Visible = true;
      			t.FormBorderStyle = FormBorderStyle.None;
				t.Parent = panel1;
				t.Show();
			}
			if(st == str[1]){
				Search t = new Search();
				t.TopLevel = false;
 				t.Visible = true;
      			t.FormBorderStyle = FormBorderStyle.None;
				t.Parent = panel1;
				t.Show();
			}
			if(st == str[2]){
				Adoption t = new Adoption();
				t.TopLevel = false;
 				t.Visible = true;
      			t.FormBorderStyle = FormBorderStyle.None;
				t.Parent = panel1;
				t.Show();
			}
			if(st == str[3]){
				Statistics t = new Statistics();
				t.TopLevel = false;
 				t.Visible = true;
      			t.FormBorderStyle = FormBorderStyle.None;
				t.Parent = panel1;
				t.Show();
			}
			if(st == str[4]){
				Users t = new Users();
				t.TopLevel = false;
 				t.Visible = true;
      			t.FormBorderStyle = FormBorderStyle.None;
				t.Parent = panel1;
				t.Show();
			}
		}
	}
}
