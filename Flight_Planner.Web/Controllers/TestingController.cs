using System.Web.Http;
using Flight_Planner.Core.Services;

namespace Flight_Planner.Web.Controllers
{
    public class TestingController : BaseController
    {
        public TestingController(IFlightService flightService) : base(flightService)
        {
        }

        [HttpPost]
        [Route("testing-api/clear")]
        public IHttpActionResult Clear()
        {
            return Ok();
        }
    }
}