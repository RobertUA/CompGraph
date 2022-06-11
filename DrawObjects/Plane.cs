
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
        return null;
    }
}