namespace HRMS.Api.Dtos
{
    public class DepartmentDTO
    {
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public long? CompanyId { get; set; }
    }
}
