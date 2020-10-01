using System.Web.Http;

namespace Flight_Planner.Web.Controllers
{
    public class TestingController : ApiController
    {
        [HttpPost]
        [Route("testing-api/clear")]
        public IHttpActionResult Clear()
        {
            return Ok();
        }
    }
}