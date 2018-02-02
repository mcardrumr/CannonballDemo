using System;
using CannonBall.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CannonBall.Web.Tests.Models
{
    [TestClass]
    public class GameFlowTest
    {
        private const string MOCK_ANGLE_ERROR_MSG = @"bad angle";
        private const string MOCK_VELOCITY_ERROR_MSG = @"bad velocity";
        private static Coordinate TestTarget = new Coordinate(x: 1, y: 4);

        [TestMethod]
        public void That_Start_CallsTargetGeneratorWithNoParamsOnce()
        {
            // given a game flow object
            IGameFlow serviceToTest = GetTestGameFlowObject(
                out Mock<ITargetGenerator> mockTargetGenerator,
                new Coordinate(x: 1, y: 2));

            // when GetNewTarget is called
            Coordinate actual = serviceToTest.GetNewTarget();

            // ITargetGenerator is called once
            mockTargetGenerator.Verify(x => x.GetTarget(), Times.Once);
        }

        [TestMethod]
        public void That_Start_ReturnsTargetFromTargetGenerator()
        {
            // given a game flow object
            var testStartTarget = new Coordinate(x: 1, y: 2);

            IGameFlow serviceToTest = GetTestGameFlowObject(
                out Mock<ITargetGenerator> mockTargetGenerator,
                testStartTarget);

            // when GetNewTarget is called
            Coordinate actual = serviceToTest.GetNewTarget();

            // assert - returns target from TargetGenerator
            Assert.AreEqual(testStartTarget, actual);
        }

        [TestMethod]
        public void That_TakeShot_CallsAngleValidatorOnce()
        {
            // given a game flow object
            IGameFlow serviceToTest = GetTestGameFlowObject(
                out Mock<ITargetGenerator> mockTargetGenerator,
                out Mock<IAngleValidator> mockAngleValidator,
                TestTarget, isAngleValid: true);

            // when TakeShot is called
            bool actual = serviceToTest.TakeShot(currentShotCount: 0,
                angle: 45M, velocity: 10M, currentTarget: TestTarget);

            // IAngleValidator is called once
            mockAngleValidator.Verify(x => x.GetIsValid(It.IsAny<decimal>()),
                Times.Once);
        }

        [TestMethod]
        public void That_TakeShot_ThrowsWhenAngleIsInvalid()
        {
            // given a game flow object
            IGameFlow serviceToTest = GetTestGameFlowObject(
                out Mock<ITargetGenerator> mockTargetGenerator,
                out Mock<IAngleValidator> mockAngleValidator,
                TestTarget, isAngleValid: false);

            // when TakeShot is called
            Exception exActual = null;
            try
            {
                serviceToTest.TakeShot(currentShotCount: 0,
                    angle: 45M, velocity: 10M, currentTarget: TestTarget);
            }
            catch (Exception ex)
            {
                exActual = ex;
            }

            // error is thrown
            Assert.IsNotNull(exActual);
            Assert.AreEqual(MOCK_ANGLE_ERROR_MSG, exActual.Message);
        }

        [TestMethod]
        public void That_TakeShot_CallsVelocityValidatorOnce()
        {
            // given a game flow object
            var testStartTarget = new Coordinate(x: 1, y: 2);

            IGameFlow serviceToTest = GetTestGameFlowObject(
                out Mock<ITargetGenerator> mockTargetGenerator,
                out Mock<IVelocityValidator> mockVelocityValidator,
                testStartTarget, isVelocityValid: true);

            // when TakeShot is called
            bool actual = serviceToTest.TakeShot(currentShotCount: 0,
                angle: 45M, velocity: 10M, currentTarget: TestTarget);

            // IVelocityValidator is called once
            mockVelocityValidator.Verify(x => x.GetIsValid(It.IsAny<decimal>()),
                Times.Once);
        }

        [TestMethod]
        public void That_TakeShot_ThrowsWhenVelocityIsInvalid()
        {
            // given a game flow object
            IGameFlow serviceToTest = GetTestGameFlowObject(
                out Mock<ITargetGenerator> mockTargetGenerator,
                out Mock<IVelocityValidator> mockVelocityValidator,
                TestTarget, isVelocityValid: false);

            // when TakeShot is called
            Exception exActual = null;
            try
            {
                serviceToTest.TakeShot(currentShotCount: 0,
                    angle: 45M, velocity: 10M, currentTarget: TestTarget);
            }
            catch (Exception ex)
            {
                exActual = ex;
            }

            // error is thrown
            Assert.IsNotNull(exActual);
            Assert.AreEqual(MOCK_VELOCITY_ERROR_MSG, exActual.Message);
        }

        [TestMethod]
        public void That_TakeShot_DoesNotCallCounterWhenAngleIsInvalid()
        {
            // given a game flow object
            IGameFlow serviceToTest = GetTestGameFlowObject(
                out Mock<ITargetGenerator> mockTargetGenerator,
                out Mock<IAngleValidator> mockAngleValidator,
                out Mock<IVelocityValidator> mockVelocityValidator,
                out Mock<IShotCounter> mockShotCounter,
                TestTarget, isAngleValid: false,
                isVelocityValid: true,
                shotCount: 1);

            // when TakeShot is called
            try
            {
                serviceToTest.TakeShot(currentShotCount: 0,
                        angle: 45M, velocity: 10M, currentTarget: TestTarget);
            }
            catch (Exception)
            {
            }

            // then shot counter is not called
            mockShotCounter.Verify(x => x.AddShot(It.IsAny<int>()), Times.Never);
        }

        [TestMethod]
        public void That_TakeShot_DoesNotCallCounterWhenVelocityIsInvalid()
        {
            // given a game flow object
            IGameFlow serviceToTest = GetTestGameFlowObject(
                out Mock<ITargetGenerator> mockTargetGenerator,
                out Mock<IAngleValidator> mockAngleValidator,
                out Mock<IVelocityValidator> mockVelocityValidator,
                out Mock<IShotCounter> mockShotCounter,
                TestTarget, isAngleValid: true,
                isVelocityValid: false,
                shotCount: 1);

            // when TakeShot is called
            try
            {
                serviceToTest.TakeShot(currentShotCount: 0,
                        angle: 45M, velocity: 10M, currentTarget: TestTarget);
            }
            catch (Exception)
            {
            }

            // then shot counter is not called
            mockShotCounter.Verify(x => x.AddShot(It.IsAny<int>()), Times.Never);
        }

        [TestMethod]
        public void That_TakeShot_CallsXCalculatorForValidShot()
        {
            // given a game flow object
            IGameFlow serviceToTest = GetTestGameFlowObject(
                out Mock<IXCoordinateCalculator> mockXCalculator,
                out Mock<IYCoordinateCalculator> mockYCalculator,
                shotCount: 0);

            // when TakeShot is called
            serviceToTest.TakeShot(currentShotCount: 0,
                angle: 45M, velocity: 10M, currentTarget: TestTarget);

            // then XCalculator is called
            mockXCalculator.Verify(x => x.Get(It.IsAny<decimal>(), It.IsAny<decimal>()),
                Times.Once);
        }

        [TestMethod]
        public void That_TakeShot_CallsYCalculatorForValidShot()
        {
            IGameFlow serviceToTest = GetTestGameFlowObject(
                out Mock<IXCoordinateCalculator> mockXCalculator,
                out Mock<IYCoordinateCalculator> mockYCalculator,
                shotCount: 0);

            // when TakeShot is called
            serviceToTest.TakeShot(currentShotCount: 0,
                angle: 45M, velocity: 10M, currentTarget: TestTarget);

            // then YCalculator is called
            mockYCalculator.Verify(x => x.Get(It.IsAny<decimal>(), It.IsAny<decimal>()),
                Times.Once);
        }

        [TestMethod]
        public void That_TakeShot_CallsShotCounterForValidShot()
        {
            // given a game flow object
            IGameFlow serviceToTest = GetTestGameFlowObject(
                out Mock<ITargetGenerator> mockTargetGenerator,
                out Mock<IAngleValidator> mockAngleValidator,
                out Mock<IVelocityValidator> mockVelocityValidator,
                out Mock<IShotCounter> mockShotCounter,
                TestTarget, isAngleValid: true,
                isVelocityValid: true,
                shotCount: 1);

            // when TakeShot is called
            serviceToTest.TakeShot(currentShotCount: 0,
                angle: 45M, velocity: 10M, currentTarget: TestTarget);

            // then shot counter is called once
            mockShotCounter.Verify(x => x.AddShot(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void That_TakeShot_ReturnsFalseForValidShotMissed()
        {
            // given a game flow object
            var testStartTarget = new Coordinate(x: 1, y: 2);

            IGameFlow serviceToTest = GetTestGameFlowObject(
                out Mock<ITargetGenerator> mockTargetGenerator,
                out Mock<IAngleValidator> mockAngleValidator,
                out Mock<IVelocityValidator> mockVelocityValidator,
                out Mock<IShotCounter> mockShotCounter,
                out Mock<IXCoordinateCalculator> xCalculator,
                out Mock<IYCoordinateCalculator> yCalculator,
                testStartTarget, isAngleValid: true,
                isVelocityValid: true,
                shotCount: 1, xResult: 0, yResult: 1);

            // when TakeShot is called for vaid missed shot
            bool actual = serviceToTest.TakeShot(currentShotCount: 0,
                angle: 45M, velocity: 10M, currentTarget: testStartTarget);

            // then false is returned
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void That_TakeShot_ReturnsTrueForValidShotMissed()
        {
            // given a game flow object
            var testStartTarget = new Coordinate(x: 1, y: 2);

            IGameFlow serviceToTest = GetTestGameFlowObject(
                out Mock<ITargetGenerator> mockTargetGenerator,
                out Mock<IAngleValidator> mockAngleValidator,
                out Mock<IVelocityValidator> mockVelocityValidator,
                out Mock<IShotCounter> mockShotCounter,
                out Mock<IXCoordinateCalculator> xCalculator,
                out Mock<IYCoordinateCalculator> yCalculator,
                testStartTarget, isAngleValid: true,
                isVelocityValid: true,
                shotCount: 1, xResult: 1, yResult: 2);

            // when TakeShot is called for vaid hit shot
            bool actual = serviceToTest.TakeShot(currentShotCount: 0,
                angle: 45M, velocity: 10M, currentTarget: testStartTarget);

            // then true is returned
                Assert.IsTrue(actual);
        }

        #region Private methods

        private IGameFlow GetTestGameFlowObject(
             out Mock<ITargetGenerator> mockTargetGenerator,
             Coordinate newTarget)
        {
            return GetTestGameFlowObject(out mockTargetGenerator,
             out Mock<IAngleValidator> mockAngleValidator,
             newTarget,
             isAngleValid: true);
        }

        private IGameFlow GetTestGameFlowObject(
             out Mock<ITargetGenerator> mockTargetGenerator,
             out Mock<IAngleValidator> mockAngleValidator,
             Coordinate newTarget,
             bool isAngleValid)
        {
            return GetTestGameFlowObject(
                out mockTargetGenerator,
                out mockAngleValidator,
                out Mock<IVelocityValidator> mockVelocityValidator,
                out Mock<IShotCounter> mockShotCounter,
                newTarget,
                isAngleValid: isAngleValid,
                isVelocityValid: true,
                shotCount: 0);
        }

        private IGameFlow GetTestGameFlowObject(
             out Mock<ITargetGenerator> mockTargetGenerator,
             out Mock<IVelocityValidator> mockVelocityValidator,
             Coordinate newTarget,
             bool isVelocityValid)
        {
            return GetTestGameFlowObject(
                out mockTargetGenerator,
                out Mock<IAngleValidator> mockAngleValidator,
                out mockVelocityValidator,
                out Mock<IShotCounter> mockShotCounter,
                newTarget,
                isAngleValid: true,
                isVelocityValid: isVelocityValid,
                shotCount: 0);
        }

        private IGameFlow GetTestGameFlowObject(
             out Mock<ITargetGenerator> mockTargetGenerator,
             out Mock<IAngleValidator> mockAngleValidator,
             out Mock<IVelocityValidator> mockVelocityValidator,
             out Mock<IShotCounter> mockShotCounter,
             Coordinate newTarget,
             bool isAngleValid,
             bool isVelocityValid,
             int shotCount)
        {
            return GetTestGameFlowObject(
                out mockTargetGenerator,
                out mockAngleValidator,
                out mockVelocityValidator,
                out mockShotCounter,
                 out Mock<IXCoordinateCalculator> mockXCalculator,
                 out Mock<IYCoordinateCalculator> mockYCalculator,
                newTarget,
                isAngleValid: isAngleValid,
                isVelocityValid: isVelocityValid,
                shotCount: shotCount,
                xResult: 10,
                yResult: 15);
        }

        private IGameFlow GetTestGameFlowObject(
            out Mock<IXCoordinateCalculator> mockXCalculator,
            out Mock<IYCoordinateCalculator> mockYCalculator,
            int shotCount)
        {
            return GetTestGameFlowObject(
                out Mock<ITargetGenerator> mockTargetGenerator,
                out Mock<IAngleValidator> mockAngleValidator,
                out Mock<IVelocityValidator> mockVelocityValidator,
                out Mock<IShotCounter> mockShotCounter,
                out mockXCalculator,
                out mockYCalculator,
                TestTarget,
                isAngleValid: true,
                isVelocityValid: true,
                shotCount: shotCount,
                xResult: 10,
                yResult: 15);
        }

        private IGameFlow GetTestGameFlowObject(
             out Mock<ITargetGenerator> mockTargetGenerator,
             out Mock<IAngleValidator> mockAngleValidator,
             out Mock<IVelocityValidator> mockVelocityValidator,
             out Mock<IShotCounter> mockShotCounter,
             out Mock<IXCoordinateCalculator> mockXCalculator,
             out Mock<IYCoordinateCalculator> mockYCalculator,
             Coordinate newTarget,
             bool isAngleValid,
             bool isVelocityValid,
             int shotCount,
             int xResult,
             int yResult)
        {
            mockTargetGenerator = new Mock<ITargetGenerator>();
            mockTargetGenerator.Setup(x => x.GetTarget())
                .Returns(newTarget);

            mockAngleValidator = new Mock<IAngleValidator>();
            mockAngleValidator.Setup(x => x.GetIsValid(It.IsAny<decimal>()))
                .Returns(isAngleValid);

            mockAngleValidator.Setup(x => x.GetErrorMessage())
                .Returns(MOCK_ANGLE_ERROR_MSG);

            mockVelocityValidator = new Mock<IVelocityValidator>();
            mockVelocityValidator.Setup(x => x.GetIsValid(It.IsAny<decimal>()))
                .Returns(isVelocityValid);

            mockVelocityValidator.Setup(x => x.GetErrorMessage())
                .Returns(MOCK_VELOCITY_ERROR_MSG);

            mockShotCounter = new Mock<IShotCounter>();
            mockShotCounter.Setup(x => x.AddShot(It.IsAny<int>()));
            mockShotCounter.Setup(x => x.GetCount())
                .Returns(shotCount);

            mockXCalculator = new Mock<IXCoordinateCalculator>();
            mockXCalculator.Setup(x => x.Get(It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns(xResult);

            mockYCalculator = new Mock<IYCoordinateCalculator>();
            mockYCalculator.Setup(x => x.Get(It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns(yResult);

            IGameFlow serviceToTest = new GameFlow(
                targetGenerator: mockTargetGenerator.Object,
                angleValidator: mockAngleValidator.Object,
                velocityValidator: mockVelocityValidator.Object,
                shotCounter: mockShotCounter.Object,
                xCalculator: mockXCalculator.Object,
                yCalculator: mockYCalculator.Object);

            return serviceToTest;
        }

        #endregion Private methods
    }
}
