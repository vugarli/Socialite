using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Infrastructure.Data.Config
{
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.Content).IsRequired();

            builder.HasMany(p=>p.Comments).WithOne(c=>c.Post)
                .HasForeignKey(c=>c.PostId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Media).WithOne(m => m.Post).HasForeignKey<Post>(p=>p.MediaId);

        }
    }
}
