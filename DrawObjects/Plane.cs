
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
    public override HitInfo GetInretsection(Ray ray)
    {
        var denom = Vector.Dot(Normal, ray.Direction);
        if (Math.Abs(denom) > 0.0001f)
        {
            var t = Vector.Dot(Position - ray.StartPosition, Normal) / denom;
            if (t>=0)
            {
                return new HitInfo(ray.StartPosition + ray.Direction * t,null);
            }
        }
        return null;
    }
}