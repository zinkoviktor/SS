using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHW91
{
    class Triangle
    {
        private Point vertex1;
        private Point vertex2;
        private Point vertex3;
        

        public Triangle() { }
        public Triangle(Point vertex1, Point vertex2, Point vertex3)
        {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            this.vertex3 = vertex3;
        }
        public List<Point> Points() { return new List<Point>() {vertex1, vertex2, vertex3}; }
        
        
        public double Perimetr()
        {
            return Math.Round(vertex1.Distance(vertex2)+vertex2.Distance(vertex3)+vertex3.Distance(vertex1), 2);
        }

        public double Square()
        {
            double p = Perimetr()/2;
            return Math.Round(Math.Sqrt(p * (p - vertex1.Distance(vertex2)) * (p - vertex2.Distance(vertex3)) * (p - vertex3.Distance(vertex1))), 2);
        }
        public void Print()
        {
            Console.WriteLine("Triangle: {0}, {1}, {2}", vertex1, vertex2, vertex3);
            Console.WriteLine("Perimetr = {0}", Perimetr());
            Console.WriteLine("Square = {0}", Square());
        }
        public double MinDistences(Point p) {
            List <double> vertexDis = new List<double>() { vertex1.Distance(p), vertex2.Distance(p), vertex3.Distance(p) };
            return vertexDis.Min();
        }
    }
}
