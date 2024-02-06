using Microsoft.AspNetCore.Identity;
using Socialite.Application.Exceptions.Auth;
using Socialite.Application.Requests.Auth;
using Socialite.Application.Services.Auth.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using Socialite.Infrastructure.Identity;
using System.Text;
using System.Threading.Tasks;
using Socialite.Application.Responses.Auth;
using Socialite.Domain.Abstract.Identity;
using Socialite.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Socialite.Infrastructure.Data;
using Socialite.Application.Services.Auth;


namespace Socialite.Infrastructure.Services
{
    public partial class AuthenticationService : IAuthenticationService
    {
        public IAuthValidator _authValidator { get; }
        public SignInManager<ApplicationUser> _signInManager { get; }
        public UserManager<ApplicationUser> _userManager { get; }
        public ITokenService _tokenService { get; }
        public ApplicationDbContext _dbContext { get; }

        public AuthenticationService(
            IAuthValidator authValidator,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            ITokenService tokenService,
            ApplicationDbContext dbContext)
        {
            _authValidator = authValidator;
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _dbContext = dbContext;
        }

        public async Task<AuthResponse> LoginAsync(LoginDto loginDto)
        {
            _authValidator.ValidateUserLogin(loginDto);

            var response = new AuthResponse();

            var result = await _signInManager
                .PasswordSignInAsync(
                loginDto.Username,
                loginDto.Password,
                false, true);

            response.Result = result.Succeeded;
            response.IsLockedOut = result.IsLockedOut;
            response.IsNotAllowed = result.IsNotAllowed;
            response.RequiresTwoFactor = result.RequiresTwoFactor;
            response.Username = loginDto.Username;

            if (result.Succeeded)
            {
                response.Token = await _tokenService.GetTokenAsync(loginDto.Username);
            }

            return response;
        }

        public async Task RegisterAsync(RegisterDto dto)
        {
            _authValidator.ValidateUserRegister(dto);

            var identityUser = new ApplicationUser();
            identityUser.Email = dto.Email;
            identityUser.UserName = dto.Email;
            identityUser.DisplayName = dto.DisplayName;

            var result = await _userManager.CreateAsync(identityUser,dto.Password);
            
            _authValidator.ValidateRegisterIdentityResult(result);

            var user = new User(identityUser.Id);

            await _dbContext.Set<User>().AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }




    }
}
