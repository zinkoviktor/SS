using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 8-1.1
            //IEnumerable<int> numbers = Enumerable.Range(-5, 10);
            int[] numbers = { 1, 2, 5, 7, 4, -2, 3, -1, -22, 8 };

            var negativeNumbers = from number in numbers where number < 0 select number;
            Print(negativeNumbers);

            var positiveEvenNum = from number in numbers where number > 0 && number % 2 == 0 select number;
            Print(positiveEvenNum);

            int minElem = numbers.Min();
            int maxElem = numbers.Max();
            int sumElements = numbers.Sum();
            int elem = numbers.First(n => n < numbers.Average());
            Console.WriteLine("min = {0}, max = {1}, sum = {2}, elem = {3}", minElem, maxElem, sumElements, elem);

            Print(numbers.OrderBy(n => n));

            Console.ReadKey();

         }
        static void Print(IEnumerable<int> print)
        {
            Console.WriteLine(print.GetHashCode());
            foreach(int value in print)
            {
                Console.WriteLine(value);
            }
        }
    }
}
