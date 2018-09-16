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
            try
            {
                triangles.Add(new Triangle(new Point(-2, 2), new Point(3, 3), new Point(5, -2)));
                triangles.Add(new Triangle(new Point(2, 9), new Point(0, 0), new Point(-3, 5)));
                triangles.Add(new Triangle(new Point(0, 1), new Point(2, -3), new Point(-7, 2)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw new Exception();
                Console.Write("\nPress any key to exit . . . ");
                Console.ReadKey();
                return;
            }
            
            foreach (Triangle triangle in triangles)
            {
                triangle.Print();
            }
                        
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

            if (x.DistenceTo(p) < y.DistenceTo(p))
            {
                return x;
            }
            return y;
        }
    }
}
    
