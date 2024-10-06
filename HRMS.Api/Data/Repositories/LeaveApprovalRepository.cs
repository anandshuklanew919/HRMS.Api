using HRMS.Api.Data.Database;
using HRMS.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Api.Data.Repositories
{
    public class LeaveApprovalRepository : BaseRepository<LeaveApproval>
    {
        public LeaveApprovalRepository(AppDbContex context) : base(context)
        {
        }
    }
}
