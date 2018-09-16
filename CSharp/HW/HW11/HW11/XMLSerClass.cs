using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HW11
{
    [Serializable]
    public class Person
    {        
        public Person() { }
        
        public string name { get; set; }        

        public Person(string name)
        {
            this.name = name;
        }              
        
        public void Print()
        {
            Console.WriteLine("Name: {0}", name);
        }
    }
}
