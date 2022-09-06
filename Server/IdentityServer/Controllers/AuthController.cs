using AutoMapper;
using IdentityServer.DAL;
using IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IIdentityUnitOfWork _identity;
        private IMapper _mapper;
        private IConfiguration _configuration;

        public AuthController(IIdentityUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
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

    }
}
