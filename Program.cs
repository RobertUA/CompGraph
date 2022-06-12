using System;

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Scene scene = new Scene();
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        while (keyInfo.Key != ConsoleKey.Escape) 
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    {
                        Scene.Instance.Camera.Move(Vector.forward);
                        Update();
                        break;
                    }
                case ConsoleKey.S:
                    {
                        Scene.Instance.Camera.Move(-Vector.forward);
                        Update();
                        break;
                    }
                case ConsoleKey.D:
                    {
                        Scene.Instance.Camera.Move(Vector.right);
                        Update();
                        break;
                    }
                case ConsoleKey.A:
                    {
                        Scene.Instance.Camera.Move(-Vector.right);
                        Update();
                        break;
                    }
                case ConsoleKey.Spacebar:
                    {
                        Scene.Instance.Camera.Move(Vector.up);
                        Update();
                        break;
                    }
                case ConsoleKey.C:
                    {
                        Scene.Instance.Camera.Move(-Vector.up);
                        Update();
                        break;
                    }
                case ConsoleKey.E:
                    {
                        Scene.Instance.Camera.RotateY(15);
                        Update();
                        break;
                    }
                case ConsoleKey.Q:
                    {
                        Scene.Instance.Camera.RotateY(-15);
                        Update();
                        break;
                    }
                case ConsoleKey.R:
                    {
                        Scene.Instance.Camera.RotateX(-15);
                        Update();
                        break;
                    }
                case ConsoleKey.T:
                    {
                        Scene.Instance.Camera.RotateX(15);
                        Update();
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        Scene.Instance.LightSource.RotateY(15);
                        Update();
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        Scene.Instance.LightSource.RotateY(-15);
                        Update();
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        Scene.Instance.LightSource.RotateX(-15);
                        Update();
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        Scene.Instance.LightSource.RotateX(15);
                        Update();
                        break;
                    }
            }
            keyInfo = Console.ReadKey(true);
        }
    }
    public static void Update()
    {
        Console.Clear();
        Scene.Instance.Screen.Update();
    }
}
