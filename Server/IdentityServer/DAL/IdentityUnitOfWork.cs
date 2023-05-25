using AutoMapper;
using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using vApplication.Interface;

namespace IdentityServer.DAL
{
    public class IdentityUnitOfWork: IIdentityUnitOfWork
    {
        private IUserAuthRepository _userAuthRepository;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IMapper _mapper;
        private IConfiguration _configuration;
        private IEmailService _emailService;

        public IdentityUnitOfWork(UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            IMapper mapper, 
            IEmailService emailService,
            IConfiguration configuration)
        {
            _emailService = emailService;
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
                    _userAuthRepository = new UserAuthRepository(_userManager, _roleManager, _emailService, _configuration, _mapper);
                }
                return _userAuthRepository;
            }
        }
    }
}
