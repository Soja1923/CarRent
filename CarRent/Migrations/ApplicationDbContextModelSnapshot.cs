﻿// <auto-generated />
using CarRent.Data;
using CarRent.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace CarRent.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarRent.Models.Address", b =>
                {
                    b.Property<int>("Address_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Address_ID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("CarRent.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CarRent.Models.Car", b =>
                {
                    b.Property<int>("Car_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Body");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<double>("EngineCapacity");

                    b.Property<int>("Fuel");

                    b.Property<int>("GearboxType");

                    b.Property<int>("GradeID");

                    b.Property<string>("Img")
                        .IsRequired();

                    b.Property<string>("Mark")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("NumberOfSeats");

                    b.Property<int>("Year");

                    b.HasKey("Car_ID");

                    b.HasIndex("GradeID");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("CarRent.Models.CarDetails", b =>
                {
                    b.Property<int>("CarDetailsID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarID");

                    b.Property<string>("Comments");

                    b.Property<int>("LocationID");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired();

                    b.Property<int>("State");

                    b.HasKey("CarDetailsID");

                    b.HasIndex("CarID");

                    b.HasIndex("LocationID");

                    b.ToTable("CarDetails");
                });

            modelBuilder.Entity("CarRent.Models.Grade", b =>
                {
                    b.Property<int>("Grade_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GradeType");

                    b.Property<double>("PricePerDay");

                    b.HasKey("Grade_ID");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("CarRent.Models.Location", b =>
                {
                    b.Property<int>("Location_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Address_ID")
                        .IsRequired();

                    b.Property<string>("E_mail")
                        .IsRequired();

                    b.Property<string>("Phone_Number")
                        .IsRequired();

                    b.HasKey("Location_ID");

                    b.HasIndex("Address_ID")
                        .IsUnique();

                    b.ToTable("Location");
                });

            modelBuilder.Entity("CarRent.Models.Order", b =>
                {
                    b.Property<int>("Order_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarID");

                    b.Property<DateTime>("DateEnd");

                    b.Property<DateTime>("DateOfReturn");

                    b.Property<DateTime>("DateStart");

                    b.Property<string>("LocationEnd")
                        .IsRequired();

                    b.Property<string>("LocationStart")
                        .IsRequired();

                    b.Property<int>("Person_ID");

                    b.Property<string>("RegistrationNumberCar");

                    b.Property<int>("State");

                    b.HasKey("Order_ID");

                    b.HasIndex("CarID");

                    b.HasIndex("Person_ID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("CarRent.Models.Person", b =>
                {
                    b.Property<int>("Person_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Address_ID");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(65);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("PESEL")
                        .IsRequired();

                    b.HasKey("Person_ID");

                    b.HasIndex("Address_ID")
                        .IsUnique()
                        .HasFilter("[Address_ID] IS NOT NULL");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique()
                        .HasFilter("[ApplicationUserId] IS NOT NULL");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("CarRent.Models.UserRating", b =>
                {
                    b.Property<int>("UserRating_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarID");

                    b.Property<string>("Comment");

                    b.Property<int>("CustomerID");

                    b.Property<bool>("RatingNegative");

                    b.Property<bool>("RatingPositive");

                    b.Property<int?>("UserRating_ID1");

                    b.HasKey("UserRating_ID");

                    b.HasIndex("CarID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("UserRating_ID1");

                    b.ToTable("UserRating");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CarRent.Models.Customer", b =>
                {
                    b.HasBaseType("CarRent.Models.Person");


                    b.ToTable("Person");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("CarRent.Models.Employee", b =>
                {
                    b.HasBaseType("CarRent.Models.Person");

                    b.Property<int?>("LocationID")
                        .IsRequired();

                    b.HasIndex("LocationID");

                    b.ToTable("Person");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("CarRent.Models.Car", b =>
                {
                    b.HasOne("CarRent.Models.Grade", "Grade")
                        .WithMany("Cars")
                        .HasForeignKey("GradeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarRent.Models.CarDetails", b =>
                {
                    b.HasOne("CarRent.Models.Car", "Car")
                        .WithMany("CarsDetails")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarRent.Models.Location", "Location")
                        .WithMany("CarDetails")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarRent.Models.Location", b =>
                {
                    b.HasOne("CarRent.Models.Address", "Address")
                        .WithOne("Location")
                        .HasForeignKey("CarRent.Models.Location", "Address_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarRent.Models.Order", b =>
                {
                    b.HasOne("CarRent.Models.Car", "Car")
                        .WithMany("Orders")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarRent.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("Person_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarRent.Models.Person", b =>
                {
                    b.HasOne("CarRent.Models.Address", "Address")
                        .WithOne("Person")
                        .HasForeignKey("CarRent.Models.Person", "Address_ID");

                    b.HasOne("CarRent.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("Person")
                        .HasForeignKey("CarRent.Models.Person", "ApplicationUserId");
                });

            modelBuilder.Entity("CarRent.Models.UserRating", b =>
                {
                    b.HasOne("CarRent.Models.Car", "Car")
                        .WithMany("UserRatings")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarRent.Models.Customer", "Customer")
                        .WithMany("UserRatings")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarRent.Models.UserRating")
                        .WithMany("UserRatings")
                        .HasForeignKey("UserRating_ID1");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CarRent.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CarRent.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarRent.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CarRent.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarRent.Models.Employee", b =>
                {
                    b.HasOne("CarRent.Models.Location", "Location")
                        .WithMany("Employees")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
