using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8
{
    class Square : Shape
    {
        private double side;        
        public Square(string name, double side) : base(name)
        {
            this.side = side;
        }
        public override double Area()
        {
            return Math.Pow(side, 2);
        }
        public override double Perimeter()
        {
            return 4 * side;
        }
        override public void Print()
        {
            Console.WriteLine("Shape name = {0}, Area = {1}, Perimetr = {2}", Name, Area(), Perimeter());
        }
    }
}
