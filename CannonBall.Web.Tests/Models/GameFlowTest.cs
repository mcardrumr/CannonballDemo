using System;
using CannonBall.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CannonBall.Web.Tests.Models
{
    [TestClass]
    public class GameFlowTest
    {
        [TestMethod]
        public void That_Start_CallsTargetGeneratorWithNoParamsOnce()
        {
            // given a game flow object
            var mockTargetGenerator = new Mock<ITargetGenerator>();
            mockTargetGenerator.Setup(x => x.GetTarget())
                .Returns(new Coordinate(x: 1, y: 2));

            IGameFlow serviceToTest = new GameFlow(
                targetGenerator: mockTargetGenerator.Object);

            // when GetTarget is called
            Coordinate actual = serviceToTest.Start();

            // ITargetGenerator is called once
            mockTargetGenerator.Verify(x => x.GetTarget(), Times.Once);
        }

        [TestMethod]
        public void That_Start_ReturnsTargetFromTargetGenerator()
        {
            // given a game flow object
            var testStartTarget = new Coordinate(x: 1, y: 2);

            var mockTargetGenerator = new Mock<ITargetGenerator>();
            mockTargetGenerator.Setup(x => x.GetTarget())
                .Returns(testStartTarget);

            IGameFlow serviceToTest = new GameFlow(
                targetGenerator: mockTargetGenerator.Object);

            // when GetTarget is called
            Coordinate actual = serviceToTest.Start();

            // assert - returns target from TargetGenerator
            Assert.AreEqual(testStartTarget, actual);
        }

        [TestMethod]
        public void That_TakeShot_CallsAngleValidatorOnce()
        {
            // given a game flow object
            var testStartTarget = new Coordinate(x: 1, y: 2);

            var mockTargetGenerator = new Mock<ITargetGenerator>();
            var mockAngleValidator = new Mock<IAngleValidator>();
            mockAngleValidator.Setup(x => x.GetIsValid(It.IsAny<decimal>()))
                .Returns(true);

            IGameFlow serviceToTest = new GameFlow(
                targetGenerator: mockTargetGenerator.Object);

            // when GetTarget is called
            bool actual = serviceToTest.TakeShot(angle: 45M, velocity: 10M);

            // IAngleValidator is called once
            mockAngleValidator.Verify(x => x.GetIsValid(It.IsAny<decimal>()), 
                Times.Once);
        }
    }
}
