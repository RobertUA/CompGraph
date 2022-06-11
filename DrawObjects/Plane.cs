
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
        if (denom > 1e-6)
        {
            var p010 = Position - ray.StartPosition;
            var t = Vector.Dot(p010, Normal) / denom;
            return new HitInfo(ray.StartPosition + ray.Direction * t,null);
        }
        return null;
    }
}