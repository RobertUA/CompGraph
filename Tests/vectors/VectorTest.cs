using System;
using NUnit.Framework;

public class VectorTest
{
    private Vector vector1 = new Vector(1, 1, 1);
    private Vector vector2 = new Vector(-2, -2, -2);
    
    [Test]
    public void VectorDotShouldReturnScalarProduct()
    {
        var dot = Vector.Dot(vector1, vector2);
        Assert.AreEqual(-6,dot);
    }
    [Test]
    public void VectorCrossShouldReturnVectorWithNewCoordinates()
    {
        var newVector = Vector.Cross(vector1, vector2);
        var expectedVector = new Vector(0, 0, 0);
        Assert.AreEqual(expectedVector,newVector);
    }
    [Test]
    public void VectorGetMagnitudeShouldReturnVectorMagnitude()
    {
        Assert.AreEqual(1.73205078f,vector1.GetMagnitude());
        Assert.AreEqual(3.46410155f,vector2.GetMagnitude());
    }
    [Test]
    public void VectorGetNormalizedShouldReturnNormalizedVector()
    {
        Assert.AreEqual(new Vector(0.5773503f,0.5773503f,0.5773503f), vector1.GetNormalized());
        Assert.AreEqual(new Vector(0,0,0),vector2.GetNormalized());
    }
    [Test]
    public void VectorSubShouldReturnNewVector()
    {
        var subVector = vector1 - vector2;
        Assert.AreEqual(new Vector(3,3,3),subVector);
    }
    [Test]
    public void VectorAddShouldReturnNewVector()
    {
        var addVector = vector1 + vector2;
        Assert.AreEqual(new Vector(-1,-1,-1),addVector);
    }
    [Test]
    public void VectorDivShouldReturnNewVector()
    {
        var div1 = vector1/2;
        var div2 = vector2/2;
        Assert.AreEqual(new Vector(0.5f,0.5f,0.5f),div1);
        Assert.AreEqual(new Vector(-1,-1,-1),div2);
    }
    [Test]
    public void VectorMultiplyShouldReturnNewVector()
    {
        var mul1 = vector1*2;
        var mul2 = vector2*2;
        Assert.AreEqual(new Vector(2,2,2),mul1);
        Assert.AreEqual(new Vector(-4,-4,-4),mul2);
    }
    [Test]
    public void VectorDistanceShouldReturnCorrectDistance()
    {
        var distance = Vector.Distance(vector1, vector2);
        Assert.AreEqual(5.196152422706632,distance);
    }
    [Test]
    public void VectorMinusShouldReturnNegativeVector()
    {
        Assert.AreEqual(new Vector(-1,-1,-1),-vector1);
        Assert.AreEqual(new Vector(2,2,2),-vector2);
    }
    
}