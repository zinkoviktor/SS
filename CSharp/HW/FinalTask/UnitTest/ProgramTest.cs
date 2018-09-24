using System;
using System.IO;
using FinalTask;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTest
{
    [TestFixture]
    public class ProgramTest
    {
        [Test]
        public void PrintSortFruitByParametsTest()
        {
            //Arrange
            List<Fruit> fruits = new List<Fruit>();
            fruits.Add(new Fruit("Apple", "Green"));
            fruits.Add(new Fruit("Blueberrie", "Blue"));
            fruits.Add(new Fruit("Orange", "Orange"));
            fruits.Add(new Fruit("Banana", "yellow"));

            List<Fruit> expected = new List<Fruit>();
            expected.Add(new Fruit("Apple", "Green"));
            expected.Add(new Fruit("Banana", "Yellow"));
            expected.Add(new Fruit("Blueberrie", "Blue"));
            expected.Add(new Fruit("Orange", "Orange"));

            //Act
            List<Fruit> actual = Program.PrintSortFruitByParamets(fruits, "Name", false);
            
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }
        [Test]
        public void FruitsXMLDeserializerExeptionTest()
        {
            //Arrange  
            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => Program.FruitsXMLDeserializer("Exeption.txt"));
        }
        [Test]
        public void SerializationTest()
        {
            //Arrange
            List<Fruit> fruits = new List<Fruit>();
            fruits.Add(new Fruit("Apple", "Green"));
            fruits.Add(new Fruit("Blueberrie", "Blue"));
            fruits.Add(new Fruit("Orange", "Orange"));
            fruits.Add(new Fruit("Banana", "yellow"));
            Program.FruitsXMLSerializer(fruits, "xml_fruits.xml");
            List<Fruit> newfruits = Program.FruitsXMLDeserializer("xml_fruits.xml");            
            Program.FruitsXMLSerializer(newfruits, "xml_new_fruits.xml");
            StreamReader expected = new StreamReader("xml_fruits.xml");

            //Act
            StreamReader actual = new StreamReader("xml_new_fruits.xml");

            //Assert
            FileAssert.AreEqual(expected.BaseStream, actual.BaseStream);
        }


    }
}
