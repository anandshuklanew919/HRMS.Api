namespace HRMS.Api.Dtos
{
    public class LeaveApprovalDTO
    {
        public long ApprovalId { get; set; }
        public long? LeaveRequestId { get; set; }
        public long? ApproverId1 { get; set; }
        public DateTime? ApprovalDate1 { get; set; }
        public string ApprovalStatus1 { get; set; }
        public string ApprovalComments1 { get; set; }
    }
}
