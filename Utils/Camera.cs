
class Camera
{
    public float HorizontalFOV;
    public float VerticalFOV;
    public Vector Position;
    public Vector Direction;
    public Screen TargetScreen;
    public Camera(Vector position, Vector direction, float horizontalFOV, float verticalFOV, Screen targetScreen)
    {
        Position = position;
        Direction = direction;
        HorizontalFOV = horizontalFOV;
        VerticalFOV = verticalFOV;
        TargetScreen = targetScreen;
        TargetScreen.Camera = this;
    }
}
