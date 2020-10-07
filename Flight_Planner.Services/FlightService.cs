using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Data;
using Flight_Planner.Services.Validator.Interfaces;
using MoreLinq;

namespace Flight_Planner.Services
{
    public class FlightService : EntityService<Flight>, IFlightService
    {
        private readonly IValidationService _validationService;

        public FlightService(IFlightPlannerDbContext ctx, IValidationService validationService) : base(ctx)
        {
            _validationService = validationService;
        }

        public async Task<IEnumerable<Flight>> GetFlights()
        {
            return (await Query().ToListAsync())
                .DistinctBy(f => new {f.To, f.ArrivalTime, f.Carrier, f.DepartureTime, f.From}).ToList();
        }

        public async Task<ServiceResult> AddFlight(Flight flight)
        {
            var validationResponse = _validationService.ValidateFlight(flight);

            if (!validationResponse.Succeeded)
                return new ServiceResult(false) {Errors = validationResponse.Errors};

            if (await Exists(flight))
                return new ServiceResult(false) {Errors = new List<string> {"Flight must be unique!"}};

            return Create(flight);
        }

        public async Task<ServiceResult> DeleteFlight(int id)
        {
            var flightToDelete = await GetById(id);
            return flightToDelete == null ? new ServiceResult(false) : Delete(flightToDelete);
        }

        public async Task<FlightServiceSearchResponse> SearchFlights(FlightServiceSearchRequest request)
        {
            var validationResponse = _validationService.ValidateFlightSearchRequest(request);

            if (validationResponse.Succeeded)
            {
                var list = (await Query().Where(f => f.From.AirportCode == request.From &&
                                                     f.To.AirportCode == request.To &&
                                                     f.DepartureTime.Contains(request.DepartureDate)).ToListAsync())
                    .DistinctBy(f => new {f.To, f.ArrivalTime, f.Carrier, f.DepartureTime, f.From}).ToList();

                return new FlightServiceSearchResponse(true).Set(list);
            }

            return new FlightServiceSearchResponse(false).Set(validationResponse.Errors);
        }

        public async Task<bool> Exists(Flight flight)
        {
            if (_validationService.ValidateFlight(flight).Succeeded)
                return await Query().AnyAsync(
                    f => f.ArrivalTime == flight.ArrivalTime &&
                         f.Carrier == flight.Carrier &&
                         f.DepartureTime == flight.DepartureTime &&
                         f.From.AirportCode == flight.From.AirportCode &&
                         f.From.City == flight.From.City &&
                         f.From.Country == flight.From.Country &&
                         f.To.AirportCode == flight.To.AirportCode &&
                         f.To.City == flight.To.City &&
                         f.To.Country == flight.To.Country);

            return false;
        }
    }
}