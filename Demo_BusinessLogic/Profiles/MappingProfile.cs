using AutoMapper;
using Demo_BusinessLogic.DTOs.Employees;
using Demo_DataAccess.Models.Employees;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BusinessLogic.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee,EmployeeDto>()
                .ForMember(dest => dest.EmpGender,options => options.MapFrom(src => src.Gender))
                .ForMember(dest => dest.EmpType, options => options.MapFrom(src => src.EmployeeType))
                .ForMember(dest => dest.DepartmentName, options => options.MapFrom(src => src.Department != null ? src.Department.Name : "No Department"));

            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender))
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)))
                .ForMember(dest => dest.DepartmentName, options => options.MapFrom(src => src.Department != null ? src.Department.Name : "No Department"))
                .ForMember(dest => dest.Image, options => options.MapFrom(src => src.ImageName));

            CreateMap<CreatedEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(new TimeOnly())));

            CreateMap<UpdatedEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(new TimeOnly())));

        }
    }
}
