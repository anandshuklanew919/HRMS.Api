using Microsoft.AspNetCore.Identity;

namespace HRMS.Api.Data.Entities
{
    public class HrmsUserRole :IdentityUserRole<string>
    {
        public virtual HrmsUser HrmsUser { get; set; }
        public virtual HrmsRole HrmsRole { get; set; }
    }
}
