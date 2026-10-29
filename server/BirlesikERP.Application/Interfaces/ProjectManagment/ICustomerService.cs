using BirlesikERP.Application.DTOs.ProjectManagment;

namespace BirlesikERP.Application.Interfaces.ProjectManagment
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task CreateAsync(CreateCustomerDto dto);
    }
}
