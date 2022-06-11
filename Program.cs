using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        List<Drawable> drawable = new List<Drawable>();
        //
        //circle
        Circle circle = new Circle(Vector.zero, Vector.forward, 10);
        drawable.Add(circle);
        //triangle
        Triangle triangle = new Triangle(Vector.zero, Vector.right, Vector.up);
        drawable.Add(triangle);
        Console.ReadLine();
    }
}
