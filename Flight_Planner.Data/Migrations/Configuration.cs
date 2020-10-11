using System.Data.Entity.Migrations;

namespace Flight_Planner.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FlightPlannerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FlightPlannerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}