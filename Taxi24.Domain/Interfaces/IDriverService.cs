using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi24.Domain.ViewModels;

namespace Taxi24.Domain.Interfaces
{
    public interface IDriverService
    {
        IEnumerable<DriverViewModel> GetAvailables();
    }
}
