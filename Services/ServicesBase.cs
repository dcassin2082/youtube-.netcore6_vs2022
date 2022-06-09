using WebApplication16.Repository;

namespace WebApplication16.Services
{
    public abstract class ServicesBase<T> where T : class
    {
        protected readonly IRepository<T> _repo;

        protected ServicesBase(IRepository<T> repo)
        {
            _repo = repo;
        }
    }
}
