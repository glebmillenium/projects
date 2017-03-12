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
		List<Tuple<int, int>> typeObj1 = new List<Tuple<int, int>>();
		List<Tuple<int, int>> typeObj2 = new List<Tuple<int, int>>();
		Tuple<int, int> middleSamples_1 = new Tuple<int, int>(0, 0);
		Tuple<int, int> middleSamples_2 = new Tuple<int, int>(0, 0);

		public MainForm()
		{
			InitializeComponent();
		}
		void Panel1Click(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
				drawNode1();

			if (checkBox2.Checked)
				drawNode2();
			if(checkBox3.Checked)
				defineRelativeObject();
		}

		void defineRelativeObject(){
			panel1.CreateGraphics().Clear(Color.WhiteSmoke);
			repaintGraphic();
			var coords_cursor_mouse = panel1.PointToClient(Control.MousePosition);
			double l1 = Math.Sqrt(Math.Pow((middleSamples_1.Item1 - coords_cursor_mouse.X), 2) + Math.Pow((middleSamples_1.Item2 - coords_cursor_mouse.Y), 2));
			double l2 = Math.Sqrt(Math.Pow((middleSamples_2.Item1 - coords_cursor_mouse.X), 2) + Math.Pow((middleSamples_2.Item2 - coords_cursor_mouse.Y), 2));
			if(l1 < l2) label3.Text = "Объект принадлежит типу 1: " + "Расстояние до усредненного значения:" + Math.Round(l1, 2);
			else label3.Text = "Объект принадлежит типу 2. " + "Расстояние до усредненного значения:" + Math.Round(l1, 2);
			var circle = panel1.CreateGraphics();
			var myPen = new Pen(Color.Black);
			circle.DrawEllipse(new Pen(Color.Black),
			                 new Rectangle(coords_cursor_mouse.X-15, 
			                               coords_cursor_mouse.Y-15, 10, 10));
			
			
		}
		
		void defineMiddleSample(List<Tuple<int, int>> obj, int i){
			double res_x = 0;
			double res_y = 0;
			foreach(var val in obj)
			{
				res_x += val.Item1;
				res_y += val.Item2;
			}
			res_x = res_x / obj.Count;
			res_y = res_y / obj.Count;
			string str = "Средняя точка для первого типа объекта: " + Math.Round(res_x, 2) + ":" + Math.Round(res_y, 2);
			
			if(i == 1){
				middleSamples_1 = new Tuple<int, int>((int)res_x, (int)res_y);
				label1.Text = str;
			}
			else{
				middleSamples_2 = new Tuple<int, int>((int)res_x, (int)res_y);
				label2.Text = str;
			}
		}
		
		void drawNode1()
		{
			var coords_cursor_mouse = panel1.PointToClient(Control.MousePosition);

			typeObj1.Add(new Tuple<int, int>(coords_cursor_mouse.X, coords_cursor_mouse.Y));
			defineMiddleSample(typeObj1, 1);
			repaintGraphic();
		}
		
		void drawNode2()
		{
			var coords_cursor_mouse = panel1.PointToClient(Control.MousePosition);

			
			typeObj2.Add(new Tuple<int, int>(coords_cursor_mouse.X, coords_cursor_mouse.Y));
			defineMiddleSample(typeObj2, 2);
			repaintGraphic();
		}
		
		void repaintGraphic(){
			panel1.CreateGraphics().Clear(Color.WhiteSmoke);
			foreach(var val in typeObj1){
				var circle = panel1.CreateGraphics();
				var myPen = new Pen(Color.Black);
				circle.FillRectangle(new SolidBrush(Color.Red), 
				                 new Rectangle(val.Item1-15, 
				                               val.Item2-15, 10, 10));
				var text = val.Item1.ToString() + ":" +val.Item2;
				circle.DrawString(text, 
				                  new Font("Arial", 7), 
				                new SolidBrush(Color.Black), 
				                new Rectangle(val.Item1-7, 
				                              val.Item2-5,
				                              40, 30));
			}
			foreach(var val in typeObj2){
				var circle = panel1.CreateGraphics();
				var myPen = new Pen(Color.Black);
				circle.FillEllipse(new SolidBrush(Color.Blue), 
				                 new Rectangle(val.Item1-15, 
				                               val.Item2-15, 10, 10));
				var text = val.Item1.ToString() + ":" +val.Item2;
				circle.DrawString(text, 
				                  new Font("Arial", 7), 
				                new SolidBrush(Color.Black), 
				                new Rectangle(val.Item1-7, 
				                              val.Item2-5,
				                              40, 30));
			}
			
			var p = panel1.CreateGraphics();
			p.DrawRectangle(new Pen(Color.Red), 
			                new Rectangle(middleSamples_1.Item1-15,
                   		    middleSamples_1.Item2-15, 5, 5));
			p.DrawEllipse(new Pen(Color.Blue), 
		                  new Rectangle(middleSamples_2.Item1-15,
                   		  middleSamples_2.Item2-15, 5, 5));
			
			var x_mid = (double)(middleSamples_1.Item1 + middleSamples_2.Item1) / 2;
			var y_mid = (double)(middleSamples_1.Item2 + middleSamples_2.Item2) / 2;
			
			var a = (double)(middleSamples_2.Item2 - middleSamples_1.Item2) / (double)(middleSamples_2.Item1 - middleSamples_1.Item1);
			
			if(a != 0 && typeObj1.Count != 0 && typeObj2.Count != 0){
				var b = (double)(y_mid + (double)(x_mid / a));
				var y_top = b;
				var x_top = 0;
				var y_bot = (double)-469/a + b;
				var x_bot = 469;
				p.DrawLine(new Pen(Color.Black), (int)x_top, (int)y_top, (int)x_bot, (int)y_bot);
			}
		}
		
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			checkBox2.Checked = false;
			checkBox3.Checked = false;
		}
		void CheckBox2CheckedChanged(object sender, EventArgs e)
		{
			checkBox1.Checked = false;
			checkBox3.Checked = false;
		}
		void CheckBox3CheckedChanged(object sender, EventArgs e)
		{
			checkBox1.Checked = false;
			checkBox2.Checked = false;
		}

	}
}
