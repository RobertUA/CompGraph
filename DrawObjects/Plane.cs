using System;

public class Plane : Drawable
{
    public Vector Position;
    public Vector Normal;

    public Plane(Vector position, Vector normal)
    {
        Position = position;
        Normal = normal;
    }

    public override HitInfo GetIntersection(Ray ray)
    {
        var denom = Vector.Dot(Normal, ray.Direction);
        if (Math.Abs(denom) > 0.0001f)
        {
            var t = Vector.Dot(Position - ray.Origin, Normal) / denom;
            if (t >= 0)
            {
                return new HitInfo(ray.Origin + ray.Direction * t, Normal, this);
            }
        }

        return null;
    }
}