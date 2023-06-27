using System.ComponentModel.DataAnnotations;

namespace HRMS.Api.Business.UserManagement.DTO
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
