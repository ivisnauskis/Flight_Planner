using System.Collections.Generic;
using Flight_Planner.Core.Interfaces;

namespace Flight_Planner.Core.Services
{
    public class ServiceResult
    {
        public bool Succeeded { get; private set; }
        public int  Id { get; }
        public IEntity Entity { get; private set; }
        public IEnumerable<string> Errors = new List<string>();

        public ServiceResult(bool succeeded)
        {
            Succeeded = succeeded;
        }

        public ServiceResult(bool succeeded, int id)
        {
            Succeeded = succeeded;
            Id = id;
        }

        public ServiceResult Set(IEntity entity)
        {
            Entity = entity;
            return this;
        }

        public ServiceResult Set(IEnumerable<string> errors)
        {
            Errors = errors;
            return this;
        }
    }
}