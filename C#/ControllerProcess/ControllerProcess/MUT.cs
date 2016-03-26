/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 06.11.2015
 * Время: 20:01
 * 
 * 
 */
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace ControllerProcess
{
	/**
	 * class MUT
	 * Класс, который контролирует вход потоков в контроллируемую часть
	 * часть кода с помощью применения Мьютекса (одноместного семафора)
	 * 
	 */
	public partial class MUT : Form
	{
		/**
		 * @param StarterMutex - объект, имеющий ссылку на созданный мьюекс
		 * @var	  Mutex
		 */
		Mutex StarterMutex = null;
		
		/**
		 * @param StarterProcess - объект имеющий ссылку на созданный процесс
		 * @var	  Process
		 */
		Process StarterProcess = null;
		
		/**
		 * Constructor MUT - инициализирует графический интерфейс,
		 * где пользователь вводит имя приложения (путь к нему)
		 * 
		 */
		public MUT()
		{
			InitializeComponent();
		}
		
		/**
		 * Method Button1Click - ожидаемое событие при нажатии кнопки,
		 * осуществляет запуск параллельного потока, точка вызового которого
		 * является метод startProgram
		 * 
		 * @param  sender Слушатель
		 * @param  e	  Ожидаемое событие (в данном случае "нажатие на кнопку")
		 * 
		 * @return void
		 * 
		 */
		void Button1Click(object sender, EventArgs e)
		{
			button2.Enabled = true;
			button3.Enabled = false;
			Thread myThread = new Thread(() => startProgram());
			myThread.Start();
		}
		
		/**
		 * Method startProgram - проверяет свободен ли мьютекс,
		 * если свободен запускает процесс, и переводит мьютекс в режим ожидания
		 * (ждет, когда мьютекс будет свободен), чтобы закрыть поток).
		 * Если мьютекс занят выводит сообщение об ошибке.
		 * 
		 * @return void
		 * 
		 */
		void startProgram()
		{
			bool existed;
			Mutex mutexObj = new Mutex(true, "MutexControllProcess", out existed);
			if(existed)
			{
				label4.Invoke(new Action(() => label4.Text = ""));
				StarterMutex = mutexObj;
				mutexObj.WaitOne();
				StarterProcess = Process.Start(textBox1.Text);
			}
			else 
			{
				label4.Invoke(new Action(() => label4.Text = "Приложение уже было запущено!"));
				mutexObj.Dispose();
			}
				
		}

		/**
		 * Method Button2Click - ожидаемое событие при нажатии кнопки,
		 * осуществляет запуск приложения
		 * 
		 * @param  sender Слушатель
		 * @param  e	  Ожидаемое событие (в данном случае "нажатие на кнопку")
		 * 
		 * @return void
		 * 
		 */
		void Button2Click(object sender, EventArgs e)
		{
			/* Если Объект имеет ссылку на созданный мьютекс (т.е. 
			 * мьютекс был создан) и процесс не был завершен пользователем
			 * преждевременно, то убиваем процесс и освобождаем мьютекс
			 */
			StarterMutex.Dispose();
			if ( StarterMutex != null && !StarterProcess.HasExited )
			{
				StarterProcess.Kill();
				Invoke(new Action(() => label4.Text = ""));
			}
			
			button2.Enabled = false;
			button3.Enabled = true;
		}
		
		/**
		 * Method Button3Click - ожидаемое событие нажатия кнопки "Назад"
		 * 
		 * @param  sender Слушатель
		 * @param  e	  Ожидаемое событие (в данном случае "нажатие на кнопку")
		 * 
		 * @return void
		 * 
		 */
		void Button3Click(object sender, EventArgs e)
		{
			Hide(); // Закрываем это окно
			MainForm MainMenu= new MainForm();
			MainMenu.Show(); // Переходим в главное меню
		}
		
		/**
		 * Method MUTFormClosing - ожидаемое событие закрытия окна пользователем.
		 * Освобождает ресурсы приложения и закрывает его.
		 * 
		 * @param  sender Слушатель
		 * @param  e	  Ожидаемое событие (в данном случае "нажатие на кнопку")
		 * 
		 * @return void
		 * 
		 */
		void MUTFormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}
	}
}
