using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HargaSaham.Models
{
    public class SahamContext:DbContext
    {
        public SahamContext(DbContextOptions<SahamContext>options):base(options)
        {

        }

        public DbSet<Saham> Sahams { get; set; }
        public DbSet<Sektor> Sektors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sektor>().HasData(
                new Sektor { SektorId="I",Nama="Infra"},
                new Sektor { SektorId="B",Nama="Banking"},
                new Sektor { SektorId="M",Nama="Mining"}
                );

          


            modelBuilder.Entity<Saham>().HasData(
                new Saham { 
                SahamID=1,
                NamaSaham="WIKA",
                Harga=1900,
                SektorId="I"
                },
                new Saham { 
                SahamID=2,
                NamaSaham="BRIS",
                Harga=2000,
                SektorId="B"
                }
                
                );

        
        }

    }
}
