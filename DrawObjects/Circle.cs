
public class Circle : Drawable
{
    public Vector Center;
    public Vector Normal;
    public float Diameter;
    public Circle(Vector center, Vector normal, float diameter)
    {
        Center = center;
        Normal = normal;
        Diameter = diameter;
    }
    public override HitInfo GetIntersection(Ray ray)
    {
        return null;
    }
}