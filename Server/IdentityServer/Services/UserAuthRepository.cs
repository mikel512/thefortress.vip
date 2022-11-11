using AutoMapper;
using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace IdentityServer.Services
{
    internal sealed class UserAuthRepository : IUserAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private IEmailService _emailService;
        private ApplicationUser _user;
        private readonly string _env;

        public UserAuthRepository(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IEmailService mailService,
            IConfiguration config,
            IMapper mapper)
        {
            _emailService = mailService;
            _userManager = userManager;
            _mapper = mapper;
            _config = config;
            _roleManager = roleManager;
            _env = _config.GetValue<string>("ASPNETCORE_ENVIRONMENT");
        }

        public async Task<IdentityResult> RegisterUserAsync(RegistrationDto InputModel)
        {
            ApplicationUser user = _mapper.Map<ApplicationUser>(InputModel);
            IdentityResult result = await _userManager.CreateAsync(user, InputModel.Password);
            // add to roles
            await _userManager.AddToRoleAsync(user, UserRoles.User);

            // send confirmation email
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            String callbackUrl = null;
            if (_env == "Development")
            {
                callbackUrl = $"https://localhost:4200/auth/confirm-email/{user.Id}/{code}";
            }
            else
            {
                callbackUrl = $"https://thefortress.vip/auth/confirm-email/{user.Id}/{code}";
            }
            await _emailService.SendMailAsync("admin@thefortress.vip", "Admin", InputModel.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            return result;
        }
        public async Task<bool> ValidateUserAsync(LoginDto loginDto)
        {
            await EnsureSeedRoles();
            // first try by username
            _user = await _userManager.FindByNameAsync(loginDto.Username);
            if (_user == null)
            {
                // if username not found try email
                _user = await _userManager.FindByEmailAsync(loginDto.Username);

            }
            var result = _user != null && await _userManager.CheckPasswordAsync(_user, loginDto.Password);
            return result;
        }


        public async Task<IActionResult> ConfirmEmailAsync(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                //_logger.LogInformation("User not found");
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return new StatusCodeResult(StatusCodes.Status200OK);

        }

        public async Task<string> CreateTokenAsync()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }


        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _config.GetSection("JwtConfig");

            string iss = "";
            string aud = "";
            if (_env == "Development")
            {
                iss = jwtSettings["ValidIssuerDEV"];
                aud = jwtSettings["ValidAudienceDEV"]; 
            }
            else
            {
                iss = jwtSettings["ValidIssuerPROD"];
                aud = jwtSettings["ValidAudiencePROD"]; 
            }
            var tokenOptions = new JwtSecurityToken
            (
            issuer: iss,
            audience: aud,
            claims: claims,
            expires: DateTime.Now.AddHours(Convert.ToDouble(jwtSettings["TimeTilExp"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtConfig = _config.GetSection("jwtConfig");
            var key = Encoding.UTF8.GetBytes(jwtConfig["Secret"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName),
                new Claim(ClaimTypes.Email, _user.Email),
            };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            // add main API scope
            claims.Add(new Claim("scope", "api1"));

            return claims;
        }

        private async Task EnsureSeedRoles()
        {
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            if (!await _roleManager.RoleExistsAsync(UserRoles.Artist))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Artist));
        }
    }
}
