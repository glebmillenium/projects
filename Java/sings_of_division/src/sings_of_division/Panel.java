/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sings_of_division;

import java.awt.Color;
import java.awt.Graphics;
import javax.swing.JPanel;

/**
 *
 * @author Student
 */
public class Panel extends JPanel{
    private Tuple[] first; 
    private Tuple[] second;
    int sign = 0;
    Tuple mid = new Tuple();
    Tuple freak;
    int sup_sign = 0;
    int classificator = 0;
    Tuple jer;

    Panel(){

    }

    public void paintComponent(Graphics g){
        super.paintComponent(g);
        if(sign != 0){
            painter(g);
        }
        if(sup_sign != 0){
            painter_sup(g);
        }
    }

    private void painter_sup(Graphics g){
        g.setColor(jer.getThird());
        g.drawRect(jer.getFirst(), 500-jer.getSecond(), 5, 5);
    }

    private void painter(Graphics g)
    {
        g.setColor(Color.RED);
        for(int i = 0; i< first.length; i++){
            g.drawOval(first[i].getFirst(), 500-first[i].getSecond(), 8, 8);
        }
        g.setColor(Color.BLUE);
        for(int i = 0; i< second.length; i++){
            g.drawOval(second[i].getFirst(), 500-second[i].getSecond(), 8, 8);
        }
        g.setColor(Color.BLACK);
        //int coef1 = (int) (500.0 / mid.getFirst()));
        //int coef2 = (int) (500.0 / mid.getSecond()));
        g.drawLine(0, 500, mid.getFirst(), (500-mid.getSecond()));
    }

    public void settingSigns(Tuple[] one, Tuple[] two, Tuple mid){
        this.sign = 1;
        this.first = one;
        this.second = two;
        this.mid = mid;
        repaint();
    }

    public void newSigns(Tuple sign){
        this.sup_sign = 1;
        this.jer = sign;
        repaint();
    }
}
