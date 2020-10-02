using System.Web.Http;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Web.Attributes;

namespace Flight_Planner.Web.Controllers
{
    [BasicAuthentication]
    public class AdminController : BaseController
    {
        public AdminController(IFlightService flightService) : base(flightService)
        {
        }

        [HttpGet]
        [Route("admin-api/flights/")]
        public IHttpActionResult Get()
        {
            return Ok(FlightService.Get());
        }

        [HttpGet]
        [Route("admin-api/flights/{Id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok();
        }

        [HttpPut]
        [Route("admin-api/flights/")]
        public IHttpActionResult Put(Flight flightRequest)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("admin-api/flights/{Id}")]
        public IHttpActionResult DeleteFlights(int id)
        {
            return Ok();
        }
    }
}