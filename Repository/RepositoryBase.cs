using Microsoft.EntityFrameworkCore;
using WebApplication16.Models;

namespace WebApplication16.Repository
{
    public abstract class RepositoryBase<T> : IDisposable where T : class
    {
        protected readonly internal TestDbContext _dbContext;
        protected readonly internal DbSet<T> _dbSet;

        protected RepositoryBase(TestDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
