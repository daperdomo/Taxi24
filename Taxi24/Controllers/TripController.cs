using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24.Domain.Controllers;
using Taxi24.Domain.Models;
using Taxi24.Domain.ViewModels;
using Taxi24.Infrastructure.Interfaces;

namespace Taxi24.Controllers
{
    public class TripController : CrudBaseController<Trip, TripViewModel>
    {
        [HttpGet]
        public IActionResult GetActiveTrips()
        {
            return Ok(UnitOfWork.TripService.GetActiveTrips());
        }

        [HttpPost]
        public IActionResult NewTrip([FromBody] NewTripViewModel model)
        {
            if (UnitOfWork.TripService.ActiveTripExists(model.PassengerId))
            {
                return BadRequest("There is an active trip.");
            }
            return Ok(UnitOfWork.TripService.Create(model));
        }

        [HttpPost]
        public IActionResult Complete(int PassengerId)
        {
            try
            {
                var trip = UnitOfWork.TripService.Complete(PassengerId);
                var invoice = UnitOfWork.InvoiceService.GetByTripId(trip.Id);
                return Ok(invoice);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
