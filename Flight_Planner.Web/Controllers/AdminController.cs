using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.WebPages;
using AutoMapper;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Web.Attributes;
using Flight_Planner.Web.Models;

namespace Flight_Planner.Web.Controllers
{
    [BasicAuthentication]
    public class AdminController : BaseController
    {
        public AdminController(IFlightService flightService, IMapper mapper) : base(flightService, mapper)
        {
        }

        [HttpGet]
        [Route("admin-api/flights/")]
        public async Task<IHttpActionResult> Get()
        {
            var flights = await FlightService.GetFlights();
            return Ok(flights.Select(f => Mapper.Map<FlightResponse>(f)).ToList());
        }

        [HttpGet]
        [Route("admin-api/flights/{Id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var flight = await FlightService.GetById(id);
            if (flight == null) return NotFound();

            return Ok(Mapper.Map<FlightResponse>(flight));
        }

        [HttpPut]
        [Route("admin-api/flights/")]
        public async Task<IHttpActionResult> Put(FlightRequest flightRequest)
        {
            if (!IsAddFlightRequestValid(flightRequest)) return BadRequest();

            var response = await FlightService.AddFlight(Mapper.Map<Flight>(flightRequest));

            if (response.Succeeded)
                return Created($"{Request.RequestUri}/{response.Entity.Id}",
                    Mapper.Map<FlightResponse>(response.Entity));

            return Conflict();
        }

        [HttpDelete]
        [Route("admin-api/flights/{Id}")]
        public async Task<IHttpActionResult> DeleteFlights(int id)
        {
            await FlightService.DeleteFlight(id);
            return Ok();
        }

        private static bool IsAddFlightRequestValid(FlightRequest flightRequest)
        {
            return IsFlightInfoValid(flightRequest) &&
                   IsAirportValid(flightRequest.From) &&
                   IsAirportValid(flightRequest.To) &&
                   !IsSameAirports(flightRequest.From, flightRequest.To);
        }

        private static bool IsSameAirports(AirportRequest from, AirportRequest to)
        {
            return string.Equals(from.Airport.Trim(), to.Airport.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        private static bool IsFlightInfoValid(FlightRequest flightRequest)
        {
            return flightRequest != null &&
                   flightRequest.To != null &&
                   flightRequest.From != null &&
                   !flightRequest.Carrier.IsEmpty() &&
                   IsDatesValid(flightRequest.ArrivalTime, flightRequest.DepartureTime);
        }

        private static bool IsDatesValid(string arrivalTime, string departureTime)
        {
            if (departureTime.IsEmpty() || arrivalTime.IsEmpty())
                return false;

            var arrTime = DateTime.Parse(arrivalTime);
            var depTime = DateTime.Parse(departureTime);

            return arrTime > depTime;
        }

        private static bool IsAirportValid(AirportRequest airport)
        {
            return airport != null && !airport.Airport.IsEmpty() && !airport.City.IsEmpty() &&
                   !airport.Country.IsEmpty();
        }
    }
}