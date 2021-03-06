﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannonBall.Web.Models
{
    public class XCoordinateCalculator : IXCoordinateCalculator
    {
        private IDegreeCalculator _degreeCalculator;

        public XCoordinateCalculator(IDegreeCalculator degreeCalculator)
        {
            _degreeCalculator = degreeCalculator;
        }

        public int Get(decimal velocity, decimal angle)
        {
            var radians = _degreeCalculator.GetDegrees(angle);

            return Convert.ToInt32(Math.Round(
                Math.Cos(Convert.ToDouble(radians)) * Convert.ToDouble(velocity), 0)
                );
        }
    }
}