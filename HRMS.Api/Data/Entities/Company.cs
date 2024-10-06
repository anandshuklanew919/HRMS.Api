using System;
using System.Collections.Generic;

namespace HRMS.Api.Data.Entities
{
    public partial class Company
    {
        public Company()
        {
            Departments = new HashSet<Department>();
            Employees = new HashSet<Employee>();
            LeaveTypes = new HashSet<LeaveType>();
        }

        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<LeaveType> LeaveTypes { get; set; }
    }
}
