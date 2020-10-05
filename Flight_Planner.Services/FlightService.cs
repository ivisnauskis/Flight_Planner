using System;
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

        public async Task<IEnumerable<Flight>> GetFlights()
        {
            return await Query().ToListAsync();
        }

        public async Task<ServiceResult> AddFlight(Flight flight)
        {
            if (await Exists(flight)) 
                return new ServiceResult(false) { Errors = new List<string>() { "Flight must be unique!"}};
            
            return Create(flight);
        }


        public async Task<ServiceResult> DeleteFlight(int id)
        {
            var flightToDelete = await GetById(id);
            return flightToDelete == null ? new ServiceResult(false) : Delete(flightToDelete);
        }

        public async Task<IEnumerable<Flight>> SearchFlights(string from, string to, string departureDate)
        {
            return await Query().Where(f => f.From.AirportCode == from &&
                                            f.To.AirportCode == to &&
                                            f.DepartureTime.Contains(departureDate)).ToListAsync();
        }

        private async Task<bool> Exists(Flight flight)
        {
            return await Query().AnyAsync(f => f.ArrivalTime == flight.ArrivalTime &&
                                               f.Carrier == flight.Carrier &&
                                               f.DepartureTime == flight.DepartureTime &&
                                               f.From.AirportCode == flight.From.AirportCode &&
                                               f.From.City == flight.From.City &&
                                               f.From.Country == flight.From.Country &&
                                               f.To.AirportCode == flight.To.AirportCode &&
                                               f.To.City == flight.To.City &&
                                               f.To.Country == flight.To.Country);
        }
    }
}