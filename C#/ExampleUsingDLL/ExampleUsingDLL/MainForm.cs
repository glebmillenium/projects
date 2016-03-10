/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 18.11.2015
 * Время: 0:29
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ExampleUsingDLL
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
	  	[DllImport(@"my_library.dll", 
		           CharSet = CharSet.Auto, EntryPoint = "Double")]
		public static extern int Double(int N);
		
		[DllImport(@"my_library.dll", 
		           CharSet = CharSet.Auto, EntryPoint = "Triple")]
		public static extern int Triple(int N);
		
		[DllImport(@"my_library.dll", 
           CharSet = CharSet.Auto, EntryPoint = "DoublePChar")]
		public static extern int DoublePChar(int N);
		
		[DllImport(@"my_library.dll", 
   			CharSet = CharSet.Auto, EntryPoint = "DoubleString")]
		public static extern string DoubleString([MarshalAs(UnmanagedType.LPStr)]string s, [MarshalAs(UnmanagedType.LPStr)]string Separat);
		
		[DllImport(@"my_library.dll", 
   			CharSet = CharSet.Auto, EntryPoint = "readFileToMemo")]
		public static extern string readFileToMemo([MarshalAs(UnmanagedType.LPStr)]string way);
		
		[DllImport(@"my_library.dll", 
   			CharSet = CharSet.Auto, EntryPoint = "readFileToMemo")]
		public static extern int writeTextInFile([MarshalAs(UnmanagedType.LPStr)]string fileDir, [MarshalAs(UnmanagedType.LPStr)]string text);
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			int temp = Double(Convert.ToInt32(textBox1.Text));
			textBox1.Text = Convert.ToString(temp);
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			int temp = Triple(Convert.ToInt32(textBox2.Text));
			textBox2.Text = Convert.ToString(temp);
		}
		void Button3Click(object sender, EventArgs e)
		{
			string separate = ",";
			string temp = DoubleString(textBox3.Text, separate);
			textBox3.Text = Convert.ToString(temp);
		}
		void Button5Click(object sender, EventArgs e)
		{
			textBox5.Enabled = false;
			button5.Enabled = false;
			textBox7.Enabled = true;
			button6.Enabled = true;
			textBox6.Text = readFileToMemo(textBox5.Text);
		}
		void Button6Click(object sender, EventArgs e)
		{
			int res = writeTextInFile(textBox7.Text, textBox6.Text);
		}

		
	}
}
