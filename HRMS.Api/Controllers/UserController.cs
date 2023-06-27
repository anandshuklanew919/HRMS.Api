using HRMS.Api.Business.UserManagement.DTO;
using HRMS.Api.Business.UserManagement.UserRepository;
using HRMS.Api.ResponseWrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace HRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet("get-all-users")]
        [Authorize]
        public async Task<List<SignUpUserEditDto>> GetAllUsers()
        {
            var result = await _userRepository.GetUsersAsync();
            return result;
        }

        [HttpGet("get-user-by-user-name")]
        [Authorize]
        public async Task<SignUpUserEditDto> GetUserByUserName([Required]string UserName)
        {
            var result = await _userRepository.GetUserByUserNameAsync(UserName);
            return result;
        }


        [HttpPost("create-user")]
        [Authorize]
        public async Task<IActionResult> CreateUser([Required] [FromBody]SignUpUserDto signUpUserDto)
        {
            var result = await _userRepository.CreateUserAsync(signUpUserDto);
            if (result != null && result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            else if(result != null && !result.Succeeded)
            {
                var errors = result.Errors?.Select(error => error.Description.ToString());
                return BadRequest(HrmsApiResponse.ValidationResponse(errors));
            }
            return BadRequest(HrmsApiResponse.ErrorResponse(HttpStatusCode.BadRequest, "User already exist"));
        }

        [HttpPut("edit-user")]
        [Authorize]
        public async Task<IActionResult> EditUser([Required][FromBody] SignUpUserEditDto signUpUserEditDto)
        {
            var result = await _userRepository.EditUserAsync(signUpUserEditDto);
            if (result != null && result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            else if (result != null && !result.Succeeded)
            {
                var errors = result.Errors?.Select(error => error.Description.ToString());
                return BadRequest(HrmsApiResponse.ValidationResponse(errors));
            }
            return BadRequest(HrmsApiResponse.ErrorResponse(HttpStatusCode.BadRequest, "Invalid user"));
        }


        [HttpDelete("Delete-user")]
        [Authorize]
        public async Task<IActionResult> DeleteUser([Required] string UserName)
        {
            var result = await _userRepository.DeleteUserAsync(UserName);
            if (result != null && result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            else if (result != null && !result.Succeeded)
            {
                var errors = result.Errors?.Select(error => error.Description.ToString());
                return BadRequest(HrmsApiResponse.ValidationResponse(errors));
            }
            return BadRequest(HrmsApiResponse.ErrorResponse(HttpStatusCode.BadRequest, "Invalid user"));
        }


        [HttpGet("get-role")]
        [Authorize]
        public async Task<List<RoleGridDto>> GetRoles()
        {
            var result = await _userRepository.GetRoleAsync();
            return result;
        }


        [HttpPost("create-role")]
        [Authorize]
        public async Task<IActionResult> CreateRole([Required] string role)
        {
            var result = await _userRepository.CreateRoleAsync(role);

            if (result != null && result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            else if (result != null && !result.Succeeded)
            {
                var errors = result.Errors?.Select(error => error.Description.ToString());
                return BadRequest(HrmsApiResponse.ValidationResponse(errors));
            }

            return BadRequest(HrmsApiResponse.ErrorResponse(HttpStatusCode.BadRequest,"Role already exist"));
        }

        [HttpPut("edit-role")]
        [Authorize]
        public async Task<IActionResult> EditeRole([Required] RoleDto roleDto)
        {
            var result = await _userRepository.EditRoleAsync(roleDto);
            if (result != null && result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            else if (result != null && !result.Succeeded)
            {
                var errors = result.Errors?.Select(error => error.Description.ToString());
                return BadRequest(HrmsApiResponse.ValidationResponse(errors));
            }
            return BadRequest(HrmsApiResponse.ErrorResponse(HttpStatusCode.BadRequest, "Role does not exist"));
        }

        [HttpDelete("delete-role")]
        [Authorize]
        public async Task<IActionResult> DeleteRole([Required] string roleId)
        {
            var result = await _userRepository.DeleteRoleAsync(roleId);
            if (result != null && result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            else if (result != null && !result.Succeeded)
            {
                var errors = result.Errors?.Select(error => error.Description.ToString());
                return BadRequest(HrmsApiResponse.ValidationResponse(errors));
            }
            return BadRequest(HrmsApiResponse.ErrorResponse(HttpStatusCode.BadRequest, "Either role is assigned or does not exist"));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginDto loginDto)
        {
            var result = await _userRepository.LoginAsync(loginDto);
            if(result == null)
            {
                return Unauthorized();
            }
                return Ok(result);
        }
    }
}
