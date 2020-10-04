using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Data;

namespace Flight_Planner.Services
{
    public class FlightService : EntityService<Flight>, IFlightService
    {
        public FlightService(IFlightPlannerDbContext ctx) : base(ctx)
        {
        }

        public IEnumerable<Flight> GetFlights()
        {
            return Get<Flight>();
        }

        public ServiceResult AddFlight(Flight flight)
        {
            if (Exists(flight))
            {
                var response = new ServiceResult(false);
                response.Set(new List<string>() {"Flight must be unique!"});
                return response;
            }

            return Create(flight);
        }

        private bool Exists(Flight flight)
        {
            return Query().Any(f => f.ArrivalTime == flight.ArrivalTime &&
                                    f.Carrier == flight.Carrier &&
                                    f.DepartureTime == flight.DepartureTime &&
                                    f.From.AirportCode == flight.From.AirportCode &&
                                    f.From.City == flight.From.City &&
                                    f.From.Country == flight.From.Country &&
                                    f.To.AirportCode == flight.To.AirportCode &&
                                    f.To.City == flight.To.City &&
                                    f.To.Country == flight.To.Country);
        }


        public async Task<ServiceResult> DeleteFlight(int id)
        {
            var flightToDelete = await GetById(id);
            return flightToDelete == null ? new ServiceResult(false) : Delete(flightToDelete);
        }
    }
}