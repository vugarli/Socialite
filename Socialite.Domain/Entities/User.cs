using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Socialite.Domain.Entities.PostAggregate;

namespace Socialite.Domain.Entities
{
    public class User : BaseEntity
    {
        public string IdentityId { get; private set; }
        public string DisplayName { get; set; }

        public string? ProfileImage { get; set; }

        public List<Post> Posts { get; set; } = new();

        // neo4j
        //public List<User> Followers { get; set; }
        //public List<User> Followees { get; set; }

        public User(string identityId,string displayName)
        {
            IdentityId = identityId;
            DisplayName = displayName;
        }

        #pragma warning disable CS8618 // Ef requires
        private User() { }
    }
}
