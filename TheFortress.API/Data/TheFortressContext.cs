using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TheFortress.API.Models;

namespace TheFortress.API.Data
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
        public virtual DbSet<AppUser> AppUsers { get; set; } = null!;
        public virtual DbSet<ApprovalQueue> ApprovalQueues { get; set; } = null!;
        public virtual DbSet<Artist> Artists { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<CodeUser> CodeUsers { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<EventConcert> EventConcerts { get; set; } = null!;
        public virtual DbSet<LinkType> LinkTypes { get; set; } = null!;
        public virtual DbSet<TrustedCode> TrustedCodes { get; set; } = null!;
        public virtual DbSet<Venue> Venues { get; set; } = null!;


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

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__AppUser__1788CC4C158866CB");

                entity.ToTable("AppUser");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.DisplayName).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);
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
                    .HasMaxLength(25)
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venue_City");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
