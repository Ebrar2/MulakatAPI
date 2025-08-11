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
    internal class SarkiConfiguration : IEntityTypeConfiguration<Sarki>
    {
        public void Configure(EntityTypeBuilder<Sarki> builder)
        {
           builder.HasKey(x => x.Id);
           builder.Property(x=>x.Id).UseIdentityColumn();
           builder.ToTable("Sarkilar");
           builder.HasOne(x => x.Album).WithMany(x=>x.Sarkis).HasForeignKey(x=>x.AlbumId);
          // builder.HasOne(x => x.Sanatci).WithMany(x => x.Sarkis).HasForeignKey(x=>x.SanatciId); sanatci-sarkici iliskisi kaldır


        }
    }
}
