using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add Shapes to list
            List<Shape> shapes = new List<Shape>();
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    shapes.Add(EnterShape());
                    Console.Write("\r\n");
                }            
                catch (Exception e)
                {
                    Console.WriteLine("Error! {0}\n", e.Message);
                    i--;
                }
            }

            //Print all Shapes
            Console.WriteLine("\nAll Shapes");
            foreach (Shape shape in shapes)
            {
                shape.Print();
            }

            //find largest perimeter
            //Copy to Dictionary
            Dictionary<string, double> shapesNamePerim = new Dictionary<string, double>();
            int addToName = 1;
            foreach (Shape shape in shapes)
            {
                try
                {
                    shapesNamePerim.Add(shape.Name, shape.Perimeter());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error! {0}\n", e.Message);
                    shapesNamePerim.Add(shape.Name + "(" + addToName + ")", shape.Perimeter());
                    addToName++;
                }
                
            }
            //Find max perimeter
            string largestPerimeterName ="";
            double largestPerimeter =0;
            bool first = true;
            foreach(KeyValuePair<string,double> shape in shapesNamePerim)
            {
                if (first)
                {
                    largestPerimeterName = shape.Key;
                    largestPerimeter = shape.Value;
                    first = false;
                }
                else
                {
                    if(shape.Value > largestPerimeter)
                    {
                        largestPerimeterName = shape.Key;
                        largestPerimeter = shape.Value;
                    }
                }
            }
            Console.WriteLine("\nShape named {0} has largest perimeter", largestPerimeterName);

            //Sorting by Area
            IComparer<Shape> comparer = new Comparer();
            shapes.Sort(comparer);

            Console.WriteLine("\nShapes are sorted by area");            
            foreach (Shape shape in shapes)
            {
                shape.Print();
            }

            Console.ReadKey();

        }
        static Shape EnterShape()
        {
            Console.WriteLine("Enter type of shape (Circle or Square)");

            string type = Console.ReadLine();
            string name;
            double value=0;
            if (type.ToLower() == "circle" || type == "c")
            {
                Console.Write("Enter  name:");
                name = Console.ReadLine();
                Console.Write("Enter  radius:");
                value = double.Parse(Console.ReadLine());

                return new Circle(name, value);
            }
            else if(type.ToLower() == "square" || type == "s")
            {
                Console.Write("Enter  name:");
                name = Console.ReadLine();
                Console.Write("Enter  side:");
                value = double.Parse(Console.ReadLine());
                
                return new Square(name, value);
            }
            else
            {
                throw new Exception("Incorrect type of shape");
            }

        }
        
    }

}
