using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI3.Models
{
    public partial class wordContext : DbContext
    {

        public wordContext(DbContextOptions<wordContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WordList> WordsList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:shop-db2.database.windows.net,1433;Initial Catalog=word;Persist Security Info=False;User ID=batuhand;Password=Bthn1236540321;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<WordList>(entity =>
            {
                entity.Property(e => e.WordEn)
                    .IsRequired()
                    .HasColumnName("Word_En")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WordTr)
                    .IsRequired()
                    .HasColumnName("Word_Tr")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
