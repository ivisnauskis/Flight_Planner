using AutoMapper;
using Flight_Planner.Core.Models;
using Flight_Planner.Web.Models;


namespace Flight_Planner.Web
{
    public class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FlightRequest, Flight>();
                cfg.CreateMap<Flight, FlightResponse>();

                cfg.CreateMap<AirportRequest, Airport>()
                    .ForMember(d => d.AirportCode,
                        s => s.MapFrom(p => p.Airport.Trim()))
                    .ForMember(d => d.Id,
                        s => s.Ignore());

                cfg.CreateMap<Airport, AirportResponse>()
                    .ForMember(m => m.Airport,
                        opt =>
                            opt.MapFrom(s => s.AirportCode));
            });
            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}