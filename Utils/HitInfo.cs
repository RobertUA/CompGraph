
public class HitInfo
{
    public Vector Position;
    public Vector Normal;
    public HitInfo(Vector hitPosition, Vector hitNormal)
    {
        Position = hitPosition;
        Normal = hitNormal;
    }
}