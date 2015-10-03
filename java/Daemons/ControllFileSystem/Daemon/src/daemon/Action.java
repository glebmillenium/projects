/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package daemon;

import java.io.IOException;

/**
 *
 * @author glebmillenium
 */
public class Action{

    /**
     * Метод main - осуществляет запуск параллельного потока, 
     * в виде демона с задержкой в 10 сек.
     * 
     * @param args the command line arguments
     */
    public static void main(String[] args)
            throws IOException, InterruptedException {
        int count=0;
        while(true){
        Daemon.main(count);
        Thread.sleep(10000); //задержка между запуском нового процесса: 10 сек
        }
        
    }
    
}

