using MySchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Model.Mappers
{
    public class BookMapper : EntityTypeConfiguration<Book>
    {
        public BookMapper()
        {
            ToTable("Book", "Users");
            HasKey(x => x.Id);
            Property(x => x.Title).IsRequired().HasMaxLength(100);
            Property(x => x.Author).IsRequired().HasMaxLength(100);
            Property(x => x.Description).IsRequired().HasMaxLength(100);
            Property(x => x.IsDeleted).IsRequired();
            Property(x => x.CreatedBy).IsRequired().HasMaxLength(100);
            Property(x => x.CreatedDate).IsRequired().HasColumnType("DATETIME2"); ;
            Property(x => x.ModifiedBy).IsOptional().HasMaxLength(100);
            Property(x => x.ModifiedDate).IsOptional().HasColumnType("DATETIME2"); ;
        }
    }
}
