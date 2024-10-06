using System;
using System.Collections.Generic;

namespace HRMS.Api.Data.Entities
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public long? CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
