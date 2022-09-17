using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SD_340_W22SD_Lab4.Models
{
    public partial class SD340W22SDLab4Context : DbContext
    {
        public SD340W22SDLab4Context()
        {
        }

        public SD340W22SDLab4Context(DbContextOptions<SD340W22SDLab4Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Route> Routes { get; set; } = null!;
        public virtual DbSet<ScheduledStop> ScheduledStops { get; set; } = null!;
        public virtual DbSet<Stop> Stops { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SD-340-W22SD-Lab4;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(e => e.Number);

                entity.ToTable("Route");

                entity.Property(e => e.Direction).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ScheduledStop>(entity =>
            {
                entity.ToTable("ScheduledStop");

                entity.Property(e => e.ScheduledArrival).HasColumnType("datetime");

                entity.HasOne(d => d.RoutenNumberNavigation)
                    .WithMany(p => p.ScheduledStops)
                    .HasForeignKey(d => d.RoutenNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduledStop_Route");

                entity.HasOne(d => d.StopNumberNavigation)
                    .WithMany(p => p.ScheduledStops)
                    .HasForeignKey(d => d.StopNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduledStop_Stop");
            });

            modelBuilder.Entity<Stop>(entity =>
            {
                entity.HasKey(e => e.Number);

                entity.ToTable("Stop");

                entity.Property(e => e.Direction).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
