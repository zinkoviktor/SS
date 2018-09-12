using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8
{
    abstract class Shape
    {
        private string name;
        public string Name { get { return name; } }
        public Shape(string name)
        {
            this.name = name;
        }
        abstract public double Area();
        abstract public double Perimeter();
        virtual public void Print()
        {
            Console.WriteLine("Name = {0}", name);
        }
    }
}
