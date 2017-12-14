using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannonBall.Web.Models
{
    public class NumberGenerator : INumberGenerator
    {
        private const int MIN_INT = 1;
        private const int MAX_INT = 10;
        private Random _random;

        public NumberGenerator()
        {
            _random = new Random();
        }

        public int GetNumber()
        {
            return _random.Next(MIN_INT, MAX_INT);
        }
    }
}