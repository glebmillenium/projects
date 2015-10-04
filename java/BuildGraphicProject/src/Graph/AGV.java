/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Graph;

import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Point;
import java.awt.Polygon;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import javax.swing.JOptionPane;
import javax.script.*;

/**
 *
 * @author glebmillenium
 */
public class AGV {
    
    public static void windowClose(java.awt.event.WindowEvent evt)
    {
                Object[] options = { "Нет", "Да" };
        int n = JOptionPane
                        .showOptionDialog(evt.getWindow(), "Закрыть приложение?",
                                "Подтверждение", JOptionPane.YES_NO_OPTION,
                                JOptionPane.QUESTION_MESSAGE, null, options,
                                options[1]);
                if (n == 0) 
                    System.exit(0);
    }
    
    public static double treatmentExpression(String str) throws ScriptException, IOException
    {  
        
    // Это текст сценария, который требуется скомпилировать.
    String scripttext = readFileAsString
        ("/home/glebmillenium/projects/java/BuildGraphicProject/src/Graph/Data/AGV.js");
    // Создать экземпляр интерпретатора, или "ScriptEngine", для запуска сценария
    ScriptEngineManager scriptManager = new ScriptEngineManager();
    ScriptEngine js = scriptManager.getEngineByExtension("js");
    // Запустить сценарий. Результат его работы отбрасывается, поскольку
    // интерес для нас представляет только определение функции.
    js.eval(scripttext);
    // Теперь можно вызвать функцию, объявленную в сценарии.
    try {
            // Привести ScriptEngine к типу интерфейса Invokable, 
            // чтобы получить возможность вызова функций.
            Invocable invocable = (Invocable) js;
            for(int i = 0; i < 5; i++) {   
                Object result = invocable.invokeFunction("evaluationExpression", i*2); 
                // Вызов функции f(i)
                System.out.printf("f(%d) = %s%n", i, result); 
                // Вывод результата
            }
        }
    catch(NoSuchMethodException e) {
        // Эта часть программы выполняется, если сценарий не содержит
        // определение функции с именем "f".
        System.out.println(e);
    }
        
    return 2.0;
    }
    
    /**
     * Метод readFileAsString - считывает метаданные 
     * из файла и переводит полученные данные в переменную типа String
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
    
}
