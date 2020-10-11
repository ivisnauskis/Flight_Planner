using System;
using System.Collections.Generic;
using Flight_Planner.Core.Services;
using Flight_Planner.Services.Validator.Interfaces;

namespace Flight_Planner.Services.Validator
{
    public class FlightSearchRequestValidator : IFlightSearchRequestValidator
    {
        public ValidationResponse Validate(FlightServiceSearchRequest request)
        {
            var errors = new List<string>();
            if (request == null)
            {
                errors.Add("Request cannot be null.");
                return new ValidationResponse(false).Set(errors);
            }

            if (string.IsNullOrWhiteSpace(request.To)) errors.Add("To cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(request.From)) errors.Add("From cannot be null or empty.");
            if (!DateTime.TryParse(request.DepartureDate, out _)) errors.Add("Date/Time is not valid.");
            if (string.Equals(request.To, request.From, StringComparison.OrdinalIgnoreCase))
                errors.Add("Origin/Destination airports cannot be same.");

            return errors.Count > 0 ? new ValidationResponse(false).Set(errors) : new ValidationResponse(true);
        }
    } 
}