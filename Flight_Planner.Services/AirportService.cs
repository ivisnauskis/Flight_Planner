using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Airport>> SearchAirports(string search)
        {
            search = search.ToLower().Trim();
            return await Query().Where(a => a.City.Contains(search) ||
                                      a.Country.Contains(search) ||
                                      a.AirportCode.Contains(search)).ToListAsync();
        }
    }
}