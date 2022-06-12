using System;
using System.Collections.Generic;

class Scene
{
    public Screen Screen;
    public Camera Camera;
    public LightSource LightVector;
    public List<Drawable> Drawables = new List<Drawable>();
    public static Scene Instance;
    public Scene()
    {
        Instance = this;

        //---- Setup
        Screen screen = new Screen(60, 30);
        Camera camera = new Camera(new Vector(0, 0, -4f), Vector.forward, 50, 30, screen);
        //---- Drawables
        /*Sphere sphere1 = new Sphere(new Vector(-1, 0, 0), 1);
        Drawables.Add(sphere1);
        Sphere sphere2 = new Sphere(new Vector(1, 0, 0), 1);
        Drawables.Add(sphere2);*/
        Drawables.Add(new Triangle(new Vector(-2, -2, 0),
                                            new Vector(2, -2, 0),
                                            new Vector(0, 2, 0)));
        //---- Start
        screen.Update();
    }
}
