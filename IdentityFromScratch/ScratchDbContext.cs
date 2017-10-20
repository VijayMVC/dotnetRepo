using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityFromScratch
{
    public class ScratchDbContext : IdentityDbContext<IdentityUser> //handles users and data added to the system
    {
        public ScratchDbContext() : base("scratch")
        {

        }
    }
}