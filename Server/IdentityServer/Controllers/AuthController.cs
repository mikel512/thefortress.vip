using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using vDomain.Attributes;
using vDomain.Dto;
using vDomain.Interface;

namespace IdentityServer.Controllers
{
    [NTypewriterIgnore]
    [Route("identity/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserAuthService _auth;
        private IConfiguration _configuration;

        public AuthController(IUserAuthService auth, 
            IConfiguration configuration)
        {
            _auth = auth;
            _configuration = configuration;
        } 

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] RegistrationDto model)
        {
            if (String.IsNullOrEmpty(model.Username))
            {
                model.Username = model.Email;
            }
            IdentityResult result = await _auth.RegisterUserAsync(model);
            return !result.Succeeded ? new BadRequestObjectResult(result) : StatusCode(201);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {
            var jwtConf = _configuration.GetSection("JwtConfig");
            return !await _auth.ValidateUserAsync(user)
                ? Unauthorized(new { errorMessage = "Wrong username or password" } )
                : Ok(new
                {
                    Token = await _auth.CreateTokenAsync(),
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

            return Ok(await _auth.ConfirmEmailAsync(userId, code));

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                return Ok();
            }

            return Ok(await _auth.SendPasswordResetAsync(email)); 
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPassword([FromBody] LoginDto input)
        {
            if (String.IsNullOrEmpty(input.Username) || String.IsNullOrEmpty(input.Code) || String.IsNullOrEmpty(input.Password))
            {
                return Ok();
            }

            return Ok(await _auth.ResetPasswordAsync(input.Username, input.Code, input.Password));
        }
    }
}
