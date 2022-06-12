using NUnit.Framework;


public class PlaneIntersectTest
{
    [Test]
    public void RayPlaneIntersectShouldNotIntersect()
    {
        var Plane = new Plane(Vector.zero, Vector.up);
        var Ray = new Ray(new Vector(0,6,0), Vector.up);
        Assert.Null(Plane.GetIntersection(Ray));
    }
    
    [Test]
    public void RayPlaneIntersectShouldIntersect()
    {
        var Plane = new Plane(Vector.zero, Vector.up);
        var Ray = new Ray(new Vector(0,6,0), -Vector.up);
        Assert.NotNull(Plane.GetIntersection(Ray));
    }
}