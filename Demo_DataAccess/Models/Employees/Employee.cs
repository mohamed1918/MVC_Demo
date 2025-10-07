using Demo_DataAccess.Models.Departments;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DataAccess.Models.Employees
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public string Address { get; set; } = null!;
        public decimal Salary { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public bool IsActive { get; set; }

        public int? DepartmentId { get; set; }   // Foreign key to Department
        public virtual Department? Department { get; set; }  // Navigation property to Department

        public string? ImageName { get; set; }
    }
}
