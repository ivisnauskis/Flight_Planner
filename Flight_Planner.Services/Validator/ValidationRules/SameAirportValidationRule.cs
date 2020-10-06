using System;
using Flight_Planner.Core.Models;

namespace Flight_Planner.Services.Validator.ValidationRules
{
    public class SameAirportValidationRule : IValidationRule
    {
        public bool IsValid(Flight flight)
        {
            if (flight.To == null || flight.From == null) return false;
            return !string.Equals(flight.To.AirportCode, flight.From.AirportCode, StringComparison.OrdinalIgnoreCase);
        }

        public string ErrorMessage => "Origin and destination airports cannot be same.";
    }
}