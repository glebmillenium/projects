/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 07.11.2015
 * Время: 1:23
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CALL_PROGRAM_WITH_ARGS
{
	/**
	 * Class MainForm - графический класс предназаначенный 
	 * для вызова другой программы и передачи ей аргументов,
	 * введенных самим пользователем.
	 * 
	 */
	public partial class MainForm : Form
	{
		/**
		 * @param Starter - объект содержащий свойство, вызваемого процесса
		 * (приложения).
		 * 
		 * @var Process
		 * 
		 */
		Process Starter = null;
		
		/**
		 * Constructor MainForm - инициализирует графический интерфейс,
		 * где пользователь вводит имя приложения (путь к нему) и передаваемые
		 * аргументы.
		 * 
		 */
		public MainForm()
		{
			InitializeComponent();
		}
		
		/**
		 * Method Button1Click - ожидаемое событие при нажатии кнопки,
		 * осуществляет запуск приложения
		 * 
		 * @param  sender Слушатель
		 * @param  e	  Ожидаемое событие (в данном случае "нажатие на кнопку")
		 * 
		 * @return void
		 * 
		 */
		void Button1Click(object sender, EventArgs e)
		{
			button1.Enabled = false;
			button2.Enabled = true;
			/* Вызываем процесс и присваиваем ссылку объекту Starter, 
			 * Process.Start(arg1, arg2) - где,
			 * 				arg1 - Путь к приложению (или его имя),
			 * 				arg2 - Передаваемые параметры
			 */
			Starter = Process.Start(textBox1.Text, textBox2.Text);
		}
		
		/**
		 * Method Button2Click - ожидаемое событие при нажатии кнопки,
		 * осуществляет мгновенную остановку приложения
		 * 
		 * @param  sender Слушатель
		 * @param  e	  Ожидаемое событие (в данном случае "нажатие на кнопку")
		 * 
		 * @return void
		 * 
		 */
		void Button2Click(object sender, EventArgs e)
		{
			button1.Enabled = true;
			button2.Enabled = false;
			/* Если приложение было закрыто пользователем то ничего не делаем */
			if(!Starter.HasExited)
				Starter.Kill();
		}
	}
}
