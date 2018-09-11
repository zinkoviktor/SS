using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Teacher : Staff
    {
        private string subject;
        public Teacher(string name, int salary, string subject) : base(name, salary)
        {
            this.subject = subject;
        }
        override public void Print()
        {            
            Console.WriteLine("Teacher {0} teaches: {1}",
                            Name, subject);
        }        
    }
}
