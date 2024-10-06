using HRMS.Api.Data.Entities;
using HRMS.Api.Data.Repositories;
using HRMS.Api.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Api.Services
{
    public class LeaveBalanceService
    {
        private readonly LeaveBalanceRepository _leaveBalanceRepository;

        public LeaveBalanceService(LeaveBalanceRepository leaveBalanceRepository)
        {
            _leaveBalanceRepository = leaveBalanceRepository;
        }

        public async Task<IEnumerable<LeaveBalanceDTO>> GetAllLeaveBalancesAsync()
        {
            var leaveBalances = await _leaveBalanceRepository.GetAllAsync();
            return leaveBalances.Select(lb => new LeaveBalanceDTO
            {
                LeaveBalanceId = lb.LeaveBalanceId,
                EmployeeId = lb.EmployeeId,
                LeaveTypeId = lb.LeaveTypeId,
                Balance = lb.Balance
            });
        }

        public async Task<LeaveBalanceDTO> GetLeaveBalanceByIdAsync(long id)
        {
            var leaveBalance = await _leaveBalanceRepository.GetByIdAsync(id);
            return new LeaveBalanceDTO
            {
                LeaveBalanceId = leaveBalance.LeaveBalanceId,
                EmployeeId = leaveBalance.EmployeeId,
                LeaveTypeId = leaveBalance.LeaveTypeId,
                Balance = leaveBalance.Balance
            };
        }

        public async Task AddLeaveBalanceAsync(LeaveBalanceDTO leaveBalanceDto)
        {
            var leaveBalance = new LeaveBalance
            {
                EmployeeId = leaveBalanceDto.EmployeeId,
                LeaveTypeId = leaveBalanceDto.LeaveTypeId,
                Balance = leaveBalanceDto.Balance
            };

            await _leaveBalanceRepository.AddAsync(leaveBalance);
        }

        public async Task UpdateLeaveBalanceAsync(LeaveBalanceDTO leaveBalanceDto)
        {
            var leaveBalance = await _leaveBalanceRepository.GetByIdAsync(leaveBalanceDto.LeaveBalanceId);
            if (leaveBalance != null)
            {
                leaveBalance.EmployeeId = leaveBalanceDto.EmployeeId;
                leaveBalance.LeaveTypeId = leaveBalanceDto.LeaveTypeId;
                leaveBalance.Balance = leaveBalanceDto.Balance;

                await _leaveBalanceRepository.UpdateAsync(leaveBalance);
            }
        }

        public async Task DeleteLeaveBalanceAsync(long id)
        {
            await _leaveBalanceRepository.DeleteAsync(id);
        }
    }
}
