using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            FirtsTask();

            Console.Clear();
             SecondTask();

            Console.Clear();
            ThirdTask();

            Console.Clear();
            FourthTask();
        }

        // 1 task
        static void FirtsTask()
        {
            float [] numbers = new float[3];

            try
            {
                Console.Write("Give me 1 number = ");
                numbers[0] = float.Parse(Console.ReadLine());
                Console.Write("\nGive me 2 number = ");
                numbers[1] = float.Parse(Console.ReadLine());
                Console.Write("\nGive me 3 number = ");
                numbers[2] = float.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Erorr in value!");
                numbers[0] = 6;
                numbers[1] = 6;
                numbers[2] = 6;

            }
            catch (OverflowException)
            {
                Console.WriteLine("Erorr! Value was either too large or too small!");
                numbers[0] = 6;
                numbers[1] = 6;
                numbers[2] = 6;
            }


            bool result;

            result = (numbers[0] > -5 && numbers[0] > 5)? false : (numbers[1] > -5 && numbers[1] > 5)? false : 
                      (numbers[2] > -5 && numbers[2] > 5)? false : true;

            if (result)
            {
                Console.WriteLine("\nAll numbers belong to the range [-5,5]");
            }
            else
            {
                Console.WriteLine("\nall numbers not belong to the range [-5,5]");
            }
            
            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        // 2 Task
        static void SecondTask()
        {
            int[] numbers = new int[3];

            try
            {
                Console.Write("Give me 1 number = ");
                numbers[0] = int.Parse(Console.ReadLine());
                Console.Write("\nGive me 2 number = ");
                numbers[1] = int.Parse(Console.ReadLine());
                Console.Write("\nGive me 3 number = ");
                numbers[2] = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Erorr in value!");
                numbers[0] = 0;
                numbers[1] = 0;
                numbers[2] = 0;

            }
            catch (OverflowException)
            {
                Console.WriteLine("Erorr! Value was either too large or too small!");
                numbers[0] = 0;
                numbers[1] = 0;
                numbers[2] = 0;
            }

            int minValue = numbers[0];
            int maxValue = numbers[0];
            
            for(int i = 1; i < numbers.Length; i++)
            {
                if (maxValue < numbers[i])
                {
                    maxValue = numbers[i];
                }
                if(minValue > numbers[i])
                {
                    minValue = numbers[i];
                }
            }

            Console.WriteLine("\nMaxValue = {0}", maxValue);
            Console.WriteLine("MinValue = {0}", minValue);

            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        //3 task

        enum HttpErrors { BadRequest = 400, Unauthorized, PaymentRequired, Forbidden, NotFound};

        static void ThirdTask()
        {
            int HttpErrorCode;

            try
            {
                Console.Write("Give me HttpErrorCode [400-404]: ");
                HttpErrorCode = int.Parse(Console.ReadLine());                
            }
            catch (FormatException)
            {
                Console.WriteLine("Erorr in value!");
                HttpErrorCode = 0;
                

            }
            catch (OverflowException)
            {
                Console.WriteLine("Erorr! Value was either too large or too small!");
                HttpErrorCode = 0;                
            }

            if (HttpErrorCode >= 400 && HttpErrorCode <= 404)
            {
                Console.WriteLine("\n{0}", (HttpErrors)HttpErrorCode);
            }
            else
            {
                Console.WriteLine("Incorrect HTTP Error code!!!");
            }            

            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        //4 task

        struct Dog
        {
            public string name;
            public string mark;
            public string age;
        }

        static void FourthTask()
        {
            Dog myDog;

            myDog.name = "Beethoven";
            myDog.mark = "St Bernard";
            myDog.age = "3";

            Console.WriteLine("My Dog\n\nName: {0}\nMark: {1}\nAge: {2}", myDog.name, myDog.mark, myDog.age);

            Console.Write("\nPress any key to exit . . . ");
            Console.ReadKey();
        }
    }
}
