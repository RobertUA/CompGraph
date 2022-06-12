using System;

class Screen
{
    public Camera Camera;
    public int Width;
    public int Height;
    public Pixel[][] Pixels;
    public Screen(int width, int height)
    {
        Width = width;
        Height = height;
        Pixels = new Pixel[Width][];
        for (int x = 0; x < Pixels.Length; x++)
        {
            Pixels[x] = new Pixel[Height];
            for (int y = 0; y < Pixels[x].Length; y++)
            {
                Pixels[x][y] = new Pixel(this, x, y);
            }
        }
    }
    public void Update()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Pixels[x][y].Update();
                Console.Write(Pixels[x][y].Value);
            }
            Console.WriteLine();
        }
    }
}
