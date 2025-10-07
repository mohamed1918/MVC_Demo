using Demo_DataAccess.Data.Contexts;
using Demo_DataAccess.Models.Departments;
using Demo_DataAccess.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DataAccess.Repositories.Departments
{
    public class DepartmentRepository : GenericRepository<Department> , IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext) // Constructor Injection
        {
            _dbContext = dbContext;
        }

        
    }
}
