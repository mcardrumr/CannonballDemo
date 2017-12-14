using System;
using CannonBall.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CannonBall.Web.Tests.Models
{
    [TestClass]
    public class XCoordinateCalculatorTest
    {
        [TestMethod]
        public void That_Get_Returns1ForVelocity1AndDegrees1()
        {
            // given a calculator
            IXCoordinateCalculator target = new XCoordinateCalculator();

            // when I enter velocity, 1; degrees 1
            int actual = target.Get(velocity: 1M, degrees: 1M);

            // assert - result is 1
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void That_Get_Returns2ForVelocity2AndDegrees1()
        {
            // given a calculator
            IXCoordinateCalculator target = new XCoordinateCalculator();

            // when I enter velocity, 2; degrees 1
            int actual = target.Get(velocity: 2M, degrees: 1M);

            // assert - result is 2
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void That_Get_Returns20ForVelocity20AndDegrees1()
        {
            // given a calculator
            IXCoordinateCalculator target = new XCoordinateCalculator();

            // when I enter velocity, 20; degrees 1
            int actual = target.Get(velocity: 20M, degrees: 1M);

            // assert - result is 20
            Assert.AreEqual(20, actual);
        }
    }
}
