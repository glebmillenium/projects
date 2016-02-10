using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Library;

namespace MainFrame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton5.Checked = true; //По умолчанию: прямое преобразование
            Dir = 1; //по умолчанию прямое преобразование
            textBox17.ReadOnly = true; //Поля с текущими данными не редактируемое
            textBox1.ReadOnly = true; //Поля с текущими данными не редактируемое
            textBox2.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            button1.Enabled = false; //До загрузки данных запуск алгоритма не возможен.
            button3.Enabled = false; //До обработки данных алгоритмом сохранение результата невозможно
        }
        int Dir; //Прямое или обратное преобразование
        Vector<Complex> Data;
        ulong Dimension;

        #region Проверка данных, вызов алгоритма
        private void button1_Click(object sender, EventArgs e)
        {
            if (Data == null) //Если всё же удалось запустить без данных - ошибка.
            {
                MessageBox.Show("Введите данные!");
                return;
            }
            textBox17.Text = (Data.ToString());

            //Для проверки выполняем глупый алгоритм
            Vector<Complex> NewData;
            NewData = Transformation.FFT_L(Data, Dir);

            Transformation.FFTReOrder(Data);
            Transformation.FFT_T(Data, 0, Dimension, Dir);

            if (Dir == -1)
            {
                for (ulong i = 0; i < Dimension; i++)
                {
                    Data[i].i /= Dimension;
                    Data[i].r /= Dimension;

                    NewData[i].i /= Dimension;
                    NewData[i].r /= Dimension;
                }
            }

            if (NewData != null) textBox2.Text = (NewData.ToString());
            if (Data != null) textBox1.Text = (Data.ToString());
            button3.Enabled = true;
        }
        #endregion

        #region Открытие из файла
        string s;
        OpenFileDialog Open;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Open = new OpenFileDialog();
                Open.Filter = "Текстовые файлы (*.txt)|*txt|Все файлы (*.*)|*.*";
                Open.ShowDialog();
                StreamReader openfile = new StreamReader(Open.FileName, Encoding.GetEncoding(1251)); //Явно декодируем виндуузовскую кодировку
                openfile.BaseStream.Position = 0;  // В начало потока перейти
                if ((s = openfile.ReadLine()) != null)
                {
                    if (s.Length > 2000)
                    {
                        MessageBox.Show("Входная строка имеет длину больше 100!");
                        openfile.Close();
                        return;
                    }
                    
                    s = s.Replace("  ", string.Empty);
                    s = s.Trim().Replace(" ", string.Empty);

                    string[] numbers = s.Split(new char[3]{ '+', 'i', ';' });
                    Dimension = (ulong)numbers.Length/3; //Размерность вектора
                    Data = new Vector<Complex>(Dimension);

                    for (ulong i = 0; i < Dimension; i ++)
                    {
                        Data[i] = new Complex(Convert.ToDouble(numbers[3 * i]), Convert.ToDouble(numbers[3 * i + 1]));
                        if (Data[i].i > 1000 || Data[i].r > 1000 || Data[i].r < -1000 || Data[i].i < -1000) {
                            MessageBox.Show(String.Format("Данные числа с номером {0} превышают по модулю 1000!", i));
                            Data = null;
                            textBox1.Text = "";
                            openfile.Close();
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неверный формат входных данных!");
                    Data = null;
                    textBox1.Text = "";
                    openfile.Close();
                    return;
                }
                if (openfile.ReadLine() != null)
                {
                    MessageBox.Show("В файле содержится больше одной строки!");
                    Data = null;
                    textBox1.Text = "";
                    openfile.Close();
                    return;
                }
                openfile.Close(); //До сюда доходим только если ранее не вылетело ошибок
                button1.Enabled = true;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Файл не соответствет формату!");
                Data = null;
                textBox17.Text = "";
                return;
            }
            catch (Exception exc)  // возможные ошибки типа "Доступ к файлу запрещён"
            {
                MessageBox.Show(exc.Message + "\n");
                Data = null;
                textBox17.Text = "";
                return;
            }
            if (Data != null) textBox17.Text = (Data.ToString());
        }
