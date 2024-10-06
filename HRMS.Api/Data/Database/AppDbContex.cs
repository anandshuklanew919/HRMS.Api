using HRMS.Api.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Api.Data.Database
{
    public partial class AppDbContex : IdentityDbContext<HrmsUser, HrmsRole, string,
        IdentityUserClaim<string>, HrmsUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public AppDbContex(DbContextOptions<AppDbContex> options) : base(options)
        {

        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<LeaveApproval> LeaveApprovals { get; set; }
        public virtual DbSet<LeaveBalance> LeaveBalances { get; set; }
        public virtual DbSet<LeaveRequest> LeaveRequests { get; set; }
        public virtual DbSet<LeaveType> LeaveTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-T6Q9SGJ;Initial Catalog=LMS;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.CompanyId)
                    .ValueGeneratedNever()
                    .HasColumnName("CompanyID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("DepartmentID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.CompanyId);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeamLeadId).HasColumnName("TeamLeadID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CompanyId);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Employee_Employee_EmployeeID");

                entity.HasOne(d => d.TeamLead)
                    .WithMany(p => p.InverseTeamLead)
                    .HasForeignKey(d => d.TeamLeadId)
                    .HasConstraintName("FK_Employee_Employee_EmployeeID_TeamLeadID");

              
            });

            modelBuilder.Entity<LeaveApproval>(entity =>
            {
                entity.HasKey(e => e.ApprovalId)
                    .HasName("PK_LeaveApproval_ApprovalID");

                entity.ToTable("LeaveApproval");

                entity.Property(e => e.ApprovalId)
                    .ValueGeneratedNever()
                    .HasColumnName("ApprovalID");

                entity.Property(e => e.ApprovalComments1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalComments2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalComments3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalComments4)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalComments5)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalDate1).HasColumnType("date");

                entity.Property(e => e.ApprovalDate2).HasColumnType("date");

                entity.Property(e => e.ApprovalDate3).HasColumnType("date");

                entity.Property(e => e.ApprovalDate4).HasColumnType("date");

                entity.Property(e => e.ApprovalDate5).HasColumnType("date");

                entity.Property(e => e.ApprovalStatus1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ApprovalStatus2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ApprovalStatus3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ApprovalStatus4)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ApprovalStatus5)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ApproverId1).HasColumnName("ApproverID1");

                entity.Property(e => e.ApproverId2).HasColumnName("ApproverID2");

                entity.Property(e => e.ApproverId3).HasColumnName("ApproverID3");

                entity.Property(e => e.ApproverId4).HasColumnName("ApproverID4");

                entity.Property(e => e.ApproverId5).HasColumnName("ApproverID5");

                entity.Property(e => e.FinalApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.LeaveRequestId).HasColumnName("LeaveRequestID");

                entity.HasOne(d => d.ApproverId1Navigation)
                    .WithMany(p => p.LeaveApprovalApproverId1Navigations)
                    .HasForeignKey(d => d.ApproverId1);

                entity.HasOne(d => d.ApproverId2Navigation)
                    .WithMany(p => p.LeaveApprovalApproverId2Navigations)
                    .HasForeignKey(d => d.ApproverId2);

                entity.HasOne(d => d.ApproverId3Navigation)
                    .WithMany(p => p.LeaveApprovalApproverId3Navigations)
                    .HasForeignKey(d => d.ApproverId3);

                entity.HasOne(d => d.ApproverId4Navigation)
                    .WithMany(p => p.LeaveApprovalApproverId4Navigations)
                    .HasForeignKey(d => d.ApproverId4);

                entity.HasOne(d => d.ApproverId5Navigation)
                    .WithMany(p => p.LeaveApprovalApproverId5Navigations)
                    .HasForeignKey(d => d.ApproverId5);

                entity.HasOne(d => d.LeaveRequest)
                    .WithMany(p => p.LeaveApprovals)
                    .HasForeignKey(d => d.LeaveRequestId);
            });

            modelBuilder.Entity<LeaveBalance>(entity =>
            {
                entity.ToTable("LeaveBalance");

                entity.Property(e => e.LeaveBalanceId)
                    .ValueGeneratedNever()
                    .HasColumnName("LeaveBalanceID");

                entity.Property(e => e.Balance).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.LeaveTypeId).HasColumnName("LeaveTypeID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.LeaveBalances)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.LeaveType)
                    .WithMany(p => p.LeaveBalances)
                    .HasForeignKey(d => d.LeaveTypeId)
                    .HasConstraintName("FK__LeaveBala__Leave__4CA06362");
            });

            modelBuilder.Entity<LeaveRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK_LeaveRequest_RequestID");

                entity.ToTable("LeaveRequest");

                entity.Property(e => e.RequestId)
                    .ValueGeneratedNever()
                    .HasColumnName("RequestID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.FinalStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LeaveTypeId).HasColumnName("LeaveTypeID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.LeaveRequests)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.LeaveType)
                    .WithMany(p => p.LeaveRequests)
                    .HasForeignKey(d => d.LeaveTypeId);
            });

            modelBuilder.Entity<LeaveType>(entity =>
            {
                entity.ToTable("LeaveType");

                entity.Property(e => e.LeaveTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("LeaveTypeID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.LeaveTypes)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);

            base.OnModelCreating(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}

