using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHW91
{
    public struct Point
    {
        public int X, Y;
        public Point(int x, int y) { X = x; Y = y; }
        public double Distance(Point p)
        {
            return Math.Sqrt(Math.Pow(p.X-this.X, 2)+Math.Pow(p.Y-this.Y, 2));
        }
        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }       
    }
}
