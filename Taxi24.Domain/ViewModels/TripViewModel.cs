using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi24.Domain.ViewModels
{
    public class TripViewModel
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public string Passenger { get; set; }
        public int DriverId { get; set; }
        public string Driver { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
}
