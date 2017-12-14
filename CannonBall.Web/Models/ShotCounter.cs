using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannonBall.Web.Models
{
    public class ShotCounter : IShotCounter
    {
        private int _count;

        public ShotCounter()
        {
            // intentionally left empty
        }

        public ShotCounter(int startCount)
        {
            _count = startCount;
        }

        public void AddShot()
        {
            _count++;
        }

        public int GetCount()
        {
            return _count;
        }
    }
}