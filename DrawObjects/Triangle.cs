using System;

public class Triangle : Drawable
{
    public Vector[] corners = new Vector[3];

    public Triangle(Vector firstCorner, Vector secondCorner, Vector thirdCorner)
    {
        corners[0] = firstCorner;
        corners[1] = secondCorner;
        corners[2] = thirdCorner;
        var firstV0 = corners[1] - corners[0];
        var secondV0 = corners[2] - corners[0];
    }
    public override HitInfo GetIntersection(Ray ray)
    {
        const bool twoSided = true;
        float t;
        var firstV0 = corners[1] - corners[0];
        var secondV0 = corners[2] - corners[0];
        var normal = Vector.Cross(firstV0, secondV0);
        var scalarProduct = Vector.Dot(normal, ray.Direction);

        if (-scalarProduct < float.Epsilon)
        {
            if(twoSided)
            {
                if (scalarProduct < float.Epsilon)
                    return null;
            }
            else 
                return null;
        }
        var d = -Vector.Dot(normal, corners[0]);
        t = -(Vector.Dot(normal, ray.StartPosition) + d) / scalarProduct;
        if (t < 0)
        {
            return null;
        }

        var P = ray.StartPosition + ray.Direction * t;

        var edge0 = corners[1] - corners[0];
        var vp0 = P - corners[0];

        Vector C = Vector.Cross(edge0, vp0);
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
        return new HitInfo(P, normal, this);
    }

}