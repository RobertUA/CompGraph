using NUnit.Framework;

public class TriangleIntersectTest
{
    [Test]
    public void RayTriangleIntersectShouldNotIntersect()
    {
        var Triangle = new Triangle(new Vector(1,1,1),new Vector(2,2,2),new Vector(3,3,3));
        var Ray = new Ray(new Vector(0,6,0), Vector.up);
        Assert.Null(Triangle.GetIntersection(Ray));
    }
    
    [Test]
    public void RayTriangleIntersectShouldIntersect()
    {
        var Triangle = new Triangle(new Vector (-2,0,-2), new Vector (2,0,-2), new Vector (0,0,2));
        var Ray = new Ray(new Vector(0,6,0), -Vector.up);
        Assert.NotNull(Triangle.GetIntersection(Ray));
    }
}