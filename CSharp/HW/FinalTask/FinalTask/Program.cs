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
            Fruit = '1',
            Citrus
        }
        static void Main(string[] args)
        {
            List<Fruit> fruits = new List<Fruit>(); //List for some fruits
            string readPath = @"file.txt"; //path to file, with data of fruits        

            //Adds fruits from file
            using (StreamReader sr = new StreamReader(readPath))
            {
                int count = 3;
                int peekLine;
                {
                    do
                    {
                        peekLine = sr.Peek();

                        if (peekLine == (char)FruitsId.Fruit)
                        {
                            try
                            {
                                fruits.Add(new Fruit());
                                fruits[fruits.Count - 1].Input(sr);
                                count--;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        else if (peekLine == (char)FruitsId.Citrus)
                        {
                            Console.WriteLine("{0} - {1}", sr.Peek(), sr.ReadLine());                            
                            count--;
                        }
                        else if(peekLine > 0)
                        {
                            sr.ReadLine();                            
                        }                        
                        else
                        {
                            count = 0;
                        }
                    }
                    while (count > 0);
                }                
            }

            foreach(Fruit fruit in fruits)
            {
                fruit.Print();
            }

            Console.ReadKey();

        }
    }
}
