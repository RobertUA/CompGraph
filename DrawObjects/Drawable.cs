﻿
public abstract class Drawable
{
    public static int count = 0;
    protected int Id;
    public Drawable()
    {
        Id = count++;
    }
    public abstract HitInfo GetInretsection(Ray ray);
    public int GetID()
    {
        return Id;
    }
}