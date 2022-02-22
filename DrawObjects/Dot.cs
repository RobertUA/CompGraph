using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dot
{
    private static int count=0;
    public int Id;
    public Dot()
    {
        Id = count++;
    }
}
