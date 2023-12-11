namespace EventManagerService.Application.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        T Get(Func<T, bool> filter);
        IEnumerable<T> Where(Func<T, bool> filter);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
