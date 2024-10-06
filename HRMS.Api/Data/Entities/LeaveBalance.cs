using System;
using System.Collections.Generic;

namespace HRMS.Api.Data.Entities
{
    public partial class LeaveBalance
    {
        public long LeaveBalanceId { get; set; }
        public long? EmployeeId { get; set; }
        public int? LeaveTypeId { get; set; }
        public decimal? Balance { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual LeaveType LeaveType { get; set; }
    }
}
