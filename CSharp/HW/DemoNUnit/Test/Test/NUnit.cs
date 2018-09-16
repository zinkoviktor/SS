using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

namespace Test
{
    class NUnit
    {
        [TestFixture]
        public class CalcTest        
        {
            [SetUp]
            public void Init() {
                //throw new Exception("Start");
            }

            [TearDown]
            public void Cleanup()
            {
                //throw new Exception("End");
            }

            Calc calc = new Calc();
           
            [Test]
            public void AddTest()
            {
                Assert.AreEqual(calc.Add(154, 200), 154 + 201, "154 + 200 != 354");
                Assert.AreNotEqual(calc.Add(154, 200), 154 - 200, "154 - 200 = 354");
            }
            [Test]
            public void MulTest([Random(2)] double x, [Random(2)] double y)
            {
                Assert.AreEqual(calc.Mul(x, y), (x * y), x + "*" + y + "=" + x * y);
            }
            [Test]
            public void SubTest([Range(1, 5)]double x, [Range(1, 5)] double y)
            {
                Assert.AreEqual(calc.Sub(x, y), x - y, x + "-" + y + "=" + (x - y));
            }
            [Test]

            public void DivTest()
            {
                Assert.Throws<DivideByZeroException>(() => calc.Div(5, 0));
            }

        }

        [TestFixture]
        public class NUnitStringTest
        {
            string str1 = "Hello";
            string str2 = "hello";
            string str3 = "Test";
            string str4 = "Hello 12345 Test";

            [Test]
            public void DoesNotContain()
            {
                StringAssert.DoesNotContain(str1, str2);
            }
            [Test]
            public void StartsWith()
            {
                StringAssert.StartsWith(str1, str4);
            }
            [Test]
            public void EndsWith()
            {
                StringAssert.EndsWith(str3, str4);
            }
            [Test]
            public void AreEqualIgnoringCase()
            {
                StringAssert.AreEqualIgnoringCase(str1, str2);
            }
        }

        [TestFixture]
        public class NUnitFileTest
        {
            [SetUp]
            public void Init()
            {
                using (new StreamWriter(@"e:/1.txt"));
                using (new StreamWriter(@"e:/2.txt"));
            }
            [TearDown]
            public void Cleanup()
            {
                new StreamReader(@"e:/1.txt").Close();
                new StreamReader(@"e:/2.txt").Close();
            }

            [Test]            
            public void AreEqualFile()
            {
                StreamReader stream1 = new StreamReader(@"e:/1.txt");
                StreamReader stream2 = new StreamReader(@"e:/2.txt");
                FileAssert.AreEqual(stream1.BaseStream, stream2.BaseStream);                
            }            
        }
        [TestFixture]
        public class ListMapped
        {
            [Test]
            public void ListMappedRun()
            {
                int[] lengths = new int[] { 1, 2, 3 };
                string[] strings = new string[] { "a", "ab", "abcd" };
                Assert.That(new ListMapper(strings).Property("Length"), Is.EqualTo(lengths));
            }
        }
    }
}
