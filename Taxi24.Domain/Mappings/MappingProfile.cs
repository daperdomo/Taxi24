using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi24.Domain.Models;
using Taxi24.Domain.ViewModels;

namespace Taxi24.Domain.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Driver, DriverViewModel>().ReverseMap();
            CreateMap<Passenger, PassengerViewModel>().ReverseMap();
            CreateMap<Invoice, InvoiceViewModel>().ReverseMap();

            CreateMap<NewTripViewModel, Trip>();
            CreateMap<Trip, TripViewModel>()
                .ForMember(m => m.Passenger, m => m.MapFrom(mm => mm.Passenger.Name))
                .ForMember(m => m.Driver, m => m.MapFrom(mm => mm.Driver.Name))
                .ReverseMap();
        }
    }
}
