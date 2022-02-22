using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Dot[] dot = new Dot[2];
        //
        for(int i = 0; i < dot.Length; i++)
        {
            dot[i] = new Dot();
            Console.WriteLine("Dot: " + dot[i].Id);
        }
        Console.ReadLine();
    }
}
