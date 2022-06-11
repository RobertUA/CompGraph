
class Sphere : Drawable
{
    public Vector Center;
    public float Diameter;
    public Sphere(Vector center, float diameter)
    {
        Center = center;
        Diameter = diameter;
    }
    public override HitInfo GetInretsection(Ray ray)
    {
        return null;
    }
}
