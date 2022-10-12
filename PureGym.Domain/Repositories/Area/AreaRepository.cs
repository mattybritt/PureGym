using PureGym.Domain.Repositories;

namespace PureGym.Domain
{
    internal class AreaRepository : IRepository<AreaAggregate, AreaId>
    {
        private List<AreaAggregate> list = new List<AreaAggregate>();

        public void Add(AreaAggregate entity)
        {
            list.Add(entity);
        }

        public void Delete(AreaId id)
        {
            list.Remove(list.First(l => l.AreaId == id));
        }

        public AreaAggregate GetById(AreaId id)
        {
            return new AreaAggregate(id, "Yoga", 10);
        }

        public AreaAggregate TryGetById(AreaId id)
        {
            return new AreaAggregate(id, "Yoga", 10);
        }

        public void Update(AreaAggregate entity)
        {
        }
    }

}
