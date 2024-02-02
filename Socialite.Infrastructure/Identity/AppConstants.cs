using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Infrastructure.Identity
{
    public static class AppConstants
    {
        public const string JWTKEY = "publicconststringpublicconststringpublic";

        public const string SUPERADMIN_USERNAME = "a@a.com";
        public const string SUPERADMIN_PASSWORD = "admin123";

        public const string REG_USERNAME = "someone@somewhere.com";
        public const string REG_PASSWORD = "salam123";


        public static class Roles
        {
            public const string SUPERADMINROLE = "Superadmin";
            public const string ADMINROLE = "Admin";
            public const string MEMBERROLE = "Member";
        }



    }
}
