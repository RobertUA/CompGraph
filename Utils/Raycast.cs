using System;
using System.Collections.Generic;

public class Raycast
{
    public Vector hitPosition;
    // public Vector hitNormal;
    private static Raycast CheckIntersection(Vector start, Vector direction, Drawable obj)
    {
        var raycast = new Raycast();
        raycast.hitPosition = obj.GetIntersection(start, direction);
        return raycast;
    }
    public static Raycast RaycastCheck(Vector start, Vector direction, List<Drawable> env)
    {
        foreach (Drawable obj in env)
        {
            Raycast raycast = CheckIntersection(start, direction, obj);
            if (raycast != null) return raycast;
        }
        return null;
    }
    public static List<Raycast> RaycastCheckAll(Vector start, Vector direction, List<Drawable> env)
    {
        List<Raycast> raycasts = new List<Raycast>();
        foreach (Drawable obj in env)
        {
            Raycast raycast = CheckIntersection(start, direction, obj);
            if (raycast != null) raycasts.Add(raycast);
        }
        if (raycasts.Count > 0) return raycasts;
        else return null;
    }
}