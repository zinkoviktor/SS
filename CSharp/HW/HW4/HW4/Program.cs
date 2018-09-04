using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{
    class Program
    {
        static void Main(string[] args)
        {
            Person personA = new Person("Eric", new DateTime(2001, 11, 11));
            Person personB = new Person("Pol", new DateTime(1981, 11, 11));
            Person personC = new Person("Sem", new DateTime(1982, 11, 11));
            Person personD = new Person("Veronica", new DateTime(2002, 11, 11));
            Person personE = new Person("Pol", new DateTime(1990, 11, 30));
            Person personF = new Person("Victor", new DateTime(1988, 01, 11));
            
            Person[] persons = new[] { personA, personB, personC, personD, personE, personF };

            //personF.Input();
            
            foreach (Person person in persons)
            {
                Console.WriteLine("{0} {1} years old", person.Name, person.Age()); 
            }

            Console.WriteLine("\nAll Persons:");
            foreach (Person person in persons)
            {
                if (person.Age() < 16)
                {
                    person.ChangeName("Very Young");
                }
            }

            foreach (Person person in persons)
            {
                person.Output();
            }

            Console.WriteLine("\nEquals Person:");
            for(int i = 0; i<persons.Length-1; i++)
            {
                for (int j = i+1; j < persons.Length - 1; j++)
                {
                    if (persons[i] == persons[j])
                    {
                        persons[i].Output();
                        persons[j].Output();
                    }
                }
                    
            }

            Console.ReadKey();
        }
    }
}
