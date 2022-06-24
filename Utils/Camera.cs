
using System;

class Camera
{
    public double HorizontalFOV;
    public double VerticalFOV;
    public Vector Position;
    public Vector Direction;
    public Screen TargetScreen;
    public Vector Right { get { return -Vector.Cross(Direction, Vector.up); } }
    public Camera(Vector position, Vector direction, double horizontalFOV, double verticalFOV, Screen targetScreen)
    {
        Position = position;
        Direction = direction;
        HorizontalFOV = horizontalFOV;
        VerticalFOV = verticalFOV;
        //
        TargetScreen = targetScreen;
        TargetScreen.Camera = this;
    }
    public void Move(Vector moveDirection)
    {
        Position += moveDirection.x * Right 
            + moveDirection.y * Vector.up
            + moveDirection.z * Direction;
    }
    public void RotateY(double angle)
    {
        Direction = Direction.Rotate(angle, Vector.up);
    }
}
