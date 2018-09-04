using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{
    class Person
    {
        private string name;
        private DateTime birthYear;
          
        public string Name
        {
            get
            {
                return name;
            }
        }
        public DateTime BirthYear
        {
            get
            {
                return birthYear;
            }
        }


        public Person(string name = "none", DateTime birthYear = new DateTime())
        {
            this.name = name;
            this.birthYear = birthYear;
        }

       public int Age()
        {
            DateTime today = DateTime.Now;
            
            DateTime tmp = birthYear;
            int years = -1;
            while (tmp < today)
            {
                years++;
                tmp = tmp.AddYears(1);
            }

            return years;          
        }

        public void Input()
        {
            Console.Write("Enter name: ");
            string inputName = Console.ReadLine();
            Console.Write("Enter birthday date:");
            Console.Write("Year:");
            int inputYear = Int32.Parse(Console.ReadLine());
            Console.Write("Month:");
            int inputMonth = Int32.Parse(Console.ReadLine());
            Console.Write("Day:");
            int inputDay = Int32.Parse(Console.ReadLine());


            name = inputName;
            birthYear = new DateTime(inputYear, inputMonth, inputDay);

            Console.WriteLine("Name = {0}; Birthday = {1}", name, birthYear);            
        }

        public void ChangeName(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return ("Person " + name +"\n" + "Birthday = " + birthYear.ToShortDateString());
        }

        public void Output()
        {
            Console.WriteLine("{0}", ToString());
        }

        public static bool operator ==(Person first, Person second)
        {
            return first.name.Equals(second.name);
        }
        public static bool operator !=(Person first, Person second)
        {
            return !first.name.Equals(second.name);
        }        
    }
}
