using Microsoft.EntityFrameworkCore;
using Socialite.Application.Abstract.Repositories;
using Socialite.Application.Queries;
using Socialite.Application.Specifications;
using Socialite.Domain.Entities;
using Socialite.Infrastructure.Data;
using Socialite.Infrastructure.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _dbContext { get; }
        public IQueryable<User> UserQueryable { get => _dbContext.Set<User>().AsQueryable(); }
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserBySpecification(Specification<User> specification)
        => await SpecificationEvaluator
            .GetQuery(UserQueryable,specification)
            .FirstOrDefaultAsync();
    }
}
