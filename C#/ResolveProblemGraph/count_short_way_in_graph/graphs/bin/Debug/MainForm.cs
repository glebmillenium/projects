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
        bool openColor = false;
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


		}

		void CheckBox1Click(object sender, EventArgs e)
		{
			if (checkBox2.Checked)
			{
				checkBox2.Checked = false;
			}
		}
		void CheckBox2Click(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				checkBox1.Checked = false;
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
			textBox3.Text = "";
			int minimal = int.Parse(result.Head.Item2.ToString());
            
			foreach (var iter1 in result)
			{
                textBox3.Text += "Путь: " + start + " ";
				foreach (var iter2 in iter1.Item1)
				{
                    textBox3.Text += iter2 + " ";
				}
                if (iter1.Item2 < minimal)
                {
                    minimal = iter1.Item2;
                }
                textBox3.Text += "\n Длина: " + iter1.Item2 + "\n" + Environment.NewLine;
			}

            List<int> wayMinimum = new List<int>();
            foreach (var iter1 in result)
            {
                
                if (iter1.Item2 == minimal)
                {
                    wayMinimum.Clear();
                    wayMinimum.Add(start);
                    textBox4.Text = "Путь: " + start + " ";
                    foreach (var iter2 in iter1.Item1)
                    {
                        wayMinimum.Add(iter2);
                        textBox4.Text += iter2 + " ";
                    }
                    repaint();
                    drawChoosedLine(wayMinimum);
                    textBox4.Text += "\n Длина:" + iter1.Item2 + "\n" + Environment.NewLine;
                    break;
                }

            }


		}

        private void drawChoosedLine(List<int> wayMinimum)
        {

            if(wayMinimum.Count > 1)
            {
                int x1, x2, y1, y2;
                var line = panel1.CreateGraphics();
                var myPen = new Pen(Color.Red, 3);
                IEnumerable<int> search;
                for (int i = 1; i < wayMinimum.Count; i++)
                {
                    search = from link in Links
                                where link.A == wayMinimum[i - 1] && link.B == wayMinimum[i]
                                select link.coor_A_x;
                    x1 = search.First();

                    search = from link in Links
                             where link.A == wayMinimum[i - 1] && link.B == wayMinimum[i]
                             select link.coor_A_y;
                    y1 = search.First();

                    search = from link in Links
                             where link.A == wayMinimum[i - 1] && link.B == wayMinimum[i]
                             select link.coor_B_x;
                    x2 = search.First();
                    search = from link in Links
                             where link.A == wayMinimum[i - 1] && link.B == wayMinimum[i]
                             select link.coor_B_y;
                    y2 = search.First();
                    double ugol = Math.Atan2(x1 - x2, y1 - y2);
                    line.DrawLine(myPen, x1, y1, x2, y2);
                    if(radioButton1.Checked){
	                    line.DrawLine(myPen, x2, y2, Convert.ToInt32(x2 + 15 * Math.Sin(0.3 + ugol)), Convert.ToInt32(y2 + 15 * Math.Cos(0.3 + ugol)));
	                    line.DrawLine(myPen, x2, y2, Convert.ToInt32(x2 + 15 * Math.Sin(ugol - 0.3)), Convert.ToInt32(y2 + 15 * Math.Cos(ugol - 0.3)));
                    }
                }
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
							line.DrawLine(myPen, pero_x1, pero_y1, 
							              pero_x2, pero_y2);
						}
						else
						{
							pero_x1 = this.temp.first - 10;
							pero_y1 = this.temp.second;
							pero_x2 = node.centr.first + 10;
			            	pero_y2 = node.centr.second;
							line.DrawLine(myPen, pero_x1, pero_y1,
                                          pero_x2, pero_y2);
						}
			
			            double ugol = Math.Atan2(pero_x1 - pero_x2, pero_y1 - pero_y2);
			            if(radioButton1.Checked){
				            line.DrawLine(myPen, pero_x2, pero_y2, Convert.ToInt32(pero_x2 + 15*Math.Sin(0.3 + ugol)), Convert.ToInt32(pero_y2 + 15*Math.Cos(0.3 + ugol)));
				            line.DrawLine(myPen, pero_x2, pero_y2, Convert.ToInt32(pero_x2 + 15 * Math.Sin( ugol - 0.3)), Convert.ToInt32(pero_y2 + 15 * Math.Cos(ugol - 0.3)));
			            }
			            var value = new TextBox();
			            value.Size = new Size(20, 20);
			            value.Location = new Point((this.temp.first + node.centr.first)/2,
			                          (this.temp.second + node.centr.second)/2);
			            panel1.Controls.Add(value);
			            value.Text = "0";
			            Links.Add(new SnippetConnect() { 
			                      	A = this.temp.zero,
			                      	B = node.id,
                                    coor_A_x = pero_x1,
                                    coor_A_y = pero_y1,
                                    coor_B_x = pero_x2,
                                    coor_B_y = pero_y2,
                                    line = value
			                      });
						checkBox1.Enabled = true;
						checkBox2.Enabled = true;
						this.temp = null;
					}
					break;
                  }
			}
		}


        void repaint()
        {
            panel1.Invalidate();
            var circle = panel1.CreateGraphics();
            var myPen = new Pen(Color.Black);


            foreach (var link in this.Links)
            {
                double ugol = Math.Atan2(link.coor_A_x - link.coor_B_x, link.coor_A_y - link.coor_B_y);
                if(radioButton1.Checked){
	                circle.DrawLine(myPen, link.coor_B_x, link.coor_B_y, Convert.ToInt32(link.coor_B_x + 15 * Math.Sin(0.3 + ugol)), Convert.ToInt32(link.coor_B_y + 15 * Math.Cos(0.3 + ugol)));
	                circle.DrawLine(myPen, link.coor_B_x, link.coor_B_y, Convert.ToInt32(link.coor_B_x + 15 * Math.Sin(ugol - 0.3)), Convert.ToInt32(link.coor_B_y + 15 * Math.Cos(ugol - 0.3)));
                }
                circle.DrawLine(myPen, link.coor_A_x, link.coor_A_y, link.coor_B_x, link.coor_B_y);
                panel1.Controls.Add(link.line);
            }
            double ug = Math.Atan2(Links[0].coor_A_x - Links[0].coor_B_x, Links[0].coor_A_y - Links[0].coor_B_y);
            circle.DrawLine(myPen, Links[0].coor_A_x, Links[0].coor_A_y, Links[0].coor_B_x, Links[0].coor_B_y);
            if(radioButton1.Checked){
	            circle.DrawLine(myPen, Links[0].coor_B_x, Links[0].coor_B_y, Convert.ToInt32(Links[0].coor_B_x + 15 * Math.Sin(0.3 + ug)), Convert.ToInt32(Links[0].coor_B_y + 15 * Math.Cos(0.3 + ug)));
	            circle.DrawLine(myPen, Links[0].coor_B_x, Links[0].coor_B_y, Convert.ToInt32(Links[0].coor_B_x + 15 * Math.Sin(ug - 0.3)), Convert.ToInt32(Links[0].coor_B_y + 15 * Math.Cos(ug - 0.3)));
            }
            foreach (var node in this.Nodes)
            {
                circle.DrawEllipse(myPen,
                 new Rectangle(node.x.first,
                               node.y.first, 30, 30));
                if (openColor) {
                    SolidBrush solidBrush = new SolidBrush(
                    node.color);
                    circle.FillRectangle(solidBrush, new Rectangle (node.x.first, node.y.first, 8, 8));
                }
                circle.DrawString(node.id.ToString(),
                                new Font("Arial", 10),
                                new SolidBrush(Color.Black),
                                new Rectangle(node.x.first + 7,
                                              node.y.first + 7,
                                              30, 30));
            }
            openColor = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Nodes.Clear();
            Links.Clear();
            panel1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            repaint();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            MessageBox.Show("Выбран файл: " + saveFileDialog1.FileName);

        }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            MessageBox.Show("Выбран файл: " + openFileDialog1.FileName);
        }
        private void button4_Click(object sender, EventArgs e) {
            SnippetConnect temp = null;
            for (int k = 0; k < this.Links.Count; k++)
            {
                for (int i = 1; i < this.Links.Count; i++)
                {
                    if (Int32.Parse(Links[i - 1].line.Text) > Int32.Parse(Links[i].line.Text))
                    {
                        temp = Links[i - 1];
                        Links[i - 1] = Links[i];
                        Links[i] = temp;
                    }
                }
            }
            List<int> graph_left = new List<int>();
            List<int> graph_right = new List<int>();
            graph_left.Add(Links[0].A);
            graph_right.Add(Links[0].B);
            int check;
            for (int k = 0; k < Links.Count; k++)
            {
                int check2 = 0;
                for (int i = 0; i < Links.Count; i++)
                {
                    check = 0;
                    if (graph_left.Contains(Links[i].A) ||
                       graph_right.Contains(Links[i].A)) check++;
                    if (graph_left.Contains(Links[i].B) ||
                       graph_right.Contains(Links[i].B)) check++;
                    if (check < 2 && check != 0) {
                        
                        graph_left.Add(Links[i].A);
                        graph_right.Add(Links[i].B);
                        if (check2 == 1) break;
                    }
                    if(check == 0)
                    {
                        check2 = 1;
                    }
                }
            }
        	List<Tuple<int, int, int, int>> search;
            var circle = panel1.CreateGraphics();
            var myPen = new Pen(Color.Red, 3);
            int summ = 0;
        	for (int i = 0; i < graph_left.Count; i++)
            {
                var sr = from link in Links
                	where (link.A == graph_left[i] && link.B == graph_right[i] || 
                	       link.A == graph_right[i] && link.B == graph_left[i])
                	select new Tuple<int, int, int, int, int>(link.coor_A_x, link.coor_A_y, link.coor_B_x, link.coor_B_y, Int32.Parse(link.line.Text));
                Tuple<int, int, int, int, int> tuple = sr.First();
			
                circle.DrawLine(myPen, tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
                summ += tuple.Item5;
            }
            textBox4.Text = "Суммарная длина кратчайшего остового дерево L=" + summ;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<Color> colors = new List<Color>();
            colors = addColor(colors);
            List<Tuple<int, Color>> dot_color = new List<Tuple<int, Color>>();
            foreach(var node in Nodes)
            {
                var query = from link in Links
                            where link.A == node.id
                            select link.B;
                var dd = query.ToList() ;
                var query2 = from link in Links
                             where link.B == node.id
                             select link.A;
                var ff = query2.ToList();
                dd.AddRange(ff);
                List<Color> temporaryColors = new List<Color>(colors);
                int count = dd.Count();
                for(int i = 0; i < count; i++)
                {
                    var qu = from dot in dot_color
                             where dot.Item1 == dd.ElementAt(i)
                             select dot.Item2;
                    int cd = qu.Count();
                    if(cd > 0) {
                        temporaryColors.Remove(qu.First());
                    }
                }
                if(temporaryColors.Count == 0)
                {
                    colors = addColor(colors);
                    node.color = colors.Last();
                    dot_color.Add(new Tuple<int, Color>(node.id, colors.Last()));

                } else
                {
                    node.color = temporaryColors.First();
                    dot_color.Add(new Tuple<int, Color>(node.id, node.color));
                }
            }
            openColor = true;
            textBox4.Text = "Минимальное количество цветов для раскраски графа: " + colors.Count;
            repaint();
        }

        private int getIndex(int uzel, List<int> dot)
        {
            int res = -1;
            int i = 0;
            foreach(var kl in dot)
            {
                if (kl == uzel) { res = i; break; }
            }
            return res;
        }

        private List<Color> addColor(List<Color> colors)
        {
            Random random = new Random();
            int r, g, b;
            bool notGet = true;
            Color color;
            while(notGet)
            {
                r = random.Next(byte.MaxValue);
                g = random.Next(byte.MaxValue);
                b = random.Next(byte.MaxValue);
                color = Color.FromArgb(r, g, b);
                if (!colors.Contains(color))
                {
                    notGet = false;
                    colors.Add(color);
                }
            }
            return colors;
        }
    }
}
