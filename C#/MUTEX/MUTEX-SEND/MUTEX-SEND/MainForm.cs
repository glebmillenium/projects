/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 21.10.2015
 * Время: 9:30
 * 
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MUTEX_SEND
{
	/**
	 * Class MainForm - графический класс предназаначенный 
	 * для передачи файлов искомого разрешения(txt, exe, dll и т.д.) 
 	 * во временную папку темп, и передачи управления 
	 * (mutex-a) другой программе (процессу)
	 * 
	 */
	public partial class MainForm : Form
	{
		/**
		 * @param myMutex Создание массива, с глобальным именем 
		 * (идентификатором доступа) "TreatmentFiles"
		 * 
		 * @var Mutex
		 */
		private static Mutex MyMutex = new Mutex(false, "TreatmentFiles");
		
		/**
		 * @param Process Инициализация процесса, 
		 * который будет вызывать и передавать параметры 
		 * другой программе(args[0] - путь к папке в которой будут находится найденные файлы
		 * 
		 * @var Process
		 */
		private static Process MyProcess;
		
		
		public MainForm()
		{
			InitializeComponent();
		}
		
		/**
		 * Method Button1Click - ожидаемое событие при нажатии кнопки, производит
		 * запуск приложения и передачу ей аргумента (место хранения найденных файлов)
		 * 
		 * @param  sender Слушатель
		 * @param  e		 Ожидаемое событие (в данном случае "нажатие на кнопку")
		 * 
		 * @return void
		 */
		void Button1Click(object sender, EventArgs e)
		{
			MyProcess = Process.Start
				("C:\\Users\\Глеб\\Documents\\SharpDevelop Projects" +
				 "\\MUTEX_RECIPIENT\\MUTEX_RECIPIENT\\bin\\Debug" +
				 "\\MUTEX_RECIPIENT.exe", textBox3.Text);			// Вызов программы, по заданному пути
																	// и передача ей аргумента (пути к папке)
			Directory.CreateDirectory(textBox3.Text);
			Directory.CreateDirectory(textBox3.Text + "temp");
			
			label4.Text = "Идет передача файлов...";
			
			Thread myThreadMD = new Thread(()=> getAwayFiles());	// Вызов параллельного потока
 			myThreadMD.Start();
		}
		
		
		/**
		 * Method getAwayFiles - производит передачу файлов во временный каталог
		 *  					 для их обработки другим приложением
		 * 
		 * @reutrn void
		 */
		void getAwayFiles()
		{
			Mutex m = null;								// Инициализируем память для m - типа Mutex,
			DirectoryInfo dirInfo = new DirectoryInfo(textBox1.Text); // Получаем путь к поиску файлов
			int listener = 0;							// Уловка, имеющая двоичное значение, 
														// помогает ниже следуемому циклу определить первый ли 
														//это элемент
			m = Mutex.OpenExisting("TreatmentFiles");	// Попытка открыть созданный мьютекс "TreatmentFiles"
			
			/* Обработка файлов
			 * в данном случае  - просто перенос найденного файла во временный
			 * GetFiles - метод класса dirInfo (arg1, arg2), где
			 * 					  arg1 - регулярное выражение поиска по имени файла
			 * 					  arg2 - параметр задающий тип поиска (AllDirectories -рекурсионный)
			 * 
			 */
		  	foreach (FileInfo file in dirInfo.GetFiles("*."+textBox2.Text, System.IO.SearchOption.AllDirectories))
		  	{
		  		if (listener != 0)
		  		{
		  			Thread.Sleep(2000); // Засыпаем на 2 сек, чтобы другая программа перехватила мьютекс
		  		}
		  		else
		  		{
		  			listener = 1;
		  		}
		  		
		  		if(m.WaitOne())
		  		{
			    	File.Copy(file.FullName, textBox3.Text + "temp" + "\\" + file.Name, true);
			    	m.ReleaseMutex();	// Освобождаем мьютекс
		  		}
			}
		  	
		  	label4.Invoke(new Action(updateLabel)); // При окончании передачи перерисовываем графич. панель 
		  											// (изменяем label4 на "Передача завершена!"
		  	
		  	MyProcess.Close();						// Освобождаем ресурсы процесса
		  	//File.Delete( textBox3.Text + "temp");	// Работает только если приложение запущено с правами Админа!
		}
		
		/** 
		 * Method updateLabel - ввиду вшитой защиты приложения от несанкционированного доступа извне,
		 *  					невозможно перерисовать фрейм в явном виде 
		 * 						(только путем использования не явных функции) типа updateLabel
		 * 
		 * @return void
		 */
		void updateLabel()
        {
            label4.Text = "Передача завершена!";
        }
	}
}
