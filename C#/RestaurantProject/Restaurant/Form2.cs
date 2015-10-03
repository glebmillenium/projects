/*
 * Created by SharpDevelop.
 * User: Глеб
 * Date: 06.06.2015
 * Time: 21:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Restaurant
{
	/// <summary>
	/// Description of Form2.
	/// </summary>
	public partial class Form2 : Form
	{
		string MySQL_host = "localhost";
		string MySQL_port = "3306";
		string MySQL_uid = "root";
		string MySQL_pw = "root";
		string MySQL_db = "restaurant"; // coding of UTF-8(general_ci)
		string MySQL_tbname = "booking";
		private DataGridView bookingDataGridView = new DataGridView();
		
		public Form2()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			MySqlConnection Connection = new MySqlConnection("Data Source=" + MySQL_host + ";" +
			                                                 "Port=" + MySQL_port + ";" +
			                                                 "User Id=" + MySQL_uid + ";" +
			                                                 "Password=" + MySQL_pw + ";" +
				                                             "database=" + MySQL_db + ";");
			MySqlCommand Query = new MySqlCommand(); // It's object for connecting in db, and send any query
			Query.Connection = Connection; // definity object new connection user, pas, db etc.
			
			try
			{
			    Connection.Open();// Соединяемся
			    label12.BackColor=Color.Chartreuse;
			    label11.Text="Соединение с сервером установлено!";
			}
			catch (MySqlException SSDB_Exception)
			{
			    // Ошибка - выходим
			    label12.BackColor=Color.DarkRed;
			    label11.Text="Сервер базы данных не найден!"+SSDB_Exception;    
			}	
			
			SetupDataGridView();
        		Query.CommandText = "SELECT * FROM  dish;";
			MySqlDataReader MyReader = Query.ExecuteReader();// Запрос, подразумевающий чтение данных из таблиц.
			
			string[] str1= new string[256];
			string[] str2= new string[256];
	
	
			int i=0;
			DataGridViewComboBoxColumn comboBoxColumn =
	        new DataGridViewComboBoxColumn();
			
			while (MyReader.Read())
			{
			// Каждое значение вытягиваем с помощью MySqlDataReader.GetValue(<номер значения в выборке>);
	
			str1[i] += (MyReader.GetValue(1));
			str2[i] += (MyReader.GetValue(2));
			comboBoxColumn.Items.AddRange(str1[i]);
			i++;
			}
			
			for(i=0;i<20;i++)
			{
				bookingDataGridView.Rows[i].Cells[0].Value = i+1;
			}
			
	        bookingDataGridView.Columns.Add(comboBoxColumn);
	        bookingDataGridView.Columns[1].Name = "Наименование";
	        bookingDataGridView.Columns.Add("","Количество");
	        bookingDataGridView.Columns.Add("","Цена");
	
			MyReader.Close();
			Query.Dispose();
			Connection.Close();
			
		}
		
		private void bookingDataGridView_CellFormatting(object sender,
        System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
	    {
	        if (this.bookingDataGridView.Columns[e.ColumnIndex].Name == "Release Date")
	        {
	            if (e != null)
	            {
	                if (e.Value != null)
	                {
	                    try
	                    {
	                        e.Value = DateTime.Parse(e.Value.ToString())
	                            .ToLongDateString();
	                        e.FormattingApplied = true;
	                    }
	                    catch (FormatException)
	                    {
	                        Console.WriteLine("{0} is not a valid date.", e.Value.ToString());
	                    }
	                }
	            }
	        }
	    }

    private void SetupDataGridView()
    {
        this.Controls.Add(bookingDataGridView);

        bookingDataGridView.ColumnCount = 1;
        bookingDataGridView.RowCount = 20;

        bookingDataGridView.Name = "bookingDataGridView";
        bookingDataGridView.Location = new Point(40, 140);
        bookingDataGridView.Size = new Size(600, 450);

        bookingDataGridView.RowHeadersVisible = false;

        bookingDataGridView.Columns[0].Name = "№";
        bookingDataGridView.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.Fill;

    }
		
		void Label1Click(object sender, EventArgs e)
		{
	
		}
		void Label5Click(object sender, EventArgs e)
		{
	
		}
		void TextBox3TextChanged(object sender, EventArgs e)
		{
	
		}
		void TableLayoutPanel1Paint(object sender, PaintEventArgs e)
		{
			
		}
		void Label4Click(object sender, EventArgs e)
		{
	
		}
		void Label2Click(object sender, EventArgs e)
		{
	
		}
		void Label3Click(object sender, EventArgs e)
		{
	
		}
		void Label6Click(object sender, EventArgs e)
		{
	
		}
		void Label11Click(object sender, EventArgs e)
		{
	
		}
		void Label12Click(object sender, EventArgs e)
		{
	
		}
		void Button1Click(object sender, EventArgs e)
		{
			float summ=0;
			for(int i=0;i<20;i++)
			{
				summ+=Convert.ToInt32(bookingDataGridView.Rows[i].Cells[2].Value)
					*Convert.ToInt32(bookingDataGridView.Rows[i].Cells[3].Value);
			}
			label7.Text= Convert.ToString(summ);
		}
		void Button2Click(object sender, EventArgs e)
		{
			InitializeComponent();
			MySqlConnection Connection = new MySqlConnection("Data Source=" + MySQL_host + ";" +
			                                                 "Port=" + MySQL_port + ";" +
			                                                 "User Id=" + MySQL_uid + ";" +
			                                                 "Password=" + MySQL_pw + ";" +
				                                             "database=" + MySQL_db + ";");
			MySqlCommand Query = new MySqlCommand(); // It's object for connecting in db, and send any query
			Query.Connection = Connection;
			Connection.Open();
			Query.CommandText = "INSERT INTO " + MySQL_tbname + " VALUES('"+11+"', '" +40 + "','" + 30 + "','" + 20 + "','" + 10 + "');";
				//"INSERT INTO booking VALUES ('" + textBox4.Text + "', '" + Convert.ToString(textBox2.Text) + "', '" + Convert.ToString(textBox1.Text) + "', '" + Convert.ToString(label7.Text) + "', '" + Convert.ToString(textBox3.Text) + "');";
    		Query.ExecuteNonQuery();
    		Query.Dispose();			
			Connection.Close();
		}
		void TextBox4TextChanged(object sender, EventArgs e)
		{
	
		}
		void TextBox1TextChanged(object sender, EventArgs e)
		{
	
		}
		
		
	}
}
