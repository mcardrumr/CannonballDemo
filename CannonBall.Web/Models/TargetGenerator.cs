using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannonBall.Web.Models
{
    public class TargetGenerator : ITargetGenerator
    {
        private INumberGenerator _numberGenerator;

        public TargetGenerator(INumberGenerator numberGenerator)
        {
            _numberGenerator = numberGenerator;
        }

        public Coordinate GetTarget(int x, int y)
        {
            return new Coordinate(x, y);
        }

        public Coordinate GetTarget()
        {
            var x = _numberGenerator.GetNumber();
            var y = _numberGenerator.GetNumber();

            return new Coordinate(x, y);
        }
    }
}