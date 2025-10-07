using Demo_DataAccess.Models.Departments;
using Demo_DataAccess.Repositories.Generics;

namespace Demo_DataAccess.Repositories.Departments
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        
    }
}