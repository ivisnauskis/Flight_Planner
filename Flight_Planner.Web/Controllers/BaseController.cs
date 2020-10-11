using System.Web.Http;
using AutoMapper;
using Flight_Planner.Core.Services;

namespace Flight_Planner.Web.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected readonly IFlightService FlightService;
        protected readonly IMapper Mapper;

        protected BaseController(IFlightService flightService, IMapper mapper)
        {
            FlightService = flightService;
            Mapper = mapper;
        }
    }
}