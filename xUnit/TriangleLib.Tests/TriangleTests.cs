using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriangleProj.Tests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void IsFirstCorrectTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(2, 3, 4));
        }

        [TestMethod]
        public void IsSecondCorrectTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(2, 5, 6));
        }
        [TestMethod]
        public void IsThirdCorrectTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(4, 5, 6));
        }

        [TestMethod]
        public void DoesAllSidesEqualZero()
        {
            Assert.IsFalse(Triangle.IsTriangle(0, 0, 0));
        }

        [TestMethod]
        public void DoesAllSidesNegative()
        {
           // Assert.IsFalse(Triangle.IsTriangle(-4, -5, -6));
        }

        [TestMethod]
        public void DoesSidesCorrect()
        {
            Assert.IsFalse(Triangle.IsTriangle(20, 10, 5));
        }

        [TestMethod]
        public void DoesOneSideEqualZero()
        {
            Assert.IsFalse(Triangle.IsTriangle(0, 3, 6));
        }

        [TestMethod]
        public void DoesOneSideNegative()
        {
            Assert.IsFalse(Triangle.IsTriangle(3, -4, 5));
        }

        [TestMethod]
        public void DoesTriangleIsoscele()
        {
            Assert.IsTrue(Triangle.IsTriangle(5, 5, 7));
        }

        [TestMethod]
        public void DoesTriangleEquilateral()
        {
            Assert.IsTrue(Triangle.IsTriangle(5, 5, 5));
        }
    }
}
