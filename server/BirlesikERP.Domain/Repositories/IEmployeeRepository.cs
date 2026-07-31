using BirlesikERP.Domain.Entities.HumanResources;

namespace BirlesikERP.Domain.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<IEnumerable<Employee>> GetAsync(int page, int pageSize);
        Task<Employee?> GetByIdAsync(Guid Id);
        Task<Employee?> GetByEmailAsync(string Email);
        Task CreateAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteByIdAsync(Guid Id);
        Task<IEnumerable<Employee>> SearchAsync(string value);
    }
}
