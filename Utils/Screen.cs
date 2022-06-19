using System;
using System.IO;

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
        Console.WriteLine("Start calculation...");
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Pixels[x][y].Update();
            }
        }
        Console.WriteLine("Pixels Calculated. Start output...");
        OutPPM();
        OutConsole();
        Console.WriteLine("Output end");
    }
    public void OutPPM()
    {
        StreamWriter sw = new StreamWriter("F:\\CompGraph\\CompGraph\\picture.ppm");
        sw.WriteLine("P3");
        sw.WriteLine(Width + " " + Height);
        sw.WriteLine(Pixel.maxColorValue);
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                sw.WriteLine(Pixels[x][y].Color.x 
                    + " " + Pixels[x][y].Color.y
                    + " " + Pixels[x][y].Color.z);
            }
        }
        sw.Close();
    }
    public void OutConsole()
    {
        Console.WriteLine("Cam: " + Camera.Position + "[" + Camera.Direction + "] LightDir: " + Scene.Instance.LightSource.Direction);
        for (int x = 0; x < Width + 2; x++) Console.Write("=");
        Console.WriteLine();
        for (int y = 0; y < Height; y++)
        {
            Console.Write("|");
            for (int x = 0; x < Width; x++)
            {
                Console.Write(Pixels[x][y].Color == Vector.zero ? " " : "#");
            }
            Console.Write("|");
            Console.WriteLine();
        }
        for (int x = 0; x < Width + 2; x++) Console.Write("=");
        Console.WriteLine();
    }
}
