using Demo_BusinessLogic.DataTransfarObjects.Departments;
using Demo_BusinessLogic.DTOs.Departments;

namespace Demo_BusinessLogic.Services.Interfaces
{
    public interface IDepartmentServices
    {
        int AddDepartment(CreatedDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmenrDetailsDto? GetDepatmentById(int id);
        int UpdateDepartment(UpdatedDepartmentdto departmentDto);
    }
}