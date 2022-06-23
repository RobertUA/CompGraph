using System;
using System.Collections.Generic;
using System.IO;

class Scene
{
    public Screen Screen;
    public Camera Camera;
    public LightSource LightSource;
    public List<Drawable> Drawables = new List<Drawable>();
    public static Scene Instance;
    
    
    public Scene(List<Drawable> drawables,LightSource lightSource)
    {
        Drawables = drawables;
        // LOH
        LightSource = lightSource;
        Instance = this;
    }

    public Scene()
    {
        Instance = this;
        //---- Setup
        LightSource = new LightSource(new Vector(0, 0, 1).GetNormalized());
        //Screen = new Screen(1920, 1080);
        Screen = new Screen(400, 250);
        //Screen = new Screen(200, 40);
        Camera = new Camera(new Vector(0, 0, -1), new Vector(0, 0, 1), 40, 25, Screen);
        //Camera = new Camera(new Vector(6, 0, 0), new Vector(-1, 0, 1), 40, 25, Screen);
        //---- Drawables
        //---- Drawables
        /*Drawables.Add(new Sphere(new Vector(-1, 0.5f, 0.5f), 1.25f));
        Drawables.Add(new Sphere(new Vector(1, 0.5f, 0.5f), 1.25f));
        Drawables.Add(new Sphere(new Vector(1, 0.5f, 0.5f), 0.5f));
        Drawables.Add(new Triangle(
            new Vector(-2, -0.1f, 0),
            new Vector(2, -0.1f, 0),
            new Vector(0, -2, 0)));*/

        /*Drawables.Add(new Triangle(
            new Vector(-20, -10, 8),
            new Vector(0, 10, 8),
            new Vector(20, -10, 8)));
        Drawables.Add(new Triangle(
            new Vector(2, -2, 5),
            new Vector(0, 2, 5),
            new Vector(-2, -2, 5)));
        Drawables.Add(new Sphere(new Vector(-1, 0, 4), 2f));
        Drawables.Add(new Sphere(new Vector(1, 0, 4), 2f));*/
        //
        //Drawables.AddRange(ObjReader.ReadFromFile(Program.GetAbsolutePath("Assets\\test.obj")));
        //Drawables.AddRange(ObjReader.ReadFromFile(Program.GetAbsolutePath("Assets\\box.obj")));
        Drawables.AddRange(ObjReader.ReadFromFile(Program.GetAbsolutePath("Assets\\cow.obj")));
        //Drawables.AddRange(ObjReader.ReadFromFile(Program.GetAbsolutePath("Assets\\dragon.obj")));
        //Drawables.AddRange(ObjReader.ReadFromFile(Program.GetAbsolutePath("Assets\\car.obj")));

        StreamWriter sw = new StreamWriter(Program.GetAbsolutePath("Output\\triangles.txt"));
        foreach (Drawable item in Drawables)
        {
            if (item.GetType() == typeof(Triangle))
            {
                sw.WriteLine((item as Triangle).corners[0] + " " + (item as Triangle).corners[1] + " " + (item as Triangle).corners[2]);
            }
        }
        sw.Close();
        //---- Start
        Screen.Update();
        Console.Beep();
    }
    
}
