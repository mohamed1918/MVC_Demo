using Demo_BusinessLogic.DTOs.Employees;
using Demo_BusinessLogic.Services.Interfaces;
using Demo_DataAccess.Models.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MVC_Demo.ViewModels.Employees;
namespace MVC_Demo.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(IEmployeeService employeeService,
                                    ILogger<EmployeesController> logger,
                                    IWebHostEnvironment env
                                    )
        {
            _employeeService = employeeService;
            _env = env;
            
            _logger = logger;
        }


        public IActionResult Index(string? EmployeeSearchName)
        {
            var employees = _employeeService.GetAllEmployees(EmployeeSearchName);
            return View(employees);
        }

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var employeeDto = new CreatedEmployeeDto()
                    {
                        Name = employeeVM.Name,
                        Email = employeeVM.Email,
                        Address = employeeVM.Address,
                        PhoneNumber = employeeVM.PhoneNumber,
                        Age = employeeVM.Age,
                        Salary = employeeVM.Salary,
                        IsActive = employeeVM.IsActive,
                        HiringDate = employeeVM.HiringDate,
                        Gender = employeeVM.Gender,
                        EmployeeType = employeeVM.EmployeeType,
                        DepartmentId = employeeVM.DepartmentId,
                        Image = employeeVM.Image
                    };
                    var result = _employeeService.CreateEmployee(employeeDto);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                          ModelState.AddModelError(string.Empty, "can;t created employee right now");
                    }
                }
                catch(Exception ex)
                {
                    if(_env.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }   
            }
            return View(employeeVM);
        }
        #endregion

        #region Details
        public IActionResult Details(int? id)
        {
           if(id is null) return BadRequest();
           var employee = _employeeService.GetEmployeeById(id.Value);
           if(employee is null) return NotFound();

            return View(employee);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id) 
        { 
            if(id is null) return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            if(employee is null) return NotFound();
            return View(new EmployeeViewModel()
            {
                
                Name = employee.Name,
                Address = employee.Address,
                Age = employee.Age,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
                DepartmentId = employee.DepartmentId
            });
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id,EmployeeViewModel employeeVM)
        {
            if (id is null) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var employeeDto = new UpdatedEmployeeDto()
                    {
                        Id = id.Value,
                        Name = employeeVM.Name,
                        Email = employeeVM.Email,
                        Address = employeeVM.Address,
                        PhoneNumber = employeeVM.PhoneNumber,
                        Age = employeeVM.Age,
                        Salary = employeeVM.Salary,
                        IsActive = employeeVM.IsActive,
                        HiringDate = employeeVM.HiringDate,
                        Gender = employeeVM.Gender,
                        EmployeeType = employeeVM.EmployeeType,
                        DepartmentId = employeeVM.DepartmentId
                    };

                        var result = _employeeService.UpdateEmployee(employeeDto);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "can;t update employee right now");
                    }
                }
                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }
            }
            return View(employeeVM);
        }

        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest();
            try
            {
                var result = _employeeService.DeleteEmployee(id.Value);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _logger.LogError("can't delete employee right now");
                }
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    _logger.LogError(ex.Message);
                }
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
