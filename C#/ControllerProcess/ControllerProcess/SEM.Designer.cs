﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 05.11.2015
 * Время: 1:08
 * 
 * 
 */
namespace ControllerProcess
{
	partial class SEM
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button4;
		
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(141, 139);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(122, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Начать запуск!";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 90);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "notepad";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(12, 139);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 2;
			this.textBox2.Text = "3";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(37, 188);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(98, 40);
			this.button2.TabIndex = 3;
			this.button2.Text = "Закрыть приложение";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Visible = false;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(141, 188);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(90, 40);
			this.button3.TabIndex = 4;
			this.button3.Text = "Запустить приложение";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Visible = false;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 113);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(154, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "Максим. кол-во приложений";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "Приложение";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(63, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(200, 46);
			this.label3.TabIndex = 7;
			this.label3.Text = "Данная программа запускает, и контролирует кол-во запущенных приложений";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(37, 241);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(194, 39);
			this.label4.TabIndex = 8;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(245, 257);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 9;
			this.button4.Text = "Назад";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// SEM
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(332, 298);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
			this.Location = new System.Drawing.Point(500, 0);
			this.Name = "SEM";
			this.Text = "SEMAPHORE";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SEMFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		void MainFormLoad(object sender, System.EventArgs e)
		{
			throw new System.NotImplementedException();
		}
	}
}
