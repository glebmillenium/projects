/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 26.03.2016
 * Время: 0:32
 * 
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LifeSafety
{
	
	public partial class Annex1 : Form
	{
		string core = @"C:\Users\Глеб\Desktop\LifeSafety\Core\";
		string data = @"C:\Users\Глеб\Desktop\LifeSafety\Data\";
		string tables = @"C:\Users\Глеб\Desktop\LifeSafety\Tables\";
		string tasks = @"C:\Users\Глеб\Desktop\LifeSafety\Tasks\";
		DataGridView information = new DataGridView();

		string[] str = new string[]{
			"Значения коэффициента аэродинамического споротивления Cx при избыточном давлении delPfi < 0,5 кгс/см^2",
			"Степень возгорания материалов в зависимости от величины теплового импульса",
			"Степень поражения людей от теплового импульса",
			"Токсодозы некоторых СДЯВ и ОХВ",
			"Величины избыточного давления delPfi, кгс/см^2, при которых возникают разрушения различной степени",
			"Показатели врзывопожароопасности горючих газов, паров, легковоспламеняющихся и горючих жидкостей",
			"Показатели взрывной опасности некоторых взрывоопасных целей и волокон",
			"Теплота сгорания некоторых углеводородов",
			"Плотность вохдуха при различных температурах",
			"Максимальные значения светотеплового импульса Uсв, кДж/м^2, соответствующие избыточным давлениям delPfi, кПа на расстоянии R, м, от очага назменого ядерного взрыва разной мощности",
			"Радиусы зон поражения, км, в зависимости от мощности ядерного боеприпаса"
			};

		public Annex1()
		{
			InitializeComponent();
	        this.Controls.Add(information);	
        	information.Name = "bookingDataGridView";
	        information.Location = new Point(20, 70);
	        information.Size = new Size(500, 250);
			foreach (var arg1 in str)
			{
				comboBox1.Items.Add(arg1);
			}
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			information.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
				
		}
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			information.Rows.Clear();
			if (comboBox1.SelectedItem.ToString() == str[0])
			{
				head1();
				basis(1);
			}
			if (comboBox1.SelectedItem.ToString() == str[1]){
				head2();
				basis(2);
			}
			if (comboBox1.SelectedItem.ToString() == str[2]){
				head3();
				basis(3);
			}
			if (comboBox1.SelectedItem.ToString() == str[3]){
				head4();
				basis(4);
			}
			if (comboBox1.SelectedItem.ToString() == str[4]){
				head5();
				basis(5);
			}
			if (comboBox1.SelectedItem.ToString() == str[5]){
				head6();
				basis(6);
			}
			if (comboBox1.SelectedItem.ToString() == str[6]){
				head7();
				basis(7);
			}
			if (comboBox1.SelectedItem.ToString() == str[7]){
				head8();
				basis(8);
			}
			if (comboBox1.SelectedItem.ToString() == str[8]){
				head9();
				basis(9);
			}
			if (comboBox1.SelectedItem.ToString() == str[9]){
				head10();
				basis(10);
			}
			if (comboBox1.SelectedItem.ToString() == str[10]){
				head11();
				basis(11);
			}
		}
		
		void head1()
		{
        	information.ColumnCount = 3;
	
	        information.RowHeadersVisible = false;
	
	        information.Columns[0].Name = "Форма тела";
	        information.Columns[0].Width = 210;
	        information.Columns[1].Name = "Cx";
	        information.Columns[1].Width = 80;
	        information.Columns[2].Name = "Направление движения воздуха";
	        information.Columns[2].Width = 210;
	        //data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.;
		}
		
		void head2()
		{

        	information.ColumnCount = 3;

        	information.Name = "bookingDataGridView";
	        information.Location = new Point(20, 70);
	        information.Size = new Size(500, 250);
	
	        information.RowHeadersVisible = false;
	
	        information.Columns[0].Name = "Наименование материалов и оборудования";
	        information.Columns[0].Width = 200;
	        information.Columns[1].Name = "Воспламенение, обугливание";
	        information.Columns[1].Width = 150;
	        information.Columns[2].Name = "Устойчивое горение";
	        information.Columns[2].Width = 150;
		}
		
		void head3()
		{

        	information.ColumnCount = 5;

        	information.Name = "bookingDataGridView";
	        information.Location = new Point(20, 70);
	        information.Size = new Size(500, 250);
	
	        information.RowHeadersVisible = false;
	
	        information.Columns[0].Name = "Степень поражения";
	        information.Columns[0].Width = 100;
	        information.Columns[1].Name = "Тепловой импульс, ккал/см2";
	        information.Columns[1].Width = 50;
	        information.Columns[2].Name = "Тепловой импульс, кДж/м2";
	        information.Columns[2].Width = 50;
	        information.Columns[3].Name = "Внешние признаки ожога";
	        information.Columns[3].Width = 150;
	        information.Columns[4].Name = "Лечение ожога";
	        information.Columns[4].Width = 150;
		}
		
		void head4()
		{
        	information.ColumnCount = 4;

        	information.Name = "bookingDataGridView";
	        information.Location = new Point(20, 70);
	        information.Size = new Size(500, 250);
	
	        information.RowHeadersVisible = false;
	
	        information.Columns[0].Name = "Наименование вещества";
	        information.Columns[0].Width = 120;
	        information.Columns[1].Name = "Смертельная токсодоза г.мин/м3";
	        information.Columns[1].Width = 120;
	        information.Columns[2].Name = "Поражающая токсодоза г.мин/м3";
	        information.Columns[2].Width = 120;
	        information.Columns[3].Name = "Смертельное поражение через кожу мг/чел";
	        information.Columns[3].Width = 120;
		}
		
		void head5()
		{
			information.ColumnCount = 4;

        	information.Name = "bookingDataGridView";
	        information.Location = new Point(20, 70);
	        information.Size = new Size(500, 250);
	
	        information.RowHeadersVisible = false;
	
	        information.Columns[0].Name = "Объекты разрушения";
	        information.Columns[0].Width = 220;
	        information.Columns[1].Name = "сильная степень";
	        information.Columns[1].Width = 90;
	        information.Columns[2].Name = "средняя степень";
	        information.Columns[2].Width = 90;
	        information.Columns[3].Name = "слабая степень";
	        information.Columns[3].Width = 90;
		}
		
		void head6()
		{
			information.ColumnCount = 7;

        	information.Name = "bookingDataGridView";
	        information.Location = new Point(20, 70);
	        information.Size = new Size(500, 250);
	
	        information.RowHeadersVisible = false;
	
	        information.Columns[0].Name = "Вещество";
	        information.Columns[0].Width = 120;
	        information.Columns[1].Name = "Условное обозначение";
	        information.Columns[1].Width = 60;
	        information.Columns[2].Name = "Температура вспышки";
	        information.Columns[2].Width = 60;
	        information.Columns[3].Name = "% по объему";
	        information.Columns[3].Width = 60;
	        information.Columns[4].Name = "г/м3 при 20 °С";
	        information.Columns[4].Width = 60;
	        information.Columns[5].Name = "% по объему";
	        information.Columns[5].Width = 60;
	        information.Columns[6].Name = "г/м3 при 20 °С";
	        information.Columns[6].Width = 60;
		}
		
		void head7()
		{
			information.ColumnCount = 3;

        	information.Name = "bookingDataGridView";
	        information.Location = new Point(20, 70);
	        information.Size = new Size(500, 250);
	        information.Columns[0].Name = "Взрывоопасная пыль (волокно)";
	        information.Columns[0].Width = 200;
	        information.Columns[1].Name = "Температура самовоспламенения аэрозоля, tc, °С";
	        information.Columns[1].Width = 150;
	        information.Columns[2].Name = "Нижний концентрационный предел взрываемости, г/м1";
	        information.Columns[2].Width = 150;
		}
		
		void head8()
		{
			information.ColumnCount = 2;
	        information.Location = new Point(20, 70);
	        information.Size = new Size(500, 250);
	        information.Columns[0].Name = "Углеводороды";
	        information.Columns[0].Width = 250;
	        information.Columns[1].Name = "Теплота сгорания, q, Дж/кг";
	        information.Columns[1].Width = 250;
		}
		
		void head9()
		{
			information.ColumnCount = 2;
	        information.Location = new Point(20, 70);
	        information.Size = new Size(500, 250);
	        information.Columns[0].Name = "Температура воздуха, иС";
	        information.Columns[0].Width = 250;
	        information.Columns[1].Name = "Плотность воздуха, кг/м3";
	        information.Columns[1].Width = 250;
		}
		
		void head10()
		{
			
		}
		
		void head11()
		{
			
		}
		
		void basis(int number)
		{
			string[][] need_data = (new WorkWithFile(tables + "Annex_1/table_" + number + ".bjd")).writtingToArray(new char[]{'|', '|'});
			foreach(var arg1 in need_data)
			{
				information.Rows.Add(arg1);
			}
		}
	}
}
