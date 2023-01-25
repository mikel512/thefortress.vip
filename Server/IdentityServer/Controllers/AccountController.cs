﻿using Common.Attributes;
using IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace IdentityServer.Controllers
{
    [Route("auth/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
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

                if(userId == null)
                {
                    return new StatusCodeResult(StatusCodes.Status403Forbidden);
                }

                ApplicationUser user = await _userManager.FindByIdAsync(userId);
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

    }
}