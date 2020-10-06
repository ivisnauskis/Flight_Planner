using Flight_Planner.Core.Models;

namespace Flight_Planner.Services.Validator.ValidationRules
{
    public class CarrierValidationRule : IValidationRule
    {
        public bool IsValid(Flight flight)
        {
            return !string.IsNullOrEmpty(flight.Carrier);
        }

        public string ErrorMessage => "Carrier is not valid.";
    }
}