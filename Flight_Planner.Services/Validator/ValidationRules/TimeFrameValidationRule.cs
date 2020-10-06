using System;
using Flight_Planner.Core.Models;

namespace Flight_Planner.Services.Validator.ValidationRules
{
    public class TimeFrameValidationRule : IValidationRule
    {
        public bool IsValid(Flight flight)
        {
            return IsTimeFrameValid(flight.ArrivalTime, flight.DepartureTime);
        }

        private bool IsTimeFrameValid(string arrivalTime, string departureTime)
        {
            DateTime.TryParse(arrivalTime, out var arrTime);
            DateTime.TryParse(departureTime, out var depTime);

            return arrTime > depTime;
        }

        public string ErrorMessage => "Arrival time must be greater than departure time.";
    }
}