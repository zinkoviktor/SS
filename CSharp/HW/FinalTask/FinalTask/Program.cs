using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    class Program
    {
        public enum FruitsId
        {
            None = '0',
            Fruit,
            Citrus
        }
        static void Main(string[] args)
        {
            List<Fruit> fruits = new List<Fruit>(); //List for some fruits
            string readPath = @"file.txt"; //path to file, with data of fruits        
            fruits.AddRange(AddFromFile(readPath));
            fruits.AddRange(AddFromConsole(2));
                        
            foreach(Fruit fruit in fruits)
            {
                fruit.Print();
            }

            Console.ReadKey();
        }

        /// <summary>Adds fruits from file, return fruit list</summary>
        static List<Fruit> AddFromFile(string path)
        {
            List<Fruit> fruits = new List<Fruit>();
            using (StreamReader sr = new StreamReader(path))
            {
                int count = 3;
                int peekLine;
                do
                {
                    peekLine = sr.Peek();
                    try
                    {
                        if (peekLine == (char)FruitsId.Fruit)
                        {
                            fruits.Add(new Fruit());
                            fruits[fruits.Count - 1].Input(sr);
                            count--;
                        }
                        else if (peekLine == (char)FruitsId.Citrus)
                        {
                            fruits.Add(new Citrus());
                            fruits[fruits.Count - 1].Input(sr);
                            count--;
                        }
                        else if (peekLine > 0)
                        {
                            sr.ReadLine();
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                while (count > 0);
                return fruits;
            }
        }

        static List<Fruit> AddFromConsole(int count)
        {
            List<Fruit> fruits = new List<Fruit>();
            FruitsId type;

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter Fruits type");
                type = parseToFruitsId(Console.ReadLine());
                try
                {
                    if (type.Equals(FruitsId.Fruit))
                    {
                        fruits.Add(new Fruit());
                        fruits[fruits.Count].Input();
                    }
                    else if (type.Equals(FruitsId.Citrus))
                    {
                        fruits.Add(new Citrus());
                        fruits[fruits.Count].Input();
                    }
                    else
                    {
                        Console.WriteLine("Not supported");
                        i--;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }                
            }

            return fruits;
        }

        //Changes first string character to UpperCase
        static string firstCharToUpper(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }
        
        static FruitsId parseToFruitsId(string value)
        {
            try
            {
                return (FruitsId)Enum.Parse(typeof(FruitsId), firstCharToUpper(value));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return FruitsId.None;
            }            
        }
    }
}
