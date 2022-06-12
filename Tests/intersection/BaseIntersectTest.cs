using System.Collections.Generic;
using NUnit.Framework;

public abstract class BaseIntersectTest
{
    protected Drawable testFigure;
    

    protected Ray setupRay(Vector rayStart,Vector rayDirection)
    {
        return new Ray(rayStart, rayDirection);
    }

    protected void checkRaysIntersection()
    {
        foreach (var ray in initRaysWithIntersect())
        {
            Assert.NotNull(testFigure.GetIntersection(ray));
        }
    }
    protected void checkRaysNoIntersection()
    {
        foreach (var ray in initRaysWithoutIntersect())
        {
            Assert.Null(testFigure.GetIntersection(ray));
        }
    }
    protected abstract List<Ray> initRaysWithIntersect();
    protected abstract List<Ray> initRaysWithoutIntersect();
}