using HRMS.Api.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Api.Data.Database
{
    public class AppDbContex : IdentityDbContext<HrmsUser, HrmsRole, string,
        IdentityUserClaim<string>, HrmsUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public AppDbContex(DbContextOptions<AppDbContex> options) : base(options)
        {

        }

        public DbSet<HrmsUser> HrmsUsers { get; set; }
        public DbSet<HrmsRole> HrmsRoles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<HrmsUser>(u =>
            {
                u.HasMany(e => e.HrmsUserRoles)
                .WithOne(e => e.HrmsUser)
                .HasForeignKey(e => e.UserId)
                .IsRequired();
            });

            builder.Entity<HrmsRole>(r =>
            {
                r.HasMany(e => e.HrmsUserRoles)
                .WithOne(r => r.HrmsRole)
                .HasForeignKey(e => e.RoleId)
                .IsRequired();

            });
        }

   
    }
}
