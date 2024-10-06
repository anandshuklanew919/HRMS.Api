using HRMS.Api.Data.Database;
using HRMS.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Api.Data.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>
    {
        public DepartmentRepository(AppDbContex context) : base(context)
        {
        }
    }
}
