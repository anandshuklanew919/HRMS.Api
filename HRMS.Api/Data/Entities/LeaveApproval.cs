using System;
using System.Collections.Generic;

namespace HRMS.Api.Data.Entities
{
    public partial class LeaveApproval
    {
        public long ApprovalId { get; set; }
        public long? LeaveRequestId { get; set; }
        public long? ApproverId1 { get; set; }
        public DateTime? ApprovalDate1 { get; set; }
        public string ApprovalStatus1 { get; set; }
        public string ApprovalComments1 { get; set; }
        public long? ApproverId2 { get; set; }
        public DateTime? ApprovalDate2 { get; set; }
        public string ApprovalStatus2 { get; set; }
        public string ApprovalComments2 { get; set; }
        public long? ApproverId3 { get; set; }
        public DateTime? ApprovalDate3 { get; set; }
        public string ApprovalStatus3 { get; set; }
        public string ApprovalComments3 { get; set; }
        public long? ApproverId4 { get; set; }
        public DateTime? ApprovalDate4 { get; set; }
        public string ApprovalStatus4 { get; set; }
        public string ApprovalComments4 { get; set; }
        public long? ApproverId5 { get; set; }
        public DateTime? ApprovalDate5 { get; set; }
        public string ApprovalStatus5 { get; set; }
        public string ApprovalComments5 { get; set; }
        public bool? IsFinalApproved { get; set; }
        public DateTime? FinalApprovedDate { get; set; }

        public virtual Employee ApproverId1Navigation { get; set; }
        public virtual Employee ApproverId2Navigation { get; set; }
        public virtual Employee ApproverId3Navigation { get; set; }
        public virtual Employee ApproverId4Navigation { get; set; }
        public virtual Employee ApproverId5Navigation { get; set; }
        public virtual LeaveRequest LeaveRequest { get; set; }
    }
}
