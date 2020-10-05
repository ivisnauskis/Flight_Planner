using System.Collections.Generic;

namespace Flight_Planner.Web.Models
{
    public class FlightSearchResponse
    {
        public int Page { get; set; }
        public int TotalItems { get; set; }
        public IEnumerable<FlightResponse> Items { get; set; }
    }
}