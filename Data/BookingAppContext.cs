using System;
using System.Collections.Generic;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data;

public partial class BookingAppContext : DbContext
{
    public BookingAppContext()
    {
    }

    public BookingAppContext(DbContextOptions<BookingAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accommodation> Accommodations { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<PropertySet> PropertySets { get; set; }

    public virtual DbSet<Temptable> Temptables { get; set; }

    public virtual DbSet<Wish> Wishes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=HP-ANDRÉ;Database=booking-app;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accommodation>(entity =>
        {
            entity.HasKey(e => e.AccId).HasName("PK__Accommod__A471AFFAE2BD3FB1");

            entity.Property(e => e.AccId)
                .ValueGeneratedNever()
                .HasColumnName("accID");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imageURL");
            entity.Property(e => e.LocId).HasColumnName("locID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");

            entity.HasOne(d => d.Loc).WithMany(p => p.Accommodations)
                .HasForeignKey(d => d.LocId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Accommoda__locID__5CD6CB2B");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Bookings__C6D03BED2845214B");

            entity.Property(e => e.BookingId)
                .ValueGeneratedNever()
                .HasColumnName("bookingID");
            entity.Property(e => e.AccId).HasColumnName("accID");
            entity.Property(e => e.ArrivalDate).HasColumnName("arrivalDate");
            entity.Property(e => e.BookingDate).HasColumnName("bookingDate");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.DepartureDate).HasColumnName("departureDate");
            entity.Property(e => e.NumberOfGuests).HasColumnName("numberOfGuests");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalPrice");

            entity.HasOne(d => d.Acc).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.AccId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__accID__60A75C0F");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__custom__5FB337D6");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__B611CB9DC89E9510");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customerID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocId).HasName("PK__Location__793196EBDFE2B813");

            entity.ToTable("Location");

            entity.Property(e => e.LocId)
                .ValueGeneratedNever()
                .HasColumnName("locID");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Province)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("province");
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => new { e.AccId, e.PropId }).HasName("PK__Properti__F99B9C39D9BD3A58");

            entity.Property(e => e.AccId).HasColumnName("accID");
            entity.Property(e => e.PropId).HasColumnName("propID");
            entity.Property(e => e.Value)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("value");

            entity.HasOne(d => d.Acc).WithMany(p => p.Properties)
                .HasForeignKey(d => d.AccId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Propertie__accID__6383C8BA");

            entity.HasOne(d => d.Prop).WithMany(p => p.Properties)
                .HasForeignKey(d => d.PropId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Propertie__propI__6477ECF3");
        });

        modelBuilder.Entity<PropertySet>(entity =>
        {
            entity.HasKey(e => e.PropId).HasName("PK__Property__DEA33C34CBD59668");

            entity.ToTable("PropertySet");

            entity.Property(e => e.PropId)
                .ValueGeneratedNever()
                .HasColumnName("propID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Temptable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("temptable");

            entity.Property(e => e.AccId).HasColumnName("accID");
            entity.Property(e => e.AccommodationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("accommodationName");
            entity.Property(e => e.ArrivalDate).HasColumnName("arrivalDate");
            entity.Property(e => e.BookingDate).HasColumnName("bookingDate");
            entity.Property(e => e.BookingId).HasColumnName("bookingID");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.DepartureDate).HasColumnName("departureDate");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("firstName");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imageURL");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.LocId).HasColumnName("locID");
            entity.Property(e => e.NumberOfGuests).HasColumnName("numberOfGuests");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.PropId).HasColumnName("propID");
            entity.Property(e => e.PropertySetName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("propertySetName");
            entity.Property(e => e.Province)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("province");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalPrice");
            entity.Property(e => e.Value)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("value");
            entity.Property(e => e.WishId).HasColumnName("wishID");
        });

        modelBuilder.Entity<Wish>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.WishId }).HasName("PK__Wishes__3B3FBE5ACD8A4F9C");

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.WishId).HasColumnName("wishID");
            entity.Property(e => e.PropId).HasColumnName("propID");
            entity.Property(e => e.Value)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("value");

            entity.HasOne(d => d.Customer).WithMany(p => p.Wishes)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Wishes__customer__6754599E");

            entity.HasOne(d => d.Prop).WithMany(p => p.Wishes)
                .HasForeignKey(d => d.PropId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Wishes__propID__68487DD7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
