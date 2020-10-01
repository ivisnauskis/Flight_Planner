using System;
using Newtonsoft.Json;

namespace Flight_Planner.Core.Models
{
    public class Airport : Entity
    {
        public string Country { get; set; }
        public string City { get; set; }

        [JsonProperty(PropertyName = "airport")]
        public string AirportCode { get; set; }

        protected bool Equals(Airport other)
        {
            return string.Equals(Country, other.Country, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(City, other.City, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(AirportCode, other.AirportCode, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Airport) obj);
        }
    }
}