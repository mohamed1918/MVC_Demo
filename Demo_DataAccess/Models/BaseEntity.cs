using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DataAccess.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }  // PK

        public int CtreatedBy { get; set; }  // User ID

        public DateTime? CreatedOn { get; set; } // Created date

        public int LastModifiedBy { get; set; } // User ID(last modified)

        public DateTime LastModifiedOn { get; set; } // Last modified date

        public bool IsDeleted { get; set; } // Soft delete flag
    }
}
