using HRMS.Api.Dtos;
using HRMS.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveBalanceController : ControllerBase
    {
        private readonly LeaveBalanceService _leaveBalanceService;

        public LeaveBalanceController(LeaveBalanceService leaveBalanceService)
        {
            _leaveBalanceService = leaveBalanceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveBalanceDTO>>> GetLeaveBalances()
        {
            var leaveBalances = await _leaveBalanceService.GetAllLeaveBalancesAsync();
            return Ok(leaveBalances);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveBalanceDTO>> GetLeaveBalance(long id)
        {
            var leaveBalance = await _leaveBalanceService.GetLeaveBalanceByIdAsync(id);
            if (leaveBalance == null)
                return NotFound();
            return Ok(leaveBalance);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLeaveBalance([FromBody] LeaveBalanceDTO leaveBalanceDto)
        {
            await _leaveBalanceService.AddLeaveBalanceAsync(leaveBalanceDto);
            return CreatedAtAction(nameof(GetLeaveBalance), new { id = leaveBalanceDto.LeaveBalanceId }, leaveBalanceDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLeaveBalance(long id, [FromBody] LeaveBalanceDTO leaveBalanceDto)
        {
            if (id != leaveBalanceDto.LeaveBalanceId)
                return BadRequest();

            await _leaveBalanceService.UpdateLeaveBalanceAsync(leaveBalanceDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLeaveBalance(long id)
        {
            await _leaveBalanceService.DeleteLeaveBalanceAsync(id);
            return NoContent();
        }
    }
}
