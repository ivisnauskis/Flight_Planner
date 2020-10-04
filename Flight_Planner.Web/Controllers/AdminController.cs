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
        public IHttpActionResult Get()
        {
            var flights = FlightService.GetFlights().ToList();
            if (flights.Count == 0) return NotFound();
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
        public IHttpActionResult Put(FlightRequest flightRequest)
        {
            if (!IsAddFlightRequestValid(flightRequest)) return BadRequest();

            var response = FlightService.AddFlight(Mapper.Map<Flight>(flightRequest));

            if (response.Succeeded) return Created($"{Request.RequestUri}{response.Entity.Id}", Mapper.Map<FlightResponse>(response.Entity));
            
            return Conflict();
        }

        [HttpDelete]
        [Route("admin-api/flights/{Id}")]
        public async Task<IHttpActionResult> DeleteFlights(int id)
        {
            await FlightService.DeleteFlight(id);
            return Ok();
        }

        public bool IsAddFlightRequestValid(FlightRequest flightRequest)
        {
            return IsFlightInfoValid(flightRequest) &&
                   IsAirportValid(flightRequest.From) &&
                   IsAirportValid(flightRequest.To) &&
                   !IsSameAirports(flightRequest.From, flightRequest.To);
        }

        // public bool IsSearchRequestValid(SearchFlightRequest req)
        // {
        //     return req != null &&
        //            req.To != null &&
        //            req.From != null &&
        //            req.DepartureDate != null &&
        //            DateTime.TryParse(req.DepartureDate, out _) &&
        //            !req.From.Equals(req.To);
        // }

        private bool IsSameAirports(AirportRequest from, AirportRequest to)
        {
            return string.Equals(from.Airport.Trim(), to.Airport.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        private bool IsFlightInfoValid(FlightRequest flightRequest)
        {
            return flightRequest != null &&
                   flightRequest.To != null &&
                   flightRequest.From != null &&
                   !flightRequest.Carrier.IsEmpty() &&
                   IsDatesValid(flightRequest.ArrivalTime, flightRequest.DepartureTime);
        }

        private bool IsDatesValid(string arrivalTime, string departureTime)
        {
            if (departureTime.IsEmpty() || arrivalTime.IsEmpty())
                return false;

            var arrTime = DateTime.Parse(arrivalTime);
            var depTime = DateTime.Parse(departureTime);

            return arrTime > depTime;
        }

        private bool IsAirportValid(AirportRequest airport)
        {
            return airport != null && !airport.Airport.IsEmpty() && !airport.City.IsEmpty() &&
                   !airport.Country.IsEmpty();
        }
    }
}