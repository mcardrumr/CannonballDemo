using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannonBall.Web.Models
{
    public class AngleValidator : IAngleValidator
    {
        public bool GetIsValid(decimal angle)
        {
            if ((angle >= 1M) && (angle <= 90M))
            {
                return true;
            }
            return false;
        }

        public string GetErrorMessage()
        {
            return @"enter angle between 1 and 90";
        }
    }
}