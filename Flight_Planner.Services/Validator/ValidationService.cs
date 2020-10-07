using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Services.Validator.Interfaces;

namespace Flight_Planner.Services.Validator
{
    public class ValidationService : IValidationService
    {
        private readonly IFlightValidator _flightValidator;
        private readonly IFlightSearchRequestValidator _searchRequestValidator;

        public ValidationService(IFlightValidator flightValidator, IFlightSearchRequestValidator searchRequestValidator)
        {
            _flightValidator = flightValidator;
            _searchRequestValidator = searchRequestValidator;
        }

        public ValidationResponse ValidateFlight(Flight flight)
        {
            return _flightValidator.ValidateFlight(flight);
        }

        public ValidationResponse ValidateFlightSearchRequest(FlightServiceSearchRequest req)
        {
            return _searchRequestValidator.Validate(req);
        }
    }
}