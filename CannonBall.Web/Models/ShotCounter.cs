using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannonBall.Web.Models
{
    public class ShotCounter : IShotCounter
    {
        private int _count;

        public void AddShot(int currentShotCount)
        {
            _count = ++currentShotCount;
        }

        public int GetCount()
        {
            return _count;
        }
    }
}