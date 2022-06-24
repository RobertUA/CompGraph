
public class Circle : Drawable
{
    public Vector Center;
    public Vector Normal;
    public double Diameter;
    public Circle(Vector center, Vector normal, double diameter)
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