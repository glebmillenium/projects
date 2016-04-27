/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package codheming;
/**
 *
 * @author Gleb 
 */
import java.lang.Math;
public class CodHeming {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
    int count=16;//кол-во элементов в векторе
    int[] bincod;
    int[] bin = {0,1,0,0,0,1,0,0,0,0,1,1,1,1,0,1};
    bincod = new int[100];
    Heming(bin, bincod, count);
    outBin(bincod, 21);
    }
    static void Heming(int[] sourcemassiv, int[] deltamassiv, int count)
    {
        int i,k=0,j=0;
        for(i=0;i<21;i++)  
        {
            
            if ((i+1)==Math.pow(2,k))  {
                k++;
                deltamassiv[i]=0;
            }
            else {
                deltamassiv[i]=sourcemassiv[j];
                j++;
            } 
        }
        i=0;
        k=0;
        while(i<21)
        {
            if ((i+1)==Math.pow(2,k))  {
                k++;
                deltamassiv[i]=preobr(deltamassiv,k);
            }
            i++;
        }
    }
    static int preobr(int[] mass ,int step)
    {
        int search=0;
        int next=step;
        for(int i=0;i<21;i++)  {
            if (i==next) {
                search+=mass[i];
                next+=(step+1);
            }
        }
        if (search%2==1)
            return 0;
        else return 1;
    }
    
    static void outBin(int[] bin, int br) 
        {
          int i;
          for(i=0;i<br;i++) {
              if (i==12)
                  System.out.print(" ");
              System.out.print(bin[i]);
          }
          System.out.print("\n");
        }
}
