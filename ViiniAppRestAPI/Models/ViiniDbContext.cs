using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ViiniAppRestAPI.Models
{
    public partial class ViiniDbContext : DbContext
    {
        public ViiniDbContext()
        {
        }

        public ViiniDbContext(DbContextOptions<ViiniDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Maa> Maas { get; set; }
        public virtual DbSet<Rypale> Rypales { get; set; }
        public virtual DbSet<Tyyppi> Tyyppis { get; set; }
        public virtual DbSet<Viinit> Viinits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PÖYTÄKONE-HANNU;Database=ViiniDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Maa>(entity =>
            {
                entity.ToTable("Maa");

                entity.Property(e => e.Maa1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Maa");
            });

            modelBuilder.Entity<Rypale>(entity =>
            {
                entity.ToTable("Rypale");

                entity.Property(e => e.Rypale1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Rypale");
            });

            modelBuilder.Entity<Tyyppi>(entity =>
            {
                entity.ToTable("Tyyppi");

                entity.Property(e => e.Tyyppi1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Tyyppi");
            });

            modelBuilder.Entity<Viinit>(entity =>
            {
                entity.HasKey(e => e.ViiniId);

                entity.ToTable("Viinit");

                entity.Property(e => e.Hinta).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ViiniNimi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Maa)
                    .WithMany(p => p.Viinits)
                    .HasForeignKey(d => d.MaaId)
                    .HasConstraintName("FK_Viinit_Maa");

                entity.HasOne(d => d.Rypale)
                    .WithMany(p => p.Viinits)
                    .HasForeignKey(d => d.RypaleId)
                    .HasConstraintName("FK_Viinit_Rypale");

                entity.HasOne(d => d.Tyyppi)
                    .WithMany(p => p.Viinits)
                    .HasForeignKey(d => d.TyyppiId)
                    .HasConstraintName("FK_Tyyppi_Viinit");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
