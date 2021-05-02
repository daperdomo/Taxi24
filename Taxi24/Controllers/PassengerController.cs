using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24.Domain.Controllers;
using Taxi24.Domain.Models;
using Taxi24.Domain.ViewModels;

namespace Taxi24.Controllers
{
    public class PassengerController : CrudBaseController<Driver, DriverViewModel>
    {

        [HttpGet]
        public IActionResult Get3NearDrivers(double latitude, double longitude)
        {
            return Ok(UnitOfWork.DriverService.Get3NearDrivers(latitude, longitude, 3));
        }
    }
}
