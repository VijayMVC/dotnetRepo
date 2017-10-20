namespace IdentityFromScratch.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentityFromScratch.ScratchDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IdentityFromScratch.ScratchDbContext context)
        {
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("admin"))
            {
                // create the admin role
                roleManager.Create(new IdentityRole() { Name = "admin" });
            }
            if (!userManager.Users.Any(u => u.UserName == "jake@sg.com"))
            {
                // create the user with the manager class
                userManager.Create(new IdentityUser() { UserName = "jake@sg.com"},"Hockey1!");
            }

            var user = userManager.FindByName("jake@sg.com");

            if (!userManager.IsInRole(user.Id,"admin"))
            { 
                // add the user to the admin role
                userManager.AddToRole(user.Id,"admin");
            }
        }
    }
}
