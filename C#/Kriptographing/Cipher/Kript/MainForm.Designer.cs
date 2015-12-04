/*
 * Created by SharpDevelop.
 * User: student
 * Date: 27.11.2015
 * Time: 14:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Kript
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button3 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(151, 14);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(546, 139);
			this.textBox1.TabIndex = 0;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(151, 226);
			this.textBox2.Margin = new System.Windows.Forms.Padding(4);
			this.textBox2.MaxLength = 1;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(161, 22);
			this.textBox2.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 26);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 34);
			this.label1.TabIndex = 3;
			this.label1.Text = "Текст";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(14, 229);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 25);
			this.label2.TabIndex = 4;
			this.label2.Text = "Ключ";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(546, 210);
			this.button1.Margin = new System.Windows.Forms.Padding(4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(130, 38);
			this.button1.TabIndex = 6;
			this.button1.Text = "Зашифровать";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(148, 378);
			this.textBox3.Margin = new System.Windows.Forms.Padding(4);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(550, 127);
			this.textBox3.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 394);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(116, 43);
			this.label3.TabIndex = 8;
			this.label3.Text = "Зашифрованный текст";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(550, 520);
			this.button2.Margin = new System.Windows.Forms.Padding(4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(126, 36);
			this.button2.TabIndex = 9;
			this.button2.Text = "Записать в файл";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// progressBar1
			// 
			this.progressBar1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.progressBar1.ForeColor = System.Drawing.Color.LightCoral;
			this.progressBar1.Location = new System.Drawing.Point(24, 330);
			this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(675, 28);
			this.progressBar1.TabIndex = 255;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(14, 162);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(116, 28);
			this.label4.TabIndex = 12;
			this.label4.Text = "Длина ключа";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(148, 524);
			this.textBox4.Margin = new System.Windows.Forms.Padding(4);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(312, 22);
			this.textBox4.TabIndex = 13;
			this.textBox4.Text = "C:\\Users\\Глеб\\Desktop\\kript";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(14, 530);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(116, 48);
			this.label5.TabIndex = 14;
			this.label5.Text = "Папка с данными шифра";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(151, 166);
			this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(140, 22);
			this.numericUpDown1.TabIndex = 15;
			this.numericUpDown1.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.NumericUpDown1ValueChanged);
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label6.Location = new System.Drawing.Point(148, 275);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(344, 28);
			this.label6.TabIndex = 256;
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(370, 218);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(104, 24);
			this.checkBox1.TabIndex = 257;
			this.checkBox1.Text = "Код ASCII";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.button3.Location = new System.Drawing.Point(467, 523);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(35, 23);
			this.button3.TabIndex = 258;
			this.button3.Text = "...";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(729, 572);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.Text = "Kript";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button button3;
	}
}
