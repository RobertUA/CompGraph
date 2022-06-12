using System;

class Sphere : Drawable
{
    public Vector Center;
    public float Diameter;

    public Sphere(Vector center, float diameter)
    {
        Center = center;
        Diameter = diameter;
    }

    public override HitInfo GetIntersection(Ray ray)
    {
        var L = ray.StartPosition - Center;
        var a = Vector.Dot(ray.Direction, ray.Direction);
        var b = 2 * Vector.Dot(ray.Direction, L);
        var c = Vector.Dot(L, L) - Diameter;
        var t = solveDiscriminant(a, b, c);
        if (t < 0)
        {
            return null;
        }
        return new HitInfo(ray.StartPosition + ray.Direction * t,null,this);
    }

    private float solveDiscriminant(float a, float b, float c)
    {
        var discr = b * b - 4 * a * c;
        float x0, x1;
        if (discr < 0)
        {
            return -1;
        }
        else if (discr == 0)
        {
            return (float)-0.5 * b / a;
        }
        else
        {
            float q = (float)((b > 0) ? -0.5 * (b + Math.Sqrt(discr)) : -0.5 * (b - Math.Sqrt(discr)));
            x0 = q / a;
            x1 = c / q;
            return Math.Max(x0, x1);
        }
    }
}