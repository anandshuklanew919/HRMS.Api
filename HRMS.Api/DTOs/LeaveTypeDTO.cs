namespace HRMS.Api.Dtos
{
    public class LeaveTypeDTO
    {
        public int LeaveTypeId { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public long CompanyId { get; set; }
    }
}
