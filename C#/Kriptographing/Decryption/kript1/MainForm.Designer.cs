/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 28.11.2015
 * Время: 11:11
 * 
 * 
 */
namespace kript1
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label6;
		
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
			this.button3 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.button3.Location = new System.Drawing.Point(555, 26);
			this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(41, 28);
			this.button3.TabIndex = 262;
			this.button3.Text = "...";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(13, 28);
			this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(135, 59);
			this.label5.TabIndex = 261;
			this.label5.Text = "Папка с данными шифра";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(169, 28);
			this.textBox4.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(363, 22);
			this.textBox4.TabIndex = 260;
			this.textBox4.Text = "C:\\Users\\Глеб\\Desktop\\kript";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(629, 26);
			this.button2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(159, 32);
			this.button2.TabIndex = 259;
			this.button2.Text = "Прочитать файлы";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(99, 251);
			this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 31);
			this.label2.TabIndex = 266;
			this.label2.Text = "Ключ";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 82);
			this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(150, 26);
			this.label1.TabIndex = 265;
			this.label1.Text = "Зашифрованный текст";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(169, 257);
			this.textBox2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.textBox2.MaxLength = 1;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(187, 22);
			this.textBox2.TabIndex = 264;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(169, 68);
			this.textBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(636, 170);
			this.textBox1.TabIndex = 263;
			// 
			// progressBar1
			// 
			this.progressBar1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.progressBar1.ForeColor = System.Drawing.Color.LightCoral;
			this.progressBar1.Location = new System.Drawing.Point(24, 367);
			this.progressBar1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.progressBar1.Maximum = 255;
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(787, 34);
			this.progressBar1.TabIndex = 270;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 446);
			this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(135, 53);
			this.label3.TabIndex = 269;
			this.label3.Text = "Расшифрованный текст";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(169, 426);
			this.textBox3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(641, 155);
			this.textBox3.TabIndex = 268;
			// 
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(636, 252);
			this.button1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(152, 30);
			this.button1.TabIndex = 267;
			this.button1.Text = "Расшифровать";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.Location = new System.Drawing.Point(191, 321);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(427, 28);
			this.label6.TabIndex = 271;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(897, 613);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.button2);
			this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MainForm";
			this.Text = "kript1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
