using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Flight_Planner.Core.Services;
using Flight_Planner.Web.Models;

namespace Flight_Planner.Web.Controllers
{
    [Route("api")]
    public class CustomerController : BaseController
    {
        private readonly IAirportService _airportService;

        public CustomerController(IFlightService flightService, IMapper mapper, IAirportService airportService) : base(
            flightService, mapper)
        {
            _airportService = airportService;
        }

        [HttpGet]
        [Route("api/airports")]
        public IHttpActionResult Get(string search)
        {
            var foundAirports = _airportService.SearchAirports(search);
            return Ok(foundAirports.Select(a => Mapper.Map<AirportResponse>(a)));
        }

        [HttpPost]
        [Route("api/flights/search")]
        public async Task<IHttpActionResult> GetFlights(FlightSearchRequest req)
        {
            if (!IsSearchRequestValid(req)) return BadRequest();

            var flights = await FlightService.SearchFlights(req.From.Trim(), req.To.Trim(), req.DepartureDate.Trim());

            var response = new FlightSearchResponse
            {
                Page = flights.Any() ? 1 : 0,
                Items = flights.Select(f => Mapper.Map<FlightResponse>(f)),
                TotalItems = flights.Count()
            };

            return Ok(response);
        }

        [HttpGet]
        [Route("api/flights/{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var flight = await FlightService.GetById(id);
            if (flight == null) return NotFound();
            return Ok(Mapper.Map<FlightResponse>(flight));
        }

        private bool IsSearchRequestValid(FlightSearchRequest req)
        {
            return req != null &&
                   req.To != null &&
                   req.From != null &&
                   req.DepartureDate != null &&
                   DateTime.TryParse(req.DepartureDate, out _) &&
                   !req.From.Equals(req.To);
        }
    }
}