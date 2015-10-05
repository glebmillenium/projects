/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Graph;

import java.awt.Graphics;
import java.awt.Polygon;
import java.io.IOException;
import java.lang.*;
import javax.script.Invocable;
import javax.script.ScriptEngine;
import javax.script.ScriptEngineManager;
import javax.script.ScriptException;

/**
 *
 * @author glebmillenium
 */
class JPanel_modif extends javax.swing.JPanel {

    private int width;
    private int height;
    private int[] centr = new int[2];
    private int[] arrayX;
    private double[] arrayY;

    JPanel_modif(int w, int h) {
        this.width = w;
        this.height = h;
        this.centr[0] = w / 2;
        this.centr[1] = h / 2;
        this.arrayX = new int[2 * w + 1];
        this.arrayY = new double[2 * w + 1];
    }

    @Override
    @SuppressWarnings("empty-statement")
    public void paintComponent(Graphics g) {

        super.paintComponent(g);

        g.drawString("O", 240, 170);
        g.drawString("x", 500, 170);
        g.drawString("y", 270, 10);

        g.drawLine(this.centr[0], 0, this.centr[0], this.height);
        g.drawLine(this.centr[0], 0, this.centr[0] - 5, 0 + 10);
        g.drawLine(this.centr[0], 0, this.centr[0] + 5, 0 + 10);

        g.drawLine(0, this.centr[1], this.width, this.centr[1]);
        g.drawLine(this.width, this.centr[1], this.width - 10, this.centr[1] + 5);
        g.drawLine(this.width, this.centr[1], this.width - 10, this.centr[1] - 5);

        /*if (this.arrayX.length != 0) {
         Polygon poly = new Polygon(this.arrayX, this.arrayY, this.arrayX.length);
         g.drawPolygon(poly);
         }*/
    }

    public int[] createArrayX(int range, int step) {
        int j = 0;
        for (int i = -range; i < range; i += step) {
            this.arrayX[j] = i;
            j++;
        }

        return this.arrayX;
    }

    public double[] treatmentExpression(String str) throws ScriptException, IOException {
        String temp;
        // Это текст сценария, который требуется скомпилировать.
        String scripttext = AGV.readFileAsString("/home/glebmillenium/projects/java/BuildGraphicProject/src/Graph/Data/AGV.js");
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
            for (int i = 0; i < this.arrayX.length; i++) {
                // Вызов функции function evaluationExpression(i)
                this.arrayY[i] = (double) invocable.invokeFunction("evaluationExpression", str, this.arrayX[i]);
                //this.arrayY[i] = result;

                System.out.print(this.arrayX[i] + " ");
                System.out.println(this.arrayY[i]);
                //System.out.println(result);
            }
        } catch (NoSuchMethodException e) {
            // Эта часть программы выполняется, если сценарий не содержит
            // определение функции с именем "evaluationExpression".
            System.out.println(e);
        }

        return this.arrayY;
    }

    /*public void paint(Graphics g)
     -            {
     -                    g.drawLine(20, 20, 360, 20);
     -                    Color oldColor = g.getColor();
     -                    Color newColor = new Color(0, 0, 255);
     -                    g.setColor(newColor);
     -                    g.drawLine(20, 30, 360, 30);
     -                    g.setColor(oldColor);
     -                    g.drawRect(20, 40, 340, 20);
     -                    newColor = new Color(0, 215, 255);
     -                    g.setColor(newColor);
     -                    g.fillRect(21, 41, 339, 19);
     -                    g.setColor(oldColor);
     -                    g.drawRoundRect(20, 70, 340, 30, 20, 15);
     -                    g.drawOval(20, 110, 150, 60);
     -                    g.drawOval(200, 110, 60, 60);
     -                    g.drawArc(280, 110, 80, 60, 0, 180);
     -                    int[] arrayX = {20, 100, 100, 250, 250, 20, 20, 50};
     -                    int[] arrayY = {180, 180, 200, 200, 220, 200, 200, 190};
     -                    Polygon poly = new Polygon(arrayX, arrayY, 8);
     -                    g.drawPolygon(poly);
     -                    Point aPoint = new Point(50, 190);
     -                    if(poly.contains(aPoint))
     -                    {
     -                            g.drawString("Yes", 50, 190);
     -                    }
     -                    newColor = new Color(0, 0, 255);
     -                    g.setColor(newColor);
     -                    Font font = new Font("Tahoma", Font.BOLD|Font.ITALIC, 40);
     -                    Font oldFont = g.getFont();
     -                    g.setFont(font);
     -                    g.drawString("SBP", 270, 220);
     -                    g.setFont(oldFont);
     -                    g.setColor(oldColor);
     -                    // Draw axes;
     -                    g.drawLine(20, 220, 20, 350);
     -                    g.drawLine(20, 350, 360, 350);
     -                    g.drawString("Y", 25, 230);
     -                    g.drawString("X", 350, 346);		
     -                    // Draw a curve;
     -                    int[] xArray = {20, 40, 60, 80, 100, 120, 130, 140, 280, 332};
     -                    int[] yArray = {350, 345, 340, 310, 290, 280, 275, 273, 271, 269};
     -                    int nPoint = 10;
     -                    g.setColor(newColor);
     -                    g.drawPolyline(xArray, yArray, nPoint);
     -                    g.setColor(oldColor);
     -                    g.drawString("y = f(x)", 180, 267);
     -            }*/
}