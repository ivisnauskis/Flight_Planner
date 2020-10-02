using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Data;

namespace Flight_Planner.Services
{
    public class FlightService : EntityService<Flight>
    {
        public FlightService(IFlightPlannerDbContext ctx) : base(ctx)
        {
        }
    }
}