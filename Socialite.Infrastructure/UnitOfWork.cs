using Socialite.Domain.Abstract;
using Socialite.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _applicationDbContext { get; }
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken token)
        {
            return await _applicationDbContext.SaveChangesAsync(token);
        }
    }
}
