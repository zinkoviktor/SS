using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IFlyable> flyables = new List<IFlyable>();

            flyables.Add(new Bird("Penguin"));
            flyables.Add(new Bird("Parrot", true));
            flyables.Add(new Plane("An-2", 200));
            flyables.Add(new Plane("Comcorde", 3000));

            foreach(IFlyable obj in flyables)
            {
                obj.Fly();
            }

            Console.Write("\nPress any key to exit . . . ");
            Console.ReadKey();
        }
    }
}
