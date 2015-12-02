/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 21.10.2015
 * Время: 9:30
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace MUTEX_SEND
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		
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
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(30, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(183, 21);
			this.label1.TabIndex = 0;
			this.label1.Text = "Путь откуда начать поиск файлов";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(138, 199);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Начать!";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(30, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(183, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Какой тип расширения файлов";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(30, 33);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(156, 20);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "C:\\Gleban";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(30, 127);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(215, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Директория для хранения этих файлов";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(30, 95);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(156, 20);
			this.textBox2.TabIndex = 6;
			this.textBox2.Text = "txt";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(30, 153);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(156, 20);
			this.textBox3.TabIndex = 7;
			this.textBox3.Text = "C:\\search\\";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 176);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(181, 20);
			this.label4.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(115, 225);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(123, 23);
			this.label5.TabIndex = 9;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Name = "MainForm";
			this.Text = "MUTEX-SEND";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
