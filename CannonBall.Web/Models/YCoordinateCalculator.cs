using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannonBall.Web.Models
{
    public class YCoordinateCalculator : IYCoordinateCalculator
    {
        private IDegreeCalculator _degreeCalculator;

        public YCoordinateCalculator(IDegreeCalculator degreeCalculator)
        {
            _degreeCalculator = degreeCalculator;
        }

        public int Get(decimal velocity, decimal angle)
        {
            var radians = _degreeCalculator.GetDegrees(angle);

            return Convert.ToInt32(Math.Round(
                Math.Sin(Convert.ToDouble(radians)) * Convert.ToDouble(velocity), 0)
                );
        }
    }
}