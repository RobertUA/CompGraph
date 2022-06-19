using System;
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
        Vector minAxis = Vector.one * +float.MaxValue;
        Vector maxAxis = Vector.one * -float.MaxValue;
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
                    float.Parse(parts[1].Replace('.',',')),
                    float.Parse(parts[2].Replace('.', ',')),
                    float.Parse(parts[3].Replace('.', ',')));
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
                    float.Parse(parts[1].Replace('.', ',')),
                    float.Parse(parts[2].Replace('.', ',')),
                    float.Parse(parts[3].Replace('.', ',')));
                vn.Add(normal);
            }
            else if (parts[0] == "f")
            {
                Vector[] vertexes = new Vector[3];
                Vector[] normals = new Vector[3];
                for (int i = 0; i < 3; i++)
                {
                    string[] subParts = parts[i+1].Split('/');
                    vertexes[i] = v[int.Parse(subParts[0])-1];
                    normals[i] = vn[int.Parse(subParts[2])-1];
                    //Console.WriteLine(vertexes[i]);
                }
                //Console.ReadKey();
                triangles.Add(new Triangle(vertexes[0], vertexes[1], vertexes[2]));
            }
            
        }
        string[] pathParts = path.Split('\\');
        
        Console.WriteLine(pathParts[pathParts.Length-1] + " | MinAxis: " + minAxis + " | MaxAxis: " + maxAxis);

        return triangles;
    }
}
