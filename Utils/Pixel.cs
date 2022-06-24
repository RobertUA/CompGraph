
using System;
using System.Collections.Generic;

class Pixel
{
    public static double maxColorValue = 255;
    public int X, Y;
    public Screen Screen;
    public Vector Color = Vector.zero;
    public char TextValue = ' ';
    public Pixel(Screen screen, int x, int y)
    {
        Screen = screen;
        X = x;
        Y = y;
    }
    public void SetValue(HitInfo hit, double power = 1)
    {
        if (hit == null)
        {
            TextValue = ' ';
            Color = new Vector(255, 0, 255);
        }
        else if (hit.Normal == null)
        {
            TextValue = ' ';
            Color = new Vector(255, 0, 255);
        }
        else
        {
            double scalarProduct = -Vector.Dot(Scene.Instance.LightSource.Direction, hit.Normal);
            // scalarProduct = 1;
            
            //
            if (scalarProduct < 0)
                Color = new Vector(0, 0, 0);
            else if (scalarProduct < 1)
                Color = maxColorValue * Vector.one * scalarProduct;
            else
                Color = maxColorValue * Vector.one;
            Color *= power;
            if (scalarProduct < 0) TextValue = '-';
            else if (scalarProduct < 0.2f) TextValue = '.';
            else if (scalarProduct < 0.5f) TextValue = '*';
            else if (scalarProduct < 0.8f) TextValue = 'O';
            else TextValue = '#';
        }
    }
    public void Update()
    {
        double angleHorizontal = ((X - Screen.Width / 2f) / (Screen.Width / 2f)) * Screen.Camera.HorizontalFOV;
        double angleVertical = -((Y - Screen.Height / 2f) / (Screen.Height / 2f)) * Screen.Camera.VerticalFOV;
        Vector direction = Screen.Camera.Direction.Rotate(angleHorizontal, Vector.up).Rotate(angleVertical, Screen.Camera.Right);
        HitInfo hit = Tools.Raycast(new Ray(Screen.Camera.Position, direction));
        double power = 1;
        if (hit != null)
        {
            Ray secondRay = new Ray(hit.Position, -Scene.Instance.LightSource.Direction);
            List<HitInfo> lightHits = Tools.RaycastAll(secondRay);
            if (lightHits != null)
            {
                foreach (var lightHit in lightHits)
                {
                    if (lightHit.Drawable != hit.Drawable)
                    {
                        power *= 0.5f;
                    }
                }
            }
        }
        SetValue(hit, power);
    }
}
