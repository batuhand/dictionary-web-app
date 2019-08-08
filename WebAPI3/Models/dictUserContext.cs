using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI3.Models
{
    public partial class dictUserContext : DbContext
    {
        public dictUserContext()
        {
        }

        public dictUserContext(DbContextOptions<dictUserContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserList> UserList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:dictionary.database.windows.net,1433;Initial Catalog=dictUser;Persist Security Info=False;User ID=batuhand;Password=Bthn1236540321;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<UserList>(entity =>
            {
                entity.ToTable("userList");

                entity.Property(e => e.EMail).HasColumnName("eMail");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.SurName).HasColumnName("surName");

                entity.Property(e => e.UserName).HasColumnName("userName");
            });
        }
    }
}
