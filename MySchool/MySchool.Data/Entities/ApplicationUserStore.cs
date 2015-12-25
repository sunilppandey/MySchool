using MySchool.Model.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Data.Entities
{
    public interface IApplicationUserStore : IUserStore<ApplicationUser, int>
    {

    }

    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IApplicationUserStore
    {
        public ApplicationUserStore() : base(new ApplicationDbContext())
        {
        }

        public ApplicationUserStore(ApplicationDbContext _ctx) : base(_ctx)
        { }
    }
}
