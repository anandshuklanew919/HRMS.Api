namespace HRMS.Api.Dtos
{
    public class LeaveBalanceDTO
    {
        public long LeaveBalanceId { get; set; }
        public long? EmployeeId { get; set; }
        public int? LeaveTypeId { get; set; }
        public decimal? Balance { get; set; }
    }
}
