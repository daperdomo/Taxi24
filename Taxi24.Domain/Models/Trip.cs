using System;
using System.Collections.Generic;

#nullable disable

namespace Taxi24.Domain.Models
{
    public partial class Trip
    {
        public Trip()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public int PassengerId { get; set; }
        public int DriverId { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual Passenger Passenger { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
