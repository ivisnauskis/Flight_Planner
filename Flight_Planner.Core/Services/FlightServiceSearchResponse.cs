using System.Collections.Generic;
using Flight_Planner.Core.Models;

namespace Flight_Planner.Core.Services
{
    public class FlightServiceSearchResponse
    {
        public FlightServiceSearchResponse(bool succeeded)
        {
            Succeeded = succeeded;
        }

        public bool Succeeded { get; set; }

        public IEnumerable<Flight> FoundFlights { get; set; }

        public IEnumerable<string> Errors = new List<string>();

        public FlightServiceSearchResponse Set(IEnumerable<string> errors)
        {
            Errors = errors;
            return this;
        }

        public FlightServiceSearchResponse Set(IEnumerable<Flight> flights)
        {
            FoundFlights = flights;
            return this;
        }
    }
}