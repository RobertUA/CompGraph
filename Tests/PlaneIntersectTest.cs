using NUnit.Framework;


public class PlaneIntersectTest
{
    [Test]
    public void RayPlaneIntersectShouldNotIntersect()
    {
        var Plane = new Plane(Vector.zero, Vector.up);
        var Ray = new Ray(new Vector(0,6,0), Vector.up);
        Assert.Null(Plane.GetInretsection(Ray));
    }
    
    [Test]
    public void RayPlaneIntersectShouldIntersect()
    {
        var Plane = new Plane(Vector.zero, Vector.up);
        var Ray = new Ray(new Vector(0,6,0), -Vector.up);
        Assert.NotNull(Plane.GetInretsection(Ray));
    }
}