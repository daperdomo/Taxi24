using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi24.Domain.Interfaces;
namespace Taxi24.Domain.Helpers
{
    public class DistanceHelper : IDistanceHelper
    {
        public bool IsNear(double latitudFrom, double longitudeFrom, double latitudTo, double longitudeTo, int km)
        {
            var d3 = 6371 * Math.Acos(Math.Cos(DegreeToRadian((90 - latitudFrom)))
                    * Math.Cos(DegreeToRadian((90 - latitudTo)))
                    + Math.Sin(DegreeToRadian((90 - latitudFrom)))
                    * Math.Sin(DegreeToRadian((90 - latitudTo)))
                    * Math.Cos(DegreeToRadian((longitudeFrom - longitudeTo))));
            return d3 <= km;
        }

        private double DegreeToRadian(double angle)
        {
            double Radians = Math.PI * angle / 180.0;
            return Radians;
        }
    }
}
