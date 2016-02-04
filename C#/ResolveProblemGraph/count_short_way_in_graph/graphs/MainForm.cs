/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 27.01.2016
 * Время: 23:58
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.FSharp.Collections;
using System.Linq;

namespace graphs
{
	public partial class MainForm : Form
	{
		Snippet temp = null;
		int count_node = 0;
		List<Node> Nodes = new List<Node>();
		List<SnippetConnect> Links = new List<SnippetConnect>();
		
		public MainForm()
		{
			InitializeComponent();
		}
		void Panel1Click(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
				drawNode();

			if (checkBox2.Checked)
				drawLine();

			if (checkBox3.Checked)
			{
				
			}
		}

		void CheckBox1Click(object sender, EventArgs e)
		{
			if (checkBox2.Checked || checkBox3.Checked)
			{
				checkBox2.Checked = false;
				checkBox3.Checked = false;
			}
		}
		void CheckBox2Click(object sender, EventArgs e)
		{
			if (checkBox1.Checked || checkBox3.Checked)
			{
				checkBox1.Checked = false;
				checkBox3.Checked = false;
			}
		}
		void CheckBox3Click(object sender, EventArgs e)
		{
			if (checkBox1.Checked || checkBox2.Checked)
			{
				checkBox1.Checked = false;
				checkBox2.Checked = false;
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			int arg0 = Int32.Parse(textBox1.Text);
			int arg1 = Int32.Parse(textBox2.Text);
			
			FSharpList<FSharpList<Tuple<int, int>>> arg2 = createList();
				//Tuple<int, int> one = new Tuple<int, int>(1, 2);
				//Tuple<int, int> two = new Tuple<int, int>(2, 7);
				//Tuple<int, int> three = new Tuple<int, int>(2, 3);
				//arg2 = SeqModule.ToList(new List<FSharpList<Tuple<int,int>>>{SeqModule.ToList(new List<Tuple<int,int>>(){one, two}), SeqModule.ToList(new List<Tuple<int,int>>(){three})});
			FSharpList<int> arg3 = FSharpList<int>.Empty;
			FSharpList<Tuple<FSharpList<int>, int>> result = Graph.search_short_way(arg0, arg1, arg2, arg3, arg0);
			outputResult(result, arg0);
		}

		FSharpList<FSharpList<Tuple<int, int>>> createList()
		{
			FSharpList<Tuple<int, int>> list;
			FSharpList<FSharpList<Tuple<int, int>>> result = 
				FSharpList<FSharpList<Tuple<int, int>>>.Empty;
			
			for (int i = (count_node - 1); i >= 0; i--)
			{
				var subset = from Link in Links
							 where Link.A == i
							 select new Tuple<int, int>(Link.B, Int32.Parse(Link.line.Text));
				list = SeqModule.ToList(subset);
				result = new FSharpList<FSharpList<Tuple<int, int>>>(list, result);
			}
			
			return result;
		}
		
		void outputResult(FSharpList<Tuple<FSharpList<int>, int>> result, int start)
		{
			label3.Text = "";
			foreach (var iter1 in result)
			{
				label3.Text += "Путь: " + start + " ";
				foreach (var iter2 in iter1.Item1)
				{
					label3.Text += iter2 + " ";
				}
				label3.Text += "\n Длина:" + iter1.Item2 + "\n";
			}
		}
		
		void drawNode()
		{
			var coords_cursor_mouse = panel1.PointToClient(Control.MousePosition);
			var circle = panel1.CreateGraphics();
			var myPen = new Pen(Color.Black);
			circle.DrawEllipse(myPen, 
			                 new Rectangle(coords_cursor_mouse.X-15, 
			                               coords_cursor_mouse.Y-15, 30, 30));
			circle.DrawString(count_node.ToString(), 
			                new Font("Arial", 10), 
			                new SolidBrush(Color.Black), 
			                new Rectangle(coords_cursor_mouse.X-7, 
			                              coords_cursor_mouse.Y-7,
			                              30, 30));
			Node node = new Node(count_node, circle, coords_cursor_mouse.X-15, 
			                     			coords_cursor_mouse.X+15,
			                      			coords_cursor_mouse.Y-15, 				                               
			                               	coords_cursor_mouse.Y+15,
			                               	count_node.ToString());
			Nodes.Add(node);
			
			this.count_node++;
		}
		
		void drawLine()
		{
			var coords_cursor_mouse = panel1.PointToClient(Control.MousePosition);
			foreach (Node node in Nodes)
			{
				if (node.belongToNode(coords_cursor_mouse.X, 
				                      coords_cursor_mouse.Y))
                {
					if (this.temp == null) 
					{
						this.temp = new Snippet(){ 
							zero = node.id,
							first = node.centr.first,
							second = node.centr.second,
						};
						checkBox1.Enabled = false;
						checkBox2.Enabled = false;
						checkBox3.Enabled = false;
					}
					else
					{
						var line = panel1.CreateGraphics();
						var myPen = new Pen(Color.Black, 1);
						
						int pero_x1, pero_x2, pero_y1, pero_y2;
						if (this.temp.first < node.centr.first)
						{
							pero_x1 = this.temp.first + 10;
							pero_y1 = this.temp.second;
							pero_x2 = node.centr.first - 10;
			            	pero_y2 = node.centr.second;
							line.DrawLine(myPen, this.temp.first + 10, this.temp.second, 
							              node.centr.first - 10, node.centr.second);
						}
						else
						{
							pero_x1 = this.temp.first - 10;
							pero_y1 = this.temp.second;
							pero_x2 = node.centr.first + 10;
			            	pero_y2 = node.centr.second;
							line.DrawLine(myPen, this.temp.first - 10, this.temp.second, 
							              node.centr.first + 10, node.centr.second);
						}
			
			            double ugol = Math.Atan2(pero_x1 - pero_x2, pero_y1 - pero_y2);
						
			            line.DrawLine(myPen, pero_x2, pero_y2, Convert.ToInt32(pero_x2 + 15*Math.Sin(0.3 + ugol)), Convert.ToInt32(pero_y2 + 15*Math.Cos(0.3 + ugol)));
			            line.DrawLine(myPen, pero_x2, pero_y2, Convert.ToInt32(pero_x2 + 15 * Math.Sin( ugol - 0.3)), Convert.ToInt32(pero_y2 + 15 * Math.Cos(ugol - 0.3)));
			            var value = new TextBox();
			            value.Size = new Size(20, 20);
			            value.Location = new Point((this.temp.first + node.centr.first)/2,
			                          (this.temp.second + node.centr.second)/2);
			            panel1.Controls.Add(value);
			            value.Text = "0";
			            Links.Add(new SnippetConnect() { 
			                      	A = this.temp.zero,
			                      	B = node.id,
			                      	line = value
			                      });
						checkBox1.Enabled = true;
						checkBox2.Enabled = true;
						checkBox3.Enabled = true;
						this.temp = null;
					}
					break;
                  }
			}
		}
	}
}
