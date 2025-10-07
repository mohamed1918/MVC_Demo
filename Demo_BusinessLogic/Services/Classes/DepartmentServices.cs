using Demo_BusinessLogic.DataTransfarObjects.Departments;
using Demo_BusinessLogic.DTOs.Departments;
using Demo_BusinessLogic.Factories;
using Demo_BusinessLogic.Services.Interfaces;
using Demo_DataAccess.Models;
using Demo_DataAccess.Repositories.Departments;
using Demo_DataAccess.Repositories.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BusinessLogic.Services.Classes
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentServices(IUnitOfWork unitOfWork) // Constructor Injection
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();

            var departmentToReturn = departments.Select(D => D.ToDepartmentDto());
            return departmentToReturn;
        }

        public DepartmenrDetailsDto? GetDepatmentById(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);

            return department is null ? null : department.ToDepartmenrDetailsDto();

        }

        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            _unitOfWork.DepartmentRepository.Add(departmentDto.ToEntity());
            return _unitOfWork.SaveChanges();

        }

        public int UpdateDepartment(UpdatedDepartmentdto departmentDto)
        {
            _unitOfWork.DepartmentRepository.Update(departmentDto.ToEntity());
            return _unitOfWork.SaveChanges();
        }

        public bool DeleteDepartment(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department is null)
            {
                return false;
            }
            else
            {
                _unitOfWork.DepartmentRepository.Remove(department);
                var Result = _unitOfWork.SaveChanges();
                return Result > 0 ? true : false;
            }

        }

    }
}
