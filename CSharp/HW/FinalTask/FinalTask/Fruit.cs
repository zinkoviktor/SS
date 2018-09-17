using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    class Fruit
    {
        public string name { get; set; }
        public string color { get; set; }

        public Fruit() { }
        public Fruit(string name, string color)
        {
            this.name = name;
            this.color = color;
        }

        virtual public void Input()
        {
            if (name == null)
            {
                Console.Write("Enter name: ");
                name = Console.ReadLine();
            }
            if (color == null)
            {
                Console.Write("Enter name: ");
                color = Console.ReadLine();
            }
        }
        virtual public void Print()
        {
            if (name != null)
            {
                Console.WriteLine("Fruit name = {0}", name);

                if (color != null)
                {
                    Console.WriteLine(", color = {0}", color);
                }
                else
                {
                    Console.WriteLine(", color = none");
                }
            }            
            else
            {
                Console.WriteLine("Empty fruit");
            }
        }
        virtual public void Input(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                    if (reader.Peek() > 0)
                    {
                        name = reader.ReadLine();
                        color = reader.ReadLine();
                    }
            }      
        }
        virtual public void Print(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(name);
                writer.WriteLine(color);
            }
        }
        public override string ToString()
        {
            return name;
        }

    }
}
