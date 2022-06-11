using System;
using System.Collections.Generic;

class Scene
{
    public Screen Screen;
    public Camera Camera;
    public LightSource LightVector;
    public List<Drawable> Drawables;
    public Scene()
    {
        //circle
        Circle circle = new Circle(Vector.zero, Vector.forward, 10);
        Drawables.Add(circle);
        //triangle
        Triangle triangle = new Triangle(Vector.zero, Vector.right, Vector.up);
        Drawables.Add(triangle);
    }
}
