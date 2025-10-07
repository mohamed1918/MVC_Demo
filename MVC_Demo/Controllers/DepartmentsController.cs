using Demo_BusinessLogic.DataTransfarObjects.Departments;
using Demo_BusinessLogic.DTOs.Departments;
using Demo_BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MVC_Demo.ViewModels.Departments;

namespace MVC_Demo.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly ILogger<DepartmentsController> _logger;
        private readonly IWebHostEnvironment _env;

        public DepartmentsController(IDepartmentServices departmentServices,
                                     ILogger<DepartmentsController> logger,
                                     IWebHostEnvironment env)
        {
            _departmentServices = departmentServices;
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            var departments = _departmentServices.GetAllDepartments();
            return View(departments);
        }

        #region Create Department
        // show the form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // handle the form submission
        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto departmentDto)
        {
            if (!ModelState.IsValid)
            {
                return View(departmentDto);
            }
            var message = string.Empty;
            try
            {
                var result = _departmentServices.AddDepartment(departmentDto);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    message = "Failed to add department. Please try again.";
                    ModelState.AddModelError(string.Empty, message);
                    return View(departmentDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                if (_env.IsDevelopment())
                {
                    message = ex.Message;
                    return View(departmentDto);
                }
                else
                {
                    message = "Department can not be created";
                    return View("Error", message);
                }
            }
        }
        #endregion

        // Department Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var department = _departmentServices.GetDepatmentById(id.Value);
            if (department is null)
            {
                return NotFound();
            }
            return View(department);

        }

        #region Edit Department 
        // Edit Department
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var department = _departmentServices.GetDepatmentById(id.Value);
            if (department is null)
            {
                return NotFound();
            }
            return View(new DepartmentViewModel()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                DateofCreation = department.DateofCreation
            });

        }
        [HttpPost]
        public IActionResult Edit(DepartmentViewModel departmentVM)
        {
            if (!ModelState.IsValid)
            {
                return View(departmentVM);
            }
            var message = string.Empty;
            try
            {
                var result = _departmentServices.UpdateDepartment(new UpdatedDepartmentdto()
                {
                    Id = departmentVM.Id,
                    Code = departmentVM.Code,
                    Name = departmentVM.Name,
                    Description = departmentVM.Description,
                    DateofCreation = departmentVM.DateofCreation
                });
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    message = "department Can't updated";

                }
            }
            catch (Exception ex)
            {
                message = _env.IsDevelopment() ? ex.Message : "Department can't be updated";
            }
            return View(departmentVM);
        }
        #endregion


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var department = _departmentServices.GetDepatmentById(id.Value);
            if (department is null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var message = string.Empty;
            try
            {
                var result = _departmentServices.DeleteDepartment(id);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    message = "Department can't be deleted";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                message = _env.IsDevelopment() ? ex.Message : "Department can't be deleted";
            }
            return View("Error", message);
        }
    }
}
