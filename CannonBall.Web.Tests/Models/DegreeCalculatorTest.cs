using System;
using CannonBall.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CannonBall.Web.Tests.Models
{
    [TestClass]
    public class DegreeCalculatorTest
    {
        [TestMethod]
        public void That_GetDegrees_ReturnsCorrectFor1()
        {
            // given a degree calculator
            IDegreeCalculator target = new DegreeCalculator();

            // when I enter 1
            decimal actual = target.GetDegrees(angle: 1M);

            // I get 0.0174532925
            Assert.AreEqual(0.0174532925M, actual);
        }

        [TestMethod]
        public void That_GetDegrees_ReturnsCorrectFor2()
        {
            // given a degree calculator
            IDegreeCalculator target = new DegreeCalculator();

            // when I enter 2
            decimal actual = target.GetDegrees(angle: 2M);

            // I get 0.034906585
            Assert.AreEqual(0.034906585M, actual);
        }

        [TestMethod]
        public void That_GetDegrees_ReturnsCorrectFor90()
        {
            // given a degree calculator
            IDegreeCalculator target = new DegreeCalculator();

            // when I enter 90
            decimal actual = target.GetDegrees(angle: 90M);

            // I get 1.570796325
            Assert.AreEqual(1.570796325M, actual);
        }
    }
}
