
using System;

class Pixel
{
    public static float maxColorValue = 255;
    public int X, Y;
    public Screen Screen;
    public Vector Color = Vector.one;
    public Pixel(Screen screen, int x, int y)
    {
        Screen = screen;
        X = x;
        Y = y;
    }
    public void SetValue(HitInfo hit)
    {
        if (hit == null) Color = Vector.zero;
        else if (hit.Normal == null) Color = Vector.zero;
        else
        {
            float scalarProduct = -Vector.Dot(Scene.Instance.LightSource.Direction, hit.Normal);
            //
            if (scalarProduct < 0)
                Color = Vector.zero;
            else if (scalarProduct <= 1)
                Color = maxColorValue * Vector.one * scalarProduct;
            else
                Color = maxColorValue * Vector.one;
            Color = maxColorValue * Vector.one;
        }
    }
    public void Update()
    {
        float angleHorizontal = ((X - Screen.Width / 2f) / (Screen.Width / 2f)) * Screen.Camera.HorizontalFOV;
        float angleVertical = -((Y - Screen.Height / 2f) / (Screen.Height / 2f)) * Screen.Camera.VerticalFOV;
        Vector direction = Screen.Camera.Direction.Rotate(angleHorizontal, Vector.up).Rotate(angleVertical, Screen.Camera.Right);
        HitInfo hit = Tools.Raycast(new Ray(Screen.Camera.Position, direction));
        SetValue(hit);
    }
}
