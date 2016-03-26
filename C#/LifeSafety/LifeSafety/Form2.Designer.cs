/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 27.03.2016
 * Время: 1:45
 * 
 * 
 */
namespace LifeSafety
{
	partial class Form2
	{
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
        	this.button1 = new System.Windows.Forms.Button();
        	this.textBox1 = new System.Windows.Forms.TextBox();
        	this.textBox2 = new System.Windows.Forms.TextBox();
        	this.textBox3 = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.groupBox1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(313, 11);
        	this.button1.Margin = new System.Windows.Forms.Padding(2);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(150, 48);
        	this.button1.TabIndex = 0;
        	this.button1.Text = "Рассчёт";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// textBox1
        	// 
        	this.textBox1.Location = new System.Drawing.Point(218, 9);
        	this.textBox1.Margin = new System.Windows.Forms.Padding(2);
        	this.textBox1.Name = "textBox1";
        	this.textBox1.Size = new System.Drawing.Size(76, 20);
        	this.textBox1.TabIndex = 1;
        	// 
        	// textBox2
        	// 
        	this.textBox2.Location = new System.Drawing.Point(218, 44);
        	this.textBox2.Margin = new System.Windows.Forms.Padding(2);
        	this.textBox2.Name = "textBox2";
        	this.textBox2.Size = new System.Drawing.Size(76, 20);
        	this.textBox2.TabIndex = 2;
        	// 
        	// textBox3
        	// 
        	this.textBox3.Location = new System.Drawing.Point(218, 79);
        	this.textBox3.Margin = new System.Windows.Forms.Padding(2);
        	this.textBox3.Name = "textBox3";
        	this.textBox3.Size = new System.Drawing.Size(76, 20);
        	this.textBox3.TabIndex = 3;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(9, 9);
        	this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(194, 13);
        	this.label1.TabIndex = 5;
        	this.label1.Text = "Радиус до эпицентра взрыва, метры";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(103, 44);
        	this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(100, 13);
        	this.label2.TabIndex = 6;
        	this.label2.Text = "Масса тратила, кг";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(6, 79);
        	this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(197, 13);
        	this.label3.TabIndex = 7;
        	this.label3.Text = "Плотность населения, тыс.чел /км^2";
        	// 
        	// panel1
        	// 
        	this.panel1.AutoScroll = true;
        	this.panel1.Location = new System.Drawing.Point(6, 19);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(465, 139);
        	this.panel1.TabIndex = 8;
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.panel1);
        	this.groupBox1.Location = new System.Drawing.Point(0, 112);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(471, 167);
        	this.groupBox1.TabIndex = 9;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "Проверка объектов на разрушение от избыточного давления";
        	// 
        	// Form2
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(474, 282);
        	this.Controls.Add(this.groupBox1);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.button1);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.textBox3);
        	this.Controls.Add(this.textBox2);
        	this.Controls.Add(this.textBox1);
        	this.Controls.Add(this.label1);
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "Form2";
        	this.Text = "Form1";
        	this.groupBox1.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
	}
}
