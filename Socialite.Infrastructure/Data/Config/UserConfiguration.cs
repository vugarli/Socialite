using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Socialite.Domain.Entities;
using Socialite.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Infrastructure.Data.Config
{
    public class UserConfiguration
        : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.IdentityId).IsUnique();

            builder.HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p=>p.UserId);
            
        }
    }
}
