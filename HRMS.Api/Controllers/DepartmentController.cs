using HRMS.Api.Dtos;
using HRMS.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDTO>>> GetDepartments()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDTO>> GetDepartment(long id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
                return NotFound();
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDepartment([FromBody] DepartmentDTO departmentDto)
        {
            await _departmentService.AddDepartmentAsync(departmentDto);
            return CreatedAtAction(nameof(GetDepartment), new { id = departmentDto.DepartmentId }, departmentDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDepartment(long id, [FromBody] DepartmentDTO departmentDto)
        {
            if (id != departmentDto.DepartmentId)
                return BadRequest();

            await _departmentService.UpdateDepartmentAsync(departmentDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(long id)
        {
            await _departmentService.DeleteDepartmentAsync(id);
            return NoContent();
        }
    }
}
