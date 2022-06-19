using System.Collections.Generic;
using NUnit.Framework;

public class TriangleIntersectTest : BaseIntersectTest
{
    [SetUp]
    public void Setup()
    {
        TestFigure = new Triangle(new Vector(0, 10, 0), new Vector(10, 10, 0), new Vector(0, 0, 0));
    }
    
    [Test]
    public void RayTriangleIntersectShouldNotIntersect()
    {
        CheckRaysNoIntersection();
    }
    
    [Test]
    public void RayTriangleIntersectShouldIntersect()
    {
        CheckRaysIntersection();
    }

    protected override List<Ray> InitRaysWithIntersect()
    {
        var rays = new List<Ray>();
        rays.Add(new Ray(new Vector(1,1,-1),new Vector(0, 0, 1)));
        rays.Add(new Ray(new Vector(3,3,-1),new Vector(0, 0, 1)));
        rays.Add(new Ray(new Vector(4,5,-1),new Vector(0, 0, 1)));
        return rays;
    }

    protected override List<Ray> InitRaysWithoutIntersect()
    {
        var rays = new List<Ray>();
        rays.Add(new Ray(new Vector(-10000,-1,0),new Vector(0,0,-1)));
        rays.Add(new Ray(new Vector(12,12,12),new Vector(0,0,5)));
        rays.Add(new Ray(new Vector(1,1,12),new Vector(-2,-1,-5)));
        return rays;
    }
}