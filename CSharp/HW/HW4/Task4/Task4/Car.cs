using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Car
    {
        public const string CompanyName = "Ford Motor Company";
        private string name;
        private string color;
        private double price;
        
        public string Color {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public Car (string name = "none", string color = "none", double price=0.0)
        {
            this.name = name;
            this.color = color;
            this.price = price;
        }

        public void Input()
        {
            Console.WriteLine("\nADD A NEW CAR");
            Console.Write("Enter name:");
            name = Console.ReadLine();

            Console.Write("Enter color:");
            color = Console.ReadLine();

            Console.Write("Enter price:");
            try
            {
                price = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("ERORR!");
            }
        }
        public void Print()
        {
            Console.WriteLine("\nINFORMATION ABOUT CAR");
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("Color: {0}", color);
            Console.WriteLine("Price: {0}", price);
        }

        public void ChangePrice(double x)
        {
            price = price - (price * (x / 100));
        }
        public override string ToString()
        {
            return ("Car " + name + " " + "Color " + color + " " + "Price " + price);
        }
        public static bool operator ==(Car first, Car second)
        {
            return first.name.Equals(second.name) && Math.Round(first.price, 2).Equals(Math.Round(second.price, 2));
        }
        public static bool operator !=(Car first, Car second)
        {
            return !first.name.Equals(second.name) && Math.Round(first.price, 2).Equals(Math.Round(second.price, 2));

        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Car obj1 = (Car)obj;
            return name.Equals(obj1.name) && price.Equals(obj1.price);
        }
        public override int GetHashCode()
        {
            return name.GetHashCode() ^ price.GetHashCode() ^ color.GetHashCode();
        }
    }
}
