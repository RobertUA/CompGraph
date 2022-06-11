using System;

public class Plane : Drawable
{
    Vector position;
    Vector normal;
    public Plane(Vector position, Vector normal)
    {
        this.position = position;
        this.normal = normal;
    }
    public override void Draw()
    {
        base.Draw();
        Console.WriteLine("Obj class: " + GetType().ToString());
    }
}