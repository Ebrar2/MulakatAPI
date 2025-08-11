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
    internal class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey( a => a.Id);
            builder.Property(a=>a.Id).UseIdentityColumn();

            builder.ToTable("Albumler");
            builder.HasOne(a => a.Sanatci).WithMany(s => s.Albums).HasForeignKey(a => a.SanatciId);

        }
    }
}
