/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 18.11.2015
 * Время: 0:29
 * 
 * 
 */
namespace ExampleUsingDLL
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox7;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(13, 13);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(155, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Вызов функции DOUBLE";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(13, 43);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(155, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Вызов функции TRIPLE";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(13, 73);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(155, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "Удвоение строки";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(13, 103);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(155, 23);
			this.button4.TabIndex = 3;
			this.button4.Text = "Удвоение PCHAR";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(187, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Значение";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(187, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Значение";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(187, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Текст";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(187, 103);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Удвоение";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(289, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 8;
			this.textBox1.Text = "2";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(289, 45);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 9;
			this.textBox2.Text = "3";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(289, 76);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(100, 20);
			this.textBox3.TabIndex = 10;
			this.textBox3.Text = "STR1";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(289, 106);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(100, 20);
			this.textBox4.TabIndex = 11;
			this.textBox4.Text = "S";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(13, 132);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(155, 21);
			this.button5.TabIndex = 12;
			this.button5.Text = "Прочитать текст из файла";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// button6
			// 
			this.button6.Enabled = false;
			this.button6.Location = new System.Drawing.Point(13, 158);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(155, 21);
			this.button6.TabIndex = 13;
			this.button6.Text = "Записать в файл";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.Button6Click);
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(289, 133);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(100, 20);
			this.textBox5.TabIndex = 14;
			this.textBox5.Text = "C:\\help.txt";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(187, 126);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(85, 32);
			this.label5.TabIndex = 15;
			this.label5.Text = "Путь откуда прочитать файл";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(13, 196);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 16;
			this.label6.Text = "Текст из файла";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(145, 193);
			this.textBox6.Multiline = true;
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(244, 93);
			this.textBox6.TabIndex = 17;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(187, 158);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(104, 32);
			this.label7.TabIndex = 18;
			this.label7.Text = "Путь куда записать";
			// 
			// textBox7
			// 
			this.textBox7.Enabled = false;
			this.textBox7.Location = new System.Drawing.Point(289, 159);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(100, 20);
			this.textBox7.TabIndex = 19;
			this.textBox7.Text = "C:\\need.txt";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(446, 298);
			this.Controls.Add(this.textBox7);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "MainForm";
			this.Text = "ExampleUsingDLL";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
