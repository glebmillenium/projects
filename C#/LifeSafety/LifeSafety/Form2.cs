/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 27.03.2016
 * Время: 1:45
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
	/// Description of Form2.
	/// </summary>
	public partial class Form2 : Form
	{
		string core = @"C:\Users\Глеб\Desktop\LifeSafety\Core\";
		string data = @"C:\Users\Глеб\Desktop\LifeSafety\Data\";
		string tables = @"C:\Users\Глеб\Desktop\LifeSafety\Tables\";
		string tasks = @"C:\Users\Глеб\Desktop\LifeSafety\Tasks\";
		string[][] need_data; 
		List <Tuple<Label, CheckBox>> list_data = new List<Tuple<Label, CheckBox>>();
		public Form2()
		{
            InitializeComponent();
            need_data = (new WorkWithFile(tables + @"\Annex_1\table_5.bjd"))
			.writtingToArray(new char[]{'|', '|'});
            int high = 0;
            foreach(var arg in need_data)
            {
            	var data = new Label(){
						Size = new Size(400, 20),
						Location = new Point(0, high),
						Text = arg[0]
            	};
            	var data1 = new CheckBox(){
						Size = new Size(20, 20),
						Location = new Point(400, high),
            	};
            	high += 20;
            	panel1.Controls.Add(data);
            	panel1.Controls.Add(data1);
            	list_data.Add(Tuple.Create(data, data1));
            }
            
            R = 0;
            M = 0;
            P = 0;
        }

        double R, M, P;
        string str = "";
        
        private void button1_Click(object sender, EventArgs e)
        {
            Double.TryParse(textBox1.Text, out R);
            Double.TryParse(textBox2.Text, out M);
            Double.TryParse(textBox3.Text, out P);
            
            Solve1 obj = new Solve1();
            Solve1.Raschet1(R, M, P, obj);
            double temp = obj.dRf * 0.01019716212978;
            str = "-----------------------------------------------\n";
            foreach(var arg in list_data)
            {
            	if(arg.Item2.Checked)
            	{
            		foreach(var arg1 in need_data)
            		{
            			if(arg.Item1.Text == arg1[0])
            			{
	            			string[] mass1 = arg1[3].Split(new char[]{'-'}, StringSplitOptions.RemoveEmptyEntries);
	            			string[] mass2 = arg1[2].Split(new char[]{'-'}, StringSplitOptions.RemoveEmptyEntries);
	            			string[] mass3 = arg1[1].Split(new char[]{'-'}, StringSplitOptions.RemoveEmptyEntries);
	            			if(mass1.Length==1 || mass2.Length == 1 || mass1.Length == 1)
	            			{
	            				continue;
	            			}
	            			if (temp >= Double.Parse(mass1[0]) && temp <= Double.Parse(mass1[1]))
	            			{
	            				str += arg.Item1.Text + ": слабое разрушение \n";
	            			}
	            			else
	            			{
	            				if (temp >= Double.Parse(mass2[0]) && temp <= Double.Parse(mass2[1]))
			        			{
			        				str += arg.Item1.Text + ":  среднее разрушение \n";
			        			}
	            				else
	            				{
	            					if (temp >= Double.Parse(mass3[0]) && temp <= Double.Parse(mass3[1]))
				        			{
				        				str += arg.Item1.Text + ": сильное разрушение \n";
				        			}
	            					else
	            					{
	            						str += arg.Item1.Text + ": разрушений нет \n";
	            					}
	            				}
	            			}
            			}
            		}
            	}
            }

            String st = String.Format("Люди, находящиеся на расстоянии {0:F2} м от эпицентра взрыва, получат увечья или могут быть убиты", obj.r2);
            MessageBox.Show(obj.ToString() + "\n" + st +"\n" + str);
                        
        }
	}
}
