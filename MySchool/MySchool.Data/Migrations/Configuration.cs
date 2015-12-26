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
    using Shared;

    internal sealed class Configuration : DbMigrationsConfiguration<MySchool.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
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

            DateTime createdDate = DateTime.Now;

            var manager = new ApplicationUserManager(new ApplicationUserStore(new ApplicationDbContext()));
 
            var user = new ApplicationUser()
            {
                UserName = "sunilp",
                Email = "sunilppandey@gmail.com",
                EmailConfirmed = true,
                FirstName = "Sunil",
                LastName = "Pandey",
                Level = 1,
                JoinDate = createdDate.AddYears(-3)
            };
 
            manager.Create(user, "Password@123");

            if(context.Client.Count() <=0)
            {
                context.Client.AddRange(BuildClientList());
                context.SaveChanges();
            }

            if (context.ComboList.Count() <= 0)
            {
                context.ComboList.AddOrUpdate(GenerateComboList(createdDate));
            }

            if (context.ComboListValue.Count() <= 0)
            {
                context.ComboListValue.AddOrUpdate(GenerateComboListValue(createdDate));
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

        private ComboList[] GenerateComboList(DateTime createdDate)
        {
            ComboList[] list = new ComboList[]
            {
                new ComboList
                {
                    CTComboListId = 1,
                    ListDesc = "Board Name",
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                },
                new ComboList
                {
                    CTComboListId = 2,
                    ListDesc = "Working Days",
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                },
                new ComboList
                {
                    CTComboListId = 3,
                    ListDesc = "Academic Year",
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                }
            };
            return list;
        }

        private ComboListValue[] GenerateComboListValue(DateTime createdDate)
        {
            ComboListValue[] list = new ComboListValue[]
            {
                new ComboListValue
                {
                    CTComboListId = 1,
                    ValueId = 1,
                    DisplayValue = "MSB",
                    UserAsDefault = true,
                    SortOrder = 1,
                    IsDeleted = false,
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                },
                new ComboListValue
                {
                    CTComboListId = 1,
                    ValueId = 2,
                    DisplayValue = "CBSE",
                    UserAsDefault = false,
                    SortOrder = 2,
                    IsDeleted = false,
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                },
                new ComboListValue
                {
                    CTComboListId = 1,
                    ValueId = 3,
                    DisplayValue = "ICSE",
                    UserAsDefault = false,
                    SortOrder = 3,
                    IsDeleted = false,
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                },
                new ComboListValue
                {
                    CTComboListId = 2,
                    ValueId = 1,
                    DisplayValue = "Monday - Saturday",
                    UserAsDefault = true,
                    SortOrder = 1,
                    IsDeleted = false,
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                },
                new ComboListValue
                {
                    CTComboListId = 2,
                    ValueId = 2,
                    DisplayValue = "Monday - Friday",
                    UserAsDefault = false,
                    SortOrder = 2,
                    IsDeleted = false,
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                },
                new ComboListValue
                {
                    CTComboListId = 2,
                    ValueId = 3,
                    DisplayValue = "Monday - Thursday",
                    UserAsDefault = false,
                    SortOrder = 3,
                    IsDeleted = false,
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                },
                new ComboListValue
                {
                    CTComboListId = 3,
                    ValueId = 1,
                    DisplayValue = "January - December",
                    UserAsDefault = true,
                    SortOrder = 1,
                    IsDeleted = false,
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                },
                new ComboListValue
                {
                    CTComboListId = 3,
                    ValueId = 2,
                    DisplayValue = "February - January",
                    UserAsDefault = false,
                    SortOrder = 2,
                    IsDeleted = false,
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                },
                new ComboListValue
                {
                    CTComboListId = 3,
                    ValueId = 3,
                    DisplayValue = "March - February",
                    UserAsDefault = false,
                    SortOrder = 3,
                    IsDeleted = false,
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                },
                new ComboListValue
                {
                    CTComboListId = 3,
                    ValueId = 4,
                    DisplayValue = "April - March",
                    UserAsDefault = false,
                    SortOrder = 4,
                    IsDeleted = false,
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                },
                new ComboListValue
                {
                    CTComboListId = 3,
                    ValueId = 5,
                    DisplayValue = "May - April",
                    UserAsDefault = false,
                    SortOrder = 5,
                    IsDeleted = false,
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                },
                new ComboListValue
                {
                    CTComboListId = 3,
                    ValueId = 6,
                    DisplayValue = "June - May",
                    UserAsDefault = false,
                    SortOrder = 6,
                    IsDeleted = false,
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                },
                new ComboListValue
                {
                    CTComboListId = 3,
                    ValueId = 7,
                    DisplayValue = "July - June",
                    UserAsDefault = false,
                    SortOrder = 7,
                    IsDeleted = false,
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                },
                new ComboListValue
                {
                    CTComboListId = 3,
                    ValueId = 8,
                    DisplayValue = "August - July",
                    UserAsDefault = false,
                    SortOrder = 8,
                    IsDeleted = false,
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                },
                new ComboListValue
                {
                    CTComboListId = 3,
                    ValueId = 9,
                    DisplayValue = "September - August",
                    UserAsDefault = false,
                    SortOrder = 9,
                    IsDeleted = false,
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                },
                new ComboListValue
                {
                    CTComboListId = 3,
                    ValueId = 10,
                    DisplayValue = "October - September",
                    UserAsDefault = false,
                    SortOrder = 10,
                    IsDeleted = false,
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                },
                new ComboListValue
                {
                    CTComboListId = 3,
                    ValueId = 11,
                    DisplayValue = "November - October",
                    UserAsDefault = false,
                    SortOrder = 11,
                    IsDeleted = false,
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                },
                new ComboListValue
                {
                    CTComboListId = 3,
                    ValueId = 12,
                    DisplayValue = "December - November",
                    UserAsDefault = false,
                    SortOrder = 12,
                    IsDeleted = false,
                    CreatedBy = Constant.ANONYMOUS,
                    CreatedDate = createdDate
                }
            };

            return list;
        }
    }
}
