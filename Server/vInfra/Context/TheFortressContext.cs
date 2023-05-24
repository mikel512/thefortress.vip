﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using vInfra;

namespace vInfra.Context
{
    public partial class TheFortressContext : DbContext
    {
        public TheFortressContext()
        {
        }

        public TheFortressContext(DbContextOptions<TheFortressContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminMessage> AdminMessages { get; set; } = null!;
        public virtual DbSet<Analytic> Analytics { get; set; } = null!;
        public virtual DbSet<ApprovalQueue> ApprovalQueues { get; set; } = null!;
        public virtual DbSet<Artist> Artists { get; set; } = null!;
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<CodeUser> CodeUsers { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<EventConcert> EventConcerts { get; set; } = null!;
        public virtual DbSet<LinkType> LinkTypes { get; set; } = null!;
        public virtual DbSet<TrustedCode> TrustedCodes { get; set; } = null!;
        public virtual DbSet<Venue> Venues { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Name=DbConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminMessage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AdminMessage");

                entity.Property(e => e.AdminMessageId).ValueGeneratedOnAdd();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Sender).HasMaxLength(50);

                entity.Property(e => e.Subject).HasMaxLength(50);
            });

            modelBuilder.Entity<Analytic>(entity =>
            {
                entity.HasKey(e => e.AnalyticsId)
                    .HasName("PK__analytic__506974E39436EBE6");

                entity.ToTable("analytics");

                entity.Property(e => e.IpAddress).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(50);
            });

            modelBuilder.Entity<ApprovalQueue>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ApprovalQueue");

                entity.Property(e => e.QueueId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Tour).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.IsFirstLogin)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.MailingListEnabled)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityName).HasMaxLength(150);

                entity.Property(e => e.Image).IsUnicode(false);
            });

            modelBuilder.Entity<CodeUser>(entity =>
            {
                entity.HasKey(e => e.CodeId)
                    .HasName("PK__CodeUser__C6DE2C15B83FB2CB");

                entity.Property(e => e.CodeId).ValueGeneratedNever();

                entity.Property(e => e.UserId).HasMaxLength(450);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("Comment_pk")
                    .IsClustered(false);

                entity.ToTable("Comment");

                entity.Property(e => e.Content).HasMaxLength(2048);

                entity.Property(e => e.DateStamp).HasColumnType("datetime");

                entity.Property(e => e.Upvotes).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<EventConcert>(entity =>
            {
                entity.HasKey(e => e.EventConcertId)
                    .HasName("PK__EventCon__91322059EC10CB1A")
                    .IsClustered(false);

                entity.ToTable("EventConcert");

                entity.HasIndex(e => new { e.EventConcertId, e.VenueFk }, "IX_EventConcert");

                entity.Property(e => e.Details).HasColumnName("details");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventTime).HasMaxLength(50);

                entity.Property(e => e.IsApproved).HasDefaultValueSql("((0))");

                entity.Property(e => e.Price)
                    .HasMaxLength(100)
                    .HasColumnName("price");

                entity.Property(e => e.Status).HasMaxLength(75);

                entity.Property(e => e.Tickets).HasMaxLength(256);

                entity.Property(e => e.VenueFk).HasColumnName("Venue_FK");

                entity.HasOne(d => d.VenueFkNavigation)
                    .WithMany(p => p.EventConcerts)
                    .HasForeignKey(d => d.VenueFk)
                    .HasConstraintName("FK_EventConcert_Venue");
            });

            modelBuilder.Entity<LinkType>(entity =>
            {
                entity.ToTable("LinkType");

                entity.Property(e => e.LinkType1)
                    .HasMaxLength(50)
                    .HasColumnName("LinkType");
            });

            modelBuilder.Entity<TrustedCode>(entity =>
            {
                entity.ToTable("TrustedCode");
            });

            modelBuilder.Entity<Venue>(entity =>
            {
                entity.ToTable("Venue");

                entity.HasIndex(e => e.VenueId, "IX_Venue");

                entity.Property(e => e.Address).HasMaxLength(128);

                entity.Property(e => e.CityFk).HasColumnName("City_FK");

                entity.Property(e => e.Hours).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.MenuLink).HasMaxLength(256);

                entity.Property(e => e.TicketsLink).HasMaxLength(256);

                entity.Property(e => e.VenueName).HasMaxLength(50);

                entity.HasOne(d => d.CityFkNavigation)
                    .WithMany(p => p.Venues)
                    .HasForeignKey(d => d.CityFk)
                    .HasConstraintName("FK_Venue_City");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
