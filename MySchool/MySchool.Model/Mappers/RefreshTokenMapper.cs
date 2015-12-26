using MySchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Model.Mappers
{
    public class RefreshTokenMapper : EntityTypeConfiguration<RefreshToken>
    {
        public RefreshTokenMapper()
        {
            this.ToTable("RefreshToken", "Users");

            this.Property(x => x.Subject).IsRequired();
            this.Property(x => x.Subject).HasMaxLength(50);

            this.Property(x => x.ClientId).IsRequired();
            this.Property(x => x.ClientId).HasMaxLength(50);

            this.Property(x => x.ProtectedTicket).IsRequired();
        }
    }
}
