using Flight_Planner.Core.Models;

namespace Flight_Planner.Services.Validator.Interfaces
{
    public interface IFlightValidator
    {
        ValidationResponse ValidateFlight(Flight flight);
    }
}