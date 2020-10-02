using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Data;

namespace Flight_Planner.Services
{
    public class AirportService : EntityService<Airport>, IAirportService
    {
        public AirportService(IFlightPlannerDbContext ctx) : base(ctx)
        {
        }
    }
}