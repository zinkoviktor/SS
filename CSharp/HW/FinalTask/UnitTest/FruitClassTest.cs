using System;
using System.IO;
using FinalTask;
using NUnit.Framework;

namespace UnitTest
{   
    [TestFixture]    
    public class FruitClassTest
    {
        public void Test()
        {
            //Arrange
            string expected;

            //Act
            string actual;

            //Assert
            
        }

        [Test]
        public void NameTest()
        {
            //Arrange
            Fruit fruit = new Fruit("Apple", "Green");
            string expected = fruit.Name;

            //Act
            string actual = "Apple";

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ColorTest()
        {
            //Arrange
            Fruit fruit = new Fruit("Apple", "Green");
            string expected = fruit.Color;

            //Act
            string actual = "Green";

            //Assert
            Assert.AreEqual(expected, actual);
        }        
        [Test]        
        public void InputFromFileTest()
        {
            //Arrange
            Fruit fruit = new Fruit();
            StreamWriter sw = new StreamWriter(@"test_file.txt");            
            sw.WriteLine("Apple/Green");
            sw.Close();
           
            StreamReader sr = new StreamReader(@"test_file.txt");
            fruit.Input(sr);
            sr.Close();
            
            string expectedName = "Apple";
            string expectedColor = "Green";

            //Act            
            string actualName = fruit.Name;
            string actualColor = fruit.Color;

            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedColor, actualColor);
        }

        [Test]
        public void PrintToFileTest()
        {
            //Arrange
            Fruit fruit = new Fruit("Orange","Orange");            
            fruit.Print("print_test_file.txt");
            
            StreamReader sr = new StreamReader(@"print_test_file.txt");
            string expected = sr.ReadLine();
            sr.Close();

            //Act            
            string actual = "1/Orange/Orange";

            //Assert
            Assert.AreEqual(actual, expected);            
        }

        [Test]
        public void parseToColorsKeyFailTest()
        {
            //Arrange
            Fruit fruit = new Fruit("Fruit","Redddddd");
            string expected = fruit.Color; 
            //Act
            string actual =  "None";

            //Assert
            Assert.AreEqual(expected, actual);           
        }

        [Test]
        public void ToStringTest()
        {
            //Arrange
            Fruit fruit = new Fruit("HelloName", "Red");
            string expected = fruit.ToString();

            //Act
            string actual = "Red HelloName";

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
