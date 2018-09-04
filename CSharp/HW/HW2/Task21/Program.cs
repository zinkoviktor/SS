using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            FirstSubtask();

            Console.Clear();
            SecondSubtask();

            Console.Clear();
            ThirdSubtask();
        }

        //Task 2-1-1
        static void FirstSubtask()
        {
            short day, month;

            //Check day
            try
            {
                Console.Write("Give me day number = ");
                day = Int16.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Erorr in value!");
                day = 0;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Erorr! Value was either too large or too small!");
                day = 0;
            }

            if (day > 0 && day <= 31)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }

            //Check month
            try
            {
                Console.Write("Give me month number  = ");
                month = Int16.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Erorr in value!");
                month = 0;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Erorr! Value was either too large or too small!");
                month = 0;
            }

            if (month > 0 && month <= 12)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }

            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        //Task 2-2
        static void SecondSubtask()
        {
            float number;
            try
            {
                Console.Write("Give me a number to 2 decimal places: ");
                number = float.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Erorr in value!");
                number = 0.0f;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Erorr! Value was either too large or too small!");
                number = 0.0f;
            }
            
            int roundNumber = (int) Math.Floor(number);
            float roundFirstNumber = number * 10;
            float roundSecondNumber = number * 100;
            int firstNumber = (int) roundFirstNumber - (roundNumber*10);
            int secondNumber = (int) roundSecondNumber - ((int) roundFirstNumber*10);

            Console.WriteLine("\nSum: {0} + {1} = {2}", firstNumber, secondNumber, firstNumber+secondNumber);      
            
            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        //Task 2-3
        static void ThirdSubtask()
        {
            short hour;
            
            try
            {
                Console.Write("Give me a hour = ");
                hour = Int16.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Erorr in value!");
                hour = 0;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Erorr! Value was either too large or too small!");
                hour = 0;
            }

            if(hour >= 1 && hour <=  24)
            {
                string message;
                message = (hour > 6 && hour <= 12) ? "\nGood morning!!!" : (hour > 12 && hour <= 17)? "\nGood day!!!": 
                              (hour > 17 && hour <= 21 )? "\nGood evening!!!": "\nGood night!!!";

                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("Incorrect hour!");
            }

            Console.Write("\nPress any key to exit . . . ");
            Console.ReadKey();
        }
    }
}
