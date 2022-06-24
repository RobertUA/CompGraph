using System;

public class Vector
{
    public double x, y, z;
    public Vector(double x, double y, double z = 0)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    //методы
    public Vector Rotate(double angle, Vector axis)
    {
        angle = angle * (double)Math.PI / 180f; //to radians
        Vector newVector = this * Math.Cos(angle) + (Cross(axis, this)) * Math.Sin(angle) + axis * (Dot(axis, this) * (1 - Math.Cos(angle)));
        return newVector.GetNormalized() * GetMagnitude();
    }
    public double GetMagnitude()
    {
        return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
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
    public static double Dot(Vector a, Vector b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z;
    }
    public double GetProjection(Vector b)
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
        return !(a==b);
    }
    public static Vector operator -(Vector a)               // -a
        => new Vector(-a.x, -a.y, -a.z);
    public static Vector operator +(Vector a, Vector b)     // a+b
        => new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
    public static Vector operator -(Vector a, Vector b)     // a-b
        => new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
    public static Vector operator *(Vector a, double f)      // a*double
       => new Vector(a.x * f, a.y * f, a.z * f);
    public static Vector operator *(double f, Vector a)      // double*a
       => a*f;
    public static Vector operator /(Vector a, double f)      // a/double
       => new Vector(a.x / f, a.y / f, a.z / f);
    /*public static double operator *(Vector a, Vector b)
       => GetScalarProduct(a, b);*/
    /*public override string ToString()
    {
        return "(" + Math.Round(x, 2) + "|" + Math.Round(y, 2) + "|" + Math.Round(z, 2) + ")";
    }*/
    public override string ToString()
    {
        return "(" + x + "|" + y + "|" + z + ")";
    }
    //стандартные наборы
    public static Vector zero = new Vector(0, 0, 0);
    public static Vector one = new Vector(1, 1, 1);
    public static Vector right = new Vector(1, 0, 0);
    public static Vector up = new Vector(0, 1, 0);
    public static Vector forward = new Vector(0, 0, 1);
    //статичные методы
    public static double Distance(Vector startVector, Vector endVector)
    {
        Vector vector = endVector - startVector;
        return vector.GetMagnitude();
    }
    public static Vector Lerp(Vector startVector, Vector endVector, double t)
    {
        Vector addVector = (endVector-startVector)*t;
        return startVector+addVector;
    }
    public Vector Value
    {
        get
        {
            return new Vector(x, y, z);
        }
    }

}