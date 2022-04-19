using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JarmuKolcsonzo.Web.Models
{
    public partial class JKContext : DbContext
    {
        public JKContext()
        {
        }

        public JKContext(DbContextOptions<JKContext> options)
            : base(options)
        {
        }

        public virtual DbSet<jarmu> jarmu { get; set; }
        public virtual DbSet<jarmu_tipus> jarmu_tipus { get; set; }
        public virtual DbSet<rendeles> rendeles { get; set; }
        public virtual DbSet<ugyfel> ugyfel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user id=root;database=jarmukolcsonzo", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.21-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<jarmu>(entity =>
            {
                entity.Property(e => e.rendszam)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.tipus)
                    .WithMany(p => p.jarmu)
                    .HasForeignKey(d => d.tipus_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jarmu_ibfk_1");
            });

            modelBuilder.Entity<rendeles>(entity =>
            {
                entity.Property(e => e.ar).HasPrecision(7);

                entity.HasOne(d => d.jarmu)
                    .WithMany(p => p.rendeles)
                    .HasForeignKey(d => d.jarmu_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rendeles_ibfk_2");

                entity.HasOne(d => d.ugyfel)
                    .WithMany(p => p.rendeles)
                    .HasForeignKey(d => d.ugyfel_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rendeles_ibfk_1");
            });

            modelBuilder.Entity<ugyfel>(entity =>
            {
                entity.Property(e => e.pont).HasPrecision(4, 2);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
