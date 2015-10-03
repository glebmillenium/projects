package daemon;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

/**
 * class Daemon
 * 
 * @author glebmillenium
 */

public class Daemon{
    
    /**
     * Метод main - демонизирует процесс передачи метаданных 
     * файлов в основной (главный) файл
     * 
     * @throws FileNotFoundException
     * @throws IOException 
     */
    public static int main(int count) throws FileNotFoundException, IOException {
        // TODO code application logic here
        try
        {
            daemonize();    
        }
        catch(Throwable e)
        {
            System.err.println("Startup error."+e.getMessage());
        }
        doProcessing(count);
        
        return count;

    }
    
    
    /**
     * daemonize отключает приложение от потоков stdin и stdout. 
     * Единственно активным остается поток stderr
     * 
     * Входные параметры: отсуствуют
     * Выходные параметры: отсуствуют
     * 
     * @throws Exception 
     */
    static private void daemonize() throws Exception
    {
        System.in.close();
        System.out.close();
    }
    
    
    /**
     * doProcessing - реализация основной логики приложения
     * 
     * Входные параметры: отсуствуют 
     * Выходные параметры: отсуствуют
     * 
     * @throws FileNotFoundException
     * @throws IOException 
     */
    public static void doProcessing(int count) throws FileNotFoundException, IOException
    {
        String way_in, way_from, rec_file, storage;
        way_in="E:\\ArchPS\\";//Путь в файл в который записываем
        way_from="E:\\ArchPS\\from\\";//Откуда записываем
        storage="E:\\ArchPS\\storage\\";
        rec_file="in.txt";//имя файла для записи метаданных
        
        File file = new File(way_from);
        String[] fileName = file.list();
        long[] fileData = new long[256];
        
        
        if (count>100)  {
        String textString = 
            readFileAsString(way_in+rec_file);
        /*Перенос прочитанного файла*/    
        writeStringAsFile(way_in+rec_file,textString);
        File f1 = new File(way_in+rec_file);//Удаление
        f1.delete();
        }
        
            for (int i = 0; i < fileName.length-1; i++)  {
                fileData[i]=(new File(way_from+fileName[i])).lastModified();
            }
            
            for(int i = 0; i < fileName.length - 1; i++)
                for(int j = 0; j < fileName.length - i - 1; j++)
                    if(fileData[j] > fileData[j + 1]){
                        swapLong(fileData[j], fileData[j + 1]);
                        swapString(fileName[j], fileName[j + 1]);
                    }
        
        
            for (int i = 0; i < fileName.length; i++)
                recordData(way_in, way_from, rec_file, fileName[i], storage, count);
        
    }
    
    
    
    
    /**
     * Метод recordData - предназначен для считывания метаданных с одного файла
     * и перемещения полученных данных в другой файл, 
     * предназначенный для записи всех данных
     * 
     * Входные параметры:
     * @param way_in - путь для записи метаданных
     * @param way_from - путь для считывания метаданных 
     * @param rec_file - название файла для записи метаданных
     * @param written_file - название файла для считывания метаданных и 
     * его дальнейшего перемещения в папку written
     * @param storage - путь для хранения прочитанных файлов
     * 
     * Выходные параметры: отсуствуют
     * 
     * @throws FileNotFoundException
     * @throws IOException 
     */
    public static void recordData 
        (String way_in, String way_from, String rec_file, String written_file, 
                String storage, int count) 
                throws FileNotFoundException, IOException{

        String textString = 
            readFileAsString(way_from+written_file);//считывание данных файла

        /*Перенос прочитанного файла*/    
        writeStringAsFile(storage+written_file,textString);
        File f1 = new File(way_from+written_file);
        f1.delete();
        
        /*Запись полученной строки в файл*/
        count++;
        writeStringAsFile(way_in+rec_file, textString);   
    }
       
        
    /**
     * Метод writeStringAsFile - предназначен для добавления текстовых данных в 
     * существующий файл из переменной типа String
     * 
     * Входные параметры:
     * @param filePath - полный путь к файлу для записи, включая название самого
     * файла
     * @param textString - строка, для записи в файл
     * 
     * Выходные параметры: отсуствуют
     * 
     * @throws IOException 
     */    
    public static void writeStringAsFile
        (String filePath, String textString) throws IOException {
            
        try{
        FileWriter sw = new FileWriter(filePath,true);
        sw.write(textString);
        sw.close();

        }catch(Exception e){
        System.out.print(e.getMessage());
        } 

    }  
        
    /**
     * Метод readFileAsString - считывает метаданные 
     * из файла и переводит полученные данные в переменную типа String
     * 
     * Входные параметры:
     * @param filePath - полный путь к файлу, включая название самого файла
     * 
     * Выходные параметры:
     * @return fileData.toString() - перменная типа String, содержащая 
     * метаданные из файла
     * 
     * @throws IOException 
     */
    private static String readFileAsString(String filePath) throws IOException {
        StringBuffer fileData = new StringBuffer();
        BufferedReader reader = new BufferedReader(
                new FileReader(filePath));
        char[] buf = new char[1024];
        int numRead=0;
        while((numRead=reader.read(buf)) != -1){
            String readData = String.valueOf(buf, 0, numRead);
            fileData.append(readData);
        }
        reader.close();
        return (fileData.toString()+"\r\n");
    }
	
	
	/**
	 * Выполняет обмен значениями между переменными
	 */
    private static void swapLong(long arg1, long arg2) {
        long temp;
        temp=arg2;
        arg2=arg1;
        arg1=temp;
    }

	/**
	 * Выполняет обмен значениями между переменными
	 */
    private static void swapString(String arg1, String arg2) {
        String temp;
        temp=arg1;
        arg1=arg2;
        arg2=temp;
    }
}