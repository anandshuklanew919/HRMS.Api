using System;
using System.Collections.Generic;

namespace HRMS.Api.Data.Entities
{
    public partial class LeaveRequest
    {
        public LeaveRequest()
        {
            LeaveApprovals = new HashSet<LeaveApproval>();
        }

        public long RequestId { get; set; }
        public long? EmployeeId { get; set; }
        public int? LeaveTypeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string FinalStatus { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual LeaveType LeaveType { get; set; }
        public virtual ICollection<LeaveApproval> LeaveApprovals { get; set; }
    }
}
