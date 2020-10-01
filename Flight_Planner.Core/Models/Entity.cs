using Flight_Planner.Core.Interfaces;

namespace Flight_Planner.Core.Models
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}