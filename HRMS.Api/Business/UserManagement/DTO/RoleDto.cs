using System.ComponentModel.DataAnnotations;

namespace HRMS.Api.Business.UserManagement.DTO
{
    public class RoleDto
    {
        [Required]
        public string RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }


    }


    public class RoleGridDto
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsDelete { get; set; }
    }
}
