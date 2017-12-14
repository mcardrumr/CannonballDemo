﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannonBall.Web.Models
{
    public class RangeValidator : IRangeValidator
    {
        public bool GetIsValid(decimal angle)
        {
            if ((angle >= 1M) && (angle <= 90M))
            {
                return true;
            }
            return false;
        }
    }
}