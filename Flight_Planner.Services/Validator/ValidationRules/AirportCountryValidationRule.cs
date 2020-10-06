using Flight_Planner.Core.Models;

namespace Flight_Planner.Services.Validator.ValidationRules
{
    public class AirportCountryValidationRule : IValidationRule
    {
        private string _error;
        public bool IsValid(Flight flight)
        {
            if (flight.To == null || flight.From == null) return false;

            _error = "";

            var isToCountryValid = IsCountryValid(flight.To.Country);
            var isFromCountryValid = IsCountryValid(flight.From.Country);

            _error += (isFromCountryValid ? "" : "[From] ") + (isToCountryValid ? "" : "[To] ");

            return isToCountryValid && isFromCountryValid;
        }

        private bool IsCountryValid(string country)
        {
            return !string.IsNullOrEmpty(country) && country.Length >= 2;
        }

        public string ErrorMessage => $"{_error}Airport country is not valid.";
    }
}