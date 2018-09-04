using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task22
{
    class Program
    {
        enum TestCaseStatus { Pass, Fail, Blocked, WP, Unexecuted };

        struct Rgb 
        {
            public byte red;
            public byte green;
            public byte blue;
        }

        static void Main(string[] args)
        {
            Console.Clear();
            FirstSubTask();

            Console.Clear();
            SecondSubTask();
        }
        static void FirstSubTask()
        {
            TestCaseStatus test1Status = TestCaseStatus.Pass;

            Console.WriteLine(test1Status);

            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        static void SecondSubTask()
        {
            Rgb white;
            white.red = 255;
            white.green = 255;
            white.blue = 255;

            Rgb black;
            black.red = 0;
            black.green = 0;
            black.blue = 0;

            Console.WriteLine("White = RGB({0},{1},{2})", white.red, white.green, white.blue);
            Console.WriteLine("Black = RGB({0},{1},{2})", black.red, black.green, black.blue);

            Console.Write("\nPress any key to exit . . . ");
            Console.ReadKey();
        }
    }   
}
