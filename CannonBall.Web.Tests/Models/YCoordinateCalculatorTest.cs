using System;
using CannonBall.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CannonBall.Web.Tests.Models
{
    [TestClass]
    public class YCoordinateCalculatorTest
    {
        [TestMethod]
        public void That_Get_Returns0ForVelocity1AndDegrees1()
        {
            // given a calculator
            IDegreeCalculator degreeCalculator = new DegreeCalculator();
            IYCoordinateCalculator target
                = new YCoordinateCalculator(degreeCalculator);

            // when I enter velocity, 1; degrees 1
            int actual = target.Get(velocity: 1M, angle: 1M);

            // assert - result is 0
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void That_Get_Returns0ForVelocity2AndDegrees1()
        {
            // given a calculator
            IDegreeCalculator degreeCalculator = new DegreeCalculator();
            IYCoordinateCalculator target
                = new YCoordinateCalculator(degreeCalculator);

            // when I enter velocity, 2; degrees 1
            int actual = target.Get(velocity: 2M, angle: 1M);

            // assert - result is 0
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void That_Get_Returns0ForVelocity20AndDegrees1()
        {
            // given a calculator
            IDegreeCalculator degreeCalculator = new DegreeCalculator();
            IYCoordinateCalculator target
                = new YCoordinateCalculator(degreeCalculator);

            // when I enter velocity, 20; degrees 1
            int actual = target.Get(velocity: 20M, angle: 1M);

            // assert - result is 0
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void That_Get_Returns7ForVelocity10AndDegrees45()
        {
            // given a calculator
            IDegreeCalculator degreeCalculator = new DegreeCalculator();
            IYCoordinateCalculator target
                = new YCoordinateCalculator(degreeCalculator);

            // when I enter velocity, 10; degrees 45
            int actual = target.Get(velocity: 10M, angle: 45M);

            // assert - result is 7
            Assert.AreEqual(7, actual);
        }
    }
}
