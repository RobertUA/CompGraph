using System.Collections.Generic;
using NUnit.Framework;

public class SphereIntersectTest : BaseIntersectTest
{
    [SetUp]
    public void Setup()
    {
        TestFigure = new Sphere(new Vector(0, 0, 0), 1);
    }
    [Test]
    public void RaySphereIntersectShouldNotIntersect()
    {
        CheckRaysNoIntersection();
    }
    
    [Test]
    public void RaySphereIntersectShouldIntersect()
    {
        CheckRaysIntersection();
    }

    protected override List<Ray> InitRaysWithIntersect()
    {
        // Outside
        var testRaysWithIntersect = new List<Ray>();
        testRaysWithIntersect.Add(new Ray(new Vector(-1,-1,-1),Vector.one));
        testRaysWithIntersect.Add(new Ray(new Vector(-1,-1,-1),new Vector(1,0,1)));
        testRaysWithIntersect.Add(new Ray(new Vector(-1,-1,-1),new Vector(0,1,1)));

        // On the sphere
        testRaysWithIntersect.Add(new Ray(Vector.right, Vector.one));
        testRaysWithIntersect.Add(new Ray(Vector.up, new Vector(1, 0, 1)));
        testRaysWithIntersect.Add(new Ray(Vector.forward, new Vector(0, 1, 1)));

        // From Sphere centre
        testRaysWithIntersect.Add(new Ray(Vector.zero, Vector.right));

        return testRaysWithIntersect;
    }

    protected override List<Ray> InitRaysWithoutIntersect()
    {
        var testRaysWithoutIntersect = new List<Ray>();
        testRaysWithoutIntersect.Add(new Ray(new Vector(-1,-1,-1),Vector.right));
        testRaysWithoutIntersect.Add(new Ray(new Vector(-1,-1,-1),Vector.up));
        testRaysWithoutIntersect.Add(new Ray(new Vector(-1,-1,-1),Vector.forward));

        return testRaysWithoutIntersect;
    }
}