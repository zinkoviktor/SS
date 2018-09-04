using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            FirstTask();

            Console.Clear();
            SecondTask();

            Console.Clear();
            ThirdTask();

            Console.Clear();
            FourthTask();

        }

        //First task
        static void FirstTask()
        {
            int a, b;

            try
            {
                Console.Write("a = ");
                a = Int32.Parse(Console.ReadLine());
                Console.Write("b = ");
                b = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Erorr in value!");
                a = 0;
                b = 0;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Erorr! Value was either too large or too small!");
                a = 0;
                b = 0;
            }
            

            Console.WriteLine("\na+b = {0}", a + b);
            Console.WriteLine("a-b = {0}", a - b);
            Console.WriteLine("a*b = {0}", a * b);

            if ( a != 0 && b != 0 )
            {
                Console.WriteLine("a/b = {0}", a / b);
            }

            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        //Second task
        static void SecondTask()
        {
            string answer;
            Console.Write("How are you?:");
            answer = Console.ReadLine();
            Console.WriteLine("\nYou are {0}", answer);

            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        //Third task
        static void ThirdTask()
        {
            char firstChar, secondChar, thirdChar;
            try
            {
                Console.Write("Give me a first char: ");
                firstChar = char.Parse(Console.ReadLine());
                Console.Write("Give me a second char: ");
                secondChar = char.Parse(Console.ReadLine());
                Console.Write("Give me 3 char: ");
                thirdChar = char.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect char!");
                firstChar = ' ';
                secondChar = ' ';
                thirdChar = ' ';
            }

            Console.WriteLine("You enter ({0}), ({1}), ({2})", firstChar,secondChar,thirdChar);

            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        //Fourth task
        static void FourthTask()
        {
            int [] numbers = { 0, 0 };
            bool checkFirstNumber, checkSecondNumber;
            Console.Write("Give me a first number: ");
            checkFirstNumber = Int32.TryParse(Console.ReadLine(), out numbers[0]);
            Console.Write("Give me a second number: ");
            checkSecondNumber = Int32.TryParse(Console.ReadLine(), out numbers[1]);

            Console.WriteLine("\nFirst number: {0}\nSecond number: {1}", checkFirstNumber, checkSecondNumber);

            Console.Write("\nPress any key to exit . . . ");
            Console.ReadKey();
        }
    }
       
}
