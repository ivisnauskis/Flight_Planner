using System.Web.Http;
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
            return Ok();
        }

        [HttpGet]
        [Route("admin-api/flights/{Id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok();
        }

        [HttpPut]
        [Route("admin-api/flights/")]
        public IHttpActionResult Put(object flightRequest)
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