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
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
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
			this.checkBox1.Location = new System.Drawing.Point(6, 19);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(181, 27);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "Создать объект первого типа";
			this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkBox3);
			this.groupBox1.Controls.Add(this.checkBox2);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Location = new System.Drawing.Point(487, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(201, 135);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Панель управления";
			// 
			// checkBox3
			// 
			this.checkBox3.Appearance = System.Windows.Forms.Appearance.Button;
			this.checkBox3.Location = new System.Drawing.Point(6, 86);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(181, 28);
			this.checkBox3.TabIndex = 6;
			this.checkBox3.Text = "Создать произвольный объект";
			this.checkBox3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckedChanged += new System.EventHandler(this.CheckBox3CheckedChanged);
			// 
			// checkBox2
			// 
			this.checkBox2.Appearance = System.Windows.Forms.Appearance.Button;
			this.checkBox2.Location = new System.Drawing.Point(6, 52);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(181, 28);
			this.checkBox2.TabIndex = 4;
			this.checkBox2.Text = "Создать объект второго типа";
			this.checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox2CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(487, 150);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(201, 37);
			this.label1.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(487, 187);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(201, 42);
			this.label2.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(487, 229);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(195, 39);
			this.label3.TabIndex = 8;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(715, 435);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Name = "MainForm";
			this.Text = "graphs";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
