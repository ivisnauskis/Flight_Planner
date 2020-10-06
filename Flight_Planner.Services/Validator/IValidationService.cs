using Flight_Planner.Core.Models;

namespace Flight_Planner.Services.Validator
{
    public interface IValidationService
    {
        ValidationResponse ValidateFlight(Flight flight);
    }
}