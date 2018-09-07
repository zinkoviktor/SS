using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<uint, string> persons = new Dictionary<uint, string>();

            persons.Add(101, "Alex");
            persons.Add(102, "Bernard");
            persons.Add(103, "Clark");
            persons.Add(105, "Ellis");
            persons.Add(106, "Grace");
            persons.Add(109, "Kevin");
            persons.Add(110, "Monica");

            uint ID = 0;

            Console.Write("Enter ID:");
            try
            {
                ID = uint.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR!");
            }

            if (persons.ContainsKey(ID))
            {
                Console.WriteLine("Name = {0}", persons[ID]);
            }
            else
            {
                Console.WriteLine("Nothing by this ID");
            }

            Console.Write("\nPress any key to exit . . . ");
            Console.ReadKey();
        }
    }
}
