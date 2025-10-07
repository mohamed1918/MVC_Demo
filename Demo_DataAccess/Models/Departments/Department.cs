using Demo_DataAccess.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DataAccess.Models.Departments
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;  // Department name
        public string Code { get; set; } = null!;  // Department code
        public string? Description { get; set; }  // Department description

        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>(); // Navigation property to Employees
    }
}
