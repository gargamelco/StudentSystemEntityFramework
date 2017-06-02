namespace SSEF.DbContext.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {

            if (!(context.Users.Any(u => u.UserName == "dinkov.com@gmail.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "dinkov.com@gmail.com", PhoneNumber = "0899119158" };
                userManager.Create(userToInsert, "std123");
            }
            if (!(context.Users.Any(u => u.Email == "student1@gmail.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "student1@gmail.com", PhoneNumber = "0797697898" };
                userManager.Create(userToInsert, "password123");
            }
            if (!(context.Users.Any(u => u.Email == "student2@gmail.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "student2@gmail.com", PhoneNumber = "0797697898", Email = "student2@gmail.com", };
                userManager.Create(userToInsert, "password123");
            }
            if (!(context.Users.Any(u => u.Email == "student3@gmail.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "student3@gmail.com", PhoneNumber = "0797697898", };
                userManager.Create(userToInsert, "password123");
            }
        }
    }
}
