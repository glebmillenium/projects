/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 06.11.2015
 * Время: 19:47
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ControllerProcess
{
	/**
	 * Class MainForm - графический класс предназначенный 
	 * для перехода в класс контролирующий синхронизацию 
	 * потоков с помощью мьютекса (при вызове 1 приложения)
	 * или семафоров.
	 * 
	 */
	public partial class MainForm : Form
	{
		/**
		 * @param MUTForm - объект имеющий графический интерфейс,
		 * реализуемого мьютекса
		 * 
		 * @var MUT
		 * 
		 */
		MUT MUTForm = new MUT();
		
		/**
		 * @param MUTForm - объект имеющий графический интерфейс,
		 * реализуемого семафора
		 * 
		 * @var SEM
		 * 
		 */
		SEM SEMForm = new SEM();
		
		/**
		 * Constructor MainForm - инициализирует автоматически 
		 * сгенерированный графический интерфейс
		 */
		public MainForm()
		{
			InitializeComponent();
		}
		
		/**
		 * Method Button1Click - запускает окно, реализующее метод
		 * контроллирования потоков с помощью мьютексов и скрывает главное меню.
		 * 
		 * @param sender - слушатель
		 * @param e		 - передаваемое событие
		 * 
		 * @return void
		 * 
		 */
		void Button1Click(object sender, EventArgs e)
		{
			MUTForm.Show();
			Hide();
		}
		
		/**
		 * Method Button2Click - запускает окно, реализующее метод
		 * контроллирования потоков с помощью семафоров и скрывает главное меню.
		 * 
		 * @param sender - слушатель
		 * @param e		 - передаваемое событие
		 * 
		 * @return void
		 * 
		 */
		void Button2Click(object sender, EventArgs e)
		{
			SEMForm.Show();
			Hide();
		}
		
		/**
		 * Method MainFormFormClosing - ожидаемое событие закрытия окна пользователем.
		 * Освобождает ресурсы приложения и закрывает его.
		 * 
		 * @param  sender Слушатель
		 * @param  e	  Ожидаемое событие (в данном случае "нажатие на кнопку")
		 * 
		 * @return void
		 * 
		 */
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}
	}
}
