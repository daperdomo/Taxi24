using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Taxi24.Domain.Models
{
    public partial class Taxi24Context : DbContext
    {
        public Taxi24Context()
        {
        }

        public Taxi24Context(DbContextOptions<Taxi24Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasIndex(e => e.TripId, "fki_fk_invoices_trips");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.TripId)
                    .HasConstraintName("fk_invoices_trips");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasIndex(e => e.DriverId, "fki_fk_trips_drivers");

                entity.HasIndex(e => e.PassengerId, "fki_fk_trips_passenger");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_trips_drivers");

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.PassengerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_trips_passenger");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
