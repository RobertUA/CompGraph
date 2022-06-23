using System;

public class Triangle : Drawable
{
    public Vector[] corners = new Vector[3];
    public Vector Normal;

    public Triangle(Vector firstCorner, Vector secondCorner, Vector thirdCorner, Vector normal = null)
    {
        //Console.WriteLine(firstCorner + secondCorner + thirdCorner);
        corners[0] = firstCorner.Value;
        corners[1] = secondCorner.Value;
        corners[2] = thirdCorner.Value;
        if (normal != null) Normal = normal;
        else
        {
            var firstV0 = corners[1] - corners[0];
            var secondV0 = corners[2] - corners[0];
            Normal = Vector.Cross(firstV0, secondV0);
        }
    }
    public override HitInfo GetIntersection(Ray ray) // нормальные тесты, но корова плевет
    {
        const bool twoSided = true;
        double t;
        var firstV0 = corners[1] - corners[0];
        var secondV0 = corners[2] - corners[0];
        //var normal = Vector.Cross(firstV0, secondV0);
        var normal = Normal;
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
        var e1 = corners[1] - corners[0];
        var e2 = corners[2] - corners[0];
        var p = Vector.Cross(ray.Direction, e2);
        var det = Vector.Dot(e1, p);

        if (Math.Abs(det) < float.Epsilon)
        {
            return null;
        }

        var inv_det = 1.0 / det;
        var tt = ray.Origin - corners[0];
        var u = Vector.Dot(tt, p) * inv_det;
        if (u < 0.0 || u > 1.0) 
        {
            return null;
        }

        var q = Vector.Cross(tt, e1);
        var v = Vector.Dot(ray.Direction, q) * inv_det;
        if (v < 0.0 || u + v > 1.0) 
        {
            return null;
        }

        var t = Vector.Dot(e2, q) * inv_det;
        t = Math.Abs(t);
        if (t > float.Epsilon) 
        {
            return new HitInfo(ray.Origin + ray.Direction * (float)t, p.GetNormalized(), this);
        }

        return null;
    }*/
}