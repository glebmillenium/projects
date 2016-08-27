/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Graph;

import java.awt.*;
import javax.swing.*;
import java.awt.event.*;
/**
 *
 * @author glebmillenium
 */
class ShowColor extends JFrame{
    private JButton changeColor;
    private Color color = Color.lightGray;
    private Container c;  
    
    public ShowColor(){
        super( "Using JColorChooser" );
        c = getContentPane();
        c.setLayout(new FlowLayout());
    }
    
    public Color choose()
    {
        color =JColorChooser.showDialog(ShowColor.this,
                     "Choose a color", color );
        return color;
    }
}
