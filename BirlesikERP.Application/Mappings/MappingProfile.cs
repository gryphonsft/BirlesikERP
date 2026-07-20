using AutoMapper;
using BirlesikERP.Application.DTOs.Core;
using BirlesikERP.Domain.Entities.Core;

namespace BirlesikERP.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
        }
    }
}
