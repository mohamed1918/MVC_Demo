using Demo_DataAccess.Data.Contexts;
using Demo_DataAccess.Models.Departments;
using Demo_DataAccess.Models.Employees;
using Demo_DataAccess.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DataAccess.Repositories.Employees
{
    public class EmployeeRepository : GenericRepository<Employee> ,IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext) // Constructor Injection
        {
            _dbContext = dbContext;
        }
        
    }
}
