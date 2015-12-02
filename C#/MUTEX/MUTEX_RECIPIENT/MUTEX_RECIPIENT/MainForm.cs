/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 21.10.2015
 * Время: 22:48
 * 
 */
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MUTEX_RECIPIENT
{

	/**
	 * class MainForm 
	 * Класс, наследник от графического класса Form, 
	 * создает интерфейс с пользователем.
	 * 
	 */
	public partial class MainForm : Form
	{
		/**
		 * @param args строковый массив, содержащий переданные программе аргументы
		 * 
		 * @var string[]
		 */
		string[] args = null;

		/**
		 * Constructor MainForm - Если были переданы параметры программе,
		 * производим передачу файлов
		 * 
		 * @param string[] input Каталог, в котором будут находится файлы
		 * 
		 */
		public MainForm(string[] input)
		{
			InitializeComponent();
			Thread.Sleep(1000);
			this.args = input;
			
			Thread myThreadMD1 = new Thread(()=> getAwayFiles( args )); // Вызов параллельного потока
 			myThreadMD1.Start();
		}
		
		/**
		 * Constructor MainForm - конструктор не имеющий входных параметров
		 * выводит сообщение об ошибке.
		 */
		public MainForm()
		{
			InitializeComponent();
			label1.Text = "Данное приложение будет корректно работать только, если будет запущено" +
				"из другого приложения, т.е. должно быть создано процессом из вне!";
		}
		
		/**
		 * Метод getAwayFiles - Производит непосредственную передачу файлов 
		 * из временной папки /temp в основной каталог
		 * 
		 * @param string[] args - входные параметры, где 
		 * 						  args[0] - путь в котором будут 
		 * 									находится искомые файлы
		 * @return void
		 * 
		 */
		void getAwayFiles(string[] args)
		{
			string[] files = null;						// Инициализируем память для массива, 
														// в котором будут находится пути файлов
			Mutex m = null;								// Инициализируем память для m - типа Mutex,
														// в котором будет находится ссылка на искомый Mutex
			m = Mutex.OpenExisting("TreatmentFiles");	// Попытка открыть системный(глобальный) Mutex
														// с именем "TreatmentFiles"

			while(true) {								// Псевдобесконечный цикл
				
				if(m.WaitOne())							// Ожидаем освобождение мьютекса и занимаем его
				{
					files = Directory.GetFiles(args[0]+"temp"); 	// Получение путей к файлам
					if(files.Length == 0){
						label1.Text += "Перенос файлов завершен!";	// Если файлы не обнаружены, 
																	// то выход из цикла и сообщение 
																	// о завершении работы
						m.ReleaseMutex();							// Освобождение мьютекса 
						break;
					}
					DirectoryInfo dirInfo = new DirectoryInfo(args[0]+"temp");
					
					/* Цикл который перемещает файл из временного каталога в основной */
				  	foreach (FileInfo file in dirInfo.GetFiles("*"))
			  		{
				  		File.Copy(file.FullName, args[0]+file.Name, true);
				  		File.Delete(file.FullName);
				  		label1.Text += "Файл "+file.FullName+" перемещен!\n";
					} // endfor
				  	
				  	m.ReleaseMutex();	// Освобождение мьютекса 
				  	Thread.Sleep(2000); // Даем квант времени (2сек) другой программе, чтобы занять мьютекс
				}
			}
		}
				
	}
}
