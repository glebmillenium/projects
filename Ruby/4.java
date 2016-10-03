package laba_4.inb;

import javax.swing.*;

public class Laba_4Inb {

    public static void main(String[] args) {
        String input;
        double Xs = 0;
        Integer a = 630360016, m = 2147483647, n = 3000;  //
        double [] mass = new double[n];
        int i = (int) (Math.random()*3000);
        //mass[0] = (int) (Math.random() * n) + 1; //случайное начальное значение
        
        input=JOptionPane.showInputDialog("x0=");
        mass[0]=Integer.parseInt(input);
                
        for (int j = 1; j < n; j++) {
            mass[j] = (a * mass[j - 1]) % m;
        }
        System.out.printf("Случайное значение = "+ i);  //случайное число [0-3000]
         
        for (int z = 0; z < n; z++){
            Xs += (mass[z]/m)/n;
        }
        //определение секретного ключа
        int k = (int) mass[i];
        System.out.printf("\nCекретный ключ : "+ k);  //i-тый элемент массива
        System.out.printf("\nCреднее значение нормированного элемента массива: "+ Xs + "\n");
    }
}
