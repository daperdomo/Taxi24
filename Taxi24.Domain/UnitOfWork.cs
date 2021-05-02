using System;
using Taxi24.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Taxi24.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IServiceProvider serviceProvider;

        public UnitOfWork(IServiceProvider _serviceProvider)
        {
            serviceProvider = _serviceProvider;
        }

        private IDriverService _DriverService;

        public IDriverService DriverService
        {
            get
            {
                return _DriverService = _DriverService ?? serviceProvider.GetService<IDriverService>();
            }
        }


        private ITripService _TripService;

        public ITripService TripService
        {
            get
            {
                return _TripService = _TripService ?? serviceProvider.GetService<ITripService>();
            }
        }

        private IInvoiceService _InvoiceService;

        public IInvoiceService InvoiceService
        {
            get
            {
                return _InvoiceService = _InvoiceService ?? serviceProvider.GetService<IInvoiceService>();
            }
        }
    }
}
