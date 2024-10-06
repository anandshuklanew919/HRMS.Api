using HRMS.Api.Data.Entities;
using HRMS.Api.Data.Repositories;
using HRMS.Api.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Api.Services
{
    public class LeaveApprovalService
    {
        private readonly LeaveApprovalRepository _leaveApprovalRepository;

        public LeaveApprovalService(LeaveApprovalRepository leaveApprovalRepository)
        {
            _leaveApprovalRepository = leaveApprovalRepository;
        }

        public async Task<IEnumerable<LeaveApprovalDTO>> GetAllLeaveApprovalsAsync()
        {
            var leaveApprovals = await _leaveApprovalRepository.GetAllAsync();
            return leaveApprovals.Select(la => new LeaveApprovalDTO
            {
                ApprovalId = la.ApprovalId,
                LeaveRequestId = la.LeaveRequestId,
                ApproverId1 = la.ApproverId1,
                ApprovalDate1 = la.ApprovalDate1,
                ApprovalStatus1 = la.ApprovalStatus1,
                ApprovalComments1 = la.ApprovalComments1
            });
        }

        public async Task<LeaveApprovalDTO> GetLeaveApprovalByIdAsync(long id)
        {
            var leaveApproval = await _leaveApprovalRepository.GetByIdAsync(id);
            return new LeaveApprovalDTO
            {
                ApprovalId = leaveApproval.ApprovalId,
                LeaveRequestId = leaveApproval.LeaveRequestId,
                ApproverId1 = leaveApproval.ApproverId1,
                ApprovalDate1 = leaveApproval.ApprovalDate1,
                ApprovalStatus1 = leaveApproval.ApprovalStatus1,
                ApprovalComments1 = leaveApproval.ApprovalComments1
            };
        }

        public async Task AddLeaveApprovalAsync(LeaveApprovalDTO leaveApprovalDto)
        {
            var leaveApproval = new LeaveApproval
            {
                LeaveRequestId = leaveApprovalDto.LeaveRequestId,
                ApproverId1 = leaveApprovalDto.ApproverId1,
                ApprovalDate1 = leaveApprovalDto.ApprovalDate1,
                ApprovalStatus1 = leaveApprovalDto.ApprovalStatus1,
                ApprovalComments1 = leaveApprovalDto.ApprovalComments1
            };

            await _leaveApprovalRepository.AddAsync(leaveApproval);
        }

        public async Task UpdateLeaveApprovalAsync(LeaveApprovalDTO leaveApprovalDto)
        {
            var leaveApproval = await _leaveApprovalRepository.GetByIdAsync(leaveApprovalDto.ApprovalId);
            if (leaveApproval != null)
            {
                leaveApproval.LeaveRequestId = leaveApprovalDto.LeaveRequestId;
                leaveApproval.ApproverId1 = leaveApprovalDto.ApproverId1;
                leaveApproval.ApprovalDate1 = leaveApprovalDto.ApprovalDate1;
                leaveApproval.ApprovalStatus1 = leaveApprovalDto.ApprovalStatus1;
                leaveApproval.ApprovalComments1 = leaveApprovalDto.ApprovalComments1;

                await _leaveApprovalRepository.UpdateAsync(leaveApproval);
            }
        }

        public async Task DeleteLeaveApprovalAsync(long id)
        {
            await _leaveApprovalRepository.DeleteAsync(id);
        }
    }
}