#endregion

        #region Сохранение в файл
        SaveFileDialog Save;
        private void button3_Click(object sender, EventArgs e)
        {
                try
                {
                    Save = new SaveFileDialog();
                    Save.FileName = "Fourier Transform.txt";
                    Save.ShowDialog();
                    if (Save.FileName != null)
                    {
                        StreamWriter savefile = new StreamWriter(Save.FileName, false, Encoding.GetEncoding(1251)); 
                    //Явно кодируем виндуозовской кодировкой
                        savefile.WriteLine(Data.ToString());
                        savefile.Flush();
                        savefile.Close();
                     }
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Файл не соответствет формату!");
                    return;
                }
                catch (Exception exc)  // возможные ошибки типа "Доступ к файлу запрещён"
                {
                    MessageBox.Show(exc.Message + "\n");
                    return;
                }
        }
        #endregion

        #region Настройки алгоритма
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Dir = 1;//Прямое преобразование
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            Dir = -1;//Обратное преобразование
        }
        #endregion

        #region Кнопка "Выход" page 1
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Кнопка "Help" page 1
        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа для вычисления дискретного преобразования Фурье (ДПФ)\n\nВходной файл должен содержать одну строку вида:\n'a_0 + b_0 i; a_1 + b_1 i; …; a_(n - 1) + b_(n - 1) i;' Где n = 2^k\nПосле загрузки входного файла выберите режим работы и нажмите кнопку 'Запуск алгоритма'.\nРезультаты работы можно сохранить в текстовый файл при помощи кнопки 'Сохранить в файл'.\n\nПрограмма выполнена в рамках лабораторных работ\nпо предмету Эксплуатация ПО\nРазработчик: Резницкий Михаил\nГруппа: ПИ13-1, 2015 год");
        }
        #endregion


        #region Кнопка "Выход" page 2
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Кнопка "Help" page 2
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для сравнения скорости работы быстрого алгоритма вычисления ДПФ\nс алгоритмом явного вычисления введите размерность вектора и колчество опытов в соответствующие поля.\nПосле нажатия кнопки 'Пуск' программа проведёт тестирование и выдаст вам результат работы.\n\nПрограмма выполнена в рамках лабораторных работ\nпо предмету Эксплуатация ПО\nРазработчик: Резницкий Михаил\nГруппа: ПИ13-1, 2015 год");
        }
        #endregion

        private void button8_Click(object sender, EventArgs e)
        {
            Dir = 1;
            int numberOfTests;
            if (!int.TryParse(textBox4.Text, out numberOfTests))
            {
                MessageBox.Show("Количество тестов должно быть целым положительным числом!");
                return;
            }
            ulong VectorsLength;
            if (!ulong.TryParse(textBox3.Text, out VectorsLength))
            {
                MessageBox.Show("Размерность вектора должна быть целым положительным числом");
                return;
            }
            if (numberOfTests > 300) {
                MessageBox.Show("Количество тестов должно не больше 300");
                return;
            }

            if (!(VectorsLength == 1||VectorsLength ==2|| VectorsLength == 4 || VectorsLength == 8|| VectorsLength == 16 || VectorsLength == 32 || VectorsLength == 64 || VectorsLength == 128 || VectorsLength == 256 || VectorsLength == 512 || VectorsLength == 1024))
            {
                MessageBox.Show("Длина вектора должна быть равна 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 или 1024.");
                return;
            }

            Random rnd = new Random();

            TimeSpan a, b;
            a = TimeSpan.Zero;
            b = TimeSpan.Zero;
             
            for (int test = 0; test < numberOfTests; test++)
            {
                Vector<Complex> vec = new Vector<Complex>(VectorsLength);
                for (ulong i = 0; i < VectorsLength; i++)
                {
                    double re = Convert.ToDouble(rnd.Next(-100, 100) / 10.0);
                    double im = Convert.ToDouble(rnd.Next(-100, 100) / 10.0);
                    vec[i] = new Complex(re, im);
                }
                System.Diagnostics.Stopwatch swatch = new System.Diagnostics.Stopwatch();
                swatch.Start();
                //Выполнили глупый алгоритм
                Vector<Complex> NewData = Transformation.FFT_L(vec, Dir);
                //Записали время
                swatch.Stop();
                TimeSpan ai = swatch.Elapsed;
                swatch.Start();
                //Выполнили быстрый алгоритм
                Transformation.FFTReOrder(vec);
                Transformation.FFT_T(vec, 0, VectorsLength, Dir);
                //Записали время
                swatch.Stop();
                TimeSpan bi = swatch.Elapsed;
                //Добавили время выполнения итераций к общему времени
                a += ai;
                b += bi - ai;
            }

            textBox5.Text = String.Format("Минут: {0}, секунд {1}, милисекунд {2}. Общее число миллисекунд: {3}", a.Minutes,a.Seconds,a.Milliseconds, a.TotalMilliseconds);
            textBox6.Text = String.Format("Минут: {0}, секунд {1}, милисекунд {2}. Общее число миллисекунд: {3}", b.Minutes, b.Seconds, b.Milliseconds, b.TotalMilliseconds);
        }
    }
}
