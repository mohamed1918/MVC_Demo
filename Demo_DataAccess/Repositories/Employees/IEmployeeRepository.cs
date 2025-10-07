using Demo_DataAccess.Models.Departments;
using Demo_DataAccess.Models.Employees;
using Demo_DataAccess.Repositories.Generics;

namespace Demo_DataAccess.Repositories.Employees
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        
    }
}