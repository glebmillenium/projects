/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 06.11.2015
 * Время: 19:49
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ControllerProcess
{
	/**
	 * Class SEM - графический класс предназначенный 
	 * для ограниченного запуска определенного количества
	 * экземпляров приложения с помощью семафоров
	 * 
	 */
	public partial class SEM : Form
	{
/**
		 * @param Controller - семафор n-ого порядка, 
		 * 					   контролирует число одновременно 
		 * 					   запущенных приложений
		 * 
		 * @var Semaphore
		 */
		Semaphore Controller = null;
		
		/**
		 * @param MyProcess - объект, предназначенный для 
		 * 					запуска процессов
		 * @var Process
		 */
		Process MyProcess = null;
		
		/**
		 * @param ProcessCollection - коллекционный тип данных 
		 * 							(массив ссылок на созданные 
		 * 							объекты определенного типа)
		 * @var List<Process>
		 */
		List<Process> ProcessCollection = new List<Process>();
		
		/**
		 * @param count - определяет число, одновременно 
		 * 				запущенных процессов (при старте 
		 * 				программы равен "0")
		 * 
		 * @var int
		 */
		int count = 0;
		
		/**
		 * Constructor SEM - инициализирует автоматически 
		 * сгенерированный графический интерфейс
		 */
		public SEM()
		{
			InitializeComponent();
		}
		
		/**
		 * Method Button1Click - переводит программу в режим запуска процессов
		 * 
		 * @return void
		 */
		void Button1Click(object sender, EventArgs e)
		{
			bool semaphoreWasCreated;
			button1.Visible  = false; // Скрывает кнопку которая фиксирует
									  // имя запускаемого процесса (или путь) 
									  // и кол-во одновременно работающих приложений
			button2.Visible  = true;  // Делает видимыми кнопки запуска копии приложения
			button3.Visible  = true;  // и остановки
			button4.Enabled  = false;
			textBox1.Enabled = false; // На время управления запущенными потоками
			textBox2.Enabled = false; // делает поле введеных значений не активными
			
			/* Создает семафор с параметрами (arg1, arg2, arg3, arg4), где
			 * 			arg1 - количество свободных входов семафора
			 * 			arg2 - максимальное количество занятых входов
			 * 			arg3 - имя семафора (не обязательно)
			 * 			arg4 - возвращаемое значение при создании семафора
			 * 					true  - успешно!
			 * 					false - не удалось!
			 */
			Controller = new Semaphore(Int32.Parse(textBox2.Text), 
			                           Int32.Parse(textBox2.Text),
			                           "SemaphoreProcess", 
			                           out semaphoreWasCreated); 
			Button3Click(sender, e); // Запуск одной копии приложения
		}
		
		/**
		 * Method Button1Click - запускает копию приложения
		 * в параллельном потоке
		 * 
		 * @param sender - слушатель
		 * @param e		 - передаваемое событие, 
		 * 				 в нашем случае нажатие button
		 * 
		 * @return void
		 */
		void Button3Click(object sender, EventArgs e)
		{
			Thread myThreadMD = new Thread(()=> startProgram()); // Инициализация метода запуска
																 // приложения в параллельном потоке
 			myThreadMD.Start();	// Запуск метода в треде
		}
		
		/**
		 * Method startProgram - запускает процесс, 
		 * и добавляет в глобальную коллекцию
		 * 
		 * @return void
		 */
		void startProgram()
		{
			if(Controller.WaitOne(500)) 
								  // Тред переходит в режим ожидания 
								  // и если все входы в течении 0,5 сек семафора уже "заняты",
								  // выходит из параллельного потока
			{
			MyProcess = Process.Start(textBox1.Text); // Запуск процессса
			
			// Добавление ссылки на объект в коллекцию
			ProcessCollection.Add(MyProcess); 
			
			// Увеличение счетчика одновременно включенных процессов на единицу
			count++; 
			}
			else
			{
			Invoke(new Action(() => label4.Text = "Запущено максимальное количество приложений!"));
			}
		}
		
		/**
		 * Method Button2Click - извлекает процесс, 
		 * 						который был запущен раньше всех
		 * 						и принудительно закрывает его
		 * @param sender - слушатель
		 * @param e		 - передаваемое событие
		 * 
		 * @return void
		 * 
		 */
		void Button2Click(object sender, EventArgs e)
		{
			MyProcess = Enumerable.First(ProcessCollection); // Извлекаем самый старый процесс
			
			// Если процесс был закрыт пользователем без ведома данного приложения
			// то выводим сообщение об ошибке, иначе принудительно закрываем его
			if (MyProcess.HasExited)
				Invoke(new Action(() => label4.Text = "Приложение скорее всего уже было закрыто пользователем!"));
			else
				MyProcess.Kill();
			
			// Удаляем ссылку на объект из коллекции
			ProcessCollection.RemoveAt(0);
			
			// Уменьшаем счетчик на единицу
			count--;
			
			// Освобождаем одно место в семафоре
			Controller.Release();
			
			if (count == 0) resetParametrs(); // Если все процессы были 
											  //закрыты вызываем обнуляющий метод
		}
		
		/**
		 * Method resetParametrs - обнуляет все поля графического класса, 
		 * 						 для дальнейшего повторного запуска приложений (процессов)
		 * 						 и делает невидимыми кнопки управления 
		 * 						 запущенными процессами
		 * 
		 * @return void
		 */
		void resetParametrs()
		{
			MyProcess = null;
			Controller.Close(); 	   // Очищаем семафор
			ProcessCollection.Clear(); // Очищаем коллекцию (массив)
			button1.Visible  = true;
			button2.Visible  = false;
			button3.Visible  = false;
			button4.Enabled  = true;
			textBox1.Enabled = true;   // Делаем textField'ы активными
			textBox2.Enabled = true;   // для нового запуса приложений
			Invoke(new Action(() => label4.Text = ""));
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
		void Button4Click(object sender, EventArgs e)
		{
			Hide(); // Закрываем это окно
			MainForm MainMenu= new MainForm();
			MainMenu.Show(); // Переходим в главное меню
		}
		
		/**
		 * Method SEMFormClosing - ожидаемое событие закрытия окна пользователем.
		 * Освобождает ресурсы приложения и закрывает его.
		 * 
		 * @param  sender Слушатель
		 * @param  e	  Ожидаемое событие (в данном случае "нажатие на кнопку")
		 * 
		 * @return void
		 * 
		 */
		void SEMFormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}
		
	}
}
