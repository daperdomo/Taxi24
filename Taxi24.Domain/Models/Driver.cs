using System;
using System.Collections.Generic;

#nullable disable

namespace Taxi24.Domain.Models
{
    public partial class Driver
    {
        public Driver()
        {
            Trips = new HashSet<Trip>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Available { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
    }
}
