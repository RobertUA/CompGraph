
using System;

class LightSource
{
    public Vector Direction;
    public LightSource(Vector direction)
    {
        if(direction == Vector.zero)
        {
            throw new System.Exception("Вектор света не может быть нулевым");
        }
        Direction = direction.GetNormalized();
    }
    public void RotateY(float angle)
    {
        Direction = Direction.Rotate(angle, Vector.up);
    }
}