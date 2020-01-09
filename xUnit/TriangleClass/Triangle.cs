using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleProj
{
    public static class Triangle
    {
        public static bool IsTriangle(double a, double b, double c) => 
            (a > 0 && b > 0 && c > 0 && (a + b > c) && (a + c > b) && (b + c > a));
    }
}
