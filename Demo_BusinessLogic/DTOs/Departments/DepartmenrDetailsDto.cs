using Demo_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BusinessLogic.DataTransfarObjects.Departments
{
    public class DepartmenrDetailsDto
    {
        

        public int Id { get; set; }
        public string Name { get; set; } = null!;  
        public string Code { get; set; } = null!;  
        public string Description { get; set; } = string.Empty;

        public int CtreatedBy { get; set; }

        public DateOnly DateofCreation { get; set; }
        public int LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
        
    }
}
