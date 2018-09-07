using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LIST");
            List<int> myColl = new List<int>();
            int count = 1;
            while (myColl.Count < 10)
            {
                Console.Write("Enter {0} number: ", count);
                try
                {
                    myColl.Add(int.Parse(Console.ReadLine()));
                }
                catch (Exception)
                {
                    Console.WriteLine("Error!");
                }
                count++;
            }

            Console.Write("\nPrint all positions of element -10: ");
            count = 0;            
            foreach (int num in myColl)
            {
                if(num == -10)
                {
                    Console.Write(count+ " ");
                }
                count++;
            }
            
            Console.WriteLine("\nRemove from collection elements, which are greater then 20: ");
            myColl.RemoveAll(delegate (int num) { return num > 20; });
            PrintListValues(myColl);

            Console.WriteLine("\nInsert elements 1,-3,-4 in positions 2, 8, 5: ");
            myColl.Insert(1, 1);
            myColl.Insert(7, -3);
            myColl.Insert(4, -4);
            PrintListValues(myColl);

            Console.WriteLine("\nSort and print collection: ");
            myColl.Sort();
            PrintListValues(myColl);

            //
            // ArrayList
            //
            Console.WriteLine("\nARRAYLIST");
            ArrayList myColl2 = new ArrayList();
            count = 1;
            while (myColl2.Count < 10)
            {
                Console.Write("Enter {0} number: ", count);
                try
                {
                    myColl2.Add(int.Parse(Console.ReadLine()));
                }
                catch (Exception)
                {
                    Console.WriteLine("Error!");
                }
                count++;
            }
                        
            Console.WriteLine("\nprint all positions of element -10: ");
            count = 0;
            foreach (int num in myColl2)
            {
                if (num == -10)
                {
                    Console.Write(count + " ");
                }
                count++;
            }

            // Remove from collection elements, which are greater then 20           
            Console.WriteLine("\nRemove from collection elements, which are greater then 20: ");
            for (int i =0; i<myColl2.Count; i++)
            {
                if ((int)myColl2[i] > 20)
                {
                    myColl2.RemoveAt(i);
                    i--;
                }                
            }
            PrintArrayListValues(myColl2);

            Console.WriteLine("\nInsert elements 1,-3,-4 in positions 2, 8, 5: ");
            myColl2.Insert(1, 1);
            myColl2.Insert(7, -3);
            myColl2.Insert(4, -4);
            PrintArrayListValues(myColl2);

            Console.WriteLine("\nSort and print collection: ");
            myColl2.Sort();
            PrintArrayListValues(myColl2);

            Console.ReadKey();
        }
        public static void PrintListValues(List<int> myList)
        {
            int count = 0;
            foreach (Object obj in myList)
            {
                Console.Write("[{0}] ", obj);
                count++;
            }
            Console.WriteLine();
        }

        public static void PrintArrayListValues(ArrayList myList)
        {
            int count = 0;
            foreach (Object obj in myList)
            {
                Console.Write("[{0}] ", obj);
                count++;
            }
            Console.WriteLine();
        }
    }
}
