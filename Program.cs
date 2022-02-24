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
        Dot[] dot = new Dot[2];
        //
        for(int i = 0; i < dot.Length; i++)
        {
            dot[i] = new Dot(Vector.zero);
            dot[i].Draw();
        }
        Console.ReadLine();
    }
}
