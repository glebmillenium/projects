/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 13.03.2016
 * Время: 13:11
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace lab1_TVP
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		List <List <TextBox>> DataValues = new List<List<TextBox>>();
		WorkingProcess StartProcess = new WorkingProcess();
		bool rad1 = true, rad2 = false, rad3 = false;
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
		
		void head()
		{
			string[] str = new string[]{"№ п/п",
			                            "Выполнение процесса, сек.", 
			                            "Обслуживание процесса, сек.",
			                            "Приоритет процесса"};
			for(int i = 0, coor = 0; i < 4; i++, coor += 100)
			{
				var data = new Label(){
					Size = new Size(100, 40),
					Location = new Point(coor, 0),
					Text = str[i]
				};
				if(i == 0) {data.Size = new Size(20, 20); coor -= 50;}
				this.panel1.Controls.Add(data);
			}
		}
		
		void main_data()
		{
			for(int j = 1, high = 40; j <= Int32.Parse(textBox1.Text); j++, high += 40)
			{
				var rowData = new List <TextBox>();
				for(int i = 0, coor = 0; i < 4; i++, coor += 100)
				{
					if(i == 0) {
						var data = new Label(){
							Size = new Size(20, 20),
							Location = new Point(coor, high),
							Text = j.ToString()
						};
						coor -= 50;
						this.panel1.Controls.Add(data);
					}
					else 
					{
						var data = new TextBox(){
							Size = new Size(90, 40),
							Location = new Point(coor, high)
						};
						this.panel1.Controls.Add(data);
						rowData.Add(data);
					};
				}
				DataValues.Add(rowData);
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			textBox1.Enabled = false;
			button1.Enabled = false;
			button2.Enabled = true;
			panel2.Visible = true;
			head();
			main_data();
		}
		void Button2Click(object sender, EventArgs e)
		{
			textBox1.Enabled = true;
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Visible = false;
			panel1.Controls.Clear();
		}
		
		void createCollections()
		{
			var rows = new List<List <Label>>();
			int i = 1;
			int high = 40;
			var data = new int[textBox2.Text.Split(' ').Length];
			var data1 = new int[(DataValues.Count+1)];
			int k = 0;
			
			foreach(var val1 in textBox2.Text.Split(' '))
			{
				data[k] = Int32.Parse(val1) - 1;
				k++;
			}
			
			int l = 0;
			foreach(var val2 in DataValues)
			{
				var row = new List<Label>();
				row.Add(new Label(){
					Size = new Size(20, 20),
					Location = new Point(0, high),
					Text = i.ToString()
		        });
				foreach(var val3 in val2)
				{
					var val2_1 = new Label(){
						Text = val3.Text,
						Location = val3.Location,
						Size = val3.Size
					};
					row.Add(val2_1);
				}
				data1[l] = Int32.Parse(val2[2].Text);
				
				row.Add(new Label(){
				Size = new Size(40, 20),
				Location = new Point(80, high),
				Text = "0"
		        });
				row.Add(new Label(){
				Size = new Size(80, 20),
				Location = new Point(150, high),
				Text = "Очередь"
		        });
				row.Add(new Label(){
				Size = new Size(40, 20),
				Location = new Point(280, high),
				Text = "0"
		        });
				row.Add(new Label(){
				Text = "0"
		        });
				
				rows.Insert(i-1, row);
				i++;
				l++;
				high += 40;
			}

			StartProcess.ProcessData = rows;
			StartProcess.queue = data;
			StartProcess.prior = data1;
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			createCollections();
			StartProcess.myShow();
			if(rad1)
			{
				StartProcess.go(0);
			}
			if(rad2)
			{
				StartProcess.go(-1);
			}
			if(rad3)
			{
				StartProcess.go(1);
			}
		}
		void RadioButton1CheckedChanged(object sender, EventArgs e)
		{
			rad1 = true;
			rad2 = false;
			rad3 = false;
		}
		void RadioButton2CheckedChanged(object sender, EventArgs e)
		{
			rad1 = false;
			rad2 = true;
			rad3 = false;
		}
		void RadioButton3CheckedChanged(object sender, EventArgs e)
		{
			rad1 = false;
			rad2 = false;
			rad3 = true;
		}
	}
}
