using MySchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Data.Mappers
{
    class BookMapper : EntityTypeConfiguration<Book>
    {
        public BookMapper()
        {
            ToTable("Book", "Users");

            HasKey(x => x.Id);
            Property(x => x.Title).IsRequired();
            
            Property(x => x.Title).HasMaxLength(100);

            Property(x => x.Author).IsRequired();
            Property(x => x.Author).HasMaxLength(100);

            Property(x => x.Description).IsRequired();
            Property(x => x.Description).HasMaxLength(100);

            Property(x => x.ModifiedDate).IsOptional();
        }
    }
}
