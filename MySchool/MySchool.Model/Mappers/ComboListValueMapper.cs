using MySchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Model.Mappers
{
    public class ComboListValueMapper : EntityTypeConfiguration<ComboListValue>
    {
        public ComboListValueMapper()
        {
            ToTable("ComboListValue", "MstAppl");
            HasKey(x => new { x.CTComboListId, x.ValueId});
            Property(x => x.ValueId).IsRequired();
            Property(x => x.DisplayValue).IsRequired().HasMaxLength(100);
            Property(x => x.UserAsDefault).IsRequired();
            Property(x => x.SortOrder).IsRequired();
            Property(x => x.IsDeleted).IsRequired();
            Property(x => x.CreatedBy).IsRequired().HasMaxLength(100);
            Property(x => x.CreatedDate).IsRequired().HasColumnType("DATETIME2"); ;
            Property(x => x.ModifiedBy).IsOptional().HasMaxLength(100);
            Property(x => x.ModifiedDate).IsOptional().HasColumnType("DATETIME2"); ;
        }
    }
}
