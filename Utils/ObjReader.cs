﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

class ObjReader
{
    public static List<Triangle> ReadFromFile(string path)
    {
        Vector minAxis = Vector.one * +double.MaxValue;
        Vector maxAxis = Vector.one * -double.MaxValue;
        List<Vector> v = new List<Vector>();
        List<Vector> vn = new List<Vector>();
        List<Triangle> triangles = new List<Triangle>();
        string[] lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            string[] parts = line.Split(' ');
            if(parts[0] == "v")
            {
                Vector vertex = new Vector(
                    GetDoubleFromStr(parts[1]),
                    GetDoubleFromStr(parts[2]),
                    GetDoubleFromStr(parts[3]));
                if (vertex.x > maxAxis.x) maxAxis.x = vertex.x;
                if (vertex.y > maxAxis.y) maxAxis.y = vertex.y;
                if (vertex.z > maxAxis.z) maxAxis.z = vertex.z;
                if (vertex.x < minAxis.x) minAxis.x = vertex.x;
                if (vertex.y < minAxis.y) minAxis.y = vertex.y;
                if (vertex.z < minAxis.z) minAxis.z = vertex.z;
                v.Add(vertex);
            }
            else if (parts[0] == "vn")
            {
                Vector normal = new Vector(
                    GetDoubleFromStr(parts[1]),
                    GetDoubleFromStr(parts[2]),
                    GetDoubleFromStr(parts[3]));
                vn.Add(normal);
            }
            else if (parts[0] == "f")
            {
                Vector[] vertexes = new Vector[3];
                Vector[] normals = new Vector[3];
                for (int i = 0; i < 3; i++)
                {
                    string[] subParts = parts[i+1].Split('/');
                    vertexes[i] = v[int.Parse(subParts[0])-1].Value;
                    normals[i] = vn[int.Parse(subParts[2])-1].Value;
                    //Console.WriteLine(vertexes[i].x + " " + vertexes[i].y + " " + vertexes[i].z);
                }
                Vector normal = (normals[0] + normals[1] + normals[2]);
                //Console.ReadKey();
                triangles.Add(new Triangle(vertexes[0], vertexes[1], vertexes[2], normal));
            }
            
        }
        string[] pathParts = path.Split('\\');
        Console.WriteLine(pathParts[pathParts.Length-1] + " | MinAxis: " + minAxis + " | MaxAxis: " + maxAxis);

        StreamWriter sw = new StreamWriter(Program.GetAbsolutePath("Output\\triangles.txt"));
        sw.WriteLine("==== FILE = " + pathParts[pathParts.Length - 1]);
        foreach (Drawable item in triangles)
        {
            if (item.GetType() == typeof(Triangle))
            {
                sw.WriteLine((item as Triangle).corners[0] + " " + (item as Triangle).corners[1] + " " + (item as Triangle).corners[2]);
            }
        }
        sw.WriteLine("====");
        sw.Close();
        return triangles;
    }
    static private double GetDoubleFromStr(string str)
    {
        int len = 100;
        if (len > str.Length) len = str.Length;
        string newStr = str.Substring(0, len);
        newStr = newStr.Replace('.', ',');
        double result = double.Parse(newStr);
        //result = Math.Round(result, 4);
        /*if (str.Contains('e'))
        {
            Console.WriteLine(str + " | " + newStr + " | " + result);
        }*/
        return result;
    }
}

