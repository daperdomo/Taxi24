﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24.Domain.Controllers;
using Taxi24.Domain.Models;
using Taxi24.Domain.ViewModels;

namespace Taxi24.Controllers
{
    public class DriverController : CrudBaseController<Driver, DriverViewModel>
    {
        public IActionResult GetAvailables()
        {
            return Ok(UnitOfWork.DriverService.GetAvailables());
        }
    }
}
