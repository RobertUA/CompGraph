using System.Collections.Generic;
using NUnit.Framework;

public class SphereIntersectTest : BaseIntersectTest
{
    [SetUp]
    public void Setup()
    {
        testFigure = new Sphere(new Vector(0, 0, 0), 1);
    }
    [Test]
    public void RaySphereIntersectShouldNotIntersect()
    {
        checkRaysNoIntersection();
    }
    
    [Test]
    public void RaySphereIntersectShouldIntersect()
    {
        checkRaysIntersection();
    }

    protected override List<Ray> initRaysWithIntersect()
    {
        // Outside
        var testRaysWithIntersect = new List<Ray>();
        testRaysWithIntersect.Add(setupRay(new Vector(-1,-1,-1),Vector.one));
        testRaysWithIntersect.Add(setupRay(new Vector(-1,-1,-1),new Vector(1,0,1)));
        testRaysWithIntersect.Add(setupRay(new Vector(-1,-1,-1),new Vector(0,1,1)));
        
        // On the sphere
        testRaysWithIntersect.Add(setupRay(Vector.right, Vector.one));
        testRaysWithIntersect.Add(setupRay(Vector.up, new Vector(1,0,1)));
        testRaysWithIntersect.Add(setupRay(Vector.forward, new Vector(0,1,1)));
        
        // From Sphere centre
        testRaysWithIntersect.Add(setupRay(Vector.zero, Vector.right));

        return testRaysWithIntersect;
    }

    protected override List<Ray> initRaysWithoutIntersect()
    {
        var testRaysWithoutIntersect = new List<Ray>();
        testRaysWithoutIntersect.Add(setupRay(new Vector(-1,-1,-1),Vector.right));
        testRaysWithoutIntersect.Add(setupRay(new Vector(-1,-1,-1),Vector.up));
        testRaysWithoutIntersect.Add(setupRay(new Vector(-1,-1,-1),Vector.forward));
        
        return testRaysWithoutIntersect;
    }
}