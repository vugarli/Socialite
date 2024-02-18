using Socialite.Application.Specifications;
using Socialite.Domain.Entities;
using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Abstract.Repositories
{
    public interface IUserRepository
    {
        //public void UpdateUserAsync(Post post);

        public Task<User> GetUserBySpecification(
            Specification<User> specification);

        
    }
}
