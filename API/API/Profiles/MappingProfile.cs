using AutoMapper;
using DataModel.Models.Dtos;
using DataModel.Models.Entities;

namespace API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //address
            CreateMap<AddressForCreationDto, Address>();
            CreateMap<AddressForUpdateDto, Address>();
            CreateMap<Address, AddressDto>();

            //company
            CreateMap<CompanyForCreationDto, Company>();
            CreateMap<CompanyForUpdateDto, Company>();
            CreateMap<Company, CompanyDto>();

            //department
            CreateMap<DepartmentForCreationDto, Department>();
            CreateMap<DepartmentForUpdateDto, Department>();
            CreateMap<Department, DepartmentDto>();

            //employee
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>();
            CreateMap<Employee, EmployeeDto>();

            //salary
            CreateMap<SalaryForCreationDto, Salary>();
            CreateMap<SalaryForUpdateDto, Salary>();
            CreateMap<Salary, SalaryDto>();

            //taxlookup
            CreateMap<TaxLookUpForCreationDto, TaxLookUp>();
            CreateMap<TaxLookUpForUpdateDto, TaxLookUp>();
            CreateMap<TaxLookUp, TaxLookUpDto>();
        }
    }
}
