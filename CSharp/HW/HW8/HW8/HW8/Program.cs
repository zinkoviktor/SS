using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace HW8
{
    class Program
    {
        static void Main(string[] args)
        {
            #region HW8 A
            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Circle("Circle1", 5));
            shapes.Add(new Circle("Circle2", 7));
            shapes.Add(new Circle("Circle3", 9));
            shapes.Add(new Square("Square1", 3));
            shapes.Add(new Square("Square2", 5));
            shapes.Add(new Square("Square3", 1));

            var shapesRange = from shape in shapes where shape.Area() > 10 && shape.Area() < 100 select shape;
            Print(shapesRange);
            WriteFile(shapesRange, "shapesRange", false);

            var shapesContainName = from shape in shapes where shape.Name.Contains('a') select shape;
            Print(shapesContainName);
            WriteFile(shapesContainName, "shapesContainName", true);

            shapes.RemoveAll((sh=>sh.Perimeter()<5));
            Print(shapes);
            #endregion
            #region HW8 B
            string[] lines = File.ReadAllLines("program.cs");
            using (StreamReader sr = new StreamReader("program.cs"))
            {
                int i=0;
                while (sr.Peek() > -1)
                {
                    lines[i] = sr.ReadLine();
                    i++;
                }
            }
            int count = 1;
            foreach(string line in lines)
            {
                Console.WriteLine("{0} line = {1} symbols", count, line.Count());
                count++;
            }

            int linesMax = lines.Max(l => l.Count());
            string longestLine  = lines.First(l => l.Count() == linesMax);
            Console.WriteLine("Longest line = {0}", longestLine);

            int linesMin = lines.Min(l => l.Count());
            int shortestLine = Array.IndexOf(lines, lines.First(l => l.Count() == linesMin));
            Console.WriteLine("position of shortest line = {0}", shortestLine);
            
            foreach(string l in lines)
            {
                if (l.Contains("var"))
                {
                    Console.WriteLine(l);
                }
            }
            #endregion
            Console.ReadKey();

        }
        static void Print(IEnumerable<Shape> print)
        {
            Console.WriteLine("--------");
            foreach (Shape value in print)
            {
                Console.WriteLine(value.Name);
            }
        }
        static void WriteFile(IEnumerable<Shape> print, string name, bool key)
        {
            using (StreamWriter sw = new StreamWriter("File.txt", key))
            {
                
                sw.WriteLine(name);
                foreach (Shape value in print)
                {
                    sw.WriteLine(value.Name + " Perimetr = " + value.Perimeter() + " Area =" + value.Area());
                }
            }
        }
    }
}
