using System;
using CannonBall.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CannonBall.Web.Tests.Models
{
    [TestClass]
    public class TargetGeneratorTest
    {
        [TestMethod]
        public void That_GetTarget_ReturnsX5Y5WhenAskedForX5Y5()
        {
            // Give a target generator
            INumberGenerator numberGenerator = new NumberGenerator();
            ITargetGenerator serviceToTest = new TargetGenerator(numberGenerator);

            // When I ask for target x = 5, y = 5
            Coordinate actual = serviceToTest.GetTarget(x: 5, y: 5);

            // then I get x = 5, y = 5
            Assert.AreEqual(5, actual.X);
            Assert.AreEqual(5, actual.Y);
        }

        [TestMethod]
        public void That_GetTarget_ReturnsX6Y5WhenAskedForX6Y5()
        {
            // Give a target generator
            INumberGenerator numberGenerator = new NumberGenerator();
            ITargetGenerator serviceToTest = new TargetGenerator(numberGenerator);

            // When I ask for target x = 6, y = 5
            Coordinate actual = serviceToTest.GetTarget(x: 6, y: 5);

            // then I get x = 6, y = 5
            Assert.AreEqual(6, actual.X);
            Assert.AreEqual(5, actual.Y);
        }

        [TestMethod]
        public void That_GetTarget_CallsNumberGeneratorTwiceWhenNoTargetAsked()
        {
            // Give a target generator
            var mockNumberGenerator = new Mock<INumberGenerator>();
            mockNumberGenerator.Setup(x => x.GetNumber()).Returns(5);

            ITargetGenerator serviceToTest = new TargetGenerator(
                mockNumberGenerator.Object);

            // When I do not ask for a target
            Coordinate actual = serviceToTest.GetTarget();

            // then number generator called twice
            mockNumberGenerator.Verify(x => x.GetNumber(), Times.Exactly(2));
        }

        [TestMethod]
        public void That_GetTarget_DoesNotCallNumberGeneratorWhenTargetAsked()
        {
            // Give a target generator
            var mockNumberGenerator = new Mock<INumberGenerator>();
            mockNumberGenerator.Setup(x => x.GetNumber()).Returns(5);

            ITargetGenerator serviceToTest = new TargetGenerator(
                mockNumberGenerator.Object);

            // When I ask for a target
            Coordinate actual = serviceToTest.GetTarget(x: 5, y: 5);

            // then number generator not called
            mockNumberGenerator.Verify(x => x.GetNumber(), Times.Never);
        }
    }
}
