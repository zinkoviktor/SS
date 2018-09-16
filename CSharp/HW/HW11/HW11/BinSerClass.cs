using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW11
{
    [Serializable]
    public class Triangle
    {
            private Point vertex1;
            private Point vertex2;
            private Point vertex3;

            private double sideA;
            private double sideB;
            private double sideC;

            public Triangle()
            {
                vertex1 = new Point();
                vertex2 = new Point();
                vertex3 = new Point();
            }

            public Triangle(Point vertex1, Point vertex2, Point vertex3)
            {
                this.vertex1 = vertex1;
                this.vertex2 = vertex2;
                this.vertex3 = vertex3;
                if (Square() == 0)
                {
                    throw new Exception("Error Point!");
                }
            }

            public List<Point> Points()
            {
                return new List<Point>() { vertex1, vertex2, vertex3 };
            }

            private void CalcDistance()
            {
                sideA = vertex1.Distance(vertex2);
                sideB = vertex2.Distance(vertex3);
                sideC = vertex3.Distance(vertex1);
            }

            public double Perimetr()
            {
                CalcDistance();
                return Math.Round(sideA + sideB + sideC, 2);
            }
            public double Square()
            {
                double p = Perimetr() / 2;
                return Math.Round(Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC)), 2);
            }

            public bool Print()
            {
                Console.WriteLine("Triangle: {0}, {1}, {2}", vertex1, vertex2, vertex3);
                Console.WriteLine("Perimetr = {0}", Perimetr());
                Console.WriteLine("Square = {0}", Square());
                return true;
            }

            public double DistenceTo(Point p)
            {
                List<double> vertexDis = new List<double>() { vertex1.Distance(p), vertex2.Distance(p), vertex3.Distance(p) };
                return vertexDis.Min();
            }
    }
    [Serializable]
    public struct Point
    {
        public int X, Y;

        public Point(int x, int y) { X = x; Y = y; }
        public double Distance(Point p)
        {
            return Math.Round(Math.Sqrt(((X - p.X) * (X - p.X)) + ((Y - p.Y) * (Y - p.Y))), 2);
        }
        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }
    }
}
