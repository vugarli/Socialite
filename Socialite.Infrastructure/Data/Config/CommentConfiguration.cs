using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Socialite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Infrastructure.Data.Config
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Content).IsRequired();

            builder.HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId);

            builder.HasMany(c => c.Replies)
                .WithOne(rc => rc.ParentComment)
                .HasForeignKey(rc => rc.ParentCommentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
