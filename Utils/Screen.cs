using System.Collections.Generic;

class Screen
{
    public int Width;
    public int Height;
    public Pixel[][] Pixels;
    public Screen(int width, int height)
    {
        Width = width;
        Height = height;
        Pixels = new Pixel[Width][];
        for (int i = 0; i < Pixels.Length; i++)
        {
            Pixels[i] = new Pixel[Height];
        }
    }
}
