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
    public class ReplyCommentConfiguration 
        : IEntityTypeConfiguration<ReplyComment>
    {
        public void Configure(EntityTypeBuilder<ReplyComment> builder)
        {
            builder.Property(c => c.Content).IsRequired();
        }
    }
}
