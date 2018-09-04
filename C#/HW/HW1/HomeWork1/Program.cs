using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            BTask();

            Console.Clear();
            CTask();

            Console.Clear();
            DTask();
        }
        
        //b task
        static void BTask()
        {
            int a;
            try
            {
                Console.Write("Square length  = ");
                a = Int32.Parse(Console.ReadLine());                
            }
            catch (FormatException)
            {
                Console.WriteLine("Erorr square length!");
                a = 0;               
            }
            catch (OverflowException)
            {
                Console.WriteLine("Erorr! Value was either too large or too small!");
                a = 0;                
            }

            Console.WriteLine("\nArea = {0}", a * a);
            Console.WriteLine("Perimeter  = {0}", 4 * a);

            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        //c task
        static void CTask()
        {
            string name;
            short age;

            
                Console.Write("What is your name? ");
                name = Console.ReadLine();
            try
            {
                Console.Write("How old are you? ");
                age = Int16.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Erorr age!");
                age = 0;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Erorr! Value was either too large or too small!");
                age = 0;
            }

            Console.WriteLine("\nHello {0}!", name);
            Console.WriteLine("You are {0}!", age);            

            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        //d task
        static void DTask()
        {
            const double PI = 3.14;
            double r;
            
            try
            {
                Console.Write("Give me a radius of a circle: ");
                r = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Erorr age!");
                r = 0;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Erorr! Value was either too large or too small!");
                r = 0;
            }

            Console.WriteLine("\nLength = {0}", 2 * PI * r);
            Console.WriteLine("Area = {0}", PI * r * r);
            Console.WriteLine("Volume = {0}", ((4 / 3) * PI * (r * r * r)));

            Console.Write("\nPress any key to exit . . . ");
            Console.ReadKey();
        }
    }
}
