using System;
using CannonBall.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CannonBall.Web.Tests.Models
{
    [TestClass]
    public class VelocityValidatorTest
    {
        [TestMethod]
        public void That_GetIsValid_ReturnsTrueFor1()
        {
            // given a validator
            IVelocityValidator target = new VelocityValidator();

            // when I enter 1
            bool actual = target.GetIsValid(velocity: 1M);

            // assert - returns true
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void That_GetIsValid_ReturnsFalseFor0()
        {
            // given a validator
            IVelocityValidator target = new VelocityValidator();

            // when I enter 0
            bool actual = target.GetIsValid(velocity: 0M);

            // assert - returns false
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void That_GetIsValid_ReturnsTrueFor20()
        {
            // given a validator
            IVelocityValidator target = new VelocityValidator();

            // when I enter 20
            bool actual = target.GetIsValid(velocity: 20M);

            // assert - returns true
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void That_GetIsValid_ReturnsFalseFor21()
        {
            // given a validator
            IVelocityValidator target = new VelocityValidator();

            // when I enter 21
            bool actual = target.GetIsValid(velocity: 21M);

            // assert - returns false
            Assert.IsFalse(actual);
        }
    }
}
