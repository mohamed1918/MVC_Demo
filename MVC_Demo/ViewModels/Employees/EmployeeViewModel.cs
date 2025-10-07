using Demo_DataAccess.Models.Employees;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MVC_Demo.ViewModels.Employees
{
    public class EmployeeViewModel
    {
        [Required(ErrorMessage = "Name is reqiured")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [MinLength(3, ErrorMessage = "Name must be at least 2 characters long.")]
        public string Name { get; set; } = null!;
        [Range(20, 40)]
        public int? Age { get; set; }
        [RegularExpression(@"^[1-9][0-9]{0,2}-[a-zA-Z]{3,15}-[a-zA-Z]{2,15}-[a-zA-Z]{2,15}$",
                                ErrorMessage = "Address must be 123-Street-City-Country")]
        public string? Address { get; set; } = null!;
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }

        public Gender Gender { get; set; }

        public EmployeeType EmployeeType { get; set; }
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        public IFormFile? Image { get; set; }

    }
}
