using System;
using CannonBall.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CannonBall.Web.Tests.Models
{
    [TestClass]
    public class ShotVerifierTest
    {
        [TestMethod]
        public void That_GetIsHit_ReturnsTrueForShotX5Y5AndTargetX5Y5()
        {
            // given a verifier
            IShotVerifier serviceToTest = new ShotVerifier();

            // when shot of x=5, y=5 and target x=5, y=5
            var testShot = new Coordinate(x: 5, y: 5);
            var testTarget = new Coordinate(x: 5, y: 5);

            bool actual = serviceToTest.GetIsHit(
                shot: testShot, target: testTarget);

            // assert - returns true
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void That_GetIsHit_ReturnsFalseForShotX5Y6AndTargetX5Y5()
        {
            // given a verifier
            IShotVerifier serviceToTest = new ShotVerifier();

            // when shot of x=5, y=6 and target x=5, y=5
            var testShot = new Coordinate(x: 5, y: 6);
            var testTarget = new Coordinate(x: 5, y: 5);

            bool actual = serviceToTest.GetIsHit(
                shot: testShot, target: testTarget);

            // assert - returns false
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void That_GetIsHit_ReturnsFalseForShotX6Y5AndTargetX5Y5()
        {
            // given a verifier
            IShotVerifier serviceToTest = new ShotVerifier();

            // when shot of x=6, y=5 and target x=5, y=5
            var testShot = new Coordinate(x: 6, y: 5);
            var testTarget = new Coordinate(x: 5, y: 5);

            bool actual = serviceToTest.GetIsHit(
                shot: testShot, target: testTarget);

            // assert - returns false
            Assert.IsFalse(actual);
        }
    }
}
