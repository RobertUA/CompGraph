
public class HitInfo
{
    public Drawable Drawable;
    public Vector Position;
    public Vector Normal;
    public HitInfo(Vector hitPosition, Vector hitNormal, Drawable drawable)
    {
        Position = hitPosition;
        Normal = hitNormal;
        Drawable = drawable;
    }
}