using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Data;

namespace Flight_Planner.Services
{
    public class FlightService : DbService, IEntityService<Flight>
    {
        public FlightService(IFlightPlannerDbContext ctx) : base(ctx)
        {
        }

        public IQueryable<Flight> Query()
        {
            return Query<Flight>();
        }

        public IQueryable<Flight> QueryById(int id)
        {
            return QueryById<Flight>(id);
        }

        public IEnumerable<Flight> Get()
        {
            return Get<Flight>();
        }

        public Task<Flight> GetById(int id)
        {
            return GetById<Flight>(id);
        }

        public ServiceResult Create(Flight entity)
        {
            return Create<Flight>(entity);
        }

        public ServiceResult Delete(Flight entity)
        {
            return Delete<Flight>(entity);
        }

        public ServiceResult Update(Flight entity)
        {
            return Update<Flight>(entity);
        }

        public bool Exists(int id)
        {
            return Exists<Flight>(id);
        }
    }
}