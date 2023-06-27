using HRMS.Api.Business.UserManagement.DTO;
using Microsoft.AspNetCore.Identity;

namespace HRMS.Api.Business.UserManagement.UserRepository
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserDto signUpUserDto);
        Task<IdentityResult> EditUserAsync(SignUpUserEditDto signUpUserEditDto);
        Task<IdentityResult> DeleteUserAsync(string UserName);
        Task<List<SignUpUserEditDto>> GetUsersAsync();
        Task<SignUpUserEditDto> GetUserByUserNameAsync(string userName);
        Task<List<RoleGridDto>> GetRoleAsync();
        Task<string> LoginAsync(LoginDto loginDto);
        Task<IdentityResult> CreateRoleAsync(string name);
        Task<IdentityResult> EditRoleAsync(RoleDto roleDto);
        Task<IdentityResult> DeleteRoleAsync(string roleId);

    }
}
