using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_1
{
    class Plane : IFlyable
    {
        private string mark;
        private int highFly;

        public Plane (string mark = "none", int highFly = 0)
        {
            this.mark = mark;
            this.highFly = highFly;
        }

        public void Fly()
        {
            Console.WriteLine("{0} high = {1}", mark, highFly);           
        }
    }
}
