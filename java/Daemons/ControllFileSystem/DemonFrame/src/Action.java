/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author glebmillenium
 */
public class Action{

    /**
     * Метод main - осуществляет запуск параллельного потока, 
     * в виде демона с задержкой в 10 сек.
     * 
     */
    public static void main(String time_daemon,String[] Data_daemon, String max_count)
            throws IOException, InterruptedException {
            
        int count=0;
        int time=Integer.parseInt(time_daemon);
        while(true){
        Daemon.main(count,Data_daemon,Integer.parseInt(max_count) );
        Thread.sleep(time*1000); //задержка между запуском нового процесса: 10 сек
        }
    }
    
}

