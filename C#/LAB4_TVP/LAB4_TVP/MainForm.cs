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
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//numericUpDown1.
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
				start = new Thread( () => goMutex());
				start.Start();
			}
			else
			{
				if (radioButton2.Checked)
				{
					semObj = new Semaphore(Int32.Parse(numericUpDown1.Value.ToString()), Int32.Parse(numericUpDown1.Value.ToString()));
					start = new Thread( () => goSemaphore());
					start.Start();
				}
				else
				{
					if(radioButton3.Checked)
					{
					start = new Thread( () => goCriticalSection());
					start.Start();
					}
					else{
						start = new Thread ( () => goEvent());
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
		
		void goMutex()
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
				//Invoke(new Action( () => label3.Text += i) );
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
		
		void goCriticalSection()
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
				//Invoke(new Action( () => label3.Text += i) );
			}
			timerReaction();
		}
		
		void goSemaphore()
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
			if (Int32.Parse(textBox1.Text)*Int32.Parse(textBox2.Text) == 1)
			{
				numericUpDown1.Maximum = 2;
			}
			else{
				numericUpDown1.Maximum = Int32.Parse(textBox1.Text)*Int32.Parse(textBox2.Text);
			}
		}
		
		void goEvent()
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
	}
}
