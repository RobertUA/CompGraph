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
    public override void Draw()
    {
        base.Draw();
        Console.WriteLine("Obj class: " + GetType().ToString());
    }
}