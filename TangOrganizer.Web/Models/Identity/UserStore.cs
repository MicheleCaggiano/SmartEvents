using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SmartEvents.Web.Models.Identity
{
    public class UserStore : UserStore<ApplicationUser, Role, Guid, UserLogin, UserRole, UserClaim>
    {
        public UserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}

