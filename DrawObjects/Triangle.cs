
public class Triangle : Drawable
{
    Vector[] corners = new Vector[3];
    public Triangle(Vector firstCorner, Vector secondCorner, Vector thirdCorner)
    {
        corners[0] = firstCorner;
        corners[1] = secondCorner;
        corners[2] = thirdCorner;
    }
    public override HitInfo GetInretsection(Ray ray)
    {
        return null;
    }
}