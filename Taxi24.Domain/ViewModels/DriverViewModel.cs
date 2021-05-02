using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi24.Domain.ViewModels
{
    public class DriverViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Available { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
