/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 12.03.2016
 * Время: 2:24
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.FSharp.Collections;

namespace LAB1_TI
{
	/// <summary>
	/// Description of SecondTask.
	/// </summary>
	public partial class SecondTask : Form
	{
		int n;
		int m;
		
		List<List<TextBox>> TextboxsConditionalProbability = new List<List <TextBox>>();
		List<List<TextBox>> TextboxsProbability = new List<List <TextBox>>();
		public SecondTask()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		void head(){
			var one_data = new Label();
			one_data.Size = new Size(30, 20);
			one_data.Location = new Point(0, 0);
			one_data.Text = "Y|X";
			this.panel1.Controls.Add(one_data);
			
			int coor = 30;
			for (int i = 1; i <= this.n; i++)
			{
				var data = new Label(){
					Size = new Size(30, 20),
					Location= new Point(coor, 0),
					Text = "p_x" + i
				};
				this.panel1.Controls.Add(data);
				coor += 30;
			}
			
			var end_data = new Label() {
				Size = new Size(30, 20),
				Location = new Point(coor, 0),
				Text = "   P"
			};
			this.panel1.Controls.Add(end_data);
		}
		
		void main_data()
		{
			int coor2 = 30;
			var conditional1 = new List <TextBox>();
			for (int i = 1; i <= this.m; i++)
			{
				var one_data = new Label(){
					Size = new Size(30, 20),
					Location= new Point(0, coor2),
					Text = "p_y" + i
				};
				this.panel1.Controls.Add(one_data);
				var row = new List <TextBox>();
				for (int j = 1, coor1 = 30; j <= this.n; j++, coor1 += 30)
				{
					var data = new TextBox(){
					Size = new Size(30, 20),
					Location= new Point(coor1, coor2),
					};
					this.panel1.Controls.Add(data);
					row.Add(data);
				}
				var end_data = new TextBox(){
				Size = new Size(30, 20),
				Location= new Point(30 * (this.n + 1), coor2),
				};
				this.panel1.Controls.Add(end_data);
				conditional1.Add(end_data);
				coor2 += 30;
				this.TextboxsConditionalProbability.Add(row);
			}
			this.TextboxsProbability.Add(conditional1);
			
			var low_data = new Label(){
				Size = new Size(30, 20),
				Location= new Point(0, 30 * (this.m + 1)),
				Text = "P*"
			};
			this.panel1.Controls.Add(low_data);
			var conditional2 = new List <TextBox>();
			for (int i = 1; i <= this.n; i++)
			{
				var lower_data = new TextBox(){
					Size = new Size(30, 20),
					Location= new Point(30 * i, 30 * (this.m + 1)),
				};
				this.panel1.Controls.Add(lower_data);
				conditional2.Add(lower_data);
			}
			this.TextboxsProbability.Add(conditional2);
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			button1.Enabled = false;
			button2.Enabled = true;
			button3.Enabled = true;
			this.n = Int32.Parse(textBox2.Text);
			this.m = Int32.Parse(textBox1.Text);
			head();
			main_data();
		}
		void Button2Click(object sender, EventArgs e)
		{
			button1.Enabled = true;
			button2.Enabled = false;
			button3.Enabled = false;
			this.TextboxsProbability.Clear();
			this.TextboxsConditionalProbability.Clear();
			panel1.Controls.Clear();
			label3.Text = "";
		}
		void Button3Click(object sender, EventArgs e)
		{
			label3.Text = "";
			FSharpList <FSharpList <double>>[] conditional_probability = new FSharpList<FSharpList<double>>[2];
			FSharpList<double>[] probability = new FSharpList<double>[2];
			conditional_probability[0] = FSharpList <FSharpList <double>>.Empty;
			conditional_probability[1] = FSharpList <FSharpList <double>>.Empty;
			probability[0] = FSharpList<double>.Empty;
			probability[1] = FSharpList<double>.Empty;
			
			
			foreach(var val1 in TextboxsConditionalProbability)
			{
				var temporary_list = FSharpList<double>.Empty;
				foreach(var val2 in val1)
				{
					temporary_list = new FSharpList<double>(double.Parse(val2.Text),temporary_list);
				}
				conditional_probability[0] = new FSharpList<FSharpList<double>>(temporary_list,conditional_probability[0]);
			}
			
			for(int i = 0; i < this.n; i++)
			{
				var temporary_list = FSharpList<double>.Empty;
				foreach(var val1 in TextboxsConditionalProbability)
				{
					int t = 0;
					foreach(var val2 in val1)
					{
						if(t == i)
						{
							temporary_list = new FSharpList<double>(double.Parse(val2.Text),temporary_list);
							break;
						}
						t++;
					}
				}
				conditional_probability[1] = new FSharpList<FSharpList<double>>(temporary_list,conditional_probability[1]);
			}
			
			int l = 0;
			foreach(var val1 in TextboxsProbability)
			{
				foreach(var val2 in val1)
				{
					probability[l] = new FSharpList<double>(double.Parse(val2.Text),probability[l]);
				}
				l++;
			}
			label3.Text += "  Энтропия объединенных систем: \n";
			
			label3.Text += "Энтропия для H(X,Y) = " + counting_entropy.Entropy.count_entropy2(conditional_probability[0],probability[0]) + "\n";
			
			label3.Text += "Энтропия для H(Y,X) = " + counting_entropy.Entropy.count_entropy2(conditional_probability[1],probability[1]);
		}
	}
}
