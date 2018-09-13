using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHW91
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Triangle> triangles = new List<Triangle>();
            triangles.Add(new Triangle(new Point(1, 5), new Point(6, -4), new Point(-2, 1)));
            triangles.Add(new Triangle(new Point(2, 9), new Point(0, 0), new Point(-3, 5)));
            triangles.Add(new Triangle(new Point(0, 1), new Point(2, -3), new Point(-7, 2)));

            foreach (Triangle triangle in triangles)
            {
                triangle.Print();
            }

            //Triangle a = from tr in triangles where tr => triangles.X == 0 select tr;
            Point coord = new Point(0, 0);

            Triangle temp = triangles[0];
            for (int i = 1; i < triangles.Count; i++)
            {
                temp = TriangleCompareByPoint(temp, triangles[i], coord);
            }

            Console.WriteLine("-------");
            temp.Print();


            Console.ReadKey();
        }
        public static Triangle TriangleCompareByPoint(Triangle x, Triangle y, Point p)
        {

            if (x.MinDistences(p) < y.MinDistences(p))
            {
                return x;
            }
            return y;
        }
    }
}
    
