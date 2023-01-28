using AutoMapper;
using Common.Attributes;
using IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace IdentityServer.Controllers
{
    [Route("identity/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private IMapper _mapper;

        public AccountController(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        [Authorize]
        [ReturnType("AppUserDto")]
        public async Task<IActionResult> UpdateUserInfo([FromBody] AppUserDto appUserDto)
        {
            try
            {
                var req = Request.Headers.Authorization[0].Replace("Bearer ", "");
                JwtSecurityToken token = new JwtSecurityTokenHandler().ReadJwtToken(req);
                string userId = token.Claims.Where(x => x.Type == ClaimTypes.Sid).FirstOrDefault().Value;

                if (userId == null)
                {
                    return new StatusCodeResult(StatusCodes.Status403Forbidden);
                }

                ApplicationUser user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return new StatusCodeResult(StatusCodes.Status404NotFound);
                }

                user.UserName = appUserDto.UserName;
                user.Email = appUserDto.Email;
                user.MailingListEnabled = appUserDto.MailingListEnabled;

                await _userManager.UpdateAsync(user);

                // TODO send email to new email if it changed

                return new ObjectResult(user);
            }
            catch (Exception e)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("[action]")]
        [Authorize]
        [ReturnType("AppUserDto")]
        public async Task<IActionResult> GetUserInfo()
        {
            try
            {
                var req = Request.Headers.Authorization[0].Replace("Bearer ", "");
                JwtSecurityToken token = new JwtSecurityTokenHandler().ReadJwtToken(req);
                string userId = token.Claims.Where(x => x.Type == ClaimTypes.Sid).FirstOrDefault().Value;

                if (userId == null)
                {
                    return new StatusCodeResult(StatusCodes.Status403Forbidden);
                }

                ApplicationUser user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return new StatusCodeResult(StatusCodes.Status404NotFound);
                }

                AppUserDto result = _mapper.Map<AppUserDto>(user);

                return new ObjectResult(result);
            }
            catch (Exception e)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpPut("[action]")]
        [ReturnType("any")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] AppUserDto appUser)
        {
            try
            {
                var req = Request.Headers.Authorization[0].Replace("Bearer ", "");
                JwtSecurityToken token = new JwtSecurityTokenHandler().ReadJwtToken(req);

                string userId = token.Claims.Where(x => x.Type == ClaimTypes.Sid).FirstOrDefault().Value;
                if (userId == null)
                {
                    return new StatusCodeResult(StatusCodes.Status403Forbidden);
                }

                ApplicationUser user = await _userManager.FindByIdAsync(userId); 
                if (user == null)
                {
                    return new StatusCodeResult(StatusCodes.Status404NotFound);
                }

                var changePasswordResult = await _userManager.ChangePasswordAsync(user, appUser.OldPassword, appUser.Password);
                if(!changePasswordResult.Succeeded)
                {
                    return new StatusCodeResult(StatusCodes.Status400BadRequest); 
                }

                return Ok();
            }
            catch (Exception e)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
