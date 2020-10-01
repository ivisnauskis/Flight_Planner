using System.Web.Http;

namespace Flight_Planner.Web.Controllers
{
    [Route("api")]
    public class CustomerController : ApiController
    {
        [HttpGet]
        [Route("api/airports")]
        public IHttpActionResult Get(string search)
        {
            return Ok();
        }

        [HttpPost]
        [Route("api/flights/search")]
        public IHttpActionResult GetFlights(object req)
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/flights/{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok();
        }
    }
}