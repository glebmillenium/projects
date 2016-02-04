/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 02.11.2015
 * Время: 21:26
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace KRI
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.Button Ок;
		
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
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label = new System.Windows.Forms.Label();
			this.Ок = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(151, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "кри";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(47, 78);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(41, 20);
			this.textBox2.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(83, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "пыль";
			// 
			// label
			// 
			this.label.Location = new System.Drawing.Point(172, 126);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(100, 23);
			this.label.TabIndex = 4;
			// 
			// Ок
			// 
			this.Ок.Location = new System.Drawing.Point(105, 126);
			this.Ок.Name = "Ок";
			this.Ок.Size = new System.Drawing.Size(41, 23);
			this.Ок.TabIndex = 5;
			this.Ок.Text = "Ок";
			this.Ок.UseVisualStyleBackColor = true;
			this.Ок.Click += new System.EventHandler(this.ОкClick);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(151, 78);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(49, 20);
			this.textBox1.TabIndex = 6;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.Ок);
			this.Controls.Add(this.label);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label1);
			this.Name = "MainForm";
			this.Text = "KRI";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
