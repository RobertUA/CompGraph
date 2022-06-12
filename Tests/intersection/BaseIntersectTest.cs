using System.Collections.Generic;
using NUnit.Framework;

public abstract class BaseIntersectTest
{
    protected Drawable TestFigure;
    
    protected void CheckRaysIntersection()
    {
        foreach (var ray in InitRaysWithIntersect())
        {
            Assert.NotNull(TestFigure.GetIntersection(ray));
        }
    }
    protected void CheckRaysNoIntersection()
    {
        foreach (var ray in InitRaysWithoutIntersect())
        {
            Assert.Null(TestFigure.GetIntersection(ray));
        }
    }
    protected abstract List<Ray> InitRaysWithIntersect();
    protected abstract List<Ray> InitRaysWithoutIntersect();
}