using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Api.Data.Entities
{
    public class HrmsUser : IdentityUser
    {
        public  string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? DataOfBirth { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("Id")]
        public string DeletedById { get; set; }
        public virtual ICollection<HrmsUserRole> HrmsUserRoles { get; set; }

    }
}
