using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;


namespace HW11
{
    class Program 
    {
        static void Main(string[] args)
        {
            BinSer();
            XmlSer();
            JsonSer();
            Console.ReadKey();
        }
        public static void BinSer()
        {
            Triangle triangle1 = new Triangle(new Point(-2, 2), new Point(3, 3), new Point(5, -2));

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream("Triangle.bin", FileMode.Create, FileAccess.Write, FileShare.None);

            formatter.Serialize(stream, triangle1);
            stream.Close();

            stream = new FileStream("Triangle.bin", FileMode.Open, FileAccess.Read, FileShare.Read);

            Triangle triangle2 = (Triangle)formatter.Deserialize(stream);

            stream.Close();
            triangle1.Print();
        }
        public static void XmlSer()
        {
            Person person1 = new Person("Victor");
           
            XmlSerializer xmlser = new XmlSerializer(typeof(Person));
            FileStream serialStream = new FileStream("Person.xml", FileMode.OpenOrCreate);

            xmlser.Serialize(serialStream, person1);
            serialStream.Close();

            serialStream = new FileStream("Person.xml", FileMode.Open);

            Person person2 = (Person) xmlser.Deserialize(serialStream);
            serialStream.Close();
            person2.Print();
        }
        public static void JsonSer()
        {
            Car car1 = new Car("Toyota", 220);
           
            Stream file = new FileStream("Car.json", FileMode.Create);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Car));
            ser.WriteObject(file, car1);

            file.Position = 0;

            Car car2 = (Car)ser.ReadObject(file);
            car2.Print();
        }

    }
}
