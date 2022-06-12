using System;

public class Triangle : Drawable
{
    Vector[] corners = new Vector[3];

    public Triangle(Vector firstCorner, Vector secondCorner, Vector thirdCorner)
    {
        corners[0] = firstCorner;
        corners[1] = secondCorner;
        corners[2] = thirdCorner;
    }

    public override HitInfo GetIntersection(Ray ray)
    {
        const double eps = 0.0000001;
        float t;
        var firstV0 = corners[1] - corners[0];
        var secondV0 = corners[2] - corners[0];
        var normal = Vector.Cross(firstV0, secondV0);
        var area = Math.Sqrt((normal.x * normal.x + normal.y * normal.y + normal.z * normal.z));

        var normalRayDirection = Vector.Dot(normal, ray.Direction);
        if (Math.Abs(normalRayDirection) < eps)
        {
            return null;
        }

        var d = -Vector.Dot(normal, corners[0]);
        t = -(Vector.Dot(normal, ray.StartPosition) + d)/normalRayDirection;
        if (t < 0)
        {
            return null;
        }

        var P = ray.StartPosition + ray.Direction * t;
        Vector C;

        var edge0 = corners[1] - corners[0];
        var vp0 = P - corners[0];
        C = Vector.Cross(edge0, vp0);
        if (Vector.Dot(normal, C) < 0)
        {
            return null;
        }

        var edge1 = corners[2] - corners[1];
        var vp1 = P - corners[1];
        C = Vector.Cross(edge1, vp1);
        if (Vector.Dot(normal, C) < 0)
        {
            return null;
        }

        var edge2 = corners[0] - corners[2];
        var vp2 = P - corners[2];
        C = Vector.Cross(edge2, vp2);
        if (Vector.Dot(normal, C) < 0)
        {
            return null;
        }
        return new HitInfo(P,null,this);
    }
}