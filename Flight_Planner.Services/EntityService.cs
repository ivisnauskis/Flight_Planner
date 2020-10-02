using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Data;

namespace Flight_Planner.Services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity

    {
        public EntityService(IFlightPlannerDbContext ctx) : base(ctx)
        {
        }

        public IQueryable<T> Query()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> QueryById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> Get()
        {
            return Get<T>().ToList();
        }

        public Task<T> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult Create(T entity)
        {
            return Create<T>(entity);
        }

        public ServiceResult Delete(T entity)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult Update(T entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}