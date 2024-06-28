using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactManager.Infrastructure.Repository
{
    public class Repository : IRepository
    {
        private readonly CMDbContext _dbContext;

        public Repository(CMDbContext dbContext)
        {

            _dbContext = dbContext;
        }


        public T Add<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Add(entity);

            return entity;
        }

        public void AddRange<T>(IEnumerable<T> entities) where T : class
        {
            _dbContext.Set<T>().AddRange(entities);
        }

        public void RemoveRange<T>(IEnumerable<T> entities) where T : class
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public void Delete<T>(T entity) where T : class
        {

            _dbContext.Set<T>().Remove(entity);

        }

        public IQueryable<T> Get<T>() where T : class
        {
            return _dbContext.Set<T>();
        }




        public Task<List<T>> ToListAsync<T>() where T : class
        {
            //var ignored = System.Attribute.IsDefined(typeof(T).GetProperty("IsDeleted"), typeof(NotMappedAttribute));

            return _dbContext.Set<T>().ToListAsync();
        }
        public List<T> List<T>() where T : class
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Update<T>(T entity) where T : class
        {

            _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }



        public void EntityState<T>(T entity, Microsoft.EntityFrameworkCore.EntityState state) where T : class
        {
            _dbContext.Entry(entity).State = state;
        }

        public void Attach<T>(T entity) where T : class
        {
            _dbContext.Attach(entity);
        }
        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
