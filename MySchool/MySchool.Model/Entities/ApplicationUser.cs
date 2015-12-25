using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace MySchool.Model.Entities
{
    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Level { get; set; }
        public DateTime JoinDate { get; set; }
    }

    public class ApplicationUserLogin : IdentityUserLogin<int> { }

    public class ApplicationUserRole : IdentityUserRole<int> { }

    public class ApplicationUserClaim : IdentityUserClaim<int> { }

    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>
    {
        public ApplicationRole() { }
        public ApplicationRole(string name)
        {
            Name = name;
        }
    }
}
