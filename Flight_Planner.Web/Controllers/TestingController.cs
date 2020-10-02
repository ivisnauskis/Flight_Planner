using System.Web.Http;
using AutoMapper;
using Flight_Planner.Core.Services;

namespace Flight_Planner.Web.Controllers
{
    public class TestingController : BaseController
    {
        private readonly IAirportService _airportService;

        public TestingController(IFlightService flightService, IMapper mapper, IAirportService airportService) : base(
            flightService, mapper)
        {
            _airportService = airportService;
        }

        [HttpPost]
        [Route("testing-api/clear")]
        public IHttpActionResult Clear()
        {
            var a = FlightService.Get();
            var b = _airportService.Get();

            foreach (var flight in a) FlightService.Delete(flight);
            foreach (var airport in b) _airportService.Delete(airport);

            return Ok();
        }
    }
}