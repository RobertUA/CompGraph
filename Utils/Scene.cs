using System;
using System.Collections.Generic;

class Scene
{
    public Screen Screen;
    public Camera Camera;
    public LightSource LightSource;
    public List<Drawable> Drawables = new List<Drawable>();
    public static Scene Instance;
    public Scene()
    {
        Instance = this;
        //---- Setup
        LightSource = new LightSource(new Vector(0, -1, -2).GetNormalizedVector());
        Screen = new Screen(60, 30);
        Camera = new Camera(new Vector(0, 0, -4f), Vector.forward, 40, 35, Screen);
        //---- Drawables
        Drawables.Add(new Sphere(new Vector(-1, 0.5f, 0), 1.25f));
        Drawables.Add(new Sphere(new Vector(1, 0.5f, 0), 1.25f));
        Drawables.Add(new Triangle(
            new Vector(-2, -0.1f, 0),
            new Vector(2, -0.1f, 0),
            new Vector(0, -2, 0)));
        //---- Start
        Screen.Update();
    }
}
