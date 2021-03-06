﻿using Flight_Planner.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flight_Planner.Core.Services
{
    public interface IFlightService : IEntityService<Flight>
    {
        Task<IEnumerable<Flight>> GetFlights();

        Task<ServiceResult> AddFlight(Flight flight);

        Task<ServiceResult> DeleteFlight(int id);

        Task<FlightServiceSearchResponse> SearchFlights(FlightServiceSearchRequest request);

        Task<bool> Exists(Flight flight);
    }
}