/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 30.05.2016
 * Время: 18:54
 * 
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;


namespace orphan_house
{
	/// <summary>
	/// Description of Statistics.
	/// </summary>
	public partial class Statistics : Form
	{
		private ZedGraph.ZedGraphControl z1;
		public Statistics()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			InitializeComponent1();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		private void InitializeComponent1()
		{
			this.z1 = new ZedGraph.ZedGraphControl();
			this.SuspendLayout();
			// 
			// zedGraphControl1
			// 
			this.z1.Location = new System.Drawing.Point(0, 0);
			this.z1.Name = "zedGraphControl1";
			this.z1.Size = new System.Drawing.Size(500, 300);
			this.z1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(510, 310);
			this.Controls.Add( this.z1 );
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.Load += new System.EventHandler( Form1_Load );

		}



		private void Form1_Load( object sender, System.EventArgs e )
		{
			z1.IsShowPointValues = true;
			z1.GraphPane.Title = "Test Case for C#";
			double[] x = new double[100];
			double[] y = new double[100];
			int	i;
			for ( i=0; i<100; i++ )
			{
				x[i] = (double) i / 100.0 * Math.PI * 2.0;
				y[i] = Math.Sin( x[i] );
			}
			z1.GraphPane.AddCurve( "Sine Wave", x, y, Color.Red, SymbolType.Square );
			z1.AxisChange();
			z1.Invalidate();
		}
	}
}
