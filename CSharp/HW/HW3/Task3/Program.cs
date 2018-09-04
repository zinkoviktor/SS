using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Subtask1();

            Console.Clear();
            Subtask2();

            Console.Clear();
            Subtask3();

            Console.Clear();
            Subtask4();

            Console.Clear();
            Subtask5();

            Console.Clear();
            Subtask6();

            Console.Clear();
            Subtask7();
        }

        // 1 Subtask
        static void Subtask1()
        {
            int a, b;
                        
            try
            {
                Console.Write("a = ");
                a = Int32.Parse(Console.ReadLine());
                Console.Write("b = ");
                b=  Int32.Parse(Console.ReadLine());
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

            int result = 0;

            for(; a<=b; a++)
            {
                if (a % 3 == 0)
                {
                    result++;                    
                }
            }

            Console.WriteLine("{0} numbers are divisible by 3", result);

            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        //2 Subtask
        static void Subtask2()
        {
            string str;
            Console.Write("String = ");
            str = Console.ReadLine();

            for (int i = 0; i < str.Length; i += 2)
            {
                Console.Write(str[i]);
            }

            Console.Write("\n\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        //3 Subtask
        static void Subtask3()
        {
            string drink;
            Console.Write("Drink = ");
            drink = Console.ReadLine();            

            switch (drink.ToLower())
            {
                case "coffee":
                    Console.WriteLine("\nCoffee - 12$");
                    break;
                case "tea":
                    Console.WriteLine("\nTea - 10$");
                    break;
                case "juice":
                    Console.WriteLine("\nJuice - 20$");
                    break;
                case "water":
                    Console.WriteLine("\nJuice - 1$");
                    break;
                default:
                    Console.WriteLine("\n{0} - none", drink);
                    break;
            }

            Console.Write("\n\nPress any key to continue . . . ");
            Console.ReadKey();

        }

        //4 Subtask
        static void Subtask4()
        {
            int number=1, sumNumbers=0;
            int count = -1;

            do
            {
                try
                {
                    Console.Write("number = ");
                    number = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erorr in value!");
                    number = 0;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Erorr! Value was either too large or too small!");
                    number = 0;
                }

                sumNumbers += number;
                count++;

                Console.Clear();
            }
            while (number > 0);

            Console.WriteLine("Average = {0}", (float) sumNumbers/count);

            Console.Write("\n\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        //5 Subtask
        static void Subtask5()
        {
            int year;
            try
            {
                Console.Write("Year = ");
                year = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Erorr in value!");
                year = 0;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Erorr! Value was either too large or too small!");
                year = 0;
            }
            
            if (year >= 1000)
            {
                if (year%4 == 0)
                {
                    Console.WriteLine("\n{0} is leap year!", year);
                }
                else
                {
                    if (year % 100 == 0)
                    {
                        if (year % 400 == 0)
                        {
                            Console.WriteLine("\n{0} is leap year!", year);
                        }
                        else
                        {
                            Console.WriteLine("\n{0} isn't leap year!", year);
                        }
                    }                    
                    else
                    {
                        Console.WriteLine("\n{0} isn't leap year!", year);
                    }
                }
            }
            else
            {
                Console.WriteLine("\nYear error!");
            }

            Console.Write("\n\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        //6 Subtask
        static void Subtask6()
        {
            string number;

            Console.Write("Number = ");
            number = Console.ReadLine();
            int sum = 0;
            foreach (char n in number)
            {
                sum = sum + (int)(n - '0');
            }

            Console.WriteLine("\nSum numbers of number = {0}", sum);

            Console.Write("\n\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        //7 Subtask
        static void Subtask7()
        {
            int number;
            try
            {
                Console.Write("Odd number = ");
                number = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Erorr in value!");
                number = 0;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Erorr! Value was either too large or too small!");
                number = 0;
            }

            if (number % 2!=0)
            {
                Console.WriteLine("\n{0} - Odd number!", number);
            }
            else
            {
                Console.WriteLine("\n{0} - not odd number!", number);
            }

            Console.Write("\n\nPress any key to exit . . . ");
            Console.ReadKey();
        }
    }
}
