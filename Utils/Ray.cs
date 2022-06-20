
public class Ray
{
    public Vector Origin;
    public Vector Direction;
    public Ray(Vector startPosition, Vector direction)
    {
        Origin = startPosition;
        Direction = direction.GetNormalized();
    }
}
