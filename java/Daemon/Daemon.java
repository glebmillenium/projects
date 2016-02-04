package daemon;

import java.io.*;
import java.util.*;

/**
 *
 * @author glebmillenium
 */
public class Daemon {


    /**
     * @param args the command line arguments
     */
    
    public static void main(String[] args) throws FileNotFoundException, IOException {
        // TODO code application logic here
        try
        {
            daemonize();    
        }
        catch(Throwable e)
                {
                    System.err.println("Startup error."+e.getMessage());
                }
        doProcessing();
        
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
    public static void doProcessing() throws FileNotFoundException, IOException
    {
        String way_in, way_from, rec_file, storage;
        way_in="/home/glebmillenium/";//Путь в файл в который записываем
        way_from="/home/glebmillenium/from/";//Откуда записываем
        storage="/home/glebmillenium/storage/";
        rec_file="in";//имя файла для записи метаданных
        
        File directory_from = new File(way_from);
        File directory_in= new File(way_in);
        File directory_storage= new File(storage);
        
        if ( !( directory_from.isDirectory() && directory_in.isDirectory() && directory_storage.isDirectory() ) ) 
            System.out.println("Some directory don't exist!");
        
        
        File file = new File(way_from);
        String[] cn = file.list();
        
            for (int i = 0; i < cn.length-1; i++)
                recordData(way_in, way_from, rec_file, cn[i], storage);
            
            //задержка

        
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
    private static void recordData 
        (String way_in, String way_from, String rec_file, String written_file, 
                String storage) 
                throws FileNotFoundException, IOException{

        String textString = 
            readFileAsString(way_from+written_file);//считывание данных файла
        /*Перенос прочитанного файла*/    
        writeStringAsFile(storage+written_file,textString);
        File f1 = new File(way_from+written_file);
        f1.delete();
        
        /*Запись полученной строки в файл*/
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
        return fileData.toString();
    }
    
}