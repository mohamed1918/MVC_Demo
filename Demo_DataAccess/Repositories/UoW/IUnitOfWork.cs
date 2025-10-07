using Demo_DataAccess.Data.Configuration;
using Demo_DataAccess.Repositories.Departments;
using Demo_DataAccess.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DataAccess.Repositories.UoW
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; }

        public IDepartmentRepository DepartmentRepository { get; }

        public int SaveChanges();
    }
}
