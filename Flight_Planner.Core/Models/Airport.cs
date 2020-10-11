using System;

namespace Flight_Planner.Core.Models
{
    public class Airport : Entity
    {
        public string Country { get; set; }
        public string City { get; set; }
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

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Country != null ? Country.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (City != null ? City.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AirportCode != null ? AirportCode.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}