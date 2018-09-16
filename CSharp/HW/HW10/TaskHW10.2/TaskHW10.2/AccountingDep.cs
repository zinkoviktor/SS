using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHW10._2
{
    class AccountingDep
    {
        public AccountingDep() { }
        public void Stipend(int mark)
        {
            if (mark >= 4)
            {
                Console.WriteLine("Student will have stipend!");
            }
            else
            {
                Console.WriteLine("Student will not have stipend!");
            }
        }
    }
}
