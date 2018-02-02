using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannonBall.Web.Models
{
    public class GameFlow : IGameFlow
    {
        private ITargetGenerator _targetGenerator;
        private IAngleValidator _angleValidator;
        private IVelocityValidator _velocityValidator;
        private IShotCounter _shotCounter;
        private IXCoordinateCalculator _xCalculator;
        private IYCoordinateCalculator _yCalculator;

        public GameFlow(ITargetGenerator targetGenerator,
            IAngleValidator angleValidator, 
            IVelocityValidator velocityValidator,
            IShotCounter shotCounter, 
            IXCoordinateCalculator xCalculator,
            IYCoordinateCalculator yCalculator)
        {
            _targetGenerator = targetGenerator;
            _angleValidator = angleValidator;
            _velocityValidator = velocityValidator;
            _shotCounter = shotCounter;
            _xCalculator = xCalculator;
            _yCalculator = yCalculator;
        }

        public int GetShotCount()
        {
            return _shotCounter.GetCount();
        }

        public Coordinate GetNewTarget()
        {
            return _targetGenerator.GetTarget();
        }

        public bool TakeShot(int currentShotCount, decimal angle, decimal velocity,
            Coordinate currentTarget)
        {
            if (!_angleValidator.GetIsValid(angle))
            {
                throw new ApplicationException(
                    _angleValidator.GetErrorMessage());
            }

            if (!_velocityValidator.GetIsValid(velocity))
            {
                throw new ApplicationException(
                    _velocityValidator.GetErrorMessage());
            }

            var xCalculated = _xCalculator.Get(velocity, angle);
            var yCalculated = _yCalculator.Get(velocity, angle);

            _shotCounter.AddShot(currentShotCount);

            if (xCalculated == currentTarget.X 
                && (yCalculated == currentTarget.Y))
            {
                return true;
            }

            return false;
        }
    }
}