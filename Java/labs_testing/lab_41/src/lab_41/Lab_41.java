/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab_41;

import javax.swing.JOptionPane;

/**
 *
 * @author glebmillenium
 */
public class Lab_41 {

    public static void count(int n){
        System.out.println("---------------");
        System.out.println("  i       s  ");
        System.out.print("---------------");

        double temp = 1.0;			//первое слагаемое
        double s = 1.0;				//начальное значение суммы
        double f = Math.exp(-1.0);		//точное значение функции

        for (int i=1; i<=n; i++)
        {
            temp /= -i;		//очередное слагаемое
            s += temp;		//очередная сумма
       //консольный вывод
            System.out.printf("\n%3d   %7.6f", i, s);			
        }

        //консольный вывод
        System.out.println();
        System.out.println("---------------");

        System.out.printf("\n    f=%7.6f\n", f);
    }
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        System.out.println("Лабораторная работа №4_1");
	System.out.println("Вариант №1");
	System.out.println("ПИ.1-13-1");
	System.out.println("Ан Глеб");
	System.out.println();
        String input;
        String str = "Введите значение переменной n:";
        for(int i = 0; i < 3; i++){
            try{
                input= 
                JOptionPane.showInputDialog(str);
                int n=Integer.parseInt(input);
                count(n);
                break;
            }
            catch(NullPointerException e){
                str = "Не ввели значение!" + 
                        "\nОсталось " + (2-i) + " попытки!"
                        + "\nВведите значение переменной n:";
            }
            catch(NumberFormatException e){
                str = "Введенная строка не имеет значения" + 
                        "\nОсталось " + (2-i) + " попытки!"
                        + "\nВведите значение переменной n:";
            }
        }
    }
    
}
