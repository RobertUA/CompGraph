
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
        else if (hit.Normal == null) Value = "#";
        else
        {
            float scalarProduct = Vector.Dot(Scene.Instance.LightSource.Direction, hit.Normal);
            if (scalarProduct < 0) Value = " ";
            else if (scalarProduct < 0.2f) Value = ".";
            else if (scalarProduct < 0.5f) Value = "*";
            else if (scalarProduct < 0.8f) Value = "O";
            else Value = "#";
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
