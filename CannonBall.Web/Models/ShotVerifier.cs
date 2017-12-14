using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannonBall.Web.Models
{
    public class ShotVerifier : IShotVerifier
    {
        public bool GetIsHit(Coordinate shot, Coordinate target)
        {
            if ((shot == null && (target != null))
                || (shot != null && (target == null)))
            {
                return false;
            };

            return (shot.X == target.X) && (shot.Y == target.Y);
        }
    }
}