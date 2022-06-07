using System;

public class Circle : Drawable
{
    Vector center;
    Vector normal;
    float diameter;
    public Circle(Vector center, Vector normal, float diameter)
    {
        this.center = center;
        this.normal = normal;
        this.diameter = diameter;
    }

    public override Vector GetIntersection(Vector start,Vector direction)
    {
        throw new NotImplementedException();
    }

    public override void Draw()
    {
       
        Console.WriteLine("Obj class: " + GetType().ToString());
    }
}