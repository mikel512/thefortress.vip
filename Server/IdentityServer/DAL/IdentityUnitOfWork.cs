﻿using AutoMapper;
using IdentityServer.Interfaces;
using IdentityServer.Models;
using IdentityServer.Services;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.DAL
{
    public class IdentityUnitOfWork: IIdentityUnitOfWork
    {
        private IUserAuthRepository _userAuthRepository;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IMapper _mapper;
        private IConfiguration _configuration;

        public IdentityUnitOfWork(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
            _roleManager = roleManager; 
        }

        public IUserAuthRepository UserAuth
        {
            get
            {
                if(_userAuthRepository is null)
                {
                    _userAuthRepository = new UserAuthRepository(_userManager, _roleManager, _configuration, _mapper);
                }
                return _userAuthRepository;
            }
        }
    }
}
