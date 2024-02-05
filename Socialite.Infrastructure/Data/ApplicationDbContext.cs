using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Socialite.Domain.Entities;
using Socialite.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        private IConfiguration _configuration { get; }
        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString(name: "MSSQL");
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            // override defaults
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<Comment>()
                .ToTable("Comments")
                .HasDiscriminator<string>("CommentType")
                .HasValue<ReplyComment>("reply")
                .HasValue<PostComment>("post");

            base.OnModelCreating(builder);
        }
    }
}
