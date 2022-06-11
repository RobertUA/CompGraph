using System;
using System.Collections.Generic;

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