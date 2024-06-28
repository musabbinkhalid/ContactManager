namespace ContactManager.Infrastructure.Repository
{
    public interface IRepository
    {
        IQueryable<T> Get<T>() where T : class;
       
        List<T> List<T>() where T : class;
        T Add<T>(T entity) where T : class;
        void AddRange<T>(IEnumerable<T> entities) where T : class;
        void RemoveRange<T>(IEnumerable<T> entities) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void EntityState<T>(T entity, Microsoft.EntityFrameworkCore.EntityState state) where T : class;
        void Attach<T>(T entity) where T : class;
        Task<int> SaveChangesAsync();

        int SaveChanges();

    }
}
