/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab_42;

import javax.swing.JOptionPane;

/**
 *
 * @author glebmillenium
 */
public class Lab_42 {

    /**
     * @param args the command line arguments
     */
    public static void count(double t, int n){
//консольный вывод
        double a1 = t;
        double a2 = Math.sin(Math.PI*a1/2), a;
        String text="Значения входных переменных:\na1=" + a1 + "\na2=" + a2 + "\nn=" + n;

        // вызов диалогового окна эхо-печати
        JOptionPane.showMessageDialog(null, text);

        //консольный вывод
        System.out.printf("a1=%f\na2=%f\nn=%d\n", a1, a2, n);

        //консольный вывод
        System.out.println("-----------------");
        System.out.println("  k     a     s ");
        System.out.print("-----------------");

        // вычисление значений переменных по заданному алгоритму
        double s = a1 + a2;	//начальное значение суммы
                        // k - номер очередного члена последовательности

        for (int k=3; k<=n; k++)
        {
            a1 = a2;
            if(k%2 == 1){
                a2 = Math.cos(Math.PI*a2/2);
            }
            else{
                a2 = Math.sin(Math.PI*a2/2);
            }
		//очередное слагаемое
            s += a2;
            //консольный вывод
            System.out.printf("\n%3d   %3f   %3f", k, a2, s);
        }

        //консольный вывод
        System.out.println();
        System.out.print("-----------------");
    }
    
    public static void main(String[] args) {
        System.out.println("Лабораторная работа №4_2");
	System.out.println("Вариант №1");
	System.out.println("ПИ.1-13-1");
	System.out.println("Ан Глеб");
	System.out.println();
        String input1;
        String input2;
        String str1 = "Введите значение переменной a1:";
        String str2 = "Введите значение переменной n:";
        for(int i = 0; i < 3; i++){
            try{
                input1= 
                JOptionPane.showInputDialog(str1);
                input2= 
                JOptionPane.showInputDialog(str2);
                double a1 = Double.parseDouble(input1);
                int n = Integer.parseInt(input2);
                count(a1, n);
                break;
            }
            catch(NullPointerException e){
                str1 = "Не ввели значение!" + 
                        "\nОсталось " + (2-i) + " попытки!"
                        + "\nВведите значение переменной a1:";
            }
            catch(NumberFormatException e){
                str1 = "Введенная строка не имеет значения" + 
                        "\nОсталось " + (2-i) + " попытки!"
                        + "\nВведите значение переменной a1:";
            }
        }
    }
}
