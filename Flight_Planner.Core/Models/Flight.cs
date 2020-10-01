namespace Flight_Planner.Core.Models
{
    public class Flight : Entity
    {
        public Airport From { get; set; }
        public Airport To { get; set; }
        public string Carrier { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }

        protected bool Equals(Flight other)
        {
            return Equals(From, other.From) && Equals(To, other.To) && Carrier == other.Carrier && DepartureTime == other.DepartureTime && ArrivalTime == other.ArrivalTime;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Flight) obj);
        }
    }
}