namespace MySchool.Data.Migrations
{
    using Model.Entities;
    using Entities;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using Infrastructure;

    internal sealed class Configuration : DbMigrationsConfiguration<MySchool.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MySchool.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var manager = new ApplicationUserManager(new ApplicationUserStore(new ApplicationDbContext()));
 
            var user = new ApplicationUser()
            {
                UserName = "sunilp",
                Email = "sunilppandey@gmail.com",
                EmailConfirmed = true,
                FirstName = "Sunil",
                LastName = "Pandey",
                Level = 1,
                JoinDate = DateTime.Now.AddYears(-3)
            };
 
            manager.Create(user, "Password@123");

            if(context.Client.Count() <=0)
            {
                context.Client.AddRange(BuildClientList());
                context.SaveChanges();
            }
        }

        private static List<Client> BuildClientList()
        {
            List<Client> clientList = new List<Client>
            {
                new Client
                {
                    Id = "mySchoolAuthApp",
                    Secret = Helper.GetHash("abc@123"),
                    Name = "AngularJS front-end Application",
                    ApplicationType =  Model.Enumerations.ApplicationTypes.JavaScript,
                    Active = true,
                    RefreshTokenLifeTime = 7200,
                    AllowedOrigin = "http://localhost:2005"
                },
                new Client
                {
                    Id = "consoleApp",
                    Secret = Helper.GetHash("123@abc"),
                    Name = "Console Application",
                    ApplicationType = Model.Enumerations.ApplicationTypes.NativeConfidential,
                    Active = true,
                    RefreshTokenLifeTime = 14400,
                    AllowedOrigin = "*"
                }
            };

            return clientList;
        }
    }
}
