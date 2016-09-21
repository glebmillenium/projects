/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab_3;

import javax.swing.JOptionPane;

/**
 *
 * @author glebmillenium
 */
public class Lab_3 {

    public static void count(double x_nach, double x_kon, double delta_x, double eps){
        
        System.out.println("--------------------------------------");
	System.out.println("   x      n         s            f");
	System.out.print("--------------------------------------");
	
	// вычисление значений переменных по заданному алгоритму
	double x = x_nach;
        double temp, s, f;
        int n;
        do				//внешний цикл - изменение аргумента
	{
            temp = 1.0;		//первое слагаемое
            s = 1.0;			//начальное значение суммы
            n = 1;			//количество итераций на каждом шаге
            f = Math.exp(-x);	//точное значение функции
            //внутренний цикл - вычисление суммы ряда
            while (Math.abs(temp) > eps)			
            {
                                    //очередное слагаемое
                temp *= - x / n;			
                s += temp;		//очередная сумма
                n++;				//количество итераций					}
            }
            System.out.printf("\n%5.3f     %d     %7.6f     %7.6f", x, n, s, f);
            x += delta_x;	//увеличение аргумента на шаг  delta_x
	}while (x <= x_kon);
        System.out.println();
        System.out.println("--------------------------------------");
    }
    
    public static void main(String[] args) {
        System.out.println("Лабораторная работа №3");
	System.out.println("Вариант №1");
	System.out.println("ПИ.1-13-1");
	System.out.println("Ан Глеб");
	System.out.println();
        String input1;
        String input2;
        String input3;
        String input4;
        String str1 = "Введите значение переменной x_nach:";
        String str2 = "Введите значение переменной x_kon:";
        String str3 = "Введите значение переменной delta_x:";
        String str4 = "Введите значение переменной eps:";
        for(int i = 0; i < 3; i++){
            try{
                input1 = 
                JOptionPane.showInputDialog(str1);
                input2 = 
                JOptionPane.showInputDialog(str2);
                input3 = 
                JOptionPane.showInputDialog(str3);
                input4 = 
                JOptionPane.showInputDialog(str4);
                double x_nach = Double.parseDouble(input1);
                double x_kon = Double.parseDouble(input2);
                double delta_x = Double.parseDouble(input3);
                double eps = Double.parseDouble(input4);
                if(x_nach > x_kon){
                    str1 = "Не корректный ввод данных!" + 
                        "\nОсталось " + (2-i) + " попытки!"
                        + "\nВведите значение переменной x_nach:";
                }
                else{
                    count(x_nach, x_kon, delta_x, eps);
                    break;
                }
            }
            catch(NullPointerException e){
                str1 = "Не ввели значение!" + 
                        "\nОсталось " + (2-i) + " попытки!"
                        + "\nВведите значение переменной x_nach:";
            }
            catch(NumberFormatException e){
                str1 = "Одна из введенных строк не имеет требуемого значения" + 
                        "\nОсталось " + (2-i) + " попытки!"
                        + "\nВведите значение переменной x_nach:";
            }
            
        }
    }
}
