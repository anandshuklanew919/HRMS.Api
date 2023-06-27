using Microsoft.AspNetCore.Identity;

namespace HRMS.Api.Data.Entities
{
    public class HrmsRole : IdentityRole
    {
        public virtual ICollection<HrmsUserRole> HrmsUserRoles { get; set; }
    }
}
