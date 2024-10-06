using HRMS.Api.Data.Entities;
using HRMS.Api.Data.Repositories;
using HRMS.Api.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Api.Services
{
    public class LeaveTypeService
    {
        private readonly LeaveTypeRepository _leaveTypeRepository;

        public LeaveTypeService(LeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<IEnumerable<LeaveTypeDTO>> GetAllLeaveTypesAsync()
        {
            var leaveTypes = await _leaveTypeRepository.GetAllAsync();
            return leaveTypes.Select(l => new LeaveTypeDTO
            {
                LeaveTypeId = l.LeaveTypeId,
                TypeName = l.TypeName,
                Description = l.Description,
                IsActive = l.IsActive,
                CompanyId = l.CompanyId
            });
        }

        public async Task<LeaveTypeDTO> GetLeaveTypeByIdAsync(int id)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
            return new LeaveTypeDTO
            {
                LeaveTypeId = leaveType.LeaveTypeId,
                TypeName = leaveType.TypeName,
                Description = leaveType.Description,
                IsActive = leaveType.IsActive,
                CompanyId = leaveType.CompanyId
            };
        }

        public async Task AddLeaveTypeAsync(LeaveTypeDTO leaveTypeDto)
        {
            var leaveType = new LeaveType
            {
                TypeName = leaveTypeDto.TypeName,
                Description = leaveTypeDto.Description,
                IsActive = leaveTypeDto.IsActive,
                CompanyId = leaveTypeDto.CompanyId
            };

            await _leaveTypeRepository.AddAsync(leaveType);
        }

        public async Task UpdateLeaveTypeAsync(LeaveTypeDTO leaveTypeDto)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(leaveTypeDto.LeaveTypeId);
            if (leaveType != null)
            {
                leaveType.TypeName = leaveTypeDto.TypeName;
                leaveType.Description = leaveTypeDto.Description;
                leaveType.IsActive = leaveTypeDto.IsActive;
                leaveType.CompanyId = leaveTypeDto.CompanyId;

                await _leaveTypeRepository.UpdateAsync(leaveType);
            }
        }

        public async Task DeleteLeaveTypeAsync(int id)
        {
            await _leaveTypeRepository.DeleteAsync(id);
        }
    }
}
