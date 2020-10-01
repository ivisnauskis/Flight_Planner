using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Data;

namespace Flight_Planner.Services
{
    public class DbService : IDbService
    {
        protected readonly IFlightPlannerDbContext Ctx;

        public DbService(IFlightPlannerDbContext ctx)
        {
            Ctx = ctx;
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return Ctx.Set<T>();
        }

        public IQueryable<T> QueryById<T>(int id) where T : Entity
        {
            return Ctx.Set<T>().Where(e => e.Id == id);
        }

        public IEnumerable<T> Get<T>() where T : Entity
        {
            return Ctx.Set<T>();
        }

        public Task<T> GetById<T>(int id) where T : Entity
        {
            return Ctx.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public ServiceResult Create<T>(T entity) where T : Entity
        {
            Ctx.Set<T>().Add(entity);
            Ctx.SaveChanges();
            return new ServiceResult(true).Set(entity);
        }

        public ServiceResult Delete<T>(T entity) where T : Entity
        {
            Ctx.Set<T>().Remove(entity);
            Ctx.SaveChanges();
            return new ServiceResult(true).Set(entity);
        }

        public ServiceResult Update<T>(T entity) where T : Entity
        {
            var entityToUpdate = GetById<T>(entity.Id).Result;
            Ctx.Entry(entityToUpdate).CurrentValues.SetValues(entity);
            Ctx.SaveChanges();
            return new ServiceResult(true).Set(entity);
        }

        public bool Exists<T>(int id) where T : Entity
        {
            return Query<T>().Any(e => e.Id == id);
        }
    }
}