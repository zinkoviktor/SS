using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHW10._2
{
    class Parent:Program
    {
        public Parent() { }
        public void OnMarkChange(int mark)
        {
            Console.WriteLine(mark);
        }
    }
}
