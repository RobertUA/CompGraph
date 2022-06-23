using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

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
        ///
        int threadsCount = 16;
        int pixelsPerThread = (Height + threadsCount) / threadsCount;
        List<Thread> threads = new List<Thread>();
        for (int i = 0; i < threadsCount; i++)
        {
            int threadIndex = i * pixelsPerThread;
            threads.Add(new Thread(new ThreadStart(() =>
            {
                for (int y = threadIndex; y < threadIndex + pixelsPerThread && y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        Pixels[x][y].Update();
                    }
                }
            })));
            threads[i].Start();
        }
        for (int i = 0; i < threads.Count; i++)
        {
            threads[i].Join();
        }
        //
        Console.WriteLine("Pixels Calculated. Start output...");
        OutPPM();
        if(Width <= 200 && Height <= 50) OutConsole();
        Console.WriteLine("Output end");
    }
    public void OutPPM()
    {
        StreamWriter sw = new StreamWriter(Program.GetAbsolutePath("Output\\picture.ppm"));
        Console.WriteLine(Program.GetAbsolutePath("Output\\picture.ppm"));
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
                Console.Write(Pixels[x][y].TextValue);
            }
            Console.Write("|");
            Console.WriteLine();
        }
        for (int x = 0; x < Width + 2; x++) Console.Write("=");
        Console.WriteLine();
    }
}
