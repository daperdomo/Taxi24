using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi24.Domain.Interfaces
{
    public interface IDistanceHelper
    {
        bool IsNear(double latitudFrom, double longitudeFrom, double latitudTo, double longitudeTo, int km);
        double GetDistance(double latitudFrom, double longitudeFrom, double latitudTo, double longitudeTo);
    }
}
