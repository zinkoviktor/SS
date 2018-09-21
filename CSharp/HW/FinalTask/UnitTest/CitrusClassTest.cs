using System;
using System.IO;
using FinalTask;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    class CitrusClassTest
    {
        [Test]
        public void NameColorTest()
        {
            //Arrange
            Citrus fruit = new Citrus("Orange", "Orange", 4.2);
            string expectedName = fruit.Name;
            string expectedColor = fruit.Name;

            //Act
            string actualName = "Orange";
            string actualColor = "Orange";


            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedColor, actualColor);
        }
        [Test]
        public void VitaminCLevelTest()
        {
            //Arrange
            Citrus fruit = new Citrus("Apple", "Green", 4.9);
            double expected = fruit.VitaminCLevel;

            //Act
            double actual = 4.9;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void InputFromFileTest()
        {
            //Arrange
            Citrus fruit = new Citrus();
            StreamWriter sw = new StreamWriter(@"citrus_test_file.txt");
            sw.WriteLine("Apple/Green/8.6");
            sw.Close();

            StreamReader sr = new StreamReader(@"citrus_test_file.txt");
            fruit.Input(sr);
            sr.Close();

            string expectedName = "Apple";
            string expectedColor = "Green";
            double expectedVitamin = 8.6;

            //Act            
            string actualName = fruit.Name;
            string actualColor = fruit.Color;
            double actualVitamin = fruit.VitaminCLevel;

            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedColor, actualColor);
            Assert.AreEqual(expectedVitamin, actualVitamin);
        }

        [Test]
        public void PrintToFileTest()
        {
            //Arrange
            Citrus fruit = new Citrus("Orange", "Orange", 8.2);
            fruit.Print("orange_print_test_file.txt");

            StreamReader sr = new StreamReader(@"orange_print_test_file.txt");
            string expected = sr.ReadLine();
            sr.Close();

            //Act            
            string actual = "2/Orange/Orange/8,2";

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void ToStringTest()
        {
            //Arrange
            Citrus fruit = new Citrus("HelloName", "Red", 2.2);
            string expected = fruit.ToString();

            //Act
            string actual = "Red HelloName Vitamin C = 2,2";

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
