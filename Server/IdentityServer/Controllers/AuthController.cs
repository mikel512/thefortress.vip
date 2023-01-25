using AutoMapper;
using IdentityServer.DAL;
using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Common.Attributes;

namespace IdentityServer.Controllers
{
    [NTypewriterIgnore]
    [Route("identity/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IIdentityUnitOfWork _identity;
        private IMapper _mapper;
        private IConfiguration _configuration;

        public AuthController(IIdentityUnitOfWork unitOfWork, 
            IMapper mapper, 
            IConfiguration configuration)
        {
            _identity = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        } 

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] RegistrationDto model)
        {
            if (String.IsNullOrEmpty(model.Username))
            {
                model.Username = model.Email;
            }
            IdentityResult result = await _identity.UserAuth.RegisterUserAsync(model);
            return !result.Succeeded ? new BadRequestObjectResult(result) : StatusCode(201);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {
            var jwtConf = _configuration.GetSection("JwtConfig");
            return !await _identity.UserAuth.ValidateUserAsync(user)
                ? Unauthorized(new { errorMessage = "Wrong username or password" } )
                : Ok(new
                {
                    Token = await _identity.UserAuth.CreateTokenAsync(),
                    ExpiresIn = Convert.ToDouble(jwtConf["TimeTilExp"]) * 60
                });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (String.IsNullOrEmpty(userId)|| String.IsNullOrEmpty(code))
            {
                return new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }

            return await _identity.UserAuth.ConfirmEmailAsync(userId, code);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                return Ok();
            }

            return await _identity.UserAuth.SendPasswordResetAsync(email); 
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPassword([FromBody] LoginDto input)
        {
            if (String.IsNullOrEmpty(input.Username) || String.IsNullOrEmpty(input.Code) || String.IsNullOrEmpty(input.Password))
            {
                return Ok();
            }

            return await _identity.UserAuth.ResetPasswordAsync(input.Username, input.Code, input.Password);
        }
    }
}
