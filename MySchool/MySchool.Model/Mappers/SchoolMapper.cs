using MySchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Model.Mappers
{
    public class SchoolMapper : EntityTypeConfiguration<School>
    {
        public SchoolMapper()
        {
            ToTable("SchoolDetail", "School");

            HasKey(x => x.Id);

            Property(x => x.Name).IsRequired();
            Property(x => x.Name).HasMaxLength(100);

            Property(x => x.Domain).IsRequired();
            Property(x => x.Domain).HasMaxLength(50);

            Property(x => x.Address).IsRequired();
            Property(x => x.Address).HasMaxLength(500);

            Property(x => x.PhoneNumber).IsRequired();
            Property(x => x.PhoneNumber).HasMaxLength(20);

            Property(x => x.RegistrationNumber).IsRequired();
            Property(x => x.RegistrationNumber).HasMaxLength(70);

            Property(x => x.BoardName).IsRequired();
            Property(x => x.WorkingDays).IsRequired();
            Property(x => x.AcademicYear).IsRequired();

            Property(x => x.CreatedBy).IsRequired();
            Property(x => x.CreatedDate).IsRequired();
        }
    }
}
