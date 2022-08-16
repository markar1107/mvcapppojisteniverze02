using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvcapppojisteniverze02.Models;

namespace mvcapppojisteniverze02.Data
{
    public class mvcapppojisteniverze02Context : IdentityDbContext
    {
        public mvcapppojisteniverze02Context (DbContextOptions<mvcapppojisteniverze02Context> options)
            : base(options)
        {
        }

        public DbSet<Klient> Klienti { get; set; }
        public DbSet<Produkt> Produkty { get; set; }
        public DbSet<ZaznamPojisteni> ZaznamyPojisteni { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Klient>().ToTable("Klient");
        //    modelBuilder.Entity<Produkt>().ToTable("Produkt");
        //    modelBuilder.Entity<ZaznamPojisteni>().ToTable("ZaznamPojisteni");
        //}

    }
}
