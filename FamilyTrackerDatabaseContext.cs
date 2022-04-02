using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Family_GPS_Tracker_Api
{
    public partial class FamilyTrackerDatabaseContext : DbContext
    {
        public FamilyTrackerDatabaseContext()
        {
        }

        public FamilyTrackerDatabaseContext(DbContextOptions<FamilyTrackerDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Geofence> Geofences { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=FamilyTrackerDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Child>(entity =>
            {
                entity.ToTable("Child");

                entity.Property(e => e.ChildId)
                    .ValueGeneratedNever()
                    .HasColumnName("child_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("code")
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Child_Parent");
            });

            modelBuilder.Entity<Geofence>(entity =>
            {
                entity.ToTable("Geofence");

                entity.Property(e => e.GeofenceId)
                    .ValueGeneratedNever()
                    .HasColumnName("geofence_id");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.ChildId).HasColumnName("child_id");

                entity.Property(e => e.Latitude)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("longitude");

                entity.Property(e => e.Radius).HasColumnName("radius");

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.Geofences)
                    .HasForeignKey(d => d.ChildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Geofence_Child");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.LocationId)
                    .ValueGeneratedNever()
                    .HasColumnName("location_id");

                entity.Property(e => e.ChildId).HasColumnName("child_id");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("time");

                entity.Property(e => e.UniqueNumber)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("unique_number");

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.ChildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_Child");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.Property(e => e.NotificationId)
                    .ValueGeneratedNever()
                    .HasColumnName("notification_id");

                entity.Property(e => e.ChildId).HasColumnName("child_id");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_at");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("message");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.ChildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_Child");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_Parent");
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.ToTable("Parent");

                entity.Property(e => e.ParentId)
                    .ValueGeneratedNever()
                    .HasColumnName("parent_id");

                entity.Property(e => e.DeviceToken)
                    .HasMaxLength(220)
                    .IsUnicode(false)
                    .HasColumnName("device_token");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.ChildId).HasColumnName("child_id");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ChildId)
                    .HasConstraintName("FK_User_Child");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_User_Parent");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserType");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("UserType");

                entity.Property(e => e.UserTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
