using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Matrix
{
    public int RowsCount;
    public int ColumnsCount;
    public double[,] Values;
    public Matrix(int rows, int columns, double[,] values = null)
    {
        RowsCount = rows;
        ColumnsCount = columns;
        if (values != null) Values = values;
        else Values = new double[rows, columns];
    }
    public static Matrix operator *(Matrix a, Matrix b)      // a*b
    {
        if (a.ColumnsCount != b.RowsCount)
        {
            throw new Exception("Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
        }

        var result = new Matrix(a.RowsCount, b.ColumnsCount);

        for (var i = 0; i < a.RowsCount; i++)
        {
            for (var j = 0; j < b.ColumnsCount; j++)
            {
                result.Values[i,j] = 0;

                for (var k = 0; k < a.ColumnsCount; k++)
                {
                    result.Values[i,j] += a.Values[i, k] * b.Values[k, j];
                }
            }
        }
        return result;
    }
    public static Matrix RotX(double angle)
    {
        double rad = angle * Math.PI / 180;
        var sin = Math.Sin(rad);
        var cos = Math.Cos(rad);

        return new Matrix(4, 4, new double[,] {
            { 1.0, 0.0, 0.0, 0.0 },
            { 0.0, cos, -sin, 0.0 },
            { 0.0, sin, cos, 0.0 },
            { 0.0, 0.0, 0.0, 1.0 }
        });
    }
    public static Matrix RotY(double angle)
    {
        double rad = angle * Math.PI / 180;
        var sin = Math.Sin(rad);
        var cos = Math.Cos(rad);

        return new Matrix(4, 4, new double[,] {
            { cos, 0.0, sin, 0.0 },
            { 0.0, 1.0, 0.0, 0.0 },
            { -sin, 0.0, cos, 0.0 },
            { 0.0, 0.0, 0.0, 1.0 }
        });
    }
    public static Matrix RotZ(double angle)
    {
        double rad = angle * Math.PI / 180;
        var sin = Math.Sin(rad);
        var cos = Math.Cos(rad);

        return new Matrix(4, 4, new double[,] {
            { cos, -sin, 0.0, 0.0 },
            { sin, cos, 0.0, 0.0 },
            { 0.0, 0.0, 1.0, 0.0 },
            { 0.0, 0.0, 0.0, 1.0 }
        });
    }
    public static Matrix Scale(Vector scale)
    {
        return new Matrix(4, 4, new double[,] {
            { scale.x, 0.0, 0.0, 0.0 },
            { 0.0, scale.y, 0.0, 0.0 },
            { 0.0, 0.0, scale.z, 0.0 },
            { 0.0, 0.0, 0.0, 1.0 }
        });
    }
    public static Matrix Move(Vector move)
    {
        return new Matrix(4, 4, new double[,]
        {
            { 1.0, 0.0, 0.0, move.x },
            { 0.0, 1.0, 0.0, move.y },
            { 0.0, 0.0, 1.0, move.z },
            { 0.0, 0.0, 0.0, 1.0 }
        });
    }
}