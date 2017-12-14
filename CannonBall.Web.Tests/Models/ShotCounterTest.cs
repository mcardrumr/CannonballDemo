using System;
using CannonBall.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CannonBall.Web.Tests.Models
{
    [TestClass]
    public class ShotCounterTest
    {
        [TestMethod]
        public void That_GetCount_Returns0ForNoShotsTaken()
        {
            // given a shot counter
            IShotCounter serviceToTest = new ShotCounter();

            // when no shots taken
            int actual = serviceToTest.GetCount();

            // assert - result is 0
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void That_GetCount_Returns6AfterShotTakenAndCounterWas5()
        {
            // given a shot counter starting at 5
            IShotCounter serviceToTest = new ShotCounter(
                startCount: 5);

            // when one shot taken
            serviceToTest.AddShot();
            int actual = serviceToTest.GetCount();

            // assert - result is 6
            Assert.AreEqual(6, actual);
        }

        [TestMethod]
        public void That_GetCount_Returns1AfterShotTakenAndCounterWas0()
        {
            // given a shot counter, starting at 0
            IShotCounter serviceToTest = new ShotCounter();

            // when one shot taken
            serviceToTest.AddShot();
            int actual = serviceToTest.GetCount();

            // assert - result is 1
            Assert.AreEqual(1, actual);
        }
    }
}
