using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannonBall.Web.Models
{
    public class GameFlow : IGameFlow
    {
        private ITargetGenerator _targetGenerator;

        public GameFlow(ITargetGenerator targetGenerator)
        {
            _targetGenerator = targetGenerator;
        }

        public int GetShotCount()
        {
            throw new NotImplementedException();
        }

        public Coordinate Start()
        {
            throw new NotImplementedException();
        }

        public bool TakeShot(decimal angle, decimal velocity)
        {
            throw new NotImplementedException();
        }
    }
}