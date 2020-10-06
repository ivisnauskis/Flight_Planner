using Flight_Planner.Core.Models;

namespace Flight_Planner.Services.Validator
{
    public interface IValidationRule
    {
        bool IsValid(Flight flight);
        string ErrorMessage { get; }
    }
}