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
using System.Text;
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
		string MySQL_db = "restaurant";
		// coding of UTF-8(general_ci)
		string MySQL_tbname = "restaurant";
		
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
			                             "database=" + MySQL_db + ";" +
			                             "charset=utf8;");
			MySqlCommand Query = new MySqlCommand(); // It's object for connecting in db, and send any query
			Query.Connection = Connection; // definity object new connection user, pas, db etc.
			
			try {
				Connection.Open();// Соединяемся
				label12.BackColor = Color.Chartreuse;
				label11.Text = "Соединение с сервером установлено!";
			} catch (MySqlException SSDB_Exception) {
				// Ошибка - выходим
				label12.BackColor = Color.DarkRed;
				label11.Text = "Сервер базы данных не найден!" + SSDB_Exception;  
				textBox1.Enabled = false;
				textBox2.Enabled = false;
				textBox3.Enabled = false;
				textBox4.Enabled = false;
				textBox5.Enabled = false;
				textBox6.Enabled = false;
				button2.Enabled = false;
			}			
			Query.CommandText = "SELECT (MAX(account_number) + 1) FROM  restaurant;";
			MySqlDataReader MyReader = Query.ExecuteReader();
			MyReader.Read();
			textBox1.Text = "" + MyReader.GetValue(0);
			if(textBox1.Text == "") textBox1.Text = "1";
			Query.Dispose();
			Connection.Close();
			
		}
		
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
		void Button2Click(object sender, EventArgs e)
		{
			MySqlConnection Connection = new MySqlConnection("Data Source=" + MySQL_host + ";" +
			                             "Port=" + MySQL_port + ";" +
			                             "User Id=" + MySQL_uid + ";" +
			                             "Password=" + MySQL_pw + ";" +
			                             "database=" + MySQL_db + ";" + "charset=utf8;");
			MySqlCommand Query = new MySqlCommand(); // It's object for connecting in db, and send any query
			Query.Connection = Connection;
			Connection.Open();
			Query.CommandText = "INSERT INTO " + MySQL_tbname + " VALUES('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "', 0);";
			//"INSERT INTO booking VALUES ('" + textBox4.Text + "', '" + Convert.ToString(textBox2.Text) + "', '" + Convert.ToString(textBox1.Text) + "', '" + Convert.ToString(label7.Text) + "', '" + Convert.ToString(textBox3.Text) + "');";
			Query.ExecuteNonQuery();
			Query.Dispose();			
			Connection.Close();
			this.Close();
		}


	}
}
