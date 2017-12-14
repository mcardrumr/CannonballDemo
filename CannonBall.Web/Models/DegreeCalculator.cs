using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannonBall.Web.Models
{
    public class DegreeCalculator : IDegreeCalculator
    {
        public decimal GetDegrees(decimal angle)
        {
            return angle * Math.Round(Convert.ToDecimal(Math.PI) / 180M, 10);
        }
    }
}