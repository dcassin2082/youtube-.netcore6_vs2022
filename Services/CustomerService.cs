using System.Linq.Expressions;
using WebApplication16.Models;
using WebApplication16.Repository;

namespace WebApplication16.Services
{
    public class CustomerService : ServicesBase<Customer>, ICustomerService
    {
        public CustomerService(IRepository<Customer> repo) : base(repo)
        {
        }

        public async Task<Customer> DeleteCustomer(Customer customer)
        {
            return await _repo.Delete(customer);
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _repo.Get(id);
        }

        public async Task<Customer> GetCustomer(Expression<Func<Customer, bool>> predicate)
        {
            return await _repo.Get(predicate);
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _repo.GetAll();
        }

        public async Task<List<Customer>> GetCustomers(Expression<Func<Customer, bool>> predicate)
        {
            return await _repo.GetAll(predicate);
        }

        public async Task<Customer> PostCustomer(Customer customer)
        {
            return await _repo.Post(customer);
        }

        public async Task<Customer> PutCustomer(Customer customer)
        {
            return await _repo.Put(customer);
        }
    }
}
