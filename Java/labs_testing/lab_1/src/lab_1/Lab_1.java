package lab_1;
import javax.swing.*;
import java.util.*;
/**
 *
 * @author glebmillenium
 */
public class Lab_1 {

    public static double count(double k){
        return k%4 > 2 ? - Math.sqrt(1.0 - Math.pow(((k%4) % 2.0 - 1.0), 2.0)):
        Math.sqrt(1.0 - Math.pow(((k%4) % 2.0 - 1.0), 2.0));
    }
    
    public static void main(String[] args) {
        System.out.println("Лабораторная работа №2");
	System.out.println("Вариант №1");
	System.out.println("ПИ.1-13-1");
	System.out.println("Ан Глеб");
	System.out.println();
        String input;
        String str = "Введите значение переменной x:";
        for(int i = 0; i < 3; i++){
            try{
                input= 
                JOptionPane.showInputDialog(str);
                double x=Double.parseDouble(input);
                System.out.println("Значение y = " + count(x));
                break;
            }
            catch(NullPointerException e){
                str = "Не ввели значение!" + 
                        "\nОсталось " + (2-i) + " попытки!"
                        + "\nВведите значение переменной x:";
            }
            catch(NumberFormatException e){
                str = "Введенная строка не имеет значения" + 
                        "\nОсталось " + (2-i) + " попытки!"
                        + "\nВведите значение переменной x:";
            }
        }
    }
}
