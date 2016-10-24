namespace OnlineTuts.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineTuts.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OnlineTuts.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(x=>x.UserName == "admin" && x.Email == "admin@tuts.com"))
            {
                var user = new ApplicationUser { FirstName = "admin", UserName = "admin", Email = "admin@tuts.com" };
                userManager.Create(user, "admin5");
                context.Roles.AddOrUpdate(x => x.Name, new IdentityRole { Name = "admin" });                
                context.SaveChanges();
                userManager.AddToRole(user.Id, "admin");                   
            }
        }
    }
}
