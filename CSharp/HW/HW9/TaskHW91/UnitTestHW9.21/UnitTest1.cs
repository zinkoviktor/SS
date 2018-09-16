using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskHW91;



namespace UnitTestHW9._21
{
    
    [TestClass]
    public class UnitTest1
    {        
        [TestMethod]
        public void PointTest()
        {
            //Arrange
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 1);
            double expected = 1;
            
            //Act
            double result = p1.Distance(p2);

            //Assert
            Assert.AreEqual(expected, result);            
        }
        [TestMethod]
        public void TriangleCreateTest()
        {
            //Arrenge
            Triangle triangle = new Triangle();
            int expected = 3;

            //Act
            int result = triangle.Points().Count;
            
            //Assert
            Assert.AreEqual(result, expected);            
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateBadValueTriangleTest()
        {
            Triangle triangle = new Triangle(new Point(1, 1), new Point(1, 1), new Point(1, 1));
        }
        [TestMethod]
        public void TrianglePrintTest()
        {
            //Arrenge
            Triangle triangle = new Triangle(new Point(-2,1), new Point(1,2), new Point(3,-3));

            //Act
            bool result = triangle.Print();

            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TrianglePerimetrTest()
        {
            //Arrenge
            Triangle triangle = new Triangle(new Point(-2, 2), new Point(3, 3), new Point(5, -2));
            double expected  = 18.55;
            
            //Act
            double result = triangle.Perimetr();
            
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TriangleSquareTest()
        {
            //Arrenge
            Triangle triangle = new Triangle(new Point(-2, 2), new Point(3, 3), new Point(5, -2));
            double expected = 13.52;

            //Act
            double result = triangle.Square();

            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TriangleDistenceToTest()
        {
            //Arrenge
            Triangle triangle = new Triangle(new Point(0, 1), new Point(3, 3), new Point(5, -2));
            Point coord = new Point(0, 0);
            double expected = 1;

            //Act
            double result = triangle.DistenceTo(coord);

            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void PointsTest()
        {
            Triangle triangle = new Triangle(new Point(0, 1), new Point(3, 3), new Point(5, -2));
            Point expected = new Point(3,3);

            //Act
            List<Point> result = triangle.Points();

            //Assert
            CollectionAssert.Contains(result, expected);
        }
    }
}
