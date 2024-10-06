using HRMS.Api.Dtos;
using HRMS.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveTypeController : ControllerBase
    {
        private readonly LeaveTypeService _leaveTypeService;

        public LeaveTypeController(LeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveTypeDTO>>> GetLeaveTypes()
        {
            var leaveTypes = await _leaveTypeService.GetAllLeaveTypesAsync();
            return Ok(leaveTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDTO>> GetLeaveType(int id)
        {
            var leaveType = await _leaveTypeService.GetLeaveTypeByIdAsync(id);
            if (leaveType == null)
                return NotFound();
            return Ok(leaveType);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLeaveType([FromBody] LeaveTypeDTO leaveTypeDto)
        {
            await _leaveTypeService.AddLeaveTypeAsync(leaveTypeDto);
            return CreatedAtAction(nameof(GetLeaveType), new { id = leaveTypeDto.LeaveTypeId }, leaveTypeDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLeaveType(int id, [FromBody] LeaveTypeDTO leaveTypeDto)
        {
            if (id != leaveTypeDto.LeaveTypeId)
                return BadRequest();

            await _leaveTypeService.UpdateLeaveTypeAsync(leaveTypeDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLeaveType(int id)
        {
            await _leaveTypeService.DeleteLeaveTypeAsync(id);
            return NoContent();
        }
    }
}
