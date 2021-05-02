using System.Collections.Generic;
using Taxi24.Domain.Models;
using Taxi24.Domain.ViewModels;

namespace Taxi24.Domain.Interfaces
{
    public interface ITripService
    {
        IEnumerable<TripViewModel> GetActiveTrips();
        Trip Create(NewTripViewModel model);
        Trip Complete(int PassengerId);
        bool ActiveTripExists(int PassengerId);
    }
}
