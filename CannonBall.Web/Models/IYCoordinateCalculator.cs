using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonBall.Web.Models
{
    public interface IYCoordinateCalculator
    {
        int Get(decimal velocity, decimal angle);
    }
}
