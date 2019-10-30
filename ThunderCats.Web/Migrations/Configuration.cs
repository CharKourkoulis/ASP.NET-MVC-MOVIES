namespace ThunderCats.Web.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ThunderCats.Web.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ThunderCats.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ThunderCats.Web.Models.ApplicationDbContext context)
        {
            string roleAdmin = "admin";
            string roleSuperAdmin = "superadmin";
            string roleSuperKaterina = "superkaterina";

            //Eftiaksa enan rolo kai ton anathetw
            if (!context.Roles.Any(u => u.Name == roleAdmin))
            {
               
                string email = "gatsos@gmail.com";
                string pass = "Aadfsd1234f";

                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser {Id="11", UserName = email, Email = email };
                manager.Create(user, pass);

                var rolestore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(rolestore);
                var identityRole = new IdentityRole { Name = roleAdmin };

                roleManager.Create(identityRole);
                manager.AddToRole(user.Id, roleAdmin);
                               
            }



            if (!context.Roles.Any(u => u.Name == roleSuperAdmin))
            {

                string email = "cult_bob@hotmail.com";
                string pass = "asd123";

                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { Id = "12", UserName = email, Email = email };
                manager.Create(user, pass);

                var rolestore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(rolestore);
                var identityRole = new IdentityRole { Name = roleSuperAdmin };

                roleManager.Create(identityRole);
                manager.AddToRole(user.Id, roleSuperAdmin);

            }

            if (!context.Roles.Any(u => u.Name == roleSuperKaterina))
            {

                string email = "kagas@hotmail.com";
                string pass = "asdasd123";

                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { Id = "13", UserName = email, Email = email };
                manager.Create(user, pass);

                var rolestore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(rolestore);
                var identityRole = new IdentityRole { Name = roleSuperKaterina };

                roleManager.Create(identityRole);
                manager.AddToRole(user.Id, roleSuperKaterina);

            }


        }
    }
}
