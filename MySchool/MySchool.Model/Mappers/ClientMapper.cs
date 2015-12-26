using MySchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Model.Mappers
{
    public class ClientMapper : EntityTypeConfiguration<Client>
    {
        public ClientMapper()
        {
            ToTable("Client", "Users");

            Property(x => x.Id).IsRequired();
            Property(x => x.Secret).IsRequired();

            Property(x => x.Name).IsRequired();
            Property(x => x.Name).HasMaxLength(100);

            Property(x => x.AllowedOrigin).HasMaxLength(100);
        }
    }
}
