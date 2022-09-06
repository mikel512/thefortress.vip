using AutoMapper;
using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityServer.Services
{
    internal sealed class UserAuthRepository : IUserAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly RoleManager<IdentityRole> _roleManager;
        private ApplicationUser _user;

        public UserAuthRepository(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration config,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _config = config;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegistrationDto InputModel)
        {
            ApplicationUser user = _mapper.Map<ApplicationUser>(InputModel);
            IdentityResult result = await _userManager.CreateAsync(user, InputModel.Password);
            // add to roles
            await _userManager.AddToRoleAsync(user, UserRoles.User);
            return result;
        }
        public async Task<bool> ValidateUserAsync(LoginDto loginDto)
        {
            await EnsureSeedRoles();
            // first try by username
            _user = await _userManager.FindByNameAsync(loginDto.Username);
            if(_user == null)
            {
                // if username not found try email
                _user = await _userManager.FindByEmailAsync(loginDto.Username);

            }
            var result = _user != null && await _userManager.CheckPasswordAsync(_user, loginDto.Password);
            return result;
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
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["ValidIssuerDEV"],
            audience: jwtSettings["ValidAudienceDEV"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["TimeTilExp"])),
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
