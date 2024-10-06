using System;
using System.Collections.Generic;

namespace HRMS.Api.Data.Entities
{
    public partial class LeaveType
    {
        public LeaveType()
        {
            LeaveBalances = new HashSet<LeaveBalance>();
            LeaveRequests = new HashSet<LeaveRequest>();
        }

        public int LeaveTypeId { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public long CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<LeaveBalance> LeaveBalances { get; set; }
        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }
    }
}
