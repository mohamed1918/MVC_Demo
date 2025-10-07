using Demo_DataAccess.Models.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BusinessLogic.DTOs.Employees
{
    public class UpdatedEmployeeDto
    {
        public int Id { get; set; }
        [Required]
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
        public int? DepartmentId { get; set; }
    }
}
