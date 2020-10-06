using System;
using Flight_Planner.Core.Models;

namespace Flight_Planner.Services.Validator.ValidationRules
{
    public class DateTimeFormatValidationRule : IValidationRule
    {
        private string _error;
        public bool IsValid(Flight flight)
        {
            _error = "";

            var isArrTimeValid = DateTime.TryParse(flight.ArrivalTime, out _);
            var isDepTimeValid = DateTime.TryParse(flight.DepartureTime, out _);

            _error += (isArrTimeValid ? "" : "[Arrival] ") + (isDepTimeValid ? "" : "[Departure] ");

            return  isArrTimeValid && isDepTimeValid;
        }

        public string ErrorMessage => $"{_error}Date/Time format is not valid.";
    }
}