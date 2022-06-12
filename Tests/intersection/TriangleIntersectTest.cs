using System.Collections.Generic;
using NUnit.Framework;

public class TriangleIntersectTest : BaseIntersectTest
{
    [SetUp]
    public void Setup()
    {
        TestFigure = new Triangle(new Vector(0, 0, 0), new Vector(10, 10, 0), new Vector(0, 10, 0));
    }
    
    [Test]
    public void RayTriangleIntersectShouldNotIntersect()
    {
        CheckRaysIntersection();
    }
    
    [Test]
    public void RayTriangleIntersectShouldIntersect()
    {
        CheckRaysNoIntersection();
    }

    protected override List<Ray> InitRaysWithIntersect()
    {
        var rays = new List<Ray>();
        rays.Add(new Ray(new Vector(1,1,-1),new Vector(-1,-1,1)));
        rays.Add(new Ray(new Vector(3,3,-1),new Vector(-2,-2,5)));
        rays.Add(new Ray(new Vector(3,3,-1),new Vector(1,2,0.5f)));
        rays.Add(new Ray(new Vector(3,3,-1),new Vector(-1,-1,0.5f)));
        rays.Add(new Ray(new Vector(4,5,-1),new Vector(-1,-1,1)));
        return rays;
    }

    protected override List<Ray> InitRaysWithoutIntersect()
    {
        var rays = new List<Ray>();
        rays.Add(new Ray(new Vector(1,1,0),new Vector(-1,-1,0)));
        rays.Add(new Ray(new Vector(12,12,12),new Vector(0,0,5)));
        rays.Add(new Ray(new Vector(1,1,12),new Vector(-2,-1,-5)));
        rays.Add(new Ray(new Vector(1,1,12),new Vector(0,0,0)));
        return rays;
    }
}