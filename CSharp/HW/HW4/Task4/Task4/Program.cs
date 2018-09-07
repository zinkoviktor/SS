using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Car.CompanyName);
            Car car1 = new Car();
            Car car2 = new Car("mondeo", "white", 13000);
            Car car3 = new Car();
            Car car4 = new Car("mondeo", "black", 13000);

            //car1.Input();
            //car3.Input();
               
            car1.ChangePrice(10);
            car2.ChangePrice(10);
            car3.ChangePrice(10);
            car4.ChangePrice(10);

            car1.Print();
            car2.Print();
            car4.Print();
            car3.Print();

            car2.Color = "Blue";

            car2.Print();
            car4.Print();

            Console.WriteLine("\ncar2 == car4: {0}", car2==car4);
            Console.WriteLine("\ncar2.Equals(car4): {0}", car2.Equals(car4));

            Console.WriteLine("\ncar2.ToString(): {0}", car2.ToString());

            Console.Write("\nPress any key to exit . . . ");
            Console.ReadKey();

        }
    }
}
