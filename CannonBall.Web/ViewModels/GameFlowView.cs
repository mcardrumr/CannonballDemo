using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CannonBall.Web.ViewModels
{
    public class GameFlowView
    {
        [Display(Name = "Target - X")]
        public int TargetX { get; set; }

        [Display(Name = "Target - Y")]
        public int TargetY { get; set; }

        [Required, Range(1, 90, 
            ErrorMessage = @"Enter a number between 1 and 90")]
        public decimal Angle { get; set; }

        [Required, Range(1, 20, 
            ErrorMessage = @"Enter a number between 1 and 20")]
        public decimal Velocity { get; set; }

        [Display(Name = "Hit?")]
        public bool WasTargetHit { get; set; }

        [Display(Name = "Shots Taken")]
        public int ShotsTaken { get; set; }
    }
}