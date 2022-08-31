﻿using AutoMapper;
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

        public AuthController(IIdentityUnitOfWork unitOfWork, IMapper mapper)
        {
            _identity = unitOfWork;
            _mapper = mapper;
        } 

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] RegistrationDTO model)
        {
            IdentityResult result = await _identity.UserAuth.RegisterUserAsync(model);
            return !result.Succeeded ? new BadRequestObjectResult(result) : StatusCode(201);
        }

        [HttpPost("[action]")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Login([FromBody] LoginDTO user)
        {
            return !await _identity.UserAuth.ValidateUserAsync(user)
                ? Unauthorized()
                : Ok(new { Token = await _identity.UserAuth.CreateTokenAsync() });
        }

    }
}
