using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SmartEvents.Web.Models.Identity
{
    public class Role : IdentityRole<Guid, UserRole>
    {
        public Role() { }
        public Role(string name) { Name = name; }
    } 
}

