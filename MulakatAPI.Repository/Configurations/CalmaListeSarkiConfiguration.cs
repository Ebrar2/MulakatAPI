using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MulakatAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MulakatAPI.Repository.Configurations
{
    internal class CalmaListeSarkiConfiguration : IEntityTypeConfiguration<CalmaListeSarki>
    {
        public void Configure(EntityTypeBuilder<CalmaListeSarki> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(cs => new { cs.SarkiId, cs.CalmaListeId }).IsUnique();
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.ToTable("CalmaListeSarkilar");
            builder.HasOne(x => x.Sarki).WithMany(x => x.CalmaListeSarkis).HasForeignKey(x => x.SarkiId);
            builder.HasOne(x => x.CalmaListe).WithMany(x => x.CalmaListeSarkis).HasForeignKey(x => x.CalmaListeId);
        }
    }
}
