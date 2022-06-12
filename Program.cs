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
                        Input(Vector.forward);
                        break;
                    }
                case ConsoleKey.S:
                    {
                        Input(-Vector.forward);
                        break;
                    }
                case ConsoleKey.D:
                    {
                        Input(Vector.right);
                        break;
                    }
                case ConsoleKey.A:
                    {
                        Input(-Vector.right);
                        break;
                    }
            }
            keyInfo = Console.ReadKey(true);
        }
    }
    public static void Input(Vector input)
    {
        Console.Clear();
        Scene.Instance.Camera.Move(input);
        Scene.Instance.Screen.Update();
    }
}
