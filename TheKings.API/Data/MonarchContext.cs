using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TheKings.API.Entities;

namespace TheKings.API.Data
{
    public class MonarchContext : DbContext
    {
        public MonarchContext(DbContextOptions<MonarchContext> options) : base(options)
        {
        }

        public DbSet<Monarch> Monarches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Monarch>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedNever(); // Bu satır veritabanının Id değerini üretmeyeceğini belirtiyor
                                                                  // Diğer özelliklerin yapılandırılması
            });

            // Burada diğer entity'ler için yapılandırmalar yapılabilir
        }

    }
}
