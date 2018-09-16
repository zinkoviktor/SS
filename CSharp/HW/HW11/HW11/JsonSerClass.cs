using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HW11
{
    [DataContract]
    class Car
    {
        public Car() { }

        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int speed { get; set; }

        public Car(string name, int speed)
        {
            this.name = name;
            this.speed = speed;
        }

        public void Print()
        {
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("Speed: {0}", speed);
        }
    }
}
