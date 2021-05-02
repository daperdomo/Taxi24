using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi24.Domain.ViewModels
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public int? TripId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Created { get; set; }
    }
}
