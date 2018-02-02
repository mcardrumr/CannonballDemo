using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonBall.Web.Models
{
    public interface IGameFlow
    {
        Coordinate GetNewTarget();

        bool TakeShot(int currentShotCount, decimal angle, decimal velocity, 
            Coordinate currentTarget);

        int GetShotCount();
    }
}
