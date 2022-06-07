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

    public override Vector GetIntersection(Vector start, Vector direction)
    {
        float denom = Vector.Dot(normal, direction);
        float t = Vector.Dot(position - start, normal) / denom;
        return start + direction * t;
    }

    public override void Draw()
    {
        Console.WriteLine("Obj class: " + GetType().ToString());
    }
}