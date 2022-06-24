using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

struct Node 
{
    public const double Dist = 0.5;
    public Vector Position;
    public List<Triangle> Drawables;
    public Vector[] bounds;
    public Node(Vector position)
    {
        Position = new Vector(position.x,
            position.y,
            position.z);
        Drawables = new List<Triangle>();
        bounds = new Vector[2] 
        { 
            new Vector(Position.x - Dist, Position.y - Dist, Position.z - Dist),
            new Vector(Position.x + Dist, Position.y + Dist, Position.z + Dist)
        };
    }
    public bool IsIn(Vector point)
    {
        if (bounds[0].x > point.x) return false;
        if (bounds[0].y > point.y) return false;
        if (bounds[0].z > point.z) return false;
        if (bounds[1].x < point.x) return false;
        if (bounds[1].y < point.y) return false;
        if (bounds[1].z < point.z) return false;
        return true;

    }
    public bool IsIntersect(Ray ray)
    {
        int[] sign = new int[3];
        double tmin, tmax, tymin, tymax, tzmin, tzmax;
        Vector invdir = 1 / ray.Direction;
        sign[0] = (invdir.x < 0) ? 1 : 0;
        sign[1] = (invdir.y < 0) ? 1 : 0;
        sign[2] = (invdir.z < 0) ? 1 : 0;

        tmin = (bounds[sign[0]].x - ray.Origin.x) * invdir.x;
        tmax = (bounds[1 - sign[0]].x - ray.Origin.x) * invdir.x;
        tymin = (bounds[sign[1]].y - ray.Origin.y) * invdir.y;
        tymax = (bounds[1 - sign[1]].y - ray.Origin.y) * invdir.y;

        if ((tmin > tymax) || (tymin > tmax))
            return false;

        if (tymin > tmin)
            tmin = tymin;
        if (tymax < tmax)
            tmax = tymax;

        tzmin = (bounds[sign[2]].z - ray.Origin.z) * invdir.z;
        tzmax = (bounds[1 - sign[2]].z - ray.Origin.z) * invdir.z;

        if ((tmin > tzmax) || (tzmin > tmax))
            return false;

        if (tzmin > tmin)
            tmin = tzmin;
        if (tzmax < tmax)
            tmax = tzmax;

        return true;
    }
}

class Booster
{
    public List<Node> Nodes = new List<Node>();
    public void AddTriangle(Triangle triangle)
    {
        foreach (var corner in triangle.vertexes)
        {
            bool isAdded = false;
            foreach (var node in Nodes)
            {
                if(node.IsIn(corner))
                {
                    node.Drawables.Add(triangle);
                    isAdded = true;
                }
            }
            if(!isAdded)
            {
                Node node = new Node(corner);
                node.Drawables.Add(triangle);
                Nodes.Add(node);
            }
        }
    }
    public void AddRange(List<Triangle> triangles)
    {
        foreach (var triangle in triangles)
        {
            AddTriangle(triangle);
        }
    }
}
