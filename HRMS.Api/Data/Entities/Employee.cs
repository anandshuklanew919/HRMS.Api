using System;
using System.Collections.Generic;

namespace HRMS.Api.Data.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            InverseManager = new HashSet<Employee>();
            InverseTeamLead = new HashSet<Employee>();
            LeaveApprovalApproverId1Navigations = new HashSet<LeaveApproval>();
            LeaveApprovalApproverId2Navigations = new HashSet<LeaveApproval>();
            LeaveApprovalApproverId3Navigations = new HashSet<LeaveApproval>();
            LeaveApprovalApproverId4Navigations = new HashSet<LeaveApproval>();
            LeaveApprovalApproverId5Navigations = new HashSet<LeaveApproval>();
            LeaveBalances = new HashSet<LeaveBalance>();
            LeaveRequests = new HashSet<LeaveRequest>();
        }

        public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? JoinDate { get; set; }
        public string Position { get; set; }
        public long? ManagerId { get; set; }
        public long? TeamLeadId { get; set; }
        public long? CompanyId { get; set; }
        public long? DepartmentId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Department Department { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual Employee TeamLead { get; set; }
        public virtual ICollection<Employee> InverseManager { get; set; }
        public virtual ICollection<Employee> InverseTeamLead { get; set; }
        public virtual ICollection<LeaveApproval> LeaveApprovalApproverId1Navigations { get; set; }
        public virtual ICollection<LeaveApproval> LeaveApprovalApproverId2Navigations { get; set; }
        public virtual ICollection<LeaveApproval> LeaveApprovalApproverId3Navigations { get; set; }
        public virtual ICollection<LeaveApproval> LeaveApprovalApproverId4Navigations { get; set; }
        public virtual ICollection<LeaveApproval> LeaveApprovalApproverId5Navigations { get; set; }
        public virtual ICollection<LeaveBalance> LeaveBalances { get; set; }
        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }

    }
}
