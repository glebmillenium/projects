/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Graph;

import java.awt.Graphics;
import java.io.IOException;
import javax.script.Invocable;
import javax.script.ScriptEngine;
import javax.script.ScriptEngineManager;
import javax.script.ScriptException;

/**
 * class JPanelGraph - дочерний класс от 
 * стандартного класса JPanel пакета javax.swing.*
 * Рисует оси координат (x, y), и при необходимости
 * дорисовывает графики заданных функций по 
 * вычисленным точкам.
 * 
 * Поля класса:
 * private int width - ширина области чертежа (в пикселях)
 * 
 * private int height - высота области чертежа (в пикселях)
 * 
 * private int[] centr = new int[2] - массив 
 * координат центра координат(в пикселях)
 * 
 * private double[] arrayX - массив координат 
 * вычисленных X
 * 
 * private double[] arrayY - массив координат
 * вычисленных Y
 * 
 * private int[] arrayX_graph
 * private int[] arrayY_graph
 * 
 * private double step - шаг функции в 1 пиксель
 * 
 * private int division - величина обратная step
 * 
 * @author glebmillenium
 */
class JPanelGraph extends javax.swing.JPanel {

    private int width;
    private int height;
    private int[] centr = new int[2];
    private double[][] arrayX;
    private double[][] arrayY;
    private int[][] arrayX_graph;
    private int[][] arrayY_graph;
    private double step;
    private int division;
    private int count = 0;
    private int ready = 0;

    JPanelGraph(int w, int h, double step) {
        this.width = w;
        this.height = h;
        this.centr[0] = w / 2;
        this.centr[1] = h / 2;
        this.step = step;
        this.division = (int) (1 / step);
        this.count = 250;
        this.arrayX = new double[count][w];
        this.arrayY = new double[count][w];
        this.arrayX_graph = new int[count][w];
        this.arrayY_graph = new int[count][w];
    }

    @Override
    @SuppressWarnings("empty-statement")
    public void paintComponent(Graphics g) {

        super.paintComponent(g);
        int delta;
        

        g.drawString("O", this.centr[0] - 20, this.centr[1] + 20);
        g.drawString("x", this.width - 20, this.centr[1] + 15);
        g.drawString("y", this.centr[0] + 10, 10);

        g.drawLine(this.centr[0], 0, this.centr[0],
                this.height);
        g.drawLine(this.centr[0], 0, this.centr[0] - 5,
                0 + 10);
        g.drawLine(this.centr[0], 0, this.centr[0] + 5,
                0 + 10);

        g.drawLine(0, this.centr[1], this.width, this.centr[1]);
        g.drawLine(this.width, this.centr[1], this.width - 10,
                this.centr[1] + 5);
        g.drawLine(this.width, this.centr[1], this.width - 10,
                this.centr[1] - 5);

        g.drawString("1", this.centr[0] + this.division, this.centr[1] + 20);
        delta = this.division;
        while (delta < this.width) {
            g.drawLine(this.centr[0] + delta, this.centr[1] - 3, this.centr[0] + delta, this.centr[1] + 3);
            delta += this.division;
        }

        delta = this.division;
        while (delta < this.width) {
            g.drawLine(this.centr[0] - delta, this.centr[1] - 3, this.centr[0] - delta, this.centr[1] + 3);
            delta += this.division;
        }

        delta = this.division;
        while (delta < this.height) {
            g.drawLine(this.centr[0] - 3, this.centr[1] + delta, this.centr[0] + 3, this.centr[1] + delta);
            delta += this.division;
        }

        delta = this.division;
        while (this.centr[1] - delta > 0) {
            g.drawLine(this.centr[0] - 3, this.centr[1] - delta, this.centr[0] + 3, this.centr[1] - delta);
            delta += this.division;
        }
        
        if (this.ready == 1) {
            
            conversionFunctionToPanel();
            
            for (int k = 0; k< this.count; k++)
            {
                
                for (int i=1; i<this.arrayX_graph[k].length;i++)
                {
                    g.drawLine(this.arrayX_graph[k][i-1],this.arrayY_graph[k][i-1],
                            this.arrayX_graph[k][i],this.arrayY_graph[k][i]);
                }
            }
        }
    }

    public void drawGraph() {
        
        repaint();
    }

    private void conversionFunctionToPanel() {
        for (int k=0; k< this.count; k++)
        {
            for (int i = 0; i < this.width; i++) {
                this.arrayX_graph[k][i] = i;
                this.arrayY_graph[k][i] = -(int) Math.round(this.arrayY[k][i] / this.step)
                        + this.centr[1];
            }
        }
    }

    
    private void createArrayX() {
        
        for(int k=0; k<this.count; k++) {
            int i = 0;
            for (double go = -this.centr[0] * step;
                    go < (this.width - this.centr[0]) * step; go += step) {
                this.arrayX[k][i] = go;
                i++;
            }
        }

    }

    public void treatmentExpression(String[] str)
            throws ScriptException, IOException {
        // Это текст сценария, который требуется скомпилировать.
        String path = AGV.wayToJar();
        path = path.replaceAll("BuildGraphicProject.jar", "") + "/Data/AGV.js";
        String scripttext = AGV.readFileAsString("/home/glebmillenium/projects/java/BuildGraphicProject/src/Graph/Data/AGV.js");
        // Создать экземпляр интерпретатора, или "ScriptEngine", для запуска сценария
        ScriptEngineManager scriptManager = new ScriptEngineManager();
        ScriptEngine js = scriptManager.getEngineByExtension("js");
        // Запустить сценарий. Результат его работы отбрасывается, поскольку
        // интерес для нас представляет только определение функции.
        js.eval(scripttext);
        this.count = str.length;
        // Теперь можно вызвать функцию, объявленную в сценарии.
        createArrayX();
        try {
            // Привести ScriptEngine к типу интерфейса Invokable, 
            // чтобы получить возможность вызова функций.
            Invocable invocable = (Invocable) js;
            for(int k=0; k < this.count; k++)
            {
                for (int i = 0; i < this.width; i++) 
                {
                    // Вызов функции function evaluationExpression(i)
                    this.arrayY[k][i] = (double) invocable.invokeFunction("evaluationExpression", str[k], this.arrayX[k][i]);
                }
            }
        } catch (NoSuchMethodException e) {
            // Эта часть программы выполняется, если сценарий не содержит
            // определение функции с именем "evaluationExpression".
            System.out.println(e);
        }
        this.ready = 1;
    }

}
