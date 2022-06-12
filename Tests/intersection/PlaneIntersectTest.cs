using System.Collections.Generic;
using NUnit.Framework;


public class PlaneIntersectTest: BaseIntersectTest
{
    [SetUp]
    public void Setup()
    {
        TestFigure = new Plane(Vector.zero, Vector.up);
    }
    
    [Test]
    public void RayPlaneIntersectShouldNotIntersect()
    {
        CheckRaysNoIntersection();
    }
    
    [Test]
    public void RayPlaneIntersectShouldIntersect()
    {
        CheckRaysIntersection();
    }

    protected override List<Ray> InitRaysWithIntersect()
    {
        var rays = new List<Ray>();
        rays.Add(new Ray(new Vector(0,6,0), -Vector.up));
        return rays;
    }

    protected override List<Ray> InitRaysWithoutIntersect()
    {
        var rays = new List<Ray>();
        rays.Add(new Ray(new Vector(0,6,0), Vector.up));
        return rays;
    }
}