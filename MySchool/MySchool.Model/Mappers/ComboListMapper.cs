using MySchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Model.Mappers
{
    public class ComboListMapper : EntityTypeConfiguration<ComboList>
    {
        public ComboListMapper()
        {
            ToTable("ComboList", "MstAppl");
            HasKey(x => x.CTComboListId);
            //Property(x => x.CTComboListId).IsRequired();
            Property(x => x.ListDesc).IsRequired().HasMaxLength(100);
            Property(x => x.CreatedBy).IsRequired().HasMaxLength(100);
            Property(x => x.CreatedDate).IsRequired().HasColumnType("DATETIME2");
            Property(x => x.ModifiedBy).IsOptional().HasMaxLength(100);
            Property(x => x.ModifiedDate).IsOptional().HasColumnType("DATETIME2"); ;
        }
    }
}
