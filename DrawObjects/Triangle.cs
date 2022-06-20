using System;

public class Triangle : Drawable
{
    public Vector[] corners = new Vector[3];

    public Triangle(Vector firstCorner, Vector secondCorner, Vector thirdCorner)
    {
        //Console.WriteLine(firstCorner + secondCorner + thirdCorner);
        corners[0] = firstCorner.Value;
        corners[1] = secondCorner.Value;
        corners[2] = thirdCorner.Value;
    }
    public override HitInfo GetIntersection(Ray ray) // нормальные тесты, но корова плевет
    {
        const bool twoSided = false;
        double t;
        var firstV0 = corners[1] - corners[0];
        var secondV0 = corners[2] - corners[0];
        var normal = Vector.Cross(firstV0, secondV0);
        double scalarProduct = Vector.Dot(normal, ray.Direction);

        if (-scalarProduct < 0.000001)
        {
            if (twoSided)
            {
                if (scalarProduct < double.Epsilon)
                    return null;
            }
            else
                return null;
        }
        double d = -Vector.Dot(normal, corners[0]);
        t = -(Vector.Dot(normal, ray.Origin) + d) / scalarProduct;
        if (t < 0)
        {
            return null;
        }

        var P = ray.Origin + ray.Direction * (float)t;

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
    /*public override HitInfo GetIntersection(Ray ray) //очертание коровы, но тест треугольника - не такой
    {
        const double Epsilon = 0.000001d;
        var edge1 = corners[1] - corners[0];
        var edge2 = corners[2] - corners[0];

        var pvec = Vector.Cross(ray.Direction, edge2);

        var det = Vector.Dot(edge1, pvec);

        if (det > -Epsilon && det < Epsilon)
        {
            return null;
        }

        var invDet = 1d / det;

        var tvec = ray.Origin - corners[0];

        var u = Vector.Dot(tvec, pvec) * invDet;

        if (u < 0 || u > 1)
        {
            return null;
        }

        var qvec = Vector.Cross(tvec, edge1);

        var v = Vector.Dot(ray.Direction, qvec) * invDet;

        if (v < 0 || u + v > 1)
        {
            return null;
        }

        var t = Vector.Dot(edge2, qvec) * invDet;
        
        return new HitInfo(ray.Direction * (float)t + ray.Origin, pvec.GetNormalized(), this);
    }*/
}