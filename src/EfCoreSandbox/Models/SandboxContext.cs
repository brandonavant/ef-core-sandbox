using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EfCoreSandbox.Models
{
    public partial class SandboxContext : DbContext
    {
        public SandboxContext()
        {
        }

        public SandboxContext(DbContextOptions<SandboxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Sandbox;User ID=sa;Password=<database-password-here>");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("decimal(38, 0)");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
