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
            RealNumberDelegate del1 = new RealNumberDelegate(FuncGraph);
            RealNumberDelegate del2 = new RealNumberDelegate(Sin);
            Tabulation(3, 5, 3, del1);
            Tabulation(4, 5, 2, del2);
            Console.ReadKey();
        }
        public delegate double RealNumberDelegate(double d);
        
        public static double FuncGraph(double x)
        {
            return 2 * x / 2 + 3 * x * Math.Cos(x / 3);
        }
        
        public static double Sin(double x)
        {
            return Math.Sin(x);
        }
        
        public static void Tabulation(int a, int b, int n, RealNumberDelegate del)
        {
            int k = 0;
            double x = (a + k * (b - a) / n);
            for (; k < n; k++)
            {
                Console.WriteLine(del(x));
            }
            
        }
        
    }
}
