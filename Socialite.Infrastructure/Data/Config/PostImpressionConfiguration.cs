using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Infrastructure.Data.Config
{
    public class PostImpressionConfiguration : IEntityTypeConfiguration<PostImpression>
    {


        public void Configure(EntityTypeBuilder<PostImpression> builder)
        {
            builder.HasOne(pi => pi.Post)
                .WithMany(p => p.Impressions)
                .HasForeignKey(pi => pi.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pi => pi.User)
                .WithMany()
                .HasForeignKey(pi => pi.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
