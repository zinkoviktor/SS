using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Staff : Person
    {
        private int salary;
        public Staff(string name, int salary) : base(name)
        { this.salary = salary; }

        override public void Print()
        {
            
            Console.WriteLine("Person {0} has salary: ${1}",
                            Name, this.salary);
        }

    }
}
