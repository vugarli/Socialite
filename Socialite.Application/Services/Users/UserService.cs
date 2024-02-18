using AutoMapper;
using Socialite.Application.Abstract.Repositories;
using Socialite.Application.Responses.Users;
using Socialite.Application.Services.Auth;
using Socialite.Application.Specifications.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Services.Users
{
    public class UserService : IUsersService
    {
        private ICurrentUserService _currentUserService { get; }
        public IUserRepository _userRepository { get; }
        private IUserValidator _userValidator { get; }
        private IMapper _mapper { get; }

        public UserService(
            ICurrentUserService currentUserService,
            IUserRepository userRepository,
            IUserValidator userValidator,
            IMapper mapper
            )
        {
            _currentUserService = currentUserService;
            _userRepository = userRepository;
            _userValidator = userValidator;
            _mapper = mapper;
        }


        public async Task<UserInfoDto> GetCurrentUserInfo()
        {
            var spec = new GetCurrentUserSpecificaiton(_currentUserService);
            var user = await _userRepository.GetUserBySpecification(spec);

            _userValidator.ValidateUserOnGet(user);

            var infoDto = _mapper.Map<UserInfoDto>(user);

            return infoDto;
        }
    }
}
