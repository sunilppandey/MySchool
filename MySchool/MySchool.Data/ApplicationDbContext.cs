using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using MySchool.Data.Mappers;
using MySchool.Model.Entities;
using System.Data.Entity.Infrastructure;
using MySchool.Model;
using System.Data.Entity.Validation;
using System.ComponentModel.DataAnnotations;
using MySchool.Infrastructure;

namespace MySchool.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext() : base("MySchoolContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /// <summary>
        /// Provides access to the collection of client in the system.
        /// </summary>
        public DbSet<Client> Client { get; set; }
        /// <summary>
        /// Provides access to the collection of refreshToken in the system.
        /// </summary>
        public DbSet<RefreshToken> RefreshToken { get; set; }

        public virtual int Commit()
        {
            //base.SaveChanges();

            try
            {
                var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
                foreach (DbEntityEntry item in modified)
                {
                    var changedOrAddedItem = item.Entity as IDateTracking;
                    if (changedOrAddedItem != null)
                    {
                        if (item.State == EntityState.Added)
                        {
                            changedOrAddedItem.CreatedDate = DateTime.Now;
                        }
                        changedOrAddedItem.ModifiedDate = DateTime.Now;
                    }
                }
                return base.SaveChanges();
            }
            catch (DbEntityValidationException entityException)
            {
                var errors = entityException.EntityValidationErrors;
                var result = new StringBuilder();
                var allErrors = new List<ValidationResult>();
                foreach (var error in errors)
                {
                    foreach (var validationError in error.ValidationErrors)
                    {
                        result.AppendFormat("\r\n  Entity of type {0} has validation error \"{1}\" for property {2}.\r\n", error.Entry.Entity.GetType().ToString(), validationError.ErrorMessage, validationError.PropertyName);
                        var domainEntity = error.Entry.Entity as DomainEntity<int>;
                        if (domainEntity != null)
                        {
                            result.Append(domainEntity.IsTransient() ? "  This entity was added in this session.\r\n" : string.Format("  The Id of the entity is {0}.\r\n", domainEntity.Id));
                        }
                        allErrors.Add(new ValidationResult(validationError.ErrorMessage, new[] { validationError.PropertyName }));
                    }
                }
                throw new ModelValidationException(result.ToString(), entityException, allErrors);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationUserMapper());
            modelBuilder.Configurations.Add(new BookMapper());
            modelBuilder.Configurations.Add(new ClientMapper());
            modelBuilder.Configurations.Add(new RefreshTokenMapper());

            base.OnModelCreating(modelBuilder);
        }

    }
}
