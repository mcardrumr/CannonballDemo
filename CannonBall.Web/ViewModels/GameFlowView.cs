using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannonBall.Web.ViewModels
{
    public class GameFlowView
    {
        public int TargetX { get; set; }
        public int TargetY { get; set; }

        public decimal Angle { get; set; }
        public decimal Velocity { get; set; }

        public bool WasTargetHit { get; set; }
        public int ShotsTaken { get; set; }
    }
}