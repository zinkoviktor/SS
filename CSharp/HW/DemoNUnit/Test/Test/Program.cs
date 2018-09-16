using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
           Calc calc = new Calc();
           Console.WriteLine(calc.Add(2, 2));
           Console.ReadKey();
        }        
    }    
}
