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
using System.Threading;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Restaurant
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class Form1 : Form
	{
		private DataGridView bookingDataGridView = new DataGridView();
		string MySQL_host = "localhost";
		string MySQL_port = "3306";
		string MySQL_uid = "root";
		string MySQL_pw = "root";
		string MySQL_db = "restaurant";
		int access;
		// coding of UTF-8(general_ci)

		public Form1(int access_level)
		{
			access = access_level;
			InitializeComponent();
			this.Load += new EventHandler(Form1_Load);
			button1.Enabled = false;
			button2.Enabled = false;
			button3.Enabled = false;
			bookingDataGridView.ReadOnly = true;
			if (access_level > 0) {
				button1.Enabled = true;
			}
			if (access_level > 1) {
				button2.Enabled = true;
				button3.Enabled = true;
				bookingDataGridView.ReadOnly = false;
			}
		}

		private void Form1_Load(System.Object sender, System.EventArgs e)
		{
			SetupDataGridView();
			PopulateDataGridView();
		}

		private void SetupDataGridView()
		{
			this.Controls.Add(bookingDataGridView);

			bookingDataGridView.ColumnCount = 6;

			bookingDataGridView.Name = "bookingDataGridView";
			bookingDataGridView.Location = new Point(40, 70);
			bookingDataGridView.Size = new Size(600, 250);
			bookingDataGridView.KeyDown += Form1KeyDown;
			bookingDataGridView.RowHeadersVisible = false;

			bookingDataGridView.Columns[0].Name = "№ счета";
			bookingDataGridView.Columns[1].Name = "Заказчик";
			bookingDataGridView.Columns[2].Name = "Кол-во человек";
			bookingDataGridView.Columns[3].Name = "Сумма";
			bookingDataGridView.Columns[4].Name = "Дата проведения";
			bookingDataGridView.Columns[5].Name = "Время проведения";
			bookingDataGridView.AutoSizeColumnsMode =
        	DataGridViewAutoSizeColumnsMode.Fill;
		}

		private void PopulateDataGridView()
		{
			MySqlConnection Connection = new MySqlConnection("Data Source=" + MySQL_host + ";" +
			                             "Port=" + MySQL_port + ";" +
			                             "User Id=" + MySQL_uid + ";" +
			                             "Password=" + MySQL_pw + ";" +
			                             "database=" + MySQL_db + ";" + "charset=utf8;");
			MySqlCommand Query = new MySqlCommand(); // It's object for connecting in db, and send any query
			Query.Connection = Connection; // definity object new connection user, pas, db etc.
		
			try {
				Connection.Open();// Соединяемся
				label8.BackColor = Color.Chartreuse;
				label9.Text = "Соединение с сервером установлено!";
			} catch (MySqlException SSDB_Exception) {
				// Ошибка - выходим
				label8.BackColor = Color.DarkRed;
				label9.Text = "Сервер базы данных не найден!" + SSDB_Exception;    
			}		
		
			bookingDataGridView.Rows.Clear();
			Query.CommandText = "SELECT * FROM  restaurant;";
			MySqlDataReader MyReader = Query.ExecuteReader();// Запрос, подразумевающий чтение данных из таблиц.
			string str0 = null;
			string str1 = null;
			string str2 = null;
			string str3 = null;
			string str4 = null;
			string str5 = null;

			while (MyReader.Read()) {
				// Каждое значение вытягиваем с помощью MySqlDataReader.GetValue(<номер значения в выборке>)
				str0 = "";
				str1 = "";
				str2 = "";
				str3 = "";
				str4 = "";
				str5 = "";
				str0 += (MyReader.GetValue(0));
				str1 += (MyReader.GetValue(1));
				str2 += (MyReader.GetValue(2));
				str3 += (MyReader.GetValue(3));
				str4 += (MyReader.GetValue(4));
				str5 += (MyReader.GetValue(5));
				Object[] str = { str0, str1, str2, str3, str4, str5 };
				bookingDataGridView.Rows.Add(str);
			}

			MyReader.Close();
			Query.Dispose();
			Connection.Close();

			bookingDataGridView.Columns[0].DisplayIndex = 0;
			bookingDataGridView.Columns[1].DisplayIndex = 1;
			bookingDataGridView.Columns[2].DisplayIndex = 2;
			bookingDataGridView.Columns[3].DisplayIndex = 3;
			bookingDataGridView.Columns[4].DisplayIndex = 4;
			bookingDataGridView.Columns[5].DisplayIndex = 5;
			bookingDataGridView.Refresh();
			this.Refresh();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			Form2 form = new Form2();
			form.ShowDialog();
			PopulateDataGridView();
		}
		
		void open()
		{
			Form2 form = new Form2();
			form.ShowDialog();
			PopulateDataGridView();
		}
		
		void delete()
		{
			String id;
			if (bookingDataGridView.CurrentRow != null) {
				id = bookingDataGridView.CurrentCell.Value.ToString();
				bookingDataGridView.Rows.Remove(bookingDataGridView.CurrentRow);
			
				MySqlConnection Connection = new MySqlConnection("Data Source=" + MySQL_host + ";" +
				                             "Port=" + MySQL_port + ";" +
				                             "User Id=" + MySQL_uid + ";" +
				                             "Password=" + MySQL_pw + ";" +
				                             "database=" + MySQL_db + ";" + "charset=utf8;");
				MySqlCommand Query = new MySqlCommand(); // It's object for connecting in db, and send any query
				Query.Connection = Connection;
				Connection.Open();
				Query.CommandText = "DELETE FROM restaurant WHERE account_number = '" + id + "';";
				//"INSERT INTO booking VALUES ('" + textBox4.Text + "', '" + Convert.ToString(textBox2.Text) + "', '" + Convert.ToString(textBox1.Text) + "', '" + Convert.ToString(label7.Text) + "', '" + Convert.ToString(textBox3.Text) + "');";
				Query.ExecuteNonQuery();
				Query.Dispose();			
				Connection.Close();
				PopulateDataGridView();
			}
		}
		void Button2Click(object sender, EventArgs e)
		{
			delete();
			
		}
		void Button4Click(object sender, EventArgs e)
		{
			this.Close();
		}
 	
		void Button5Click(object sender, EventArgs e)
		{
			string option = textBox1.Text;
			/*MySqlConnection Connection = new MySqlConnection("Data Source=" + MySQL_host + ";" +
			                             "Port=" + MySQL_port + ";" +
			                             "User Id=" + MySQL_uid + ";" +
			                             "Password=" + MySQL_pw + ";" +
			                             "database=" + MySQL_db + ";" + "charset=utf8;");
			MySqlCommand Query = new MySqlCommand(); // It's object for connecting in db, and send any query
			Query.Connection = Connection;
			Connection.Open();
			Query.CommandText = "SELECT FROM restaurant WHERE ";
			bool was = false;
			if(checkBox1.Checked) {
				Query.CommandText += "account_number = " + option;
			}
			if(checkBox2.Checked) {
				if(was) Query.CommandText += " AND ";
				Query.CommandText += " customer = " + option;
			}
			if(checkBox3.Checked) {
				if(was) Query.CommandText += " AND ";
				Query.CommandText += " count_man = " + option;
			}
			if(checkBox4.Checked) {
				if(was) Query.CommandText += " AND ";
				Query.CommandText += " count_man = " + option;
			}
			//"INSERT INTO booking VALUES ('" + textBox4.Text + "', '" + Convert.ToString(textBox2.Text) + "', '" + Convert.ToString(textBox1.Text) + "', '" + Convert.ToString(label7.Text) + "', '" + Convert.ToString(textBox3.Text) + "');";
			Query.ExecuteNonQuery();
			Query.Dispose();			
			Connection.Close();*/
		}
		

		Keys last1;
		Keys last2;
		void Form1KeyDown(object sender, KeyEventArgs e)
		{
			last1 = last2;
			last2 = e.KeyCode;
			if (e.KeyCode == Keys.Delete && access > 1) {
				delete();
			}
			if (e.KeyCode == Keys.Home && access > 0) {
				open();
			}
			if (last1 == Keys.ControlKey && last2 == Keys.N && access > 0) {
				open();
			}
		}

	}
}
