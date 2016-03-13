/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 13.03.2016
 * Время: 20:18
 * 
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace lab1_TVP
{
	/// <summary>
	/// Description of WorkingProcess.
	/// </summary>
	public partial class WorkingProcess : Form
	{
		public List<List <Label>> ProcessData = new List<List <Label>>();
		public int[] queue;
		public int[] prior;
		public WorkingProcess()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			head();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private void head()
		{
			string[] str = new string[]{"№ п/п",
			                            "Выполнено, %", 
			                            "Состояние",
			                            "Очередь"};
			for(int i = 0, coor = 0; i < 4; i++, coor += 100)
			{
				var data = new Label(){
					Size = new Size(100, 40),
					Location = new Point(coor, 0),
					Text = str[i],
				};
				if(i == 0) {data.Size = new Size(20, 20); coor -= 50;}
				Controls.Add(data);
			}
		}
		
		public void myShow()
		{
			Show();
			drawData();
		}
		private void drawData()
		{
			foreach(var val1 in ProcessData)
			{
				Controls.Add(val1[0]);
				Controls.Add(val1[4]);
				Controls.Add(val1[5]);
				Controls.Add(val1[6]);
			}
		}
		public void go(int identificator)
		{
			
			if(identificator == 0)
			{
				var launch = new Thread(() => circle());
				launch.Start();
			}
			
			if (identificator > 0)
			{
				var launch = new Thread(() => absolute());
				launch.Start();
			}
			if(identificator < 0)
			{
				var launch = new Thread(() => relative());
				launch.Start();
			}
		}
		
		private void absolute()
		{
			IComparer revComparer = new ReverseComparer();
			Array.Sort(prior, revComparer);
			while(true)
			{
				//foreach(var val1 in prior)
				for(int i = 0; i < prior.Length; i++)
				{
					if(prior[i] == -1) continue;
					foreach(var val2 in ProcessData)
					{
						if(Int32.Parse(val2[3].Text) == prior[i])
						{
							Invoke(new Action(() => val2[5].Text = "Выполняется"));
							Thread.Sleep(Int32.Parse(val2[1].Text)*1000);
							val2[7].Text = (Int32.Parse(val2[7].Text) + Int32.Parse(val2[1].Text)).ToString();
							if(Int32.Parse(val2[7].Text) >= Int32.Parse(val2[2].Text))
							{
								Invoke(new Action(() => val2[4].Text = "100%"));
						       	Invoke(new Action(() => val2[5].Text = "Выполнен"));
								prior[i] = -1;
								break;
							}
							Invoke(new Action(() => val2[4].Text = (100*double.Parse(val2[7].Text)/double.Parse(val2[2].Text)).ToString() + "%"));
							Invoke(new Action(() => val2[5].Text = "Очередь"));
						}
					}
				}
				if(checking(prior)) break;
			}
		}
		
		private void relative()
		{
			Array.Sort(prior);
			while(true)
			{
				for(int i = 0; i < prior.Length; i++)
				{
					if(prior[i] == -1) continue;
					foreach(var val2 in ProcessData)
					{
						if(Int32.Parse(val2[3].Text) == prior[i])
						{
							Invoke(new Action(() => val2[5].Text = "Выполняется"));
							Thread.Sleep(Int32.Parse(val2[1].Text)*1000);
							val2[7].Text = (Int32.Parse(val2[7].Text) + Int32.Parse(val2[1].Text)).ToString();
							if(Int32.Parse(val2[7].Text) >= Int32.Parse(val2[2].Text))
							{
								Invoke(new Action(() => val2[4].Text = "100%"));
						       	Invoke(new Action(() => val2[5].Text = "Выполнен"));
								prior[i] = -1;
								break;
							}
							Invoke(new Action(() => val2[4].Text = (100*double.Parse(val2[7].Text)/double.Parse(val2[2].Text)).ToString() + "%"));
							Invoke(new Action(() => val2[5].Text = "Очередь"));
						}
					}
				}
				if(checking(prior)) break;
			}
		}
		
		private void circle()
		{
			while (true)
			{
				for(int i = 0; i < queue.Length; i++)
				{
					if (queue[i] == -1) continue;
					var starting = ProcessData[queue[i]];
					Invoke(new Action(() => starting[5].Text = "Выполняется"));
					Thread.Sleep(Int32.Parse(starting[1].Text)*1000);
					starting[7].Text = (Int32.Parse(starting[7].Text) + Int32.Parse(starting[1].Text)).ToString();
					if(Int32.Parse(starting[7].Text) >= Int32.Parse(starting[2].Text))
					{
						Invoke(new Action(() => starting[4].Text = "100%"));
				       	Invoke(new Action(() => starting[5].Text = "Выполнен"));
						queue[i] = -1;
						break;
					}
					Invoke(new Action(() => starting[4].Text = (100*double.Parse(starting[7].Text)/double.Parse(starting[2].Text)).ToString() + "%"));
					Invoke(new Action(() => starting[5].Text = "Очередь"));
				}
				if(checking(queue)) break;
			}
		}
		
		bool checking(int[] mass)
		{
			bool t = true;
			foreach(var val in mass)
			{
				if (val != -1) t = false;
			}
			return t;
		}
	}
	
	public class ReverseComparer : IComparer  
	{
	   // Call CaseInsensitiveComparer.Compare with the parameters reversed.
	   public int Compare(Object x, Object y)  
	   {
	       return (new CaseInsensitiveComparer()).Compare(y, x );
	   }
	}

}
