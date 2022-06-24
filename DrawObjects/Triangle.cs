using System;

public class Triangle : Drawable
{
    public Vector[] vertexes = new Vector[3];
    public Vector[] normals = new Vector[3];

    public Triangle(Vector v0, Vector v1, Vector v2, 
        Vector n0 = null, Vector n1 = null, Vector n2 = null)
    {
        vertexes[0] = v0.Value;
        vertexes[1] = v1.Value;
        vertexes[2] = v2.Value;
        normals[0] = n0;
        normals[1] = n1;
        normals[2] = n2;
    }
    /*public override HitInfo GetIntersection(Ray ray) // геом
    {
        const bool twoSided = true;
        double t;
        var firstV0 = vertexes[1] - vertexes[0];
        var secondV0 = vertexes[2] - vertexes[0];
        var normal = Vector.Cross(firstV0, secondV0);
        //var normal = Normal;
        double scalarProduct = Vector.Dot(normal, ray.Direction);

        if (-scalarProduct < double.Epsilon)
        {
            if (twoSided)
            {
                if (scalarProduct < double.Epsilon)
                    return null;
            }
            else
                return null;
        }
        double d = -Vector.Dot(normal, vertexes[0]);
        t = -(Vector.Dot(normal, ray.Origin) + d) / scalarProduct;
        if (t < 0)
        {
            return null;
        }

        var P = ray.Origin + ray.Direction * t;

        var edge0 = vertexes[1] - vertexes[0];
        var vp0 = P - vertexes[0];

        Vector C = Vector.Cross(edge0, vp0);
        if (Vector.Dot(normal, C) < 0)
        {
            return null;
        }

        var edge1 = vertexes[2] - vertexes[1];
        var vp1 = P - vertexes[1];
        C = Vector.Cross(edge1, vp1);
        if (Vector.Dot(normal, C) < 0)
        {
            return null;
        }

        var edge2 = vertexes[0] - vertexes[2];
        var vp2 = P - vertexes[2];
        C = Vector.Cross(edge2, vp2);
        if (Vector.Dot(normal, C) < 0)
        {
            return null;
        }
        return new HitInfo(P, normal, this);
    }*/

    public override HitInfo GetIntersection(Ray ray) //очертание коровы, но тест треугольника - не такой
    {
        Vector edge1 = vertexes[1] - vertexes[0];
        Vector edge2 = vertexes[2] - vertexes[0];

        Vector pvec = Vector.Cross(ray.Direction, edge2);

        double det = Vector.Dot(edge1, pvec);

        if (det < double.Epsilon)
        {
            return null;
        }

        Vector tvec = ray.Origin - vertexes[0];

        double u = Vector.Dot(tvec, pvec);

        if (u < 0.0 || u > det)
        {
            return null;
        }

        Vector qvec = Vector.Cross(tvec, edge1);
        double v = Vector.Dot(ray.Direction, qvec);
        if (v < 0.0 || u + v > det)
        {
            return null;
        }

        double t = Vector.Dot(edge2, qvec);
        double inv_det = 1.0 / det;
        t *= inv_det;
        u *= inv_det;
        v *= inv_det;

        if (t < 0) return null;
        Vector pos = ray.Origin + ray.Direction * t;
        Vector normal;
        if (normals[0] == null)
        {
            normal = Vector.Cross(vertexes[1] - pos, vertexes[2] - pos);
        }
        else
        {
            normal = normals[1] * u + normals[2] * v + normals[0] * (1 - v - u);
        }
        return new HitInfo(pos, normal.GetNormalized(), this);
    }
}