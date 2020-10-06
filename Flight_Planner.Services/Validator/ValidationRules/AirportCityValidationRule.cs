using Flight_Planner.Core.Models;

namespace Flight_Planner.Services.Validator.ValidationRules
{
    public class AirportCityValidationRule : IValidationRule
    {
        private string _error;
        public bool IsValid(Flight flight)
        {
            if (flight.To == null || flight.From == null) return false;

            _error = "";

            var isFromCityValid = !string.IsNullOrWhiteSpace(flight.To.City);
            var isToCityValid = !string.IsNullOrWhiteSpace(flight.From.City);

            _error += (isFromCityValid ? "" : "[From] ") + (isToCityValid ? "" : "[To] ");

            return isFromCityValid && isToCityValid;
        }

        public string ErrorMessage => $"{_error}Airport city is not valid";
    }
}