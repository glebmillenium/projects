package sings_of_division;

import java.awt.Color;

/**
 *
 * @author Student
 */
public class Tuple
{
    private int x, y;
    private Color z;
    Tuple()
    {
        this.x = 0;
        this.y = 0;
    }

    Tuple(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    Tuple(double x, double y)
    {
        this.x = (int) Math.round(x);
        this.y = (int) Math.round(y);
    }
    
    Tuple(int x, int y, Color z){
        this.x = x;
        this.y = y;
        this.z = z;
    }
    
    Tuple(double x, double y, Color z){
        this.x = (int) Math.round(x);
        this.y = (int) Math.round(y);
        this.z = z;
    }

    public int getFirst(){
        return this.x;
    }

    public int getSecond(){
        return this.y;
    }
    
    public Color getThird(){
        return this.z;
    }
}
