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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Restaurant
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class Form1 : Form
	{
		
	private Panel buttonPanel = new Panel();
    private DataGridView bookingDataGridView = new DataGridView();
    private Button addNewRowButton = new Button();
    private Button deleteRowButton = new Button();
	string MySQL_host = "localhost";
	string MySQL_port = "3306";
	string MySQL_uid = "root";
	string MySQL_pw = "root";
	string MySQL_db = "restaurant"; // coding of UTF-8(general_ci)

    public Form1()
    {
        InitializeComponent();
    	this.Load += new EventHandler(Form1_Load);
    }

 private void Form1_Load(System.Object sender, System.EventArgs e)
    {
        SetupDataGridView();
        PopulateDataGridView();
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

        bookingDataGridView.ColumnCount = 5;

        bookingDataGridView.Name = "bookingDataGridView";
        bookingDataGridView.Location = new Point(40, 70);
        bookingDataGridView.Size = new Size(600, 250);

        bookingDataGridView.RowHeadersVisible = false;

        bookingDataGridView.Columns[0].Name = "№ счета";
        bookingDataGridView.Columns[1].Name = "Заказчик";
        bookingDataGridView.Columns[2].Name = "Кол-во человек";
        bookingDataGridView.Columns[3].Name = "Дата";
        bookingDataGridView.Columns[4].Name = "Сумма";
        bookingDataGridView.AutoSizeColumnsMode =
        	DataGridViewAutoSizeColumnsMode.Fill;


    }

    private void PopulateDataGridView()
    {
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
		    label8.BackColor=Color.Chartreuse;
		    label9.Text="Соединение с сервером установлено!";
		}
		catch (MySqlException SSDB_Exception)
		{
		    // Ошибка - выходим
		    label8.BackColor=Color.DarkRed;
		    label9.Text="Сервер базы данных не найден!"+SSDB_Exception;    
		}		
		
		
		Query.CommandText = "SELECT * FROM  booking;";
		MySqlDataReader MyReader = Query.ExecuteReader();// Запрос, подразумевающий чтение данных из таблиц.
		string str0=null;
		string str1=null;
		string str2=null;
		string str3=null;
		string str4=null;

		while (MyReader.Read())
			{
			// Каждое значение вытягиваем с помощью MySqlDataReader.GetValue(<номер значения в выборке>)
			str0=null;
			str1=null;
			str2=null;
			str3=null;
			str4=null;
			str0 += (MyReader.GetValue(0));
			str1 += (MyReader.GetValue(1));
			str2 += (MyReader.GetValue(2));
			str3 += (MyReader.GetValue(3));
			str4 += (MyReader.GetValue(4));
			string[] str={str0, str1, str2, str4, str3};
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
        
    }
		void Label3Click(object sender, EventArgs e)
		{

		}
		void Form1Load(object sender, EventArgs e)
		{
	
		}
	}
}
