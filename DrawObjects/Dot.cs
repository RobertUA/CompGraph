using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dot : Drawable
{
    public Vector vector;
    public Dot(Vector vector)
    {
        this.vector = vector;
    }
    public override void Draw()
    {
        base.Draw();
        Console.WriteLine("Obj class: " + GetType().ToString());
    }

}
