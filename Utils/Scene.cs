using System;
using System.Collections.Generic;
using System.IO;
using KdTree;

class Scene
{
    public Screen Screen;
    public Camera Camera;
    public LightSource LightSource;
    public List<Drawable> Drawables = new List<Drawable>();
    public Booster booster = new Booster();
    public static Scene Instance;
    
    
    public Scene(List<Drawable> drawables,LightSource lightSource)
    {
        Drawables = drawables;
        LightSource = lightSource;
        Instance = this;
    }

    public Scene()
    {
        Instance = this;
        //---- Setup
        LightSource = new LightSource(new Vector(0, 0, 1).GetNormalized());
        //Screen = new Screen(1920, 1080);
        //Screen = new Screen(1280, 720);
        //Screen = new Screen(400, 300);
        Screen = new Screen(200, 40);
        Camera = new Camera(new Vector(0, 0, -10), new Vector(0, 0, 1), 40, 25, Screen);
        //Camera = new Camera(new Vector(0, 0, 5), new Vector(0, 0, -1), 40, 25, Screen);
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
        //booster.AddRange(ObjReader.ReadFromFile(Program.GetAbsolutePath("Assets\\test.obj")));
        //booster.AddRange(ObjReader.ReadFromFile(Program.GetAbsolutePath("Assets\\box.obj")));
        //booster.AddRange(ObjReader.ReadFromFile(Program.GetAbsolutePath("Assets\\cow.obj")));
        booster.AddRange(ObjReader.ReadFromFile(Program.GetAbsolutePath("Assets\\dragon.obj")));
        //booster.AddRange(ObjReader.ReadFromFile(Program.GetAbsolutePath("Assets\\car.obj")));

        Console.WriteLine("Nods count: " + booster.Nodes.Count);
        /*foreach (var node in booster.Nodes)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(node.bounds[i].x + " " + node.bounds[i].y + " " + node.bounds[i].z);
            }
        }*/
        //---- Start
        Screen.Update();
        Console.Beep();
    }
    
}
