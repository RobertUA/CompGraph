using System;
using System.Collections.Generic;

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
        //Screen = new Screen(400, 400);
        Screen = new Screen(100, 40);
        Camera = new Camera(new Vector(0, 0, -2f), Vector.forward, 30, 30, Screen);
        //---- Drawables
        /*Drawables.Add(new Sphere(new Vector(-1, 0.5f, 0.5f), 1.25f));
        Drawables.Add(new Sphere(new Vector(1, 0.5f, 0.5f), 1.25f));
        Drawables.Add(new Sphere(new Vector(1, 0.5f, 0.5f), 0.5f));
        Drawables.Add(new Triangle(
            new Vector(-2, -0.1f, 0),
            new Vector(2, -0.1f, 0),
            new Vector(0, -2, 0)));*/
        //Drawables.Add(new Sphere(new Vector(0, 0, 0), 0.55f));
        Drawables.AddRange(ObjReader.ReadFromFile("F:\\CompGraph\\CompGraph\\test.obj"));
        //Drawables.AddRange(ObjReader.ReadFromFile("F:\\CompGraph\\CompGraph\\cow.obj"));
        //Drawables.AddRange(ObjReader.ReadFromFile("F:\\CompGraph\\CompGraph\\dragon.obj"));
        //Drawables.AddRange(ObjReader.ReadFromFile("F:\\CompGraph\\CompGraph\\car.obj"));
        /*foreach (Triangle item in Drawables)
        {
           Console.WriteLine(item.corners[0] + " " + item.corners[1] + " " + item.corners[2]);
        }*/
        //---- Start
        Screen.Update();
    }
}
