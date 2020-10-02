using System.Web.Http;
using AutoMapper;
using Flight_Planner.Core.Services;

namespace Flight_Planner.Web.Controllers
{
    public class TestingController : BaseController
    {
        public TestingController(IFlightService flightService, IMapper mapper) : base(flightService, mapper)
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