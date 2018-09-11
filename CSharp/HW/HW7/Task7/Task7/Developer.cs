using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Developer : Staff
    {
        private string level;

        public Developer(string name, int salary, string level) : base(name, salary)
        {
            this.level = level;
        }

        override public void Print()
        {
            Console.WriteLine("Developer {0} has {1} level:", Name, level);
        }        
    }
}
