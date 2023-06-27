using HRMS.Api.AppSettings;
using HRMS.Api.Business.UserManagement.DTO;
using HRMS.Api.Data.Database;
using HRMS.Api.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace HRMS.Api.Business.UserManagement.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<HrmsUser> _userManager;
        private readonly SignInManager<HrmsUser> _signInManager;
        private readonly RoleManager<HrmsRole> roleManager;
        private readonly HRMSAppSettings HRMSAppSettings;
        private readonly AppDbContex appDbContex;

        public UserRepository(UserManager<HrmsUser> userManager, SignInManager<HrmsUser> signInManager, 
                                RoleManager<HrmsRole> roleManager, IOptions<HRMSAppSettings> options, 
                                AppDbContex appDbContex)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.roleManager = roleManager;
            HRMSAppSettings = options.Value;
            this.appDbContex = appDbContex;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpUserDto signUpUserDto)
        {
            var user = new HrmsUser()
            {
                FirstName = signUpUserDto.FirstName,
                MiddleName = signUpUserDto.MiddleName,
                LastName = signUpUserDto.LastName,
                DataOfBirth = signUpUserDto.DataOfBirth,
                UserName = signUpUserDto.UserName,
                Email = signUpUserDto.Email
            };
            var isUserExist = await _userManager.FindByNameAsync(signUpUserDto.UserName);
            if (isUserExist == null)
            {
                var result = await _userManager.CreateAsync(user, signUpUserDto.Password);
                if (result.Succeeded && signUpUserDto != null && signUpUserDto.RoleNames.Count() > 0)
                {
                    await _userManager.AddToRolesAsync(user, signUpUserDto.RoleNames.Select(roleId => roleId));
                }
                return result;
            }
            return IdentityResult.Failed(new IdentityError() { Code = HttpStatusCode.BadRequest.ToString(), Description = "Already exist user" });
        }


        public async Task<IdentityResult> EditUserAsync(SignUpUserEditDto signUpUserEditDto)
        {

            var userToEdit = await _userManager.FindByNameAsync(signUpUserEditDto.UserName);
            if (userToEdit != null)
            {
                userToEdit.Email = signUpUserEditDto.Email;
                userToEdit.DataOfBirth = signUpUserEditDto.DataOfBirth;
                userToEdit.FirstName = signUpUserEditDto.FirstName;
                userToEdit.LastName = signUpUserEditDto.LastName;
                userToEdit.MiddleName = signUpUserEditDto.MiddleName;

                var result = await _userManager.UpdateAsync(userToEdit);
                if (result.Succeeded && signUpUserEditDto != null && signUpUserEditDto.RoleNames.Count() > 0)
                {
                    IEnumerable<string> userRoles = await _userManager.GetRolesAsync(userToEdit);
                    IEnumerable<string> roleToAssignUser = signUpUserEditDto.RoleNames.Except(userRoles);
                    IEnumerable<string> roleToDeleteFromUser = userRoles.Except(signUpUserEditDto.RoleNames);

                    await _userManager.RemoveFromRolesAsync(userToEdit, roleToDeleteFromUser);
                    await _userManager.AddToRolesAsync(userToEdit, roleToAssignUser);
                }
                return result;
            }
            return IdentityResult.Failed(new IdentityError() { Code = HttpStatusCode.BadRequest.ToString(), Description = "Invalid user" });
        }


        public async Task<IdentityResult> DeleteUserAsync(string UserName)
        {

            var userToDelete = await _userManager.FindByNameAsync(UserName);
            if (userToDelete != null)
            {
                userToDelete.IsDeleted = true;
                var result = await _userManager.UpdateAsync(userToDelete);

                return result;
            }

            return IdentityResult.Failed(new IdentityError() { Code = HttpStatusCode.BadRequest.ToString(), Description = "Invalid user" });
        }


        public async Task<List<SignUpUserEditDto>> GetUsersAsync()
        {
            var roles =  await roleManager.Roles?.ToListAsync();
            var users= await _userManager.Users.Include(x => x.HrmsUserRoles).Where(user => !user.IsDeleted).ToListAsync();

            var userList = users.Select(user => new SignUpUserEditDto()
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Email = user.Email,
                DataOfBirth = user.DataOfBirth,
                UserName = user.UserName,
                RoleNames = roles.Where(r=>  user.HrmsUserRoles.Select(ur=> ur.RoleId).Any(x=> x == r.Id)).Select(r=> r.Name).ToList(),
            }).ToList();

            return userList;
        }


        public async Task<SignUpUserEditDto> GetUserByUserNameAsync(string userName)
        {
            var roles = await roleManager.Roles?.ToListAsync();
            var users = await _userManager.Users.Include(x => x.HrmsUserRoles).Where(user => !user.IsDeleted && user.UserName == userName).ToListAsync();
            var roleIds = users.SelectMany(ur => ur?.HrmsUserRoles)?.Select(r => r.RoleId)?.ToList();

            var userList = users.Select(user => new SignUpUserEditDto()
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Email = user.Email,
                DataOfBirth = user.DataOfBirth,
                UserName = user.UserName,
                RoleNames = roles.Where(r => user.HrmsUserRoles.Select(ur => ur.RoleId).Any(x => x == r.Id)).Select(r => r.Name).ToList(),
            }).FirstOrDefault();

            return userList;
        }

        public async Task<List<RoleGridDto>> GetRoleAsync()
        {
            var Roles = await roleManager.Roles.Include(x=> x.HrmsUserRoles).Select(role => new RoleGridDto()
            {
                RoleId = role.Id,
                RoleName = role.Name,
                IsDelete = role.HrmsUserRoles.Count()<=0
            }).ToListAsync();

            return Roles;
        }

        public async Task<IdentityResult> CreateRoleAsync(string name)
        {
            var isRoleExist = await roleManager.RoleExistsAsync(name);
            if (!isRoleExist)
            {
                HrmsRole hrmsRole = new HrmsRole() { Name = name };
                IdentityResult result = await roleManager.CreateAsync(hrmsRole);
                return result;
            }
            return IdentityResult.Failed(new IdentityError() { Code = HttpStatusCode.BadRequest.ToString(), Description = "Already exist role" });
        }


        public async Task<IdentityResult> EditRoleAsync(RoleDto roleDto)
        {
            var roleToEdit = roleManager.Roles.Where(x => x.Id == roleDto.RoleId).FirstOrDefault();
            if (roleToEdit != null)
            {
                roleToEdit.Name = roleDto.RoleName;
                IdentityResult result = await roleManager.UpdateAsync(roleToEdit);
                return result;
            }
            return IdentityResult.Failed(new IdentityError() { Code = HttpStatusCode.BadRequest.ToString(), Description = "role does not exist" });
        }

        public async Task<IdentityResult> DeleteRoleAsync(string roleId)
        {
            var roleToDelete = roleManager.Roles.Where(x => x.Id == roleId).FirstOrDefault();
            var usersInRole = await _userManager.GetUsersInRoleAsync(roleToDelete.Name);

            if (roleToDelete != null && usersInRole != null && usersInRole.Count <= 0)
            {
                IdentityResult result = await roleManager.DeleteAsync(roleToDelete);
                return result;
            }

            return IdentityResult.Failed(new IdentityError() { Code = HttpStatusCode.BadRequest.ToString(), Description = "role does not exist to delete" });
        }


        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);

            if (!result.Succeeded)
            {
                return null;
            }

            var authClaim = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginDto.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(HRMSAppSettings.AuthSettings.Secret));

            var token = new JwtSecurityToken(
                issuer: HRMSAppSettings.AuthSettings.ValidIssuer,
                audience: HRMSAppSettings.AuthSettings.ValidAudience,
                expires: DateTime.Now.AddMinutes(HRMSAppSettings.AuthSettings.AccessTokenExpiration),
                claims: authClaim,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
