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
            return (shot.X == target.X) && (shot.Y == target.Y);
        }
    }
}