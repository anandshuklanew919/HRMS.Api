namespace HRMS.Api.Dtos
{
    public class EmployeeDTO
    {
        public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? JoinDate { get; set; }
        public string Position { get; set; }
        public long? ManagerId { get; set; }
        public long? TeamLeadId { get; set; }
        public long? CompanyId { get; set; }
        public long? DepartmentId { get; set; }
    }
}
