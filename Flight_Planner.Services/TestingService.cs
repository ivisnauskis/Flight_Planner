using System.Threading.Tasks;
using Flight_Planner.Core.Services;
using Flight_Planner.Data;

namespace Flight_Planner.Services
{
    public class TestingService : ITestingService
    {
        private readonly IFlightPlannerDbContext _ctx;

        public TestingService(IFlightPlannerDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Clear()
        {
            _ctx.Flights.RemoveRange(_ctx.Flights);
            _ctx.Airports.RemoveRange(_ctx.Airports);
            await _ctx.SaveChangesAsync();
        }
    }
}