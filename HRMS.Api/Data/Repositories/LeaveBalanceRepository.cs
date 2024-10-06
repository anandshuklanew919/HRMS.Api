using HRMS.Api.Data.Database;
using HRMS.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Api.Data.Repositories
{
    public class LeaveBalanceRepository : BaseRepository<LeaveBalance>
    {
        public LeaveBalanceRepository(AppDbContex context) : base(context)
        {
        }
    }
}
