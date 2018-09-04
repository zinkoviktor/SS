using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
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
        }

        // a Task Home Work
        static void FirstTask()
        {
            string str;
            Console.Write("String = ");
            str = Console.ReadLine();

            int count = 0;

            foreach(char ch in str)
            {
                if (ch >= 'A' && ch <= 'Z' || ch >= 'a' && ch <= 'z')
                {
                    count++;
                }
            }

            Console.WriteLine("\nCount = {0}", count);

            Console.Write("\n\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        // b Task Home Work        
        static void SecondTask()
        {
            short month;
            try
            {
                Console.Write("Month = ");
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

            short dayInMonth = 0;

            if(month < 1 || month > 12)
            {
                Console.WriteLine("\nIncorrect month!");
            }
            else
            {
                if(month == 1)
                {
                    dayInMonth = 31;
                }
                else if(month == 2)
                {
                    dayInMonth = 28;
                }
                else
                {
                    if (month % 2 != 0 && month < 8)
                    {
                        dayInMonth = 31;
                    }
                    else if (month % 2 == 0 && month > 7)
                    {
                        dayInMonth = 31;
                    }
                    else
                    {
                        dayInMonth = 30;
                    }
                    
                }
            }

            Console.WriteLine("\n{0} month = {1} days", month, dayInMonth);

            Console.Write("\n\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        // c Task Home Work   
        static void ThirdTask()
        {
            int[] numbers = new int[10];

            int firstFiveNumbers=0;
            int nextFiveNumbers=1;

            for(int i = 0; i < numbers.Length; i++)
            {
                try
                {
                    Console.Write("{0} number = ", i+1);
                    numbers[i] = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erorr in value!");
                    numbers[i] = -1;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Erorr! Value was either too large or too small!");
                    numbers[i] = -1;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Erorr! Not number!");
                    numbers[i] = -1;
                }
            }

            for(int i=0; i < numbers.Length/2; i++)
            {
                if (numbers[i] >= 0)
                {
                    firstFiveNumbers += numbers[i];
                }
                else
                {
                    for(int j = 5; j<numbers.Length; j++)
                    {
                        nextFiveNumbers *= numbers[j];
                    }
                    break;
                }
            }

            if (nextFiveNumbers==1)
            {
                Console.WriteLine("\nSum of first 5 elements = {0}", firstFiveNumbers);
            }
            else
            {
                Console.WriteLine("\nProduct of last 5 elements = {0}", nextFiveNumbers);
            }

            Console.Write("\n\nPress any key to exit . . . ");
            Console.ReadKey();
        }


    }
}
