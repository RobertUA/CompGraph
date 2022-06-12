using System;

public class Vector
{
    public float x, y, z;
    public Vector(float x, float y, float z = 0)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    //методы
    public Vector Rotate(float angle, Vector axis)
    {
        angle /= 180f / (float)Math.PI; //to radians
        Vector newVector = this * (float)Math.Cos(angle) + (Cross(axis, this)) * (float)Math.Sin(angle) + axis * (Vector.Dot(axis, this) * (1 - (float)Math.Cos(angle)));
        return newVector;
    }
    public float GetMagnitude()
    {
        return (float) Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
    }
    public Vector GetNormalized()
    {
        return this / GetMagnitude();
    }
    public static Vector Cross(Vector a, Vector b)
    {
        return new Vector
        (
            a.y * b.z - a.z * b.y,
            a.x * b.z - a.z * b.x, 
            a.x * b.y - a.y * b.x
        );
    }
    public static float Dot(Vector a, Vector b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z;
    }
    public float GetProjection(Vector b)
    {
        return Dot(this, b) / b.GetMagnitude();
    }
    //Equals & GetHashCode
    public override bool Equals(object other)
    {
        if (other == null) return false;
        Vector b = other as Vector;
        return x == b.x && y == b.y && z == b.z;
    }
    public override int GetHashCode()
    {
        //return int.Parse(x.ToString() + y.ToString() + z.ToString());
        return (x, y, z).GetHashCode();
    }
    //переопределенные операторы
    public static bool operator ==(Vector a, Vector b)     // a==b
    {
        if (ReferenceEquals(a, b)) return true;
        if (ReferenceEquals(a, null)) return false;
        return a.Equals(b);
    }
    public static bool operator !=(Vector a, Vector b)     // a!=b
    {
        return !a.Equals(b);
    }
    public static Vector operator -(Vector a)               // -a
        => new Vector(-a.x, -a.y, -a.z);
    public static Vector operator +(Vector a, Vector b)     // a+b
        => new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
    public static Vector operator -(Vector a, Vector b)     // a-b
        => new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
    public static Vector operator *(Vector a, float f)      // a*float
       => new Vector(a.x * f, a.y * f, a.z * f);
    public static Vector operator *(float f, Vector a)      // float*a
       => a*f;
    public static Vector operator /(Vector a, float f)      // a/float
       => new Vector(a.x / f, a.y / f, a.z / f);
    /*public static float operator *(Vector a, Vector b)
       => GetScalarProduct(a, b);*/
    public override string ToString()
    {
        return "(" + Math.Round(x,1) + "|" + (float)Math.Round(y, 1) + "|" + (float)Math.Round(z, 1) + ")";
    }
    //стандартные наборы
    public static Vector zero = new Vector(0, 0, 0);
    public static Vector one = new Vector(1, 1, 1);
    public static Vector right = new Vector(1, 0, 0);
    public static Vector up = new Vector(0, 1, 0);
    public static Vector forward = new Vector(0, 0, 1);
    //статичные методы
    public static float Distance(Vector startVector, Vector endVector)
    {
        Vector vector = endVector - startVector;
        return vector.GetMagnitude();
    }
    public static Vector Lerp(Vector startVector, Vector endVector, float t)
    {
        Vector addVector = (endVector-startVector)*t;
        return startVector+addVector;
    }


}