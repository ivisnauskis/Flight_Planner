﻿namespace Flight_Planner.Web.Models
{
    public class AirportRequest
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AirportCode { get; set; }
    }
}