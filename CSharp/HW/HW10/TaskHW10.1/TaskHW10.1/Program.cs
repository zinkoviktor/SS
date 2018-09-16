using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHW10._1
{
    class Program
    {
        static void Main(string[] args)
        {
            RealNumberDelegate del1 = new RealNumberDelegate(RealNumber);
            RealNumberDelegate del2 = new RealNumberDelegate(Sin);
            Tabulation(del1.Invoke(4.4000000), 3, 5, 2);
            Tabulation(del2(4 / 5), 4, 5, 6);
            Console.ReadKey();
        }
        public delegate double RealNumberDelegate(double d);
        
        public static double RealNumber(double d)
        {
            return d;
        }
        
        public static double Sin(double x)
        {
            return 2 * x / 2 + 3 * x * Math.Cos(x / 3);
        }
        
        public static void Tabulation(double k, double a, double b, double n)
        {
            Console.WriteLine((a + k * (b - a) / n));
        }
        
    }
}
