﻿// <auto-generated />
using System;
using BlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorApp.Migrations
{
    [DbContext(typeof(BookingAppContext))]
    partial class BookingAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorApp.Models.Accommodation", b =>
                {
                    b.Property<int>("AccId")
                        .HasColumnType("int")
                        .HasColumnName("accID");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("imageURL");

                    b.Property<int>("LocId")
                        .HasColumnType("int")
                        .HasColumnName("locID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("price");

                    b.HasKey("AccId")
                        .HasName("PK__Accommod__A471AFFAE2BD3FB1");

                    b.HasIndex("LocId");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("BlazorApp.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .HasColumnType("int")
                        .HasColumnName("bookingID");

                    b.Property<int>("AccId")
                        .HasColumnType("int")
                        .HasColumnName("accID");

                    b.Property<DateOnly?>("ArrivalDate")
                        .HasColumnType("date")
                        .HasColumnName("arrivalDate");

                    b.Property<DateOnly?>("BookingDate")
                        .HasColumnType("date")
                        .HasColumnName("bookingDate");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customerID");

                    b.Property<DateOnly?>("DepartureDate")
                        .HasColumnType("date")
                        .HasColumnName("departureDate");

                    b.Property<int?>("NumberOfGuests")
                        .HasColumnType("int")
                        .HasColumnName("numberOfGuests");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("totalPrice");

                    b.HasKey("BookingId")
                        .HasName("PK__Bookings__C6D03BED2845214B");

                    b.HasIndex("AccId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BlazorApp.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customerID");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("char(50)")
                        .HasColumnName("firstName")
                        .IsFixedLength();

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("lastName");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phoneNumber");

                    b.HasKey("CustomerId")
                        .HasName("PK__Customer__B611CB9DC89E9510");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BlazorApp.Models.Location", b =>
                {
                    b.Property<int>("LocId")
                        .HasColumnType("int")
                        .HasColumnName("locID");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("country");

                    b.Property<string>("Province")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("province");

                    b.HasKey("LocId")
                        .HasName("PK__Location__793196EBDFE2B813");

                    b.ToTable("Location", (string)null);
                });

            modelBuilder.Entity("BlazorApp.Models.Property", b =>
                {
                    b.Property<int>("AccId")
                        .HasColumnType("int")
                        .HasColumnName("accID");

                    b.Property<int>("PropId")
                        .HasColumnType("int")
                        .HasColumnName("propID");

                    b.Property<string>("Value")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("value");

                    b.HasKey("AccId", "PropId")
                        .HasName("PK__Properti__F99B9C39D9BD3A58");

                    b.HasIndex("PropId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("BlazorApp.Models.PropertySet", b =>
                {
                    b.Property<int>("PropId")
                        .HasColumnType("int")
                        .HasColumnName("propID");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("PropId")
                        .HasName("PK__Property__DEA33C34CBD59668");

                    b.ToTable("PropertySet", (string)null);
                });

            modelBuilder.Entity("BlazorApp.Models.Temptable", b =>
                {
                    b.Property<int>("AccId")
                        .HasColumnType("int")
                        .HasColumnName("accID");

                    b.Property<string>("AccommodationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("accommodationName");

                    b.Property<DateOnly?>("ArrivalDate")
                        .HasColumnType("date")
                        .HasColumnName("arrivalDate");

                    b.Property<DateOnly?>("BookingDate")
                        .HasColumnType("date")
                        .HasColumnName("bookingDate");

                    b.Property<int>("BookingId")
                        .HasColumnType("int")
                        .HasColumnName("bookingID");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("country");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customerID");

                    b.Property<DateOnly?>("DepartureDate")
                        .HasColumnType("date")
                        .HasColumnName("departureDate");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("char(50)")
                        .HasColumnName("firstName")
                        .IsFixedLength();

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("imageURL");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("lastName");

                    b.Property<int>("LocId")
                        .HasColumnType("int")
                        .HasColumnName("locID");

                    b.Property<int?>("NumberOfGuests")
                        .HasColumnType("int")
                        .HasColumnName("numberOfGuests");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phoneNumber");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("price");

                    b.Property<int>("PropId")
                        .HasColumnType("int")
                        .HasColumnName("propID");

                    b.Property<string>("PropertySetName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("propertySetName");

                    b.Property<string>("Province")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("province");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("totalPrice");

                    b.Property<string>("Value")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("value");

                    b.Property<int>("WishId")
                        .HasColumnType("int")
                        .HasColumnName("wishID");

                    b.ToTable("temptable", (string)null);
                });

            modelBuilder.Entity("BlazorApp.Models.Wish", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customerID");

                    b.Property<int>("WishId")
                        .HasColumnType("int")
                        .HasColumnName("wishID");

                    b.Property<int>("PropId")
                        .HasColumnType("int")
                        .HasColumnName("propID");

                    b.Property<string>("Value")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("value");

                    b.HasKey("CustomerId", "WishId")
                        .HasName("PK__Wishes__3B3FBE5ACD8A4F9C");

                    b.HasIndex("PropId");

                    b.ToTable("Wishes");
                });

            modelBuilder.Entity("BlazorApp.Models.Accommodation", b =>
                {
                    b.HasOne("BlazorApp.Models.Location", "Loc")
                        .WithMany("Accommodations")
                        .HasForeignKey("LocId")
                        .IsRequired()
                        .HasConstraintName("FK__Accommoda__locID__5CD6CB2B");

                    b.Navigation("Loc");
                });

            modelBuilder.Entity("BlazorApp.Models.Booking", b =>
                {
                    b.HasOne("BlazorApp.Models.Accommodation", "Acc")
                        .WithMany("Bookings")
                        .HasForeignKey("AccId")
                        .IsRequired()
                        .HasConstraintName("FK__Bookings__accID__60A75C0F");

                    b.HasOne("BlazorApp.Models.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK__Bookings__custom__5FB337D6");

                    b.Navigation("Acc");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BlazorApp.Models.Property", b =>
                {
                    b.HasOne("BlazorApp.Models.Accommodation", "Acc")
                        .WithMany("Properties")
                        .HasForeignKey("AccId")
                        .IsRequired()
                        .HasConstraintName("FK__Propertie__accID__6383C8BA");

                    b.HasOne("BlazorApp.Models.PropertySet", "Prop")
                        .WithMany("Properties")
                        .HasForeignKey("PropId")
                        .IsRequired()
                        .HasConstraintName("FK__Propertie__propI__6477ECF3");

                    b.Navigation("Acc");

                    b.Navigation("Prop");
                });

            modelBuilder.Entity("BlazorApp.Models.Wish", b =>
                {
                    b.HasOne("BlazorApp.Models.Customer", "Customer")
                        .WithMany("Wishes")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK__Wishes__customer__6754599E");

                    b.HasOne("BlazorApp.Models.PropertySet", "Prop")
                        .WithMany("Wishes")
                        .HasForeignKey("PropId")
                        .IsRequired()
                        .HasConstraintName("FK__Wishes__propID__68487DD7");

                    b.Navigation("Customer");

                    b.Navigation("Prop");
                });

            modelBuilder.Entity("BlazorApp.Models.Accommodation", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("BlazorApp.Models.Customer", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Wishes");
                });

            modelBuilder.Entity("BlazorApp.Models.Location", b =>
                {
                    b.Navigation("Accommodations");
                });

            modelBuilder.Entity("BlazorApp.Models.PropertySet", b =>
                {
                    b.Navigation("Properties");

                    b.Navigation("Wishes");
                });
#pragma warning restore 612, 618
        }
    }
}
