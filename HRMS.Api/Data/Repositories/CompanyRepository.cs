using HRMS.Api.Data.Database;
using HRMS.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Api.Data.Repositories
{
    public class CompanyRepository : BaseRepository<Company>
    {
        public CompanyRepository(AppDbContex context) : base(context)
        {
        }
    }
}
