using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi24.Domain.Interfaces;
using Taxi24.Domain.Models;
using Taxi24.Domain.ViewModels;
using Taxi24.Infrastructure.Interfaces;

namespace Taxi24.Domain.Services
{
    public class DriverService : IDriverService
    {
        private readonly IRepository<Driver> driverRepository;
        private readonly IMapper mapper;

        public DriverService(
            IRepository<Driver> _driverRepository,
            IMapper _mapper)
        {
            driverRepository = _driverRepository;
            mapper = _mapper;
        }

        public IEnumerable<DriverViewModel> GetAvailables()
        {
            return driverRepository.Table.Where(m => m.Available == true)
                .ToList()
                .Select(m => mapper.Map<DriverViewModel>(m));
        }

        public IEnumerable<DriverViewModel> GetAvailablesInRadious(double latitude, double longitude, int km)
        {
            throw new NotImplementedException();
        }
    }
}
