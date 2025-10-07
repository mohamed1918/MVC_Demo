using Demo_BusinessLogic.DataTransfarObjects.Departments;
using Demo_BusinessLogic.DTOs.Departments;
using Demo_DataAccess.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BusinessLogic.Factories
{
    public static class DepartmentFactory
    {
        public static DepartmenrDetailsDto ToDepartmenrDetailsDto(this Department department)
        {
                       return new DepartmenrDetailsDto()
                       {
                           Id = department.Id,
                           Name = department.Name,
                           Code = department.Code,
                           Description = department.Description ?? string.Empty,
                           CtreatedBy = department.CtreatedBy,
                           LastModifiedBy = department.LastModifiedBy,
                           DateofCreation = DateOnly.FromDateTime(department.CreatedOn ?? DateTime.Now),
                           IsDeleted = department.IsDeleted
                       };
        }

        public static DepartmentDto ToDepartmentDto(this Department department)
        {
            return new DepartmentDto()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description ?? string.Empty,
                DateofCreation = DateOnly.FromDateTime(department.CreatedOn ?? DateTime.Now)
            };
        }

        public static Department ToEntity(this CreatedDepartmentDto departmentDto)
        {
            return new Department()
            {
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreatedOn = departmentDto.DateofCreation.ToDateTime(new TimeOnly())
            };
        }

        public static Department ToEntity(this UpdatedDepartmentdto departmentDto)
        {
            return new Department()
            {
                Id = departmentDto.Id,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreatedOn = departmentDto.DateofCreation.ToDateTime(new TimeOnly())
            };
        }
    }

}
