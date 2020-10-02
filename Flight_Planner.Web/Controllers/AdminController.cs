using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Web.Attributes;

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
            var flights = FlightService.Get().ToList();
            if (flights.Count == 0) return NotFound();
            return Ok(flights);
        }

        [HttpGet]
        [Route("admin-api/flights/{Id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var flight = await FlightService.GetById(id);
            if (flight == null) return NotFound();
            return Ok(flight);
        }

        [HttpPut]
        [Route("admin-api/flights/")]
        public IHttpActionResult Put(Flight flightRequest)
        {
            var response = FlightService.Create(flightRequest);

            if (response.Succeeded) return Created($"{Request.RequestUri}{response.Entity.Id}", response.Entity);

            if (!response.Succeeded) return BadRequest("Validation failed");

            return Conflict();
        }

        [HttpDelete]
        [Route("admin-api/flights/{Id}")]
        public async Task<IHttpActionResult> DeleteFlights(int id)
        {
            var flightToDelete = await FlightService.GetById(id);
            if (flightToDelete == null) return Ok();

            FlightService.Delete(flightToDelete);
            return Ok();
        }
    }
}