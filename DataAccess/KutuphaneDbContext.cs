using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KutuphaneUygulamasi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace KutuphaneUygulamasi.DataAccess
{
    public class KutuphaneDbContext : DbContext
    {
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Odunc> Oduncler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=KutuphaneDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ek konfigürasyonlar istersen buraya yazabilirsin
            base.OnModelCreating(modelBuilder);
        }
    }
}