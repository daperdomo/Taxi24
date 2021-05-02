using AutoMapper;
using System;
using Taxi24.Domain.Interfaces;
using Taxi24.Domain.Models;
using Taxi24.Domain.ViewModels;
using Taxi24.Infrastructure.Interfaces;

namespace Taxi24.Domain.Services
{
    public class InvoiceService : IInvoiceService
    {
        private const decimal PRICEPERMINUTES = 10;

        private readonly IRepository<Invoice> invoiceRepository;
        private readonly IMapper mapper;
        public InvoiceService(IRepository<Invoice> _invoiceRepository,
            IMapper _mapper)
        {
            invoiceRepository = _invoiceRepository;
            mapper = _mapper;
        }
        public void Create(Trip trip)
        {
            Invoice invoice = new Invoice
            {
                TripId = trip.Id,
                Created = DateTime.Now
            };
            var minutesDifference = (trip.End - trip.Start).Value.Minutes;
            invoice.Amount = minutesDifference * PRICEPERMINUTES;
            invoiceRepository.Create(invoice);
        }

        public InvoiceViewModel GetByTripId(int TripId)
        {
            return mapper.Map<InvoiceViewModel>(invoiceRepository.First(m => m.TripId == TripId));
        }
    }
}
