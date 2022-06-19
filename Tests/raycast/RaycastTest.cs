using System.Collections.Generic;
using NUnit.Framework;

public class RaycastTest
{
    [Test]
    public void RaycastShouldFindClosest()
    {
        var drawables = new List<Drawable>();
        var triangle1 = new Triangle(
            new Vector(-2, 2, 1),
            new Vector(2, 2, 1),
            new Vector(0, -2, 1));
        var triangle2 = new Triangle(
            new Vector(-2, 2, 2),
            new Vector(2, 2, 2),
            new Vector(0, -2, 2));
        
        drawables.Add(triangle1);
        drawables.Add(triangle2);
        
        new Scene(drawables,new LightSource(Vector.forward));
        var hitInfo = Tools.Raycast(new Ray(Vector.zero, Vector.forward));
        Assert.AreEqual(hitInfo.Drawable, triangle1);
    }
}