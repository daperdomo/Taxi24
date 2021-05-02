using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi24.Domain.Interfaces;
using Taxi24.Domain.Models;
using Taxi24.Domain.ViewModels;
using Taxi24.Infrastructure.Interfaces;

namespace Taxi24.Domain.Services
{
    public class TripService : ITripService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Trip> tripRepository;
        private readonly IRepository<Passenger> passengerRepositorys;

        private readonly IInvoiceService invoiceService;
        public TripService(IMapper _mapper,
            IRepository<Trip> _tripRepository,
            IRepository<Passenger> _passengerRepositorys,
            IInvoiceService _invoiceService)
        {
            mapper = _mapper;
            tripRepository = _tripRepository;
            passengerRepositorys = _passengerRepositorys;
            invoiceService = _invoiceService;
        }

        public bool ActiveTripExists(int PassengerId)
        {
            return tripRepository.Exists(m => m.PassengerId == PassengerId && m.End == null);
        }

        public Trip Complete(int PassengerId)
        {
            if (PassengerId == 0 || !passengerRepositorys.Exists(m => m.Id == PassengerId))
            {
                throw new ArgumentException("Passenger should be valid.");
            }
            else if (!ActiveTripExists(PassengerId))
            {
                throw new ArgumentException("There is not active trip for this passenger.");
            }
            try
            {
                var trip = tripRepository.Table.FirstOrDefault(m => m.PassengerId == PassengerId && m.End == null);
                tripRepository.context.Database.BeginTransaction();


                trip.End = DateTime.Now;
                tripRepository.Update(trip);
                invoiceService.Create(trip);
                tripRepository.SaveChanges();
                tripRepository.context.Database.CommitTransaction();
                return trip;
            }
            catch (Exception ex)
            {
                tripRepository.context.Database.RollbackTransaction();
                //The error should be loggged
#if DEBUG
                throw;
#else
                throw new ArgumentException("Error completing the trip.");
#endif
            }
        }

        public Trip Create(NewTripViewModel model)
        {
            var entity = mapper.Map<Trip>(model);
            entity.Start = DateTime.Now;
            tripRepository.Create(entity);
            tripRepository.SaveChanges();
            return entity;
        }

        public IEnumerable<TripViewModel> GetActiveTrips()
        {
            return tripRepository.Table
                .Include(m => m.Passenger)
                .Include(m => m.Driver)
                .Where(m => m.End == null)
                 .ToList()
                 .Select(m => mapper.Map<TripViewModel>(m));
        }
    }
}