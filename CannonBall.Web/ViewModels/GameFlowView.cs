using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CannonBall.Web.ViewModels
{
    public class GameFlowView
    {
        public int TargetX { get; set; }
        public int TargetY { get; set; }

        [Required, Range(1, 90, 
            ErrorMessage = @"Enter a number between 1 and 90")]
        public decimal Angle { get; set; }

        [Required, Range(1, 20, 
            ErrorMessage = @"Enter a number between 1 and 20")]
        public decimal Velocity { get; set; }

        public bool WasTargetHit { get; set; }
        public int ShotsTaken { get; set; }
    }
}