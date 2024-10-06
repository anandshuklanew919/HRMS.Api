using HRMS.Api.Data.Database;
using HRMS.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Api.Data.Repositories
{
    public class LeaveTypeRepository : BaseRepository<LeaveType>
    {
        public LeaveTypeRepository(AppDbContex context) : base(context)
        {
        }
    }
}
