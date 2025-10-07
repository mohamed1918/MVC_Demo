namespace MVC_Demo.ViewModels.Departments
{
    public class DepartmentViewModel
    {
       
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; } = string.Empty;
        public DateOnly DateofCreation { get; set; }
        public int Id { get;  set; }
    }
}
