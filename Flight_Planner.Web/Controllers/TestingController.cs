using System.Threading.Tasks;
using System.Web.Http;
using Flight_Planner.Core.Services;

namespace Flight_Planner.Web.Controllers
{
    public class TestingController : ApiController
    {
        private readonly ITestingService _testingService;

        public TestingController(ITestingService testingService)
        {
            _testingService = testingService;
        }

        [HttpPost]
        [Route("testing-api/clear")]
        public async Task<IHttpActionResult> Clear()
        {
            await _testingService.Clear();
            return Ok();
        }
    }
}