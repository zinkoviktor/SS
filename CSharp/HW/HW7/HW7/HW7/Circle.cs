using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    class Circle : Shape
    {
        private double radius;        
        public Circle(string name, double radius):base(name)
        {
            this.radius = radius;
        }
        public override double Area()
        {
            return Math.PI * Math.Pow(radius, 2);
        }
        public override double Perimeter()
        {
            return 2 * Math.PI * radius;
        }
        override public void Print()
        {            
            Console.WriteLine("Cicle name = {0}, Area = {1}, Perimetr = {2}", Name, Area(), Perimeter());
        }
    }
}
