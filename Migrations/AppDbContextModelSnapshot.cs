﻿// <auto-generated />
using System;
using Family_GPS_Tracker_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Family_GPS_Tracker_Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Family_GPS_Tracker_Api.Domain.PairingCode", b =>
                {
                    b.Property<Guid>("PairingCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChildId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.HasKey("PairingCodeId");

                    b.HasIndex("ChildId")
                        .IsUnique();

                    b.ToTable("PairingCode");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Domain.RefreshToken", b =>
                {
                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsInvalidated")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<string>("JwtId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Token");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.Child", b =>
                {
                    b.Property<Guid>("ChildId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("parent_id");

                    b.HasKey("ChildId")
                        .HasName("child_id");

                    b.HasIndex("ParentId");

                    b.ToTable("Child");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.Geofence", b =>
                {
                    b.Property<Guid>("GeofenceId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("geofence_id");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("category");

                    b.Property<Guid>("ChildId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("child_id");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("latitude");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("longitude");

                    b.Property<double>("Radius")
                        .HasColumnType("float")
                        .HasColumnName("radius");

                    b.HasKey("GeofenceId");

                    b.HasIndex("ChildId");

                    b.ToTable("Geofence");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.Location", b =>
                {
                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("location_id");

                    b.Property<Guid>("ChildId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("child_id");

                    b.Property<double>("Latitude")
                        .HasColumnType("float")
                        .HasColumnName("latitude");

                    b.Property<double>("Longitude")
                        .HasColumnType("float")
                        .HasColumnName("longitude");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("time");

                    b.Property<int>("UniqueNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("unique_number")
                        .UseIdentityColumn();

                    b.HasKey("LocationId");

                    b.HasIndex("ChildId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.Notification", b =>
                {
                    b.Property<Guid>("NotificationId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("notification_id");

                    b.Property<Guid>("ChildId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("child_id");

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("created_at");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("message");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("parent_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("title");

                    b.HasKey("NotificationId");

                    b.HasIndex("ChildId");

                    b.HasIndex("ParentId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.Parent", b =>
                {
                    b.Property<Guid>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeviceToken")
                        .HasMaxLength(220)
                        .IsUnicode(false)
                        .HasColumnType("varchar(220)")
                        .HasColumnName("device_token");

                    b.HasKey("ParentId")
                        .HasName("parent_id");

                    b.ToTable("Parent");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Domain.PairingCode", b =>
                {
                    b.HasOne("Family_GPS_Tracker_Api.Models.Child", "Child")
                        .WithOne("PairingCode")
                        .HasForeignKey("Family_GPS_Tracker_Api.Domain.PairingCode", "ChildId")
                        .HasConstraintName("FK_PairingCode_Child")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Domain.RefreshToken", b =>
                {
                    b.HasOne("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.Child", b =>
                {
                    b.HasOne("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationUser", "User")
                        .WithOne("Child")
                        .HasForeignKey("Family_GPS_Tracker_Api.Models.Child", "ChildId")
                        .HasConstraintName("FK_Child_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Family_GPS_Tracker_Api.Models.Parent", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("FK_Child_Parent");

                    b.Navigation("Parent");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.Geofence", b =>
                {
                    b.HasOne("Family_GPS_Tracker_Api.Models.Child", "Child")
                        .WithMany("Geofences")
                        .HasForeignKey("ChildId")
                        .HasConstraintName("FK_Geofence_Child")
                        .IsRequired();

                    b.Navigation("Child");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationRoleClaim", b =>
                {
                    b.HasOne("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationUserClaim", b =>
                {
                    b.HasOne("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationUserLogin", b =>
                {
                    b.HasOne("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationUserRole", b =>
                {
                    b.HasOne("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationUserToken", b =>
                {
                    b.HasOne("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.Location", b =>
                {
                    b.HasOne("Family_GPS_Tracker_Api.Models.Child", "Child")
                        .WithMany("Locations")
                        .HasForeignKey("ChildId")
                        .HasConstraintName("FK_Location_Child")
                        .IsRequired();

                    b.Navigation("Child");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.Notification", b =>
                {
                    b.HasOne("Family_GPS_Tracker_Api.Models.Child", "Child")
                        .WithMany("Notifications")
                        .HasForeignKey("ChildId")
                        .HasConstraintName("FK_Notification_Child")
                        .IsRequired();

                    b.HasOne("Family_GPS_Tracker_Api.Models.Parent", "Parent")
                        .WithMany("Notifications")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("FK_Notification_Parent")
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.Parent", b =>
                {
                    b.HasOne("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationUser", "User")
                        .WithOne("Parent")
                        .HasForeignKey("Family_GPS_Tracker_Api.Models.Parent", "ParentId")
                        .HasConstraintName("FK_Parent_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.Child", b =>
                {
                    b.Navigation("Geofences");

                    b.Navigation("Locations");

                    b.Navigation("Notifications");

                    b.Navigation("PairingCode");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.IdentityModels+ApplicationUser", b =>
                {
                    b.Navigation("Child");

                    b.Navigation("Parent");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Family_GPS_Tracker_Api.Models.Parent", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Notifications");
                });
#pragma warning restore 612, 618
        }
    }
}
