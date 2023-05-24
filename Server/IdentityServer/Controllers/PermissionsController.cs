using AutoMapper;
using IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IdentityServer.Controllers
{
    /// <summary>
    /// Controller to manage roles and claims
    /// </summary>
    [Route("identity/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public PermissionsController(RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager  = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Roles()
        {
            return new ObjectResult(_roleManager.Roles.ToList());
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SetUserClaim([FromBody] UserClaimDto userClaim)
        {
            var user = await _userManager.FindByIdAsync(userClaim.UserId);
            Claim claim = _mapper.Map<Claim>(userClaim);    
            await _userManager.AddClaimAsync(user, claim);

            return Ok(); 
        }
    }
}
