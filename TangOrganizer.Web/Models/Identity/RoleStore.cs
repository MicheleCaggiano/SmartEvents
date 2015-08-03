using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SmartEvents.Web.Models.Identity
{
    public class RoleStore : RoleStore<Role, Guid, UserRole>
    {
        public RoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}

