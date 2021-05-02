using Taxi24.Domain.Models;
using Taxi24.Domain.ViewModels;

namespace Taxi24.Domain.Interfaces
{
    public interface IInvoiceService
    {
        void Create(Trip trip);
        InvoiceViewModel GetByTripId(int TripId);
    }
}
