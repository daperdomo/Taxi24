using System;
using System.Collections.Generic;
using Taxi24.Infrastructure.Interfaces;

#nullable disable

namespace Taxi24.Domain.Models
{
    public partial class Invoice : IBaseEntity
    {
        public int Id { get; set; }
        public int? TripId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Created { get; set; }

        public virtual Trip Trip { get; set; }
    }
}
