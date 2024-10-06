using HRMS.Api.Data.Entities;
using HRMS.Api.Data.Repositories;
using HRMS.Api.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Api.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees.Select(e => new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Gender = e.Gender,
                DateOfBirth = e.DateOfBirth,
                JoinDate = e.JoinDate,
                Position = e.Position,
                ManagerId = e.ManagerId,
                TeamLeadId = e.TeamLeadId,
                CompanyId = e.CompanyId,
                DepartmentId = e.DepartmentId
            });
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(long id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                DateOfBirth = employee.DateOfBirth,
                JoinDate = employee.JoinDate,
                Position = employee.Position,
                ManagerId = employee.ManagerId,
                TeamLeadId = employee.TeamLeadId,
                CompanyId = employee.CompanyId,
                DepartmentId = employee.DepartmentId
            };
        }

        public async Task AddEmployeeAsync(EmployeeDTO employeeDto)
        {
            var employee = new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Gender = employeeDto.Gender,
                DateOfBirth = employeeDto.DateOfBirth,
                JoinDate = employeeDto.JoinDate,
                Position = employeeDto.Position,
                ManagerId = employeeDto.ManagerId,
                TeamLeadId = employeeDto.TeamLeadId,
                CompanyId = employeeDto.CompanyId,
                DepartmentId = employeeDto.DepartmentId
            };

            await _employeeRepository.AddAsync(employee);
        }

        public async Task UpdateEmployeeAsync(EmployeeDTO employeeDto)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeDto.EmployeeId);
            if (employee != null)
            {
                employee.FirstName = employeeDto.FirstName;
                employee.LastName = employeeDto.LastName;
                employee.Gender = employeeDto.Gender;
                employee.DateOfBirth = employeeDto.DateOfBirth;
                employee.JoinDate = employeeDto.JoinDate;
                employee.Position = employeeDto.Position;
                employee.ManagerId = employeeDto.ManagerId;
                employee.TeamLeadId = employeeDto.TeamLeadId;
                employee.CompanyId = employeeDto.CompanyId;
                employee.DepartmentId = employeeDto.DepartmentId;

                await _employeeRepository.UpdateAsync(employee);
            }
        }

        public async Task DeleteEmployeeAsync(long id)
        {
            await _employeeRepository.DeleteAsync(id);
        }
    }
}
