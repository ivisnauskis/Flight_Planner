using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;

namespace Flight_Planner.Services.Validator.Interfaces
{
    public interface IValidationService
    {
        ValidationResponse ValidateFlight(Flight flight);

        ValidationResponse ValidateFlightSearchRequest(FlightServiceSearchRequest request);
    }
}