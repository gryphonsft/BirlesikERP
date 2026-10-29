using BirlesikERP.Domain.Entities.ProjectManagment;

namespace BirlesikERP.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task CreateAsync(Customer customer);
    }
}
