using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MulakatAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulakatAPI.Repository.Configurations
{
    internal class SanatciConfiguration : IEntityTypeConfiguration<Sanatci>
    {
        public void Configure(EntityTypeBuilder<Sanatci> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.ToTable("Sanatcilar");


        }
    }
}
