/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 26.03.2016
 * Время: 23:11
 * 
 * 
 */
namespace LifeSafety
{
    partial class Form1
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
        	this.comboBox1 = new System.Windows.Forms.ComboBox();
        	this.label4 = new System.Windows.Forms.Label();
        	this.radioButton1 = new System.Windows.Forms.RadioButton();
        	this.radioButton2 = new System.Windows.Forms.RadioButton();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.checkBox1 = new System.Windows.Forms.CheckBox();
        	this.groupBox2 = new System.Windows.Forms.GroupBox();
        	this.textBox4 = new System.Windows.Forms.TextBox();
        	this.comboBox3 = new System.Windows.Forms.ComboBox();
        	this.comboBox2 = new System.Windows.Forms.ComboBox();
        	this.label7 = new System.Windows.Forms.Label();
        	this.label6 = new System.Windows.Forms.Label();
        	this.label5 = new System.Windows.Forms.Label();
        	this.groupBox1.SuspendLayout();
        	this.groupBox2.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(29, 189);
        	this.button1.Margin = new System.Windows.Forms.Padding(2);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(209, 42);
        	this.button1.TabIndex = 0;
        	this.button1.Text = "Рассчёт";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// textBox1
        	// 
        	this.textBox1.Location = new System.Drawing.Point(460, 21);
        	this.textBox1.Margin = new System.Windows.Forms.Padding(2);
        	this.textBox1.Name = "textBox1";
        	this.textBox1.Size = new System.Drawing.Size(76, 20);
        	this.textBox1.TabIndex = 1;
        	// 
        	// textBox2
        	// 
        	this.textBox2.Location = new System.Drawing.Point(460, 55);
        	this.textBox2.Margin = new System.Windows.Forms.Padding(2);
        	this.textBox2.Name = "textBox2";
        	this.textBox2.Size = new System.Drawing.Size(76, 20);
        	this.textBox2.TabIndex = 2;
        	// 
        	// textBox3
        	// 
        	this.textBox3.Location = new System.Drawing.Point(460, 90);
        	this.textBox3.Margin = new System.Windows.Forms.Padding(2);
        	this.textBox3.Name = "textBox3";
        	this.textBox3.Size = new System.Drawing.Size(76, 20);
        	this.textBox3.TabIndex = 3;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(268, 21);
        	this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(194, 13);
        	this.label1.TabIndex = 5;
        	this.label1.Text = "Радиус до эпицентра взрыва, метры";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(332, 55);
        	this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(130, 13);
        	this.label2.TabIndex = 6;
        	this.label2.Text = "Масса вещества, тонны";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(260, 93);
        	this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(197, 13);
        	this.label3.TabIndex = 7;
        	this.label3.Text = "Плотность населения, тыс.чел /км^2";
        	// 
        	// comboBox1
        	// 
        	this.comboBox1.FormattingEnabled = true;
        	this.comboBox1.Location = new System.Drawing.Point(460, 123);
        	this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
        	this.comboBox1.Name = "comboBox1";
        	this.comboBox1.Size = new System.Drawing.Size(76, 21);
        	this.comboBox1.TabIndex = 8;
        	this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(374, 123);
        	this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(84, 13);
        	this.label4.TabIndex = 9;
        	this.label4.Text = "Тип материала";
        	// 
        	// radioButton1
        	// 
        	this.radioButton1.AutoSize = true;
        	this.radioButton1.Location = new System.Drawing.Point(4, 24);
        	this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
        	this.radioButton1.Name = "radioButton1";
        	this.radioButton1.Size = new System.Drawing.Size(101, 17);
        	this.radioButton1.TabIndex = 10;
        	this.radioButton1.TabStop = true;
        	this.radioButton1.Text = "Одна цистерна";
        	this.radioButton1.UseVisualStyleBackColor = true;
        	this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
        	// 
        	// radioButton2
        	// 
        	this.radioButton2.AutoSize = true;
        	this.radioButton2.Location = new System.Drawing.Point(4, 46);
        	this.radioButton2.Margin = new System.Windows.Forms.Padding(2);
        	this.radioButton2.Name = "radioButton2";
        	this.radioButton2.Size = new System.Drawing.Size(111, 17);
        	this.radioButton2.TabIndex = 11;
        	this.radioButton2.TabStop = true;
        	this.radioButton2.Text = "Группа объектов";
        	this.radioButton2.UseVisualStyleBackColor = true;
        	this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.radioButton2);
        	this.groupBox1.Controls.Add(this.radioButton1);
        	this.groupBox1.Location = new System.Drawing.Point(316, 156);
        	this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
        	this.groupBox1.Size = new System.Drawing.Size(218, 89);
        	this.groupBox1.TabIndex = 12;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "Количество взорвавшихся объектов";
        	// 
        	// checkBox1
        	// 
        	this.checkBox1.AutoSize = true;
        	this.checkBox1.Location = new System.Drawing.Point(20, 17);
        	this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
        	this.checkBox1.Name = "checkBox1";
        	this.checkBox1.Size = new System.Drawing.Size(218, 17);
        	this.checkBox1.TabIndex = 13;
        	this.checkBox1.Text = "Возможность возникновения пожара";
        	this.checkBox1.UseVisualStyleBackColor = true;
        	this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
        	// 
        	// groupBox2
        	// 
        	this.groupBox2.Controls.Add(this.textBox4);
        	this.groupBox2.Controls.Add(this.comboBox3);
        	this.groupBox2.Controls.Add(this.comboBox2);
        	this.groupBox2.Controls.Add(this.label7);
        	this.groupBox2.Controls.Add(this.label6);
        	this.groupBox2.Controls.Add(this.label5);
        	this.groupBox2.Enabled = false;
        	this.groupBox2.Location = new System.Drawing.Point(20, 48);
        	this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
        	this.groupBox2.Name = "groupBox2";
        	this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
        	this.groupBox2.Size = new System.Drawing.Size(220, 128);
        	this.groupBox2.TabIndex = 14;
        	this.groupBox2.TabStop = false;
        	this.groupBox2.Text = "Погодные условия";
        	// 
        	// textBox4
        	// 
        	this.textBox4.Location = new System.Drawing.Point(128, 50);
        	this.textBox4.Margin = new System.Windows.Forms.Padding(2);
        	this.textBox4.Name = "textBox4";
        	this.textBox4.Size = new System.Drawing.Size(90, 20);
        	this.textBox4.TabIndex = 5;
        	// 
        	// comboBox3
        	// 
        	this.comboBox3.FormattingEnabled = true;
        	this.comboBox3.Location = new System.Drawing.Point(128, 81);
        	this.comboBox3.Margin = new System.Windows.Forms.Padding(2);
        	this.comboBox3.Name = "comboBox3";
        	this.comboBox3.Size = new System.Drawing.Size(90, 21);
        	this.comboBox3.TabIndex = 4;
        	this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
        	// 
        	// comboBox2
        	// 
        	this.comboBox2.FormattingEnabled = true;
        	this.comboBox2.Location = new System.Drawing.Point(128, 22);
        	this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
        	this.comboBox2.Name = "comboBox2";
        	this.comboBox2.Size = new System.Drawing.Size(90, 21);
        	this.comboBox2.TabIndex = 3;
        	this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
        	// 
        	// label7
        	// 
        	this.label7.Location = new System.Drawing.Point(4, 74);
        	this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label7.Name = "label7";
        	this.label7.Size = new System.Drawing.Size(87, 49);
        	this.label7.TabIndex = 2;
        	this.label7.Text = "Состояние вертикальной устойчивости";
        	// 
        	// label6
        	// 
        	this.label6.AutoSize = true;
        	this.label6.Location = new System.Drawing.Point(4, 50);
        	this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(112, 13);
        	this.label6.TabIndex = 1;
        	this.label6.Text = "Скорость ветра, м/с";
        	// 
        	// label5
        	// 
        	this.label5.AutoSize = true;
        	this.label5.Location = new System.Drawing.Point(4, 28);
        	this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(82, 13);
        	this.label5.TabIndex = 0;
        	this.label5.Text = "Тип застройки";
        	// 
        	// Form1
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(558, 268);
        	this.Controls.Add(this.groupBox2);
        	this.Controls.Add(this.checkBox1);
        	this.Controls.Add(this.groupBox1);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.comboBox1);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.textBox3);
        	this.Controls.Add(this.textBox2);
        	this.Controls.Add(this.textBox1);
        	this.Controls.Add(this.button1);
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "Form1";
        	this.Text = "Form1";
        	this.groupBox1.ResumeLayout(false);
        	this.groupBox1.PerformLayout();
        	this.groupBox2.ResumeLayout(false);
        	this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}
