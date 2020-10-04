using Flight_Planner.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flight_Planner.Core.Services
{
    public interface IFlightService : IEntityService<Flight>
    {
        IEnumerable<Flight> GetFlights();

        ServiceResult AddFlight(Flight flight);

        Task<ServiceResult> DeleteFlight(int id);
    }
}