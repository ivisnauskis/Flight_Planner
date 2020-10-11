using System.Collections.Generic;
using Flight_Planner.Core.Models;
using Flight_Planner.Services.Validator.Interfaces;

namespace Flight_Planner.Services.Validator
{
    public class FlightValidator : IFlightValidator
    {
        private readonly IEnumerable<IValidationRule> _rules;

        public FlightValidator(IEnumerable<IValidationRule> rules)
        {
            _rules = rules;
        }

        public ValidationResponse ValidateFlight(Flight flight)
        {
            var errors = new List<string>();

            if (flight == null)
            {
                errors.Add("Flight cannot be null.");
                return new ValidationResponse(false).Set(errors);
            }

            foreach (var validationRule in _rules)
                if (!validationRule.IsValid(flight))
                    errors.Add(validationRule.ErrorMessage);

            return errors.Count > 0 ? new ValidationResponse(false).Set(errors) : new ValidationResponse(true);
        }
    }
}