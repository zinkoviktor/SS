using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_1
{
    class Bird : IFlyable
    {
        private string name;
        private bool canFly;

        public Bird(string name = "none", bool canFly = false)
        {
            this.name = name;
            this.canFly = canFly;
        }

        public void Fly()
        {
            if (canFly)
            {
                Console.WriteLine("The {0} flies!", name);
            }
            else
            {
                Console.WriteLine("The {0} can't fly!", name);
            }            
        }
    }
}
