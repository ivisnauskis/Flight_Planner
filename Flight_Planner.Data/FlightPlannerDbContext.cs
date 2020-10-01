using System.Data.Entity;
using Flight_Planner.Core.Models;
using Flight_Planner.Data.Migrations;

namespace Flight_Planner.Data
{
    public class FlightPlannerDbContext : DbContext, IFlightPlannerDbContext
    {
        public FlightPlannerDbContext() : base("flight-planner")
        {
            Database.SetInitializer<FlightPlannerDbContext>(null);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FlightPlannerDbContext, Configuration>());
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
    }
}