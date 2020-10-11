using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Web.Models;

namespace Flight_Planner.Web.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly IAirportService _airportService;

        public CustomerController(IFlightService flightService, IMapper mapper, IAirportService airportService) :
            base(flightService, mapper)
        {
            _airportService = airportService;
        }


        [HttpGet, Route("api/airports")]
        public async Task<IHttpActionResult> Get(string search)
        {
            var foundAirports = await _airportService.SearchAirports(search);
            return Ok(foundAirports.Select(a => Mapper.Map<AirportResponse>(a)));
        }

        [HttpPost, Route("api/flights/search")]
        public async Task<IHttpActionResult> GetFlights(FlightSearchRequest req)
        {
            var response = await FlightService.SearchFlights(Mapper.Map<FlightServiceSearchRequest>(req));

            if (response.Succeeded)
                return Ok(GetSearchResponse(response.FoundFlights));

            return new BadRequest(response.Errors, Request);
        }

        
        [HttpGet, Route("api/flights/{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var flight = await FlightService.GetById(id);

            if (flight == null)
                return NotFound();

            return Ok(Mapper.Map<FlightResponse>(flight));
        }

        private FlightSearchResponse GetSearchResponse(IEnumerable<Flight> flights)
        {
            return new FlightSearchResponse
            {
                Page = flights.Any() ? 1 : 0,
                Items = flights.Select(f => Mapper.Map<FlightResponse>(f)),
                TotalItems = flights.Count()
            };
        }
    }
}