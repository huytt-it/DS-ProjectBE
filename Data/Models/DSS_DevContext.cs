using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



namespace Data.Models
{
    public partial class DSS_DevContext : DbContext
    {
        public DSS_DevContext()
        {
        }

        public DSS_DevContext(DbContextOptions<DSS_DevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<DeviceScenario> DeviceScenario { get; set; }
        public virtual DbSet<Layout> Layout { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<MediaSrc> MediaSrc { get; set; }
        public virtual DbSet<MediaType> MediaType { get; set; }
        public virtual DbSet<Playlist> Playlist { get; set; }
        public virtual DbSet<PlaylistItem> PlaylistItem { get; set; }
        public virtual DbSet<PlaylistReport> PlaylistReport { get; set; }
        public virtual DbSet<Resolution> Resolution { get; set; }
        public virtual DbSet<Scenario> Scenario { get; set; }
        public virtual DbSet<ScenarioItem> ScenarioItem { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<TimeSlot> TimeSlot { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=HUYTRAN;Database=DSS_Dev;user id=sa;password=01699382011Asd;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.LayoutId).HasColumnName("LayoutID");

                entity.Property(e => e.Scale).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.VisualTypeId).HasColumnName("VisualTypeID");

                entity.Property(e => e.WidthPercent).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Layout)
                    .WithMany(p => p.Area)
                    .HasForeignKey(d => d.LayoutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Area_Layout");
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.BrandId)
                    .HasColumnName("BrandID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetUsers_Brand");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDateTime)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.IsActive).HasColumnName("isActive");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.DeviceId).HasColumnName("DeviceID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.Property(e => e.IsHorizontal).HasColumnName("isHorizontal");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.MatchingCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ScreenName).HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Device_Location");
            });

            modelBuilder.Entity<DeviceScenario>(entity =>
            {
                entity.HasKey(e => e.DeviceScenationId);

                entity.Property(e => e.DeviceScenationId).HasColumnName("DeviceScenationID");

                entity.Property(e => e.DeviceId).HasColumnName("DeviceID");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.LayoutId).HasColumnName("LayoutID");

                entity.Property(e => e.ScenarioId).HasColumnName("ScenarioID");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.DeviceScenario)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeviceScenario_Device");

                entity.HasOne(d => d.Scenario)
                    .WithMany(p => p.DeviceScenario)
                    .HasForeignKey(d => new { d.ScenarioId, d.LayoutId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeviceScenario_Scenario");
            });

            modelBuilder.Entity<Layout>(entity =>
            {
                entity.Property(e => e.LayoutId).HasColumnName("LayoutID");

                entity.Property(e => e.IsHorizontal).HasColumnName("isHorizontal");

                entity.Property(e => e.IsPublic).HasColumnName("isPublic");

                entity.Property(e => e.LayoutSrc)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.District).HasMaxLength(50);

                entity.Property(e => e.Province).HasMaxLength(50);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_Brand");
            });

            modelBuilder.Entity<MediaSrc>(entity =>
            {
                entity.Property(e => e.MediaSrcId).HasColumnName("MediaSrcID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.Property(e => e.Extension)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsPublic).HasColumnName("isPublic");

                entity.Property(e => e.SecurityHash).HasColumnType("text");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.UpdateDatetime).HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.MediaSrc)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MediaSrc_Brand");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.MediaSrc)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MediaSrc_MediaType");
            });

            modelBuilder.Entity<MediaType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.Property(e => e.TypeId)
                    .HasColumnName("TypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.Property(e => e.PlaylistId).HasColumnName("PlaylistID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.IsPublic).HasColumnName("isPublic");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.VisualTypeId).HasColumnName("VisualTypeID");
            });

            modelBuilder.Entity<PlaylistItem>(entity =>
            {
                entity.HasIndex(e => new { e.MediaSrcId, e.PlaylistId })
                    .HasName("UK_PlaylistItem")
                    .IsUnique();

                entity.Property(e => e.PlaylistItemId).HasColumnName("PlaylistItemID");

                entity.Property(e => e.MediaSrcId).HasColumnName("MediaSrcID");

                entity.Property(e => e.PlaylistId).HasColumnName("PlaylistID");

                entity.HasOne(d => d.MediaSrc)
                    .WithMany(p => p.PlaylistItem)
                    .HasForeignKey(d => d.MediaSrcId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaylistItem_MediaSrc");

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.PlaylistItem)
                    .HasForeignKey(d => d.PlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaylistItem_Playlist");
            });

            modelBuilder.Entity<PlaylistReport>(entity =>
            {
                entity.HasKey(e => new { e.PlaylistId, e.DeviceId })
                    .HasName("PK_PlaylistReport_1");

                entity.Property(e => e.PlaylistId).HasColumnName("PlaylistID");

                entity.Property(e => e.DeviceId).HasColumnName("DeviceID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.PlaylistTitle).HasMaxLength(150);

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.PlaylistReport)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaylistReport_Device");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.PlaylistReport)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaylistReport_Location");
            });

            modelBuilder.Entity<Resolution>(entity =>
            {
                entity.Property(e => e.ResolutionId).HasColumnName("ResolutionID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.Note).HasColumnType("text");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Resolution)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resolution_Brand");
            });

            modelBuilder.Entity<Scenario>(entity =>
            {
                entity.HasKey(e => new { e.ScenarioId, e.LayoutId });

                entity.Property(e => e.ScenarioId)
                    .HasColumnName("ScenarioID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LayoutId).HasColumnName("LayoutID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.IsPublic).HasColumnName("isPublic");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Scenario)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Scenario_Brand");

                entity.HasOne(d => d.Layout)
                    .WithMany(p => p.Scenario)
                    .HasForeignKey(d => d.LayoutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Scenario_Layout");
            });

            modelBuilder.Entity<ScenarioItem>(entity =>
            {
                entity.HasKey(e => new { e.PlaylistId, e.ScenarioId, e.AreaId, e.LayoutId });

                entity.HasIndex(e => new { e.AreaId, e.ScenarioId, e.PlaylistId })
                    .HasName("UK_ScenarioItem")
                    .IsUnique();

                entity.Property(e => e.PlaylistId).HasColumnName("PlaylistID");

                entity.Property(e => e.ScenarioId).HasColumnName("ScenarioID");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.LayoutId).HasColumnName("LayoutID");

                entity.Property(e => e.Note).HasColumnType("text");

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.ScenarioItem)
                    .HasForeignKey(d => d.PlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaylistScenarioArea_Playlist");

                entity.HasOne(d => d.Scenario)
                    .WithMany(p => p.ScenarioItem)
                    .HasForeignKey(d => new { d.ScenarioId, d.LayoutId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScenarioItem_Scenario");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.DeviceId).HasColumnName("DeviceID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.IsEnable).HasColumnName("isEnable");

                entity.Property(e => e.LayoutId).HasColumnName("LayoutID");

                entity.Property(e => e.ScenarioId).HasColumnName("ScenarioID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Device");

                entity.HasOne(d => d.Scenario)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => new { d.ScenarioId, d.LayoutId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Scenario");
            });

            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.HasKey(e => e.SlotId);

                entity.Property(e => e.SlotId).HasColumnName("SlotID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
