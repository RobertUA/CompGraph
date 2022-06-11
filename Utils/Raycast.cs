using System;
using System.Collections.Generic;

public class Raycast
{
    public Vector hitPosition;
    public Vector hitNormal;
    private static Raycast SoloCheck(Vector start, Vector direction, Drawable obj)
    {
        if(obj.GetType() == typeof(Dot))
        {

        }
        else if (obj.GetType() == typeof(Plane))
        {

        }
        else if(obj.GetType() == typeof(Circle))
        {

        }
        else if (obj.GetType() == typeof(Triangle))
        {

        }
        //
        return null;
    }
    public static Raycast RaycastCheck(Vector start, Vector direction, List<Drawable> env)
    {
        foreach (Drawable obj in env)
        {
            Raycast raycast = SoloCheck(start, direction, obj);
            if (raycast != null) return raycast;
        }
        return null;
    }
    public static List<Raycast> RaycastCheckAll(Vector start, Vector direction, List<Drawable> env)
    {
        List<Raycast> raycasts = new List<Raycast>();
        foreach (Drawable obj in env)
        {
            Raycast raycast = SoloCheck(start, direction, obj);
            if (raycast != null) raycasts.Add(raycast);
        }
        if (raycasts.Count > 0) return raycasts;
        else return null;
    }
}