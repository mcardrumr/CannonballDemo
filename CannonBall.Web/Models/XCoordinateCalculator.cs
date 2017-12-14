using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannonBall.Web.Models
{
    public class XCoordinateCalculator : IXCoordinateCalculator
    {
        public int Get(decimal velocity, decimal degrees)
        {
            return Convert.ToInt32(Math.Round(
                Math.Cos(Convert.ToDouble(degrees)) * Convert.ToDouble(velocity), 0)
                );
        }
    }
}