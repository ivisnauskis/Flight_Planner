using System;
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
            return Ctx.Set<T>().AsQueryable();
        }

        public IQueryable<T> QueryById<T>(int id) where T : Entity
        {
            return Ctx.Set<T>().Where(e => e.Id == id);
        }

        public IEnumerable<T> Get<T>() where T : Entity
        {
            return Ctx.Set<T>().ToList();
        }

        public async Task<T> GetById<T>(int id) where T : Entity
        {
            return await Ctx.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public ServiceResult Create<T>(T entity) where T : Entity
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Ctx.Set<T>().Add(entity);
            Ctx.SaveChanges();
            return new ServiceResult(true).Set(entity);
        }

        public ServiceResult Delete<T>(T entity) where T : Entity
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Ctx.Set<T>().Remove(entity);
            Ctx.SaveChanges();
            return new ServiceResult(true);
        }

        public ServiceResult Update<T>(T entity) where T : Entity
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Ctx.Entry(entity).State = EntityState.Modified;
            Ctx.SaveChanges();
            return new ServiceResult(true).Set(entity);
        }

        public bool Exists<T>(int id) where T : Entity
        {
            return QueryById<T>(id).Any();
        }
    }
}