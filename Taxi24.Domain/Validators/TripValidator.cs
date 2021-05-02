using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi24.Domain.Models;
using Taxi24.Domain.ViewModels;
using Taxi24.Infrastructure.Interfaces;

namespace Taxi24.Domain.Validators
{
    public class TripValidator : AbstractValidator<NewTripViewModel>
    {
        public TripValidator(IRepository<Driver> driverRepository, IRepository<Passenger> passengerRepository)
        {
            RuleFor(m => m.DriverId).Must(driverId => driverId > 0 && driverRepository.Exists(m => m.Id == driverId))
                .WithMessage("The driver should be valid.");

            RuleFor(m => m.PassengerId).Must(passengerId => passengerId > 0 && passengerRepository.Exists(m => m.Id == passengerId))
                .WithMessage("The passenger should be valid.");
        }
    }
}
