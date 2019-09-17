using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotPoint
{

    public double X_value;
    // public string X_name;
    public double Y_value;
    // public string Y_name;
    public double Z_value;
    public double size;
    // public string Z_name;
    // public int rowval;
    public int color;
    // Start is called before the first frame update
    public PlotPoint()
    {
        X_value = 0;
        Y_value = 0;
        Y_value = 0;
        size = 0;
        color = 0;

    }
    public PlotPoint(double a, double b, double c, double d, int e)
    {
        X_value = a;
        Y_value = b;
        Y_value = c;
        size = d;
        color = e;
    }
    public void set_x(double a)
    {
        X_value = a;
    }
}
