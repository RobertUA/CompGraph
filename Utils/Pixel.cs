
using System;

class Pixel
{
    public int X, Y;
    public Screen Screen;
    public string Value = " ";
    public Pixel(Screen screen, int x, int y)
    {
        Screen = screen;
        X = x;
        Y = y;
    }
    public void SetValue(HitInfo hit)
    {
        if (hit == null) Value = " ";
        else
        {
            Value = "#";
        }
    }
    public void Update()
    {
        float angleHorizontal = ((X - Screen.Width / 2f) / (Screen.Width / 2f)) * Screen.Camera.HorizontalFOV;
        float angleVertical = -((Y - Screen.Height / 2f) / (Screen.Height / 2f)) * Screen.Camera.VerticalFOV;
        Vector direction = Screen.Camera.Direction.Rotate(angleHorizontal, Vector.up).Rotate(angleVertical, Vector.right);
        HitInfo hit = Tools.Raycast(new Ray(Screen.Camera.Position, direction));
        SetValue(hit);
    }
}
