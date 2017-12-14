using System;
using CannonBall.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CannonBall.Web.Tests.Models
{
    [TestClass]
    public class AngleValidatorTest
    {
        [TestMethod]
        public void That_GetIsValid_ReturnsTrueFor1()
        {
            // given a validator
            IAngleValidator target = new AngleValidator();

            // when I enter 1
            bool actual = target.GetIsValid(angle: 1M);

            // assert - returns true
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void That_GetIsValid_ReturnsFalseFor0()
        {
            // given a validator
            IAngleValidator target = new AngleValidator();

            // when I enter 0
            bool actual = target.GetIsValid(angle: 0M);

            // assert - returns false
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void That_GetIsValid_ReturnsTrueFor90()
        {
            // given a validator
            IAngleValidator target = new AngleValidator();

            // when I enter 90
            bool actual = target.GetIsValid(angle: 90M);

            // assert - returns true
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void That_GetIsValid_ReturnsFalseFor91()
        {
            // given a validator
            IAngleValidator target = new AngleValidator();

            // when I enter 91
            bool actual = target.GetIsValid(angle: 91M);

            // assert - returns false
            Assert.IsFalse(actual);
        }
    }
}
