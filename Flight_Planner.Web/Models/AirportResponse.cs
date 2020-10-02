using Newtonsoft.Json;

namespace Flight_Planner.Web.Models
{
    public class AirportResponse
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string AirportCode { get; set; }
    }
}