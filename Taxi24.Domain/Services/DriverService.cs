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
        private readonly IDistanceHelper distanceHelper;

        public DriverService(
            IRepository<Driver> _driverRepository,
            IMapper _mapper,
            IDistanceHelper _distanceHelper)
        {
            driverRepository = _driverRepository;
            mapper = _mapper;
            distanceHelper = _distanceHelper;
        }

        public IEnumerable<DriverViewModel> GetAvailables()
        {
            return driverRepository.Table.Where(m => m.Available == true)
                .ToList()
                .Select(m => mapper.Map<DriverViewModel>(m));
        }

        public IEnumerable<DriverViewModel> GetAvailablesInRadious(double latitude, double longitude, int km)
        {
            var drivers = GetAvailables();
            return drivers.Where(m =>
            m.Latitude != null
            && m.Longitude != null
            && distanceHelper.IsNear(latitude, longitude, m.Latitude ?? 0, m.Longitude ?? 0, km)); ;
        }
    }
}
