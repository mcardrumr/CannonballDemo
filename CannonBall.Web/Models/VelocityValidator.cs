using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannonBall.Web.Models
{
    public class VelocityValidator : IVelocityValidator
    {
        public bool GetIsValid(decimal velocity)
        {
            if ((velocity >= 1) && (velocity <= 20))
            {
                return true;
            }
            return false;
        }
    }
}