/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 27.05.2016
 * Время: 22:20
 * 
 * 
 */
using System;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace orphan_house
{
	public static class DB
	{
		const string MySQL_host = "localhost";
		const string MySQL_port = "3306";
		const string MySQL_uid = "root";
		const string MySQL_pw = "root";
		const string MySQL_db = "orphan_house";
			
		public static Tuple<string, int> authentificInSystem(string login, string password)
		{
	    	MySqlConnection Connection = new MySqlConnection("Data Source=" + MySQL_host + ";" +
		                                                 "Port=" + MySQL_port + ";" +
		                                                 "User Id=" + MySQL_uid + ";" +
		                                                 "Password=" + MySQL_pw + ";" +
			                                             "database=" + MySQL_db + ";");
			MySqlCommand Query = new MySqlCommand(); 
			Query.Connection = Connection;
			
			try
			{
			    Connection.Open();
			}
			catch (MySqlException SSDB_Exception)
			{
			    return new Tuple<string, int>("", -1);
			}		
			
			
			Query.CommandText = "SELECT auth.login, auth.password, adult.full_name, adult.id_status, auth.time_input FROM auth, adult WHERE auth.id = adult.id AND login like " + "'" + login + "'";
			MySqlDataReader MyReader = Query.ExecuteReader();// Запрос, подразумевающий чтение данных из таблиц.
			string str0=null;
			string str1=null;
			string str2=null;
			string str3=null;
	
			while (MyReader.Read())
			{
				str0 += (MyReader.GetValue(0));
				str1 += (MyReader.GetValue(1));
				str2 += (MyReader.GetValue(2));
				str3 += (MyReader.GetValue(3));
			}

			MyReader.Close();
			Query.Dispose();
			Connection.Close();
			
			int val;
			if(!Int32.TryParse(str3, out val)){
				val = -1;
			}
			
			if(str0 != null && str0.Equals(login) && str1.Equals(password)) {
				return new Tuple<string, int>(str2, val);
			}
			else{
				return new Tuple<string, int>("", -1);
			}
		}
		
		public static int addHistoryId(string reason){
	    	MySqlConnection Connection = new MySqlConnection("Data Source=" + MySQL_host + ";" +
		                                                 "Port=" + MySQL_port + ";" +
		                                                 "User Id=" + MySQL_uid + ";" +
		                                                 "Password=" + MySQL_pw + ";" +
			                                             "database=" + MySQL_db + ";");
			MySqlCommand Query = new MySqlCommand(); 
			Query.Connection = Connection;
			
			try
			{
			    Connection.Open();
			}
			catch (MySqlException SSDB_Exception)
			{
			    return -1;
			}
			
			Query.CommandText = "INSERT INTO `history` (`reason`) VALUES('" + reason + "'); SELECT last_insert_id();";
			MySqlDataReader MyReader = Query.ExecuteReader();// Запрос, подразумевающий чтение данных из таблиц.
			string str = "";;
	
			while (MyReader.Read())
			{
				str += (MyReader.GetValue(0));
			}

			MyReader.Close();
			Query.Dispose();
			Connection.Close();
			int res;
			if(Int32.TryParse(str, out res)) return res; else return -1;
		}
		
		public static string[][] searchChildren(string str){
			string[][] res = null;
			MySqlConnection Connection = new MySqlConnection("Data Source=" + MySQL_host + ";" +
		                                                 "Port=" + MySQL_port + ";" +
		                                                 "User Id=" + MySQL_uid + ";" +
		                                                 "Password=" + MySQL_pw + ";" +
			                                             "database=" + MySQL_db + ";");
			MySqlCommand Query = new MySqlCommand(); 
			Query.Connection = Connection;
			
			try
			{
			    Connection.Open();
			}
			catch (MySqlException SSDB_Exception)
			{
			    return res;
			}
			
			Query.CommandText = "SELECT childrens.full_name, childrens.birthday, certificate.code, certificate.place_birth, certificate.date_reg, history.reason, history.behavior FROM childrens, certificate, history WHERE childrens.id_certificate = certificate.id_certificate AND childrens.id_history = history.id_history AND childrens.full_name='Ivanov Ivan'";
			MySqlDataReader MyReader = Query.ExecuteReader();
			int i = 0;
			while (MyReader.Read())
			{
				res[i][0] = MyReader.GetValue(0).ToString();
				res[i][1] = MyReader.GetValue(1).ToString();
				res[i][2] = MyReader.GetValue(2).ToString();
				res[i][3] = MyReader.GetValue(3).ToString();
				res[i][4] = MyReader.GetValue(4).ToString();
				res[i][5] = MyReader.GetValue(5).ToString();
				res[i][6] = MyReader.GetValue(6).ToString();
				i++;
			}

			MyReader.Close();
			Query.Dispose();
			Connection.Close();
			
			return res;
		}
		
		public static string[][] searchAdult(string str){
			string[][] res = null;
			MySqlConnection Connection = new MySqlConnection("Data Source=" + MySQL_host + ";" +
		                                                 "Port=" + MySQL_port + ";" +
		                                                 "User Id=" + MySQL_uid + ";" +
		                                                 "Password=" + MySQL_pw + ";" +
			                                             "database=" + MySQL_db + ";");
			MySqlCommand Query = new MySqlCommand(); 
			Query.Connection = Connection;
			
			try
			{
			    Connection.Open();
			}
			catch (MySqlException SSDB_Exception)
			{
			    return res;
			}
			
			Query.CommandText = "SELECT full_name, place_work, position_work, adress FROM adult WHERE full_name = '" + str + "'";
			MySqlDataReader MyReader = Query.ExecuteReader();
			int i = 0;
			while (MyReader.Read())
			{
				res[i][0] = MyReader.GetValue(0).ToString();
				res[i][1] = MyReader.GetValue(1).ToString();
				res[i][2] = MyReader.GetValue(2).ToString();
				res[i][3] = MyReader.GetValue(3).ToString();
				i++;
			}
			return res;
		}
		
		public static string[][] searchLogin(string str){
			string[][] res = null;
			MySqlConnection Connection = new MySqlConnection("Data Source=" + MySQL_host + ";" +
	                                         "Port=" + MySQL_port + ";" +
	                                         "User Id=" + MySQL_uid + ";" +
	                                         "Password=" + MySQL_pw + ";" +
	                                         "database=" + MySQL_db + ";");
			MySqlCommand Query = new MySqlCommand(); 
			Query.Connection = Connection;
			
			try
			{
			    Connection.Open();
			}
			catch (MySqlException SSDB_Exception)
			{
			    return res;
			}
			
			Query.CommandText = "SELECT auth.login, adult.full_name FROM auth, adult WHERE auth.id = adult.id AND" +
				"auth.login = '" + str +"'";
			MySqlDataReader MyReader = Query.ExecuteReader();
			int i = 0;
			while (MyReader.Read())
			{
				res[i][0] = MyReader.GetValue(0).ToString();
				res[i][1] = MyReader.GetValue(1).ToString();
				i++;
			}
			return res;
		}
	}
}
