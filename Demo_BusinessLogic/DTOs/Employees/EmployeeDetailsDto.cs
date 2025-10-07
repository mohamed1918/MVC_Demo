using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BusinessLogic.DTOs.Employees
{
    public class EmployeeDetailsDto
    {
        public int id { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; } 
        public int? Age { get; set; }
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly HiringDate { get; set; }

        public string Gender { get; set; } = null!;

        public string EmployeeType { get; set; } = null!;
        public int CtreatedBy { get; set; }  

        public DateTime? CreatedOn { get; set; } 

        public int LastModifiedBy { get; set; } 

        public DateTime LastModifiedOn { get; set; } 

        public int? DepartmentId { get; set; }
        [Display(Name = "Department")]
        public string? DepartmentName { get; set; }

        public string? Image { get; set; }
    }
}
