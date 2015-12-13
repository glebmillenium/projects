package Graph;

import java.awt.Color;
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
    public int mv_w = 0;
    public int mv_h = 0;
    private double[][] arrayX;
    private double[][] arrayY;
    private int[][] arrayX_graph;
    private int[][] arrayY_graph;
    private double[][] array_radius;
    private double step;
    private int division;
    private int count = 256;
    private int decimal_division = 0;
    private Color[] colors = new Color[256];
    private int type_function = 1;

    /**
     * JPanelGraph(int w, int h, double step) - расширенный конструктор класса,
     * позволяющий динамически определить поля создаваемого объекта
     * 
     * @param w - высота 
     * @param h
     * @param step 
     */
    JPanelGraph(int w, int h, double step) {
        this.width = w;
        this.height = h;
        this.centr[0] = (w+mv_w) / 2;
        this.centr[1] = (h+mv_h) / 2;
        this.step = step;
        this.division = (int) (1 / step);
        this.arrayX = new double[count][w+1];
        this.arrayY = new double[count][w+1];
        this.arrayX_graph = new int[count][w+1];
        this.arrayY_graph = new int[count][w+1];
        this.array_radius = new double [count][w+1];
    }

    @Override
    @SuppressWarnings("empty-statement")
    public void paintComponent(Graphics g) {

        super.paintComponent(g);
        setDefaultColorLines();
        drawSimbolsGraph(g);
        drawLinesCoordinates(g);
        drawDividesGraph(g);
                  
        conversionFunctionToPanel();

        for (int k = 0; k< this.count; k++)
        {
            g.setColor(this.colors[k]);
            for (int i = 1; i < (this.arrayX_graph[k].length - 1);i++)
            {
                g.drawLine(this.arrayX_graph[k][i-1],this.arrayY_graph[k][i-1],
                        this.arrayX_graph[k][i],this.arrayY_graph[k][i]);
            }
        }

    }
    
    private void drawDividesGraph(Graphics g)
    {
        double delta;
        delta = this.division;
        while (delta < this.width) {
            g.drawLine(this.centr[0] + (int)delta, this.centr[1] - 4, this.centr[0] + (int)delta, this.centr[1] + 4);
            g.drawLine(this.centr[0] - (int)delta, this.centr[1] - 4, this.centr[0] - (int)delta, this.centr[1] + 4);
            delta += this.division;
        }

        delta = this.division;
        while (delta < this.height) {
            g.drawLine(this.centr[0] - 4, this.centr[1] + (int)delta, this.centr[0] + 4, this.centr[1] + (int)delta);
            delta += this.division;
        }

        delta = this.division;
        while (this.centr[1] - delta > 0) {
            g.drawLine(this.centr[0] - 4, this.centr[1] - (int)delta, this.centr[0] + 4, this.centr[1] - (int)delta);
            delta += this.division;
        }
        
        if(decimal_division == 1)
        {
            delta = this.division*0.1;
            int five_div = 1;
            while (delta < this.width) {
                if (five_div == 5)
                {
                    five_div = 0;
                    g.drawLine(this.centr[0] + (int)delta, this.centr[1] - 2, this.centr[0] + (int)delta, this.centr[1] + 2);
                    g.drawLine(this.centr[0] - (int)delta, this.centr[1] - 2, this.centr[0] - (int)delta, this.centr[1] + 2);
                }
                else
                {
                    g.drawLine(this.centr[0] + (int)delta, this.centr[1] - 1, this.centr[0] + (int)delta, this.centr[1] + 1);
                    g.drawLine(this.centr[0] - (int)delta, this.centr[1] - 1, this.centr[0] - (int)delta, this.centr[1] + 1);
                }
                
                delta += this.division*0.1;
                five_div++;
            }

            delta = this.division*0.1;
            five_div = 1;
            while (delta < this.height) {
                if (five_div == 5)
                {
                    five_div = 0;
                    g.drawLine(this.centr[0] - 2, this.centr[1] + (int)delta, this.centr[0] + 2, this.centr[1] + (int)delta);
                }
                    else
                    g.drawLine(this.centr[0] - 1, this.centr[1] + (int)delta, this.centr[0] + 1, this.centr[1] + (int)delta);
                delta += this.division*0.1;
                five_div++;
            }

            delta = this.division*0.1;
            five_div = 1;
            while (this.centr[1] - delta > 0) {
                if (five_div == 5)
                {
                    five_div = 0;
                    g.drawLine(this.centr[0] - 2, this.centr[1] - (int)delta, this.centr[0] + 2, this.centr[1] - (int)delta);
                }
                else
                    g.drawLine(this.centr[0] - 1, this.centr[1] - (int)delta, this.centr[0] + 1, this.centr[1] - (int)delta);
                delta += this.division*0.1;
                five_div++;
            }
        }
    }
    
    public void changedTypeFunction(int n)
    {
        this.type_function = n;
        drawGraph();
    }
    
    private void drawLinesCoordinates(Graphics g)
    {
        g.drawLine(this.centr[0], 0, this.centr[0], this.height);
        g.drawLine(this.centr[0], 0, this.centr[0] - 5,
                0 + 10);
        g.drawLine(this.centr[0], 0, this.centr[0] + 5,
                0 + 10);  
        
        g.drawLine(0, this.centr[1], this.width, this.centr[1]);
        g.drawLine(this.width, this.centr[1], this.width - 10,
                this.centr[1] + 5);
        g.drawLine(this.width, this.centr[1], this.width - 10,
                this.centr[1] - 5);
    }
    
    private void setDefaultColorLines()
    {
        if (this.colors == null ) 
        {
            for(int i=0; i < 256;i++)
                this.colors[i] = Color.black;
        }
    }

    private void drawSimbolsGraph(Graphics g)
    {
        g.drawString("O", this.centr[0] - 20, this.centr[1] + 20);
        if (this.type_function == 1)
            g.drawString("x", this.width - 20, this.centr[1] + 15);
        if (this.type_function == 2)
            g.drawString("t", this.width - 20, this.centr[1] + 15);
        if (this.type_function == 4)
            g.drawString("ρ", this.width - 20, this.centr[1] + 15);
        g.drawString("y", this.centr[0] + 10, 10);
        g.drawString("1", this.centr[0] + this.division, this.centr[1] + 20);
        g.drawString("1", this.centr[0] + (int)(this.division*0.1), this.centr[1] - (int)(this.division*0.9));
    }
    
    public void move_h(int mv)
    {
        this.mv_h = this.mv_h + mv;
        drawGraph();
    }
    
    public void drawDecimalDivision(int value)
    {
        this.decimal_division = value;
        drawGraph();
    }
    
    public void move_w(int mv)
    {
        this.mv_w = this.mv_w + mv;
        drawGraph();
    }
    
    public void drawGraph() {    
        repaint();
    }

    private void conversionFunctionToPanel() {
        if(this.type_function == 4)
        {
            for (int k=0; k< this.count; k++)
            {
                int i=0;
                for (double g = 0; g < (2*Math.PI); g+=0.0174533) {
                    this.arrayX_graph[k][i] = (int) Math.round(this.arrayX[k][i]/this.step)
                            + this.centr[0];
                    this.arrayY_graph[k][i] = -(int) Math.round(this.arrayY[k][i]/this.step)
                            + this.centr[1];
                    i++;
                }
            }
        }
        if(this.type_function == 1 || this.type_function == 2)
            for (int k=0; k< this.count; k++)
            {
                for (int i = 0; i < this.width; i++) {
                    this.arrayX_graph[k][i] = i;
                    this.arrayY_graph[k][i] = -(int) Math.round(this.arrayY[k][i] / this.step)
                            + this.centr[1];
                }
            }
            if(this.type_function == 3)
                for (int k=0; k< this.count; k++)
                {
                    for (int i = 0; i < this.width; i++) {
                    this.arrayX_graph[k][i] = (int) Math.round(this.arrayX[k][i]/this.step)
                            + this.centr[0];
                    this.arrayY_graph[k][i] = -(int) Math.round(this.arrayY[k][i]/this.step)
                            + this.centr[1];
                    }
                }
    }

    
    private void createArrayX() {
        
        if (this.type_function == 1 || this.type_function == 2)
            for(int k=0; k<this.count; k++) {
                int i = 0;
                for (double go = -this.centr[0] * step;
                        go < (this.width - this.centr[0]) * step; go += step) {
                    this.arrayX[k][i] = go;
                    i++;
                }
            }
        

    }

    public void treatmentExpression(String[] str, Color[] colors, double interval, int w, int h)
            throws ScriptException, IOException {
        this.centr[0] = (w + this.height) / 2;
        this.centr[1] = (h + this.width) / 2;
        this.colors = colors;
        this.division = (int) (1/interval);
        this.step = interval;
        // Это текст сценария, который требуется скомпилировать.
        String path = AGV.wayToJar();
        path = path.replaceAll("BuildGraphProject.jar", "") + "/Data/AGV.js";
        String scripttext = AGV.readFileAsString(path);
        // Создать экземпляр интерпретатора, или "ScriptEngine", для запуска сценария
        ScriptEngineManager scriptManager = new ScriptEngineManager();
        ScriptEngine js = scriptManager.getEngineByExtension("js");
        // Запустить сценарий. Результат его работы отбрасывается, поскольку
        // интерес для нас представляет только определение функции.
        js.eval(scripttext);
        this.count = str.length;
        if (this.type_function == 1 || this.type_function == 2)
        {
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
                        this.arrayY[k][i] = (double) (invocable.invokeFunction("evaluationExpression", str[k], this.arrayX[k][i]));
                    }
                }
            } catch (NoSuchMethodException e) {
                // Эта часть программы выполняется, если сценарий не содержит
                // определение функции с именем "evaluationExpression".
                System.out.println(e);
            }
        }
        if (this.type_function == 3)
        {
            String[] sub_str;
            try {
                // Привести ScriptEngine к типу интерфейса Invokable, 
                // чтобы получить возможность вызова функций.
                Invocable invocable = (Invocable) js;
            for(int k=0; k<this.count; k++) {
                int i = 0;
                for (double go = -this.centr[0] * step;
                        go < (this.width - this.centr[0]) * step; go += step) {
                    sub_str = str[k].split(";");
                    this.arrayX[k][i] = (double) (invocable.invokeFunction("evaluationExpression", sub_str[0], go));
                    this.arrayY[k][i] = (double) (invocable.invokeFunction("evaluationExpression", sub_str[1], go));
                    i++;
                }
            }
            } catch (NoSuchMethodException e) {
                // Эта часть программы выполняется, если сценарий не содержит
                // определение функции с именем "evaluationExpression".
                System.out.println(e);
            }
        }
        if (this.type_function == 4)
        {
            // Теперь можно вызвать функцию, объявленную в сценарии.
            try {
                // Привести ScriptEngine к типу интерфейса Invokable, 
                // чтобы получить возможность вызова функций.
                Invocable invocable = (Invocable) js;
                for(int k=0; k < this.count; k++)
                {
                    int i = 0;
                    for (double g = 0; g < 2*Math.PI; g+=0.0174533) 
                    {
                        // Вызов функции function evaluationExpression(i)
                        this.array_radius[k][i] = (double) (invocable.invokeFunction("evaluationExpression", str[k], g));
                        this.arrayX[k][i] = Math.cos(g)*this.array_radius[k][i];
                        this.arrayY[k][i] = Math.sin(g)*this.array_radius[k][i];
                        i++;
                    }
                }
            } catch (NoSuchMethodException e) {
                // Эта часть программы выполняется, если сценарий не содержит
                // определение функции с именем "evaluationExpression".
                System.out.println(e);
            }
        }
    }

}
