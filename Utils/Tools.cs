using System;
using System.Collections.Generic;

public class Tools
{
    public static List<HitInfo> RaycastAll(Ray ray)
    {
        List<HitInfo> hits = new List<HitInfo>();
        foreach (Drawable obj in Scene.Instance.Drawables)
        {
            HitInfo hit = obj.GetIntersection(ray);
            if (hit != null) hits.Add(hit);
        }
        foreach (var node in Scene.Instance.booster.Nodes)
        {
            if (node.IsIntersect(ray))
            {
                foreach (Drawable obj in node.Drawables)
                {
                    HitInfo hit = obj.GetIntersection(ray);
                    if (hit != null) hits.Add(hit);
                }
            }
        }
        if (hits.Count > 0) return hits;
        else return null;
    }
    public static HitInfo Raycast(Ray ray)
    {
        int minIndex = -1;
        double minDist = double.MaxValue;
        List<HitInfo> hits = RaycastAll(ray);
        if (hits == null) return null;
        for (int i = 0; i < hits.Count; i++)
        {
            double dist = Vector.Distance(hits[i].Position, ray.Origin);
            if (minDist > dist)
            {
                minDist = dist;
                minIndex = i;
            }
        }
        if (minIndex == -1) return null;
        return hits[minIndex];
    }
}