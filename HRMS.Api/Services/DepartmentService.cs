using HRMS.Api.Data.Entities;
using HRMS.Api.Data.Repositories;
using HRMS.Api.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Api.Services
{
    public class DepartmentService
    {
        private readonly DepartmentRepository _departmentRepository;

        public DepartmentService(DepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return departments.Select(d => new DepartmentDTO
            {
                DepartmentId = d.DepartmentId,
                DepartmentName = d.DepartmentName,
                CompanyId = d.CompanyId
            });
        }

        public async Task<DepartmentDTO> GetDepartmentByIdAsync(long id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            return new DepartmentDTO
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                CompanyId = department.CompanyId
            };
        }

        public async Task AddDepartmentAsync(DepartmentDTO departmentDto)
        {
            var department = new Department
            {
                DepartmentName = departmentDto.DepartmentName,
                CompanyId = departmentDto.CompanyId
            };

            await _departmentRepository.AddAsync(department);
        }

        public async Task UpdateDepartmentAsync(DepartmentDTO departmentDto)
        {
            var department = await _departmentRepository.GetByIdAsync(departmentDto.DepartmentId);
            if (department != null)
            {
                department.DepartmentName = departmentDto.DepartmentName;
                department.CompanyId = departmentDto.CompanyId;

                await _departmentRepository.UpdateAsync(department);
            }
        }

        public async Task DeleteDepartmentAsync(long id)
        {
            await _departmentRepository.DeleteAsync(id);
        }
    }
}
