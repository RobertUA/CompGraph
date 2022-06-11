using System;
using System.Collections.Generic;

public struct Ray
{
    public Vector StartPosition;
    public Vector Direction;
    public Ray(Vector startPosition, Vector direction)
    {
        StartPosition = startPosition;
        Direction = direction;
    }
}
public class HitInfo
{
    public Vector HitPosition;
    public Vector HitNormal;
    public HitInfo(Vector hitPosition, Vector hitNormal)
    {
        HitPosition = hitPosition;
        HitNormal = hitNormal;
    }
}

public class Tools
{
    public static List<HitInfo> RaycastCheckAll(Ray ray, List<Drawable> env)
    {
        List<HitInfo> hits = new List<HitInfo>();
        foreach (Drawable obj in env)
        {
            HitInfo hit = obj.GetInretsection(ray);
            if (hit != null) hits.Add(hit);
        }
        if (hits.Count > 0) return hits;
        else return null;
    }
}