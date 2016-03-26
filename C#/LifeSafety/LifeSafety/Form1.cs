/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 26.03.2016
 * Время: 23:11
 * 
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LifeSafety
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class Form1 : Form
	{
		string core = @"C:\Users\Глеб\Desktop\LifeSafety\Core\";
		string data = @"C:\Users\Глеб\Desktop\LifeSafety\Data\";
		string tables = @"C:\Users\Глеб\Desktop\LifeSafety\Tables\";
		string tasks = @"C:\Users\Глеб\Desktop\LifeSafety\Tasks\";
		public Form1()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			string[][] need_data = (new WorkWithFile(data + "table_6.bjd")).writtingToArray(new char[]{'|', '|'});
			foreach (var arg in need_data)
			{
				comboBox1.Items.Add(arg[0]);
			}
            
            comboBox2.Items.Add("Открытая местность");
            comboBox2.Items.Add("Гор. застройка/Лес");
            comboBox3.Items.Add("Инверсия");
            comboBox3.Items.Add("Конвекция");
            comboBox3.Items.Add("Изотермия");

            R = 0;
            M = 0;
            P = 0;
            k1 = 0;
            k2 = 0;
            Dm = 0;
            Vb = 0;
            Q0 = 0;
            substance = "";
            one = false;
        }

        double R, M, P, k1, k2, Vb, Dm, Q0;
        string substance;
        bool one;

        private void button1_Click(object sender, EventArgs e)
        {
            Double.TryParse(textBox1.Text, out R);
            Double.TryParse(textBox2.Text, out M);
            Double.TryParse(textBox3.Text, out P);
            Double.TryParse(textBox4.Text, out Vb);

            Solve2 test = new Solve2();
            bool secondPart = false;
            if (checkBox1.Checked == true) {
                secondPart = true;
                //ПО ТАБЛИЦЕ НАХОДИМ Dm 4 табл приложение 1.
                //Токсодоза Вещества Смертельная
                Dm = 3.2;
            }

			string[][] need_data = (new WorkWithFile(data + "table_6.bjd")).writtingToArray(new char[]{'|', '|'});
			
			foreach(var arg in need_data)
			{
				if (arg[0] == substance)
				{
					Double.TryParse(arg[1], out Q0);
					break;
				}
			}
			
            Solve2.Raschet2(R, M, Q0, P, one, test, k1, k2, Vb, Dm, secondPart);
            //test.U
			need_data = (new WorkWithFile(tables + @"\Annex_1\table_2.bjd")).writtingToArray(new char[]{'|', '|'});
			string str1 = "";
			string str2 = "";
			foreach (var arg1 in need_data)
			{
				string[] mass1 = arg1[1].Split(new char[]{'-'}, StringSplitOptions.RemoveEmptyEntries);
				string[] mass2 = arg1[2].Split(new char[]{'-'}, StringSplitOptions.RemoveEmptyEntries);
				
				if(test.U >= Double.Parse(mass1[0]) && test.U <= Double.Parse(mass1[1]))
				{
					str1 += arg1[0] + ": Обугливание \n";
				}
				else 
				{
					if(test.U >= Double.Parse(mass2[0]))
					{
						str1 += arg1[0] + ": Устойчивое горение\n";
					}
					else{
						str1 += arg1[0] + ": Нет эффекта\n";
					}
				}
			}
			
			need_data = (new WorkWithFile(tables + @"\Annex_1\table_3.bjd")).writtingToArray(new char[]{'|', '|'});
			foreach(var arg1 in need_data)
			{
				string[] mass;
				if (arg1[2].Contains(">"))
				{
					mass = arg1[2].Split(new char[]{'>'}, StringSplitOptions.RemoveEmptyEntries);
				}
				else
				{
					mass = arg1[2].Split(new char[]{'-'}, StringSplitOptions.RemoveEmptyEntries);
				}
				
				if( test.U >= Double.Parse(mass[0]) && test.U <= Double.Parse(mass[1]))
				{
					str2 += arg1[3] + " " + arg1[4] + "\n";
				}
			}
			if(str2 == "") {str2 = "Пострадавших от ожогов нет";}
            MessageBox.Show(test.ToString() + "\n--------------------------------------------------------------------------------\n" + str1 + 
			               "\n--------------------------------------------------------------------------------\n" + str2);

            if (secondPart) MessageBox.Show("Радиус зоны токсичного задымления, м: " + test.R3);
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            one = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            one = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString() == "Инверсия") k2 = 1;
            if (comboBox3.SelectedItem.ToString() == "Конвекция") k2 = 1.5;
            if (comboBox3.SelectedItem.ToString() == "Изотермия") k2 = 2;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "Открытая местность") k1 = 1;
            if (comboBox2.SelectedItem.ToString() == "Гор. застройка/Лес") k1 = 3.5;
        }

   
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            substance = comboBox1.SelectedItem.ToString();
        }
	}
}
