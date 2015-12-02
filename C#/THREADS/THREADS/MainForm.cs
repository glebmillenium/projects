/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 06.11.2015
 * Время: 12:17
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace THREADS
{
	/**
	 * Class MainForm - графический класс предназаначенный 
	 * для передачи реализации двух потоков: 
	 * - Поток, показывающий прогресс в прогресс баре
	 * - Поток, генерирующий случайное число
	 * 
	 */
	public partial class MainForm : Form
	{
		/**
		 * @param ProgressBar - Тред, который будет 
		 * запускать движение полосы прогресс бар
		 * 
		 * @var Thread
		 */
		Thread ProgressBar = null;
		
		/**
		 * @param GenerateNumb - Тред, который будет
		 * генерировать случ. числа
		 * 
		 * @var Thread
		 */
		Thread GenerateNumb = null;
		
		/**
		 * Constructor MainForm - инициализирует графический интерфейс,
		 * где пользователь запускает потоки и останавливает
		 * 
		 */
		public MainForm()
		{
			InitializeComponent();
		}
		
		/**
		 * Method Button1Click - ожидаемое событие при нажатии кнопки,
		 * осуществляет запуск потоков
		 * 
		 * @param  sender Слушатель
		 * @param  e	  Ожидаемое событие (в данном случае "нажатие на кнопку")
		 * 
		 * @return void
		 * 
		 */
		void Button1Click(object sender, EventArgs e)
		{
			ProgressBar = new Thread( () => progressBar() ); // Создаем объект треда, 
												// инициализирующий запуск прогресс бара
			GenerateNumb = new Thread( ()=>generateNumb() ); // Создаем объект треда
												// инициализирующий запуск генератора случайных чисел
			button1.Enabled = false;
			button2.Enabled = true;
			ProgressBar.Start();
			GenerateNumb.Start();
		}
		
		/**
		 * Method progressBar запускает прогресс бар
		 * 
		 * @return void
		 * 
		 */
		void progressBar()
		{
			while(true)
			{
				/* Цикл, который двигает полосу прогресс бара, где его макс. значение
				 * равно 15 (выставлено в самом прогресс баре)
				 */
				for(int i=0; i<=15; i++)
				{
					/* Так как полоса прогресс бара, меняется путем задания
					 * значения из побочного потока в основной (прогресс бар создан в основном)
					 * требуется, чтобы побочный поток засыпал и 
					 * основной успел изменить значение
					 */
					Invoke(new Action(() => progressBar1.Value = i));
					Thread.Sleep(300);
				}
				Thread.Sleep(500);
			}
					
		}
		
		/**
		 * Method generateNumb - генерирует случайные числа и
		 * изменяет фон квадрата через RGB, где r, g, b получают
		 * значения случайных чисел в диапазоне от [0:255)
		 * 
		 * @return void
		 * 
		 */
		void generateNumb()
		{
			Random rnd = new Random();
			while (true)
			{
				Invoke( new Action( ()=>textBox1.Text = rnd.Next().ToString() ) );
				label2.BackColor = Color.FromArgb(rnd.Next()%255, rnd.Next()%255, rnd.Next()%255);
				Thread.Sleep(200); // Вызываем "простаивание" потока
				// Чтобы пользователь визуально увидел случ. число
			}
		}
		
		/**
		 * Method Button2Click - ожидаемое событие при нажатии кнопки,
		 * осуществляет остановку и удаление потоков как "объекта"
		 * 
		 * @param  sender Слушатель
		 * @param  e	  Ожидаемое событие (в данном случае "нажатие на кнопку")
		 * 
		 * @return void
		 * 
		 */
		void Button2Click(object sender, EventArgs e)
		{
			/* Для потока "ProgressBar" */
			ProgressBar.Abort();  // Прерывает и уничтожает
			ProgressBar.Join();   // Ждет когда система удалит этот поток из операт. памяти
			
			/* Для потока "GenerateNumb" */
			GenerateNumb.Abort(); // Прерывает и уничтожает
			GenerateNumb.Join();  // Ждет когда система удалит этот поток из операт. памяти
			
			ProgressBar  = null;  // Очищает значение объекта
			GenerateNumb = null;  // Очищает значение объекта
			button1.Enabled = true;
			button2.Enabled = false;
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
			if (!button1.Enabled)
				Button2Click(sender, e); // Освобождает ресурсы
		}
	}
}
