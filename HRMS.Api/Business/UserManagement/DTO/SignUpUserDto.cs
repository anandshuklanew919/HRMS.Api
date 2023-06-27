using System.ComponentModel.DataAnnotations;

namespace HRMS.Api.Business.UserManagement.DTO
{
    public class SignUpUserDto
    {
        [Required,MaxLength(100)]
        public string FirstName { get; set; }

        [ MaxLength(100)]
        public string MiddleName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [Required, MaxLength(100)]
        public string UserName { get; set; }

        [Required, MaxLength(100),EmailAddress]
        public string Email { get; set; }
        public DateTime DataOfBirth { get; set; }

        [Required, MaxLength(50)]
        public string Password { get; set; }

        [Required, MaxLength(50), Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public List<string> RoleNames { get; set; }

    }


    public class SignUpUserEditDto
    {
        [Required]
        public string UserId { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [Required, MaxLength(100)]
        public string UserName { get; set; }

        [Required, MaxLength(100), EmailAddress]
        public string Email { get; set; }
        public DateTime? DataOfBirth { get; set; }
        [Required]
        public List<string> RoleNames { get; set; }

    }
}
