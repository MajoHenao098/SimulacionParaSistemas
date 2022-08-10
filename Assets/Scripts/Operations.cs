using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Operations 
{
    public float x;
    public float y;

    public Operations(float x,float y)
    {
        this.x = x;
        this.y = y;

    }

    public override string ToString()
    {
        return ("(" + x + "," + y + ")");
    }
    public Operations Sumar(float x1, float y1)
    {
        float newX = x1;
        float newY = y1;

        return new Operations(x1 + x, y1 + y);
     
    }
    public Operations Sumar(Operations b)
    {

        //return new MyVector(x+b.x,y+b.y);
        return this + b;

    }
    static public Operations operator +(Operations a, Operations b)
    {
        return new Operations(a.x + b.x, a.y + b.y);
    }
    public Operations Restar(Operations b)
    {
        //return new MyVector(x-b.x,y-b.y);
        return this - b;

    }
    static public Operations operator -(Operations a, Operations b)
    {
        return new Operations(a.x - b.x, a.y - b.y);
    }
    public void Draw()
    {
        Debug.DrawLine(new Vector2(0, 0), new Vector2(x, y));
    }
    public void Draw(Operations a)
    {
        Debug.DrawLine(new Vector2(0+a.x, 0+a.y), new Vector2(x+a.x, y+a.y));
    }
    public Operations Multiplicar(float multi)
    {
        //return new MyVector(multi*x,multi*y);
        return this * multi;
    }
    static public Operations operator *(Operations a, float b)
    {
        return new Operations(a.x*b, a.y *b);
    }
    static public Operations operator *(float b, Operations a )
    {
        return new Operations(b*a.x , b* a.y);
    }
    //public static float Magnitud(MyVector d)
    //{
    //     float m = Mathf.Sqrt((d.x * d.x) + (d.y * d.y));
    //    return (m);
    //}
    public Operations Dividir(float div)
    {
        return this / div;
        //return new MyVector(x/div, y/div);
    }
    static public Operations operator /(Operations a, float b)
    {
        return new Operations(a.x / b, a.y / b);
    }
    static public Operations operator /(float b ,Operations a)
    {
        return new Operations(a.x / b, a.y / b);
    }
    public float Magnitud()
    {
        float m = Mathf.Sqrt((x * x) + (y * y));
        return (m);
    }
    public Operations Normalizar()
    {
        float m = Mathf.Sqrt((x * x) + (y * y));
        return (new Operations(x / m, y / m));
    }
    public float Punto(Operations a)
    {

        float p= (a.x * x) + (a.y * y);
        return (p);

    }
    //public MyVector Lerp( MyVector b, float t)
    //{
    //    MyVector c = new MyVector(b.x - x, b.y - y);
    //    MyVector d = new MyVector(c.x*t,c.y*t);
    //    return new MyVector(x+d.x, y+d.y);
    // }
    public Operations Lerp(Operations b, float t)
    {
        //return Sumar(b.Restar(this).Multiplicar(t));
        return this + ((b - this) * t);
    }
}
