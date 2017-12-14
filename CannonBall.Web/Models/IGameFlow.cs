using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonBall.Web.Models
{
    public interface IGameFlow
    {
        Coordinate Start();

        bool TakeShot(decimal angle, decimal velocity);

        int GetShotCount();
    }
}
