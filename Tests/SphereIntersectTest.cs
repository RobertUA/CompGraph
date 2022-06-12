using NUnit.Framework;

public class SphereIntersectTest
{
    [Test]
    public void RaySphereIntersectShouldNotIntersect()
    {
        var Sphere = new Sphere(Vector.zero, 2);
        var Ray = new Ray(new Vector(0,6,0), Vector.up);
        Assert.Null(Sphere.GetInretsection(Ray));
    }
    
    [Test]
    public void RaySphereIntersectShouldIntersect()
    {
        var Sphere = new Sphere(Vector.zero, 2);
        var Ray = new Ray(new Vector(0,6,0), -Vector.up);
        Assert.NotNull(Sphere.GetInretsection(Ray));
    }
}