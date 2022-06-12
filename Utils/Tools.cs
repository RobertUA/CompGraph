using System;
using System.Collections.Generic;

public class Tools
{
    public static List<HitInfo> RaycastAll(Ray ray)
    {
        List<HitInfo> hits = new List<HitInfo>();
        foreach (Drawable obj in Scene.Instance.Drawables)
        {
            HitInfo hit = obj.GetInretsection(ray);
            if (hit != null) hits.Add(hit);
        }
        if (hits.Count > 0) return hits;
        else return null;
    }
    public static HitInfo Raycast(Ray ray)
    {
        int minIndex = -1;
        float minDist = float.MaxValue;
        List<HitInfo> hits = RaycastAll(ray);
        if (hits == null) return null;
        for (int i = 0; i < hits.Count; i++)
        {
            float dist = Vector.Distance(hits[i].HitPosition, ray.StartPosition);
            if (minDist > dist)
            {
                minDist = dist;
                minIndex = i;
            }
        }
        return hits[minIndex];
    }
}