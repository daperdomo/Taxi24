using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi24.Domain.ViewModels;

namespace Taxi24.Domain.Interfaces
{
    public interface IDriverService
    {
        /// <summary>
        /// Get all available drivers
        /// </summary>
        /// <returns></returns>
        IEnumerable<DriverViewModel> GetAvailables();

        /// <summary>
        /// Get all available drivers in a specific radious in KM
        /// </summary>
        /// <param name="latitude">Latitude</param>
        /// <param name="longitude">Longitude</param>
        /// <param name="km">Radious in KM</param>
        /// <returns>Driver availables in radious</returns>
        IEnumerable<DriverViewModel> GetAvailablesInRadious(double latitude, double longitude, int km);
        /// <summary>
        /// Get the 3 nearest availables drivers
        /// </summary>
        /// <param name="latitude">Latitude</param>
        /// <param name="longitude">Longitude</param>
        /// <param name="km">Radious in KM</param>
        /// <returns>Driver availables neartest in radious</returns>
        IEnumerable<DriverViewModel> Get3NearDrivers(double latitude, double longitude, int km);
    }
}
