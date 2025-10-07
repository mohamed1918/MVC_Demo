using AutoMapper;
using Demo_BusinessLogic.DTOs.Employees;
using Demo_BusinessLogic.Services.Interfaces;
using Demo_DataAccess.Models.Employees;
using Demo_DataAccess.Repositories.Employees;
using Demo_DataAccess.Repositories.UoW;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BusinessLogic.Services.Classes
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAttachmentService _attachmentService;

        public EmployeeService(IUnitOfWork unitOfWork,
                                IMapper mapper,
                                IAttachmentService attachmentService)
        {
            _unitOfWork= unitOfWork;
            _mapper = mapper;
            _attachmentService = attachmentService;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(string? EmployeeSearchName, bool withtracking = false)
        {
            //var employees = _employeeRepository.GetAll(withtracking);
            IEnumerable<Employee> employees;
            if (string.IsNullOrWhiteSpace(EmployeeSearchName))
            {
                employees = _unitOfWork.EmployeeRepository.GetAll(withtracking);
            }
            else 
            {
                 employees = _unitOfWork.EmployeeRepository.GetAll(E => E.Name.ToLower().Contains(EmployeeSearchName.ToLower() ?? string.Empty));
            }

            var employeesToReturn = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            //var employeesToReturn = employees.Select(E => new EmployeeDto()
            //{
            //    id = E.Id,
            //    Name = E.Name,
            //    Age = E.Age,
            //    Email = E.Email,
            //    IsActive = E.IsActive,
            //    Salary = E.Salary,
            //    Gender = E.Gender.ToString(),
            //    EmployeeType = E.EmployeeType.ToString()
            //});

            return employeesToReturn;
        }


        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            return employee is null ? null : _mapper.Map<Employee, EmployeeDetailsDto>(employee);
            //return employee is null ? null : new EmployeeDetailsDto()
            //{
            //    id = employee.Id,
            //    Name = employee.Name,
            //    Age = employee.Age,
            //    Salary = employee.Salary,
            //    Email = employee.Email,
            //    PhoneNumber = employee.PhoneNumber,
            //    HiringDate = DateOnly.FromDateTime(employee.HiringDate),
            //    IsActive = employee.IsActive,
            //    Gender = employee.Gender.ToString(),
            //    EmployeeType = employee.EmployeeType.ToString(),
            //    CtreatedBy = employee.CtreatedBy,
            //    CreatedOn = employee.CreatedOn,
            //    LastModifiedBy = employee.LastModifiedBy,
            //    LastModifiedOn = employee.LastModifiedOn
            //};
        }

        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<CreatedEmployeeDto, Employee>(employeeDto);
            if (employeeDto.Image is not null)
            {
                employee.ImageName = _attachmentService.Upload(employeeDto.Image, "Images");

            }
            _unitOfWork.EmployeeRepository.Add(employee);
            return _unitOfWork.SaveChanges();
        }

        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<UpdatedEmployeeDto, Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Add(employee);
            return _unitOfWork.SaveChanges();
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);

            if (employee is null)
            {
                return false;
            }
            // simple delete
            employee.IsDeleted = true;
            _unitOfWork.EmployeeRepository.Update(employee);
            var result = _unitOfWork.SaveChanges();
            if (result > 0) return true;
            else return false;
            // hard delete
            //var result = _employeeRepository.Remove(employee);
            //if (result > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}


        }




    }

}
