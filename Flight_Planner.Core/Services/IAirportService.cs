using System.Collections.Generic;
using System.Threading.Tasks;
using Flight_Planner.Core.Models;

namespace Flight_Planner.Core.Services
{
    public interface IAirportService : IEntityService<Airport>
    {
        Task<IEnumerable<Airport>> SearchAirports(string search);
    }
}