using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi24.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IDriverService DriverService { get; }
        ITripService TripService { get; }
        IInvoiceService InvoiceService { get; }
    }
}
