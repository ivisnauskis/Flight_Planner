using Flight_Planner.Core.Services;

namespace Flight_Planner.Services.Validator.Interfaces
{
    public interface IFlightSearchRequestValidator
    {
        ValidationResponse Validate(FlightServiceSearchRequest request);
    }
}