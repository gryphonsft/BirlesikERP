using AutoMapper;
using BirlesikERP.Application.DTOs.Core;
using BirlesikERP.Application.DTOs.HumanResources;
using BirlesikERP.Domain.Entities.Core;
using BirlesikERP.Domain.Entities.HumanResources;

namespace BirlesikERP.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Employee, EmployeeSummaryDto>();
        }
    }
}
