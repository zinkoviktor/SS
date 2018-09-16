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
            return Math.Round(Math.Sqrt(((X - p.X) * (X - p.X)) + ((Y - p.Y) * (Y - p.Y))),2);
        }
        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }       
    }
}
