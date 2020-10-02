using System.Web.Http;
using Flight_Planner.Core.Models;
using Flight_Planner.Data;
using Flight_Planner.Services;
using Flight_Planner.Web.Attributes;

namespace Flight_Planner.Web.Controllers
{
    [BasicAuthentication]
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("admin-api/flights/")]
        public IHttpActionResult Get()
        {
            var a = new FlightService(new FlightPlannerDbContext());
            var b = a.Get();
            return Ok(b);
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
            var a = new FlightService(new FlightPlannerDbContext());
            a.Create(flightRequest);
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