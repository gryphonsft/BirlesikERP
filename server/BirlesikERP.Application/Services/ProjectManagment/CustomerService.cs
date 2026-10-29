using BirlesikERP.Application.DTOs.ProjectManagment;
using BirlesikERP.Application.Interfaces.ProjectManagment;
using BirlesikERP.Application.Interfaces.UnitOfWork;
using BirlesikERP.Domain.Entities.ProjectManagment;
using BirlesikERP.Domain.Repositories;

namespace BirlesikERP.Application.Services.ProjectManagment
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllAsync();

            return customers.Select(x => new CustomerDto
            {
                Name = x.Name,
                TaxNumber = x.TaxNumber,
                Email = x.Email,
                Phone = x.Phone,
                Type = (DTOs.ProjectManagment.CustomerType)x.Type,
                IsActive = x.IsActive
            }).ToList();
        }
        public async Task CreateAsync(CreateCustomerDto dto)
        {
            var customer = new Customer
            {
                Name = dto.Name,
                TaxNumber = dto.TaxNumber,
                Email = dto.Email,
                Phone = dto.Phone,
                Type = (Domain.Entities.ProjectManagment.CustomerType)dto.Type,
                IsActive = true
            };
            await _customerRepository.CreateAsync(customer);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
