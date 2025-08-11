using Microsoft.EntityFrameworkCore;
using MulakatAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MulakatAPI.Repository
{
    public class AppDbContext:DbContext
    {
        public DbSet<Album> Albums { get; set; }    
        public DbSet<CalmaListe> CalmaListes { get; set; }
        public DbSet<CalmaListeSarki> CalmaListeSarkis { get; set; }
        public DbSet<Sanatci> Sanatcis { get; set; }
        public DbSet<Sarki> Sarkis { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.Entity<Sanatci>().HasData(
            //    new Sanatci {Id=1, Ad = "Sanatci1" ,KurulusTarihi = new DateTime(2025, 8, 11, 0, 0, 0) },
            //    new Sanatci { Id = 2, Ad = "Sanatci2" ,KurulusTarihi = new DateTime(2025, 8, 11, 0, 0, 0) },
            //    new Sanatci { Id = 3, Ad = "Sanatci3" , KurulusTarihi = new DateTime(2025, 8, 11, 0, 0, 0) });

            //modelBuilder.Entity<Sarki>().HasData(
            //new Sarki { Id = 1, Ad = "Sarki1",AlbumId=1},
            //new Sarki { Id = 2, Ad = "Sarki2", AlbumId = 3},
            //new Sarki { Id = 3, Ad = "Sarki3", AlbumId = 2});


            //modelBuilder.Entity<Sarki>().HasData(      Album kısmı düzenlenirse
            // new Sarki { Id = 1, Ad = "Sarki1", AlbumId = 1 },
            // new Sarki { Id = 2, Ad = "Sarki2", AlbumId = 3},
            // new Sarki { Id = 3, Ad = "Sarki3", AlbumId = 2 });


            //modelBuilder.Entity<CalmaListe>().HasData(
            //    new CalmaListe { Id = 1, Ad = "CalmaListe1" },
            //    new CalmaListe { Id = 2, Ad = "CalmaListe2" },
            //    new CalmaListe { Id = 3, Ad = "CalmaListe3" });


            //modelBuilder.Entity<Album>().HasData(
            //     new Album {Id=1, Ad="Album1",SanatciId=1,CikisTarihi = new DateTime(2025, 8, 11, 0, 0, 0) },
            //     new Album {Id=2, Ad = "Album2", SanatciId = 2 , CikisTarihi = new DateTime(2025, 8, 11, 0, 0, 0) },
            //     new Album {Id=3, Ad = "Album3", SanatciId = 1 , CikisTarihi = new DateTime(2025, 8, 11, 0, 0, 0) });


            //modelBuilder.Entity<CalmaListeSarki>().HasData(
            //   new CalmaListeSarki { Id = 1, CalmaListeId = 2, SarkiId = 1 },
            //   new CalmaListeSarki { Id = 2, CalmaListeId = 2, SarkiId = 2 },
            //   new CalmaListeSarki { Id = 3, CalmaListeId = 1, SarkiId = 3 },
            //   new CalmaListeSarki { Id = 4, CalmaListeId = 2, SarkiId = 3 },
            //   new CalmaListeSarki { Id = 5, CalmaListeId = 3, SarkiId = 1 },
            //   new CalmaListeSarki { Id = 6, CalmaListeId = 3, SarkiId = 2 },
            //   new CalmaListeSarki { Id = 7, CalmaListeId = 3, SarkiId = 3 },
            //   new CalmaListeSarki { Id = 8, CalmaListeId = 1, SarkiId = 2 });

              

        }
    }
}
