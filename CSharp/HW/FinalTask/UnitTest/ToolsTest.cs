using System;
using System.IO;
using FinalTask;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    class ToolsTest
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
        public void FirstCharToUpperTest()
        {
            //Arrange
            string expected = Tools.FirstCharToUpper("sBB");

            //Act
            string actual = "SBB";

            //Assert            
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ParseToDoubleTest([Values("2.3", "2,3")] string str)
        {
            //Arrange
            double expected = Tools.ParseToDouble(str);

            //Act
            double actual = 2.3;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnIdTest()
        {
            //Arrange
            using (StreamWriter sw = new StreamWriter("id.txt"))
            {
                sw.WriteLine("12522222/...");
            }
            int expected;
            using (StreamReader sr = new StreamReader("id.txt"))
            {
                expected = Tools.ReturnId(sr);
            }

            //Act
            int actual = 12522222;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
