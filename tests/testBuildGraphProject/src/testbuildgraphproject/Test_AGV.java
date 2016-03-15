package testbuildgraphproject;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLDecoder;
import javax.swing.JOptionPane;

/**
 * class Test_AGV - набор функций (пространство имён),
 не имеющих прямого отношения
 к решаемой задачи.
 * 
 * @author glebmillenium
 */
public class Test_AGV {
    
    /**
     * Метод windowClose - создает скрытое окно,
     * которое всплывает при закрытии основного фрейма,
     * из которого оно создано.
     * 
     * Входные параметры:
     * @param evt - элемент события, которое вызывается при закрытии
     *              графического окна.
     * 
     * Выходные параметры:
     * @return void
     */
    public static void windowClose(java.awt.event.WindowEvent evt)
    {
                Object[] options = { "Да", "Нет" };
        int n = JOptionPane
                        .showOptionDialog(evt.getWindow(), "Закрыть приложение?",
                                "Подтверждение", JOptionPane.YES_NO_CANCEL_OPTION,
                                JOptionPane.QUESTION_MESSAGE, null, options,
                                options[1]);
                if (n == 0) 
                    System.exit(0);
    }
      
    
    /**
     * Метод readFileAsString - считывает метаданные из файла и переводит
     * полученные данные в переменную типа String
     *
     * Входные параметры:
     * @param filePath - полный путь к файлу, включая название самого файла
     *
     * Выходные параметры:
     * @return fileData.toString() - переменная типа String, содержащая
     * метаданные из файла
     *
     * @throws IOException
     */
    public static String readFileAsString(String filePath) throws IOException {
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
     * Метод wayToJar - Определяет путь, в котором находжится исполняемый 
     *                  jar файл
     * 
     * @return path  - путь к файлу в формате String
     * 
     * @throws UnsupportedEncodingException
     */
    public static String wayToJar() throws UnsupportedEncodingException
    {
        String path = Test_AGV.class.getProtectionDomain().getCodeSource().getLocation().getPath();
        path = URLDecoder.decode(path, "UTF-8");
        return path;
    }
    
}
