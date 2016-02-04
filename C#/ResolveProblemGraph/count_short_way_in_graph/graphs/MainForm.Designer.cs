/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 27.01.2016
 * Время: 23:58
 * 
 * 
 */
namespace graphs
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(469, 323);
			this.panel1.TabIndex = 0;
			this.panel1.Click += new System.EventHandler(this.Panel1Click);
			// 
			// checkBox1
			// 
			this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
			this.checkBox1.Location = new System.Drawing.Point(6, 33);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(158, 24);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "Создать узел";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.Click += new System.EventHandler(this.CheckBox1Click);
			// 
			// checkBox2
			// 
			this.checkBox2.Appearance = System.Windows.Forms.Appearance.Button;
			this.checkBox2.Location = new System.Drawing.Point(6, 63);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(158, 24);
			this.checkBox2.TabIndex = 4;
			this.checkBox2.Text = "Создать связь";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.Click += new System.EventHandler(this.CheckBox2Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkBox3);
			this.groupBox1.Controls.Add(this.checkBox2);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Location = new System.Drawing.Point(487, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(170, 132);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Панель управления";
			// 
			// checkBox3
			// 
			this.checkBox3.Appearance = System.Windows.Forms.Appearance.Button;
			this.checkBox3.Location = new System.Drawing.Point(6, 93);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(158, 24);
			this.checkBox3.TabIndex = 5;
			this.checkBox3.Text = "Удалить компоненту";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.Click += new System.EventHandler(this.CheckBox3Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Location = new System.Drawing.Point(493, 150);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(179, 111);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Действие:";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(6, 77);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(158, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "Построить остовное дерево";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(6, 48);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(158, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Провести раскраску графа";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(6, 19);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(158, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Найти оптимальный путь";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(499, 287);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(55, 20);
			this.textBox1.TabIndex = 7;
			this.textBox1.Text = "0";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(499, 264);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 20);
			this.label1.TabIndex = 8;
			this.label1.Text = "Начало графа";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(583, 264);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 20);
			this.label2.TabIndex = 10;
			this.label2.Text = "Конец графа";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(583, 287);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(56, 20);
			this.textBox2.TabIndex = 9;
			this.textBox2.Text = "0";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 352);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(592, 74);
			this.label3.TabIndex = 11;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(715, 435);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Name = "MainForm";
			this.Text = "graphs";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
