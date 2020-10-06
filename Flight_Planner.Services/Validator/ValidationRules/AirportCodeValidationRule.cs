using Flight_Planner.Core.Models;

namespace Flight_Planner.Services.Validator.ValidationRules
{
    public class AirportCodeValidationRule : IValidationRule
    {
        private string _error;
        public bool IsValid(Flight flight)
        {
            if (flight.To == null || flight.From == null) return false;

            _error = "";

            var isFromCodeValid = IsCodeValid(flight.From.AirportCode);
            var isToCodeValid = IsCodeValid(flight.To.AirportCode);

            _error += (isFromCodeValid ? "" : "[From] ") + (isToCodeValid ? "" : "[To] ");

            return isFromCodeValid && isToCodeValid;
        }

        private bool IsCodeValid(string code)
        {
            return !string.IsNullOrWhiteSpace(code) && code.Length >= 3;
        }

        public string ErrorMessage => $"{_error}Airport code is not valid.";
    }
}