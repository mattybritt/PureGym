namespace PureGym.Domain.Repositories
{
    public interface IRepository<T,Id>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(Id id);
        T TryGetById(Id id);
        T GetById(Id id);
    }
}
