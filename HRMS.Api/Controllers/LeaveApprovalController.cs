using HRMS.Api.Dtos;
using HRMS.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveApprovalController : ControllerBase
    {
        private readonly LeaveApprovalService _leaveApprovalService;

        public LeaveApprovalController(LeaveApprovalService leaveApprovalService)
        {
            _leaveApprovalService = leaveApprovalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveApprovalDTO>>> GetLeaveApprovals()
        {
            var leaveApprovals = await _leaveApprovalService.GetAllLeaveApprovalsAsync();
            return Ok(leaveApprovals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveApprovalDTO>> GetLeaveApproval(long id)
        {
            var leaveApproval = await _leaveApprovalService.GetLeaveApprovalByIdAsync(id);
            if (leaveApproval == null)
                return NotFound();
            return Ok(leaveApproval);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLeaveApproval([FromBody] LeaveApprovalDTO leaveApprovalDto)
        {
            await _leaveApprovalService.AddLeaveApprovalAsync(leaveApprovalDto);
            return CreatedAtAction(nameof(GetLeaveApproval), new { id = leaveApprovalDto.ApprovalId }, leaveApprovalDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLeaveApproval(long id, [FromBody] LeaveApprovalDTO leaveApprovalDto)
        {
            if (id != leaveApprovalDto.ApprovalId)
                return BadRequest();

            await _leaveApprovalService.UpdateLeaveApprovalAsync(leaveApprovalDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLeaveApproval(long id)
        {
            await _leaveApprovalService.DeleteLeaveApprovalAsync(id);
            return NoContent();
        }
    }
}
