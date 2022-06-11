using System;

public class Drawable
{
    public static int count = 0;
    protected int Id;
    public Drawable()
    {
        Id = count++;
    }
    public virtual void Draw()
    {
        Console.WriteLine("Drawed obj " + Id);
    }
    public int GetID()
    {
        return Id;
    }
}