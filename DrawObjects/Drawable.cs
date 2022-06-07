using System;

public abstract class Drawable
{
    public static int count = 0;
    protected int Id;
    public Drawable()
    {
        Id = count++;
    }

    public abstract Vector GetIntersection(Vector start,Vector direction);
    public abstract void Draw();
    public int GetID()
    {
        return Id;
    }
    
}