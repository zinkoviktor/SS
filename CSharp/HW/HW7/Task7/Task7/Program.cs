using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Teacher("Mery", 2000, "C#"));
            persons.Add(new Teacher("Den", 2500, "English"));
            persons.Add(new Developer("Sem", 500, "Junior"));
            persons.Add(new Developer("Ted", 100, "Middle"));

            foreach(Person person in persons)
            {
                person.Print();
            }

            Console.WriteLine("\nSearch persons:");
            Console.Write("Enter name:");
            string name = Console.ReadLine();
            foreach(Person person in persons)
            {
                if (name == person.Name)
                {
                    person.Print();
                }
            }
            Console.ReadKey();
        }
    }

}
