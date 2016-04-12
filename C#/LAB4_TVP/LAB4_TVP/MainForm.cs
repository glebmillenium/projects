/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 09.04.2016
 * Время: 18:54
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB4_TVP
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		int demon;
		public List<List <ProgressBar>> treatmenters = new List<List <ProgressBar>>();
		Semaphore semObj = null;
		Stopwatch timer = null;
		ManualResetEvent _gEvtObj = new ManualResetEvent(true);
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			numericUpDown1.ReadOnly = true;
			comboBox1.Items.Add("G");
			comboBox1.SelectedItem = "G";
			comboBox1.Items.Add("L");
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			
			comboBox2.Items.Add("G");
			comboBox2.Items.Add("L");
			comboBox2.SelectedItem = "G";
			comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
			
			comboBox3.Items.Add("G");
			comboBox3.Items.Add("L");
			comboBox3.SelectedItem = "L";
			comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
			
			comboBox4.Items.Add("G");
			comboBox4.Items.Add("L");
			comboBox4.SelectedItem = "L";
			comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		void Button1Click(object sender, EventArgs e)
		{
			panel1.Controls.Clear();
			button1.Enabled = false;
			clearer();
			processBuilder(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
			Thread start;
			this.demon = 0;
			label3.Text = "";
			timer = new Stopwatch();
			timer.Start();
			if (radioButton1.Checked)
			{
				string t = comboBox1.SelectedItem.ToString();
				start = new Thread( () => goMutex(t));
				start.Start();
			}
			else
			{
				if (radioButton2.Checked)
				{
					string t = comboBox2.SelectedItem.ToString();
					semObj = new Semaphore(Int32.Parse(numericUpDown1.Value.ToString()), Int32.Parse(numericUpDown1.Value.ToString()));
					start = new Thread( () => goSemaphore(t));
					start.Start();
				}
				else
				{
					if(radioButton3.Checked)
					{
						string t = comboBox3.SelectedItem.ToString();
						start = new Thread( () => goCriticalSection(t));
						start.Start();
					}
					else
					{
						string t = comboBox4.SelectedItem.ToString();
						start = new Thread ( () => goEvent(t));
						start.Start();
					}
				}
			}
		}
		
		void processBuilder(int m, int n)
		{
			int high = 0;
			for(int i = 1; i <= m; i++)
			{
				var data_programm = new Label(){
						Size = new Size(330, 20),
						Location = new Point(0, (high)),
						Text = "Программа " + i.ToString()
            	};
				panel1.Controls.Add(data_programm);
				high += 20;
				var temporary = new List <ProgressBar>();
				for(int j = 0; j < n ; j++)
				{
					var data_process = new ProgressBar(){
						Width = 350, 
						Height = 10,
						Location = new Point(0, high)
					};

					high += 10;
					temporary.Add(data_process);
					panel1.Controls.Add(data_process);
				}
				treatmenters.Add(temporary);
			}
		}
		
		void goMutex(string str)
		{
			if (str == "G") _globalGoMutex(); else _localGoMutex();
		}
		
		void _localGoMutex()
		{
			int[] rdcoll = new int[treatmenters.Count];
			rdcoll = createRandomArray(treatmenters.Count);
			
			foreach(var arg1 in rdcoll)
			{
				Thread t = new Thread(() => {
				                       	
										int[] rdelem = createRandomArray(treatmenters[arg1].Count);
										Mutex mutexObj = new Mutex(false, "_localController"+arg1.ToString());
										foreach(var arg2 in rdelem)
										{
											Thread k = new Thread( () =>
											                      {
											    
						                      	mutexObj.WaitOne(-1);
												moveBar(treatmenters[arg1][arg2]);
												Thread.Sleep(1000);
												mutexObj.ReleaseMutex();
											                      });
											k.Start();
										}
										
							});
				t.Start();
			}
			timerReaction();
		}
		
		void _globalGoMutex()
		{
			int[] rdcoll = new int[treatmenters.Count];
			rdcoll = createRandomArray(treatmenters.Count);
			
			foreach(var arg1 in rdcoll)
			{
				Thread t = new Thread(() => {
				                       	
										int[] rdelem = createRandomArray(treatmenters[arg1].Count);
										foreach(var arg2 in rdelem)
										{
											Thread k = new Thread( () =>
											                      {
											    Mutex mutexObj = new Mutex(false, "controller");
						                      	mutexObj.WaitOne(-1);
												moveBar(treatmenters[arg1][arg2]);
												Thread.Sleep(1000);
												mutexObj.ReleaseMutex();
											                      });
											k.Start();
										}
										
							});
				t.Start();
			}
			timerReaction();
		}
		
		void timerReaction()
		{
			while (true) 
			{
				if (demon == Int32.Parse(textBox1.Text)*Int32.Parse(textBox2.Text))
				{
					timer.Stop();
					Invoke(new Action( () => label3.Text = "Время выполнения: " + timer.ElapsedMilliseconds + " милисек.") );
					break;
				}
			}
			Invoke( new Action ( () => button1.Enabled = true));
		}
		
		void goCriticalSection(string str)
		{
			if (str == "G") _globalGoCriticalSection(); else _localGoCriticalSection();
		}
		
		void _localGoCriticalSection()
		{
			int[] rdcoll = new int[treatmenters.Count];
			rdcoll = createRandomArray(treatmenters.Count);
			
			foreach(var arg1 in rdcoll)
			{
				Thread t = new Thread(() => {
				                       	
										int[] rdelem = createRandomArray(treatmenters[arg1].Count);
										foreach(var arg2 in rdelem)
										{
											Thread k = new Thread( () =>
											                      {
											                      	Monitor.Enter(treatmenters[arg1]);
																	moveBar(treatmenters[arg1][arg2]);
																	Thread.Sleep(1000);
																	Monitor.Exit(treatmenters[arg1]);
											                      }
											);
											k.Start();
										}
										
							});
				t.Start();
			}
			timerReaction();
		}

		void _globalGoCriticalSection()
		{
			int[] rdcoll = new int[treatmenters.Count];
			rdcoll = createRandomArray(treatmenters.Count);
			
			foreach(var arg1 in rdcoll)
			{
				Thread t = new Thread(() => {
				                       	
										int[] rdelem = createRandomArray(treatmenters[arg1].Count);
										foreach(var arg2 in rdelem)
										{
											Thread k = new Thread( () =>
											                      {
											                      	Monitor.Enter(treatmenters);
																	moveBar(treatmenters[arg1][arg2]);
																	Thread.Sleep(1000);
																	Monitor.Exit(treatmenters);
											                      }
											);
											k.Start();
										}
										
							});
				t.Start();
			}
			timerReaction();
		}
		
		void goSemaphore(string str)
		{
			if (str == "G") _globalGoSemaphore(); else _localGoSemaphore();
		}
		
		void _globalGoSemaphore()
		{
			int[] rdcoll = new int[treatmenters.Count];
			rdcoll = createRandomArray(treatmenters.Count);
			
			foreach(var arg1 in rdcoll)
			{
				Thread t = new Thread(() => {
				                       	
										int[] rdelem = createRandomArray(treatmenters[arg1].Count);
										foreach(var arg2 in rdelem)
										{
											Thread k = new Thread( () => {
											semObj.WaitOne(-1);
											moveBar(treatmenters[arg1][arg2]);
											Thread.Sleep(1000);
											semObj.Release(1);
											});
											k.Start();
										}
											
							});
				t.Start();
			}
			timerReaction();
		}
		
		void _localGoSemaphore()
		{
			int[] rdcoll = new int[treatmenters.Count];
			rdcoll = createRandomArray(treatmenters.Count);
			
			foreach(var arg1 in rdcoll)
			{
				Thread t = new Thread(() => {
				                       	
										int[] rdelem = createRandomArray(treatmenters[arg1].Count);
										var semObj = new Semaphore(Int32.Parse(numericUpDown1.Value.ToString()), Int32.Parse(numericUpDown1.Value.ToString()));
										foreach(var arg2 in rdelem)
										{
											Thread k = new Thread( () => {
											semObj.WaitOne(-1);
											moveBar(treatmenters[arg1][arg2]);
											Thread.Sleep(1000);
											semObj.Release(1);
											});
											k.Start();
										}
											
							});
				t.Start();
			}
			timerReaction();
		}
		
		public int[] createRandomArray(int n)
		{
			Random rnd = new Random();
			int[] stack = new int[n];
			for(int i = 0; i < n; i++)
				stack[i] = -1;
			
			for (int i = 0; i < n; i++)
			{
				int temp  = rnd.Next(0, n);
				if(equalIntArray(stack, temp))
				{
					stack[i] = temp;
				}
				else
				{
					i--;
				}
			}
			
			return stack;
		}
		
		bool equalIntArray(int[] stack, int temp)
		{
			if(stack.Length != 0)
			{
				foreach(var arg in stack)
				{
					if (arg == temp) return false;
				}
			}
			return true;
		}
		
		void moveBar(ProgressBar val)
		{
			for(int i = 0; i <= val.Maximum; i++)
			{
				val.Invoke(new Action( () => val.Value = i));
			}
			demon++;
		}
		void NumericUpDown1ValueChanged(object sender, EventArgs e)
		{
			int a = 1;
			int b = 1;
			
			if(Int32.TryParse(textBox2.Text, out b) && Int32.TryParse(textBox1.Text, out a))
			{
				numericUpDown1.Maximum = a*b;
			}
			else
			{
				numericUpDown1.Maximum = 2;
			}
		}
		
		void goEvent(string str)
		{
			if (str == "G") _globalGoEvent(); else _localGoEvent();
		}
		
		void _globalGoEvent()
		{
			int[] rdcoll = new int[treatmenters.Count];
			rdcoll = createRandomArray(treatmenters.Count);
			foreach(var arg1 in rdcoll)
			{
				Thread t = new Thread(() => {
				                       	
										int[] rdelem = createRandomArray(treatmenters[arg1].Count);
										foreach(var arg2 in rdelem)
										{
											Thread k = new Thread( () => {
											this._gEvtObj.WaitOne();
											this._gEvtObj.Reset();
											moveBar(treatmenters[arg1][arg2]);
											Thread.Sleep(1000);
											this._gEvtObj.Set();
											});
											k.Start();
										}
							});
				t.Start();
			}
			timerReaction();
		}
		
		void _localGoEvent()
		{
			int[] rdcoll = new int[treatmenters.Count];
			rdcoll = createRandomArray(treatmenters.Count);
			foreach(var arg1 in rdcoll)
			{
				Thread t = new Thread(() => {
				                       	ManualResetEvent evtObj = new ManualResetEvent(true);
										int[] rdelem = createRandomArray(treatmenters[arg1].Count);
										foreach(var arg2 in rdelem)
										{
											Thread k = new Thread( () => {
											evtObj.WaitOne();
											evtObj.Reset();
											moveBar(treatmenters[arg1][arg2]);
											Thread.Sleep(1000);
											evtObj.Set();
											});
											k.Start();
										}
							});
				t.Start();
			}
			timerReaction();
		}
		
		void clearer()
		{
			this.demon = 0;
			this.treatmenters = new List<List <ProgressBar>>();
			this.semObj = null;
			this.timer = null;
		}
		void RadioButton2CheckedChanged(object sender, EventArgs e)
		{
			numericUpDown1.Visible = true;
		}
		void RadioButton1CheckedChanged(object sender, EventArgs e)
		{
			numericUpDown1.Visible = false;
		}
		void RadioButton3CheckedChanged(object sender, EventArgs e)
		{
			numericUpDown1.Visible = false;
		}
		void RadioButton4CheckedChanged(object sender, EventArgs e)
		{
			numericUpDown1.Visible = false;
		}
	}
}
