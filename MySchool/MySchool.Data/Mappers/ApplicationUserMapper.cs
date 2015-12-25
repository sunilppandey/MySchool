using MySchool.Model.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MySchool.Data.Mappers
{
    class ApplicationUserMapper : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserMapper()
        {
            this.ToTable("AspNetUsers", "Users");

            this.Property(c => c.FirstName).IsRequired();
            this.Property(c => c.FirstName).HasMaxLength(100);

            this.Property(c => c.LastName).IsRequired();
            this.Property(c => c.LastName).HasMaxLength(100);

            this.Property(c => c.Level).IsRequired();

            this.Property(c => c.JoinDate).IsRequired();
        }
    }
}
