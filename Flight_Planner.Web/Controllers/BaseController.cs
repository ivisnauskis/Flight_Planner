using System.Web.Http;
using Flight_Planner.Core.Services;

namespace Flight_Planner.Web.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected readonly IFlightService FlightService;

        protected BaseController(IFlightService flightService)
        {
            FlightService = flightService;
        }
    }
}